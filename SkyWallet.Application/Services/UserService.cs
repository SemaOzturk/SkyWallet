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
using SkyWallet.Application.Helper;
using SkyWallet.Application.Services.Interfaces;
using SkyWallet.Dal.Entities;
using SkyWallet.Dal.IRepositories;


namespace SkyWallet.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IMongoRepository<User> _userRepository;
        // private MongoClient _client;
        private readonly AppSettings _appSettings;

        public UserService(IMongoRepository<User> userRepository, IOptions<AppSettings> appSettings)
        {
            _userRepository = userRepository;
            _appSettings = appSettings.Value;
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

        public void HardDelete(string id)
        {
            _userRepository.Delete(id);
            
        }

        public void SoftDelete(string id)
        {
            var user=_userRepository.GetByKey(id);
            user.IsDeleted = true;
            _userRepository.Update(user);
        }

        public User GetByKey(string id)
        {
            var user = _userRepository.GetByKey(id);
            return user;
        }

        public AuthenticateResponse Authenticate(User user)
        {
            var loginUser = _userRepository.GetAll().FirstOrDefault(x=>x.Username==user.Username && x.Password==user.Password);
            if (loginUser == null)
            {
                return null;
            }

            (string token, DateTime expireDate) generateJwtToken;
            generateJwtToken = GenerateJwtToken(user,loginUser.Id.ToString());
            return new AuthenticateResponse()
            {
                FullName = loginUser.FirstName + " " + loginUser.LastName,
                Token = generateJwtToken.token,
                ExpiresDate = generateJwtToken.expireDate,
                UserName = loginUser.Username
            };

        }

        private (string token,DateTime expireDate) GenerateJwtToken(User user,string id)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor()
            {
                Subject = new ClaimsIdentity(new List<Claim>()
                {
                    new Claim(ClaimTypes.Name, id)
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key),
                    SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return (tokenHandler.WriteToken(token),tokenDescriptor.Expires.Value);
        }
    }
}
