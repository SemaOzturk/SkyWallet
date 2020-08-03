using System;
using System.Collections.Generic;
using System.Text;
using SkyWallet.Application.Entities;
using SkyWallet.Dal.Entities;
using SkyWallet.Shared.Models;

namespace SkyWallet.Application.Services.Interfaces
{
    public interface IUserService
    {
        IEnumerable<User> GetAll();
        User CreateUser(User user);
        User UpdateUser(User user);
        void Delete(string id);
        void GetByKey(string id);
        AuthenticateResponse Authenticate(AuthenticateRequest authenticate);
    }
}
