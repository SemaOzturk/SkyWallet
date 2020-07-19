using System;
using System.Collections.Generic;
using System.Text;
using SkyWallet.Application.AppEntities;

namespace SkyWallet.Application.Services.Interfaces
{
    public interface IUserService
    {
        IEnumerable<User> GetAll();
        User CreateUser(User user);
        User UpdateUer(User user);
        void Delete(string id);
        void GetByKey(string id);
    }
}
