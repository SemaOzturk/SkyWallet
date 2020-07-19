using System;
using System.Collections.Generic;
using System.Text;
using SkyWallet.Application.AppEntities;
using SkyWallet.Application.Services.Interfaces;

namespace SkyWallet.Application.Services
{
    public class UserService:IUserService
    {
       // private readonly IMongoRepository<UserDb>
        public IEnumerable<User> GetAll()
        {
            throw new NotImplementedException();
        }

        public User CreateUser(User user)
        {
            throw new NotImplementedException();
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
