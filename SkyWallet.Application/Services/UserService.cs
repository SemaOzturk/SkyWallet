using System;
using System.Collections.Generic;
using System.Text;
using MongoDB.Driver;
using SkyWallet.Application.Services.Interfaces;
using SkyWallet.Dal.Entities;
using SkyWallet.Dal.IRepositories;

namespace SkyWallet.Application.Services
{
    public class UserService:IUserService
    {
        private readonly IMongoRepository<User> _userRepository;
        private MongoClient _client;
        public UserService(IMongoRepository<User> userRepository)
        {
            _userRepository = userRepository;
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

        public User UpdateUer(User user)
        {
            throw new NotImplementedException();
        }

        public void Delete(string id)
        {
            throw new NotImplementedException();
        }

        public void GetByKey(string id)
        {
            throw new NotImplementedException();
        }
    }
}
