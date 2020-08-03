using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using MongoDB.Driver;
using SkyWallet.Application.Entities;
using SkyWallet.Application.Services.Interfaces;
using SkyWallet.Application.Settings;
using SkyWallet.Dal.Entities;
using SkyWallet.Dal.IRepositories;
using SkyWallet.Shared.Models;

namespace SkyWallet.Application.Services
{
    public class UserService:IUserService
    {
        private readonly IMongoRepository<User> _userRepository;
        private MongoClient _client;
        private readonly TokenSettings _tokenSettings;  
        public UserService(IMongoRepository<User> userRepository, IOptions<TokenSettings> tokenSettings)
        {
            _userRepository = userRepository;
            _tokenSettings = tokenSettings.Value;
        }

        public IEnumerable<User> GetAll()
        {
            return _userRepository.GetAll();
        }

        public User CreateUser(User user)
        {
             _userRepository.Insert(user);
             return user;
        }

        public User UpdateUser(User user)
        {
            _userRepository.Update(user);
            return user;
        }

        public void Delete(string id)
        {
            _userRepository.Delete(id);
        }

        public void GetByKey(string id)
        {
            _userRepository.GetByKey(id);
        }

        public AuthenticateResponse Authenticate(AuthenticateRequest authenticate)
        {
            var user = _userRepository.AsQueryable().FirstOrDefault(x =>
                x.Username == authenticate.UserName && x.Password == authenticate.Password);
            if (user==null)
            {
                return null;
            }

            var token = GenerateJwtToken(user);
            return new AuthenticateResponse(user,token);
        }

        private string GenerateJwtToken(User user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_tokenSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] {new Claim("id", user.Id.ToString()),}),
                Expires = DateTime.Now.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key),
                SecurityAlgorithms.HmacSha256Signature)
            };
            var securityToken = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(securityToken);
        }
    }
}
