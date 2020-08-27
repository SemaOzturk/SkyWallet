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
        void HardDelete(string id);
        void SoftDelete(string id);
        User GetByKey(string id);
        AuthenticateResponse Authenticate(User user);
    }

    public interface IWalletService
    {
        IEnumerable<MoneyBox> GetAll();
        MoneyBox CreateMoneyBox(MoneyBox moneyBox);
        MoneyBox UpdateMoneyBox(MoneyBox moneyBox);
        void HardDelete(string id);
        void SoftDelete(string id);
        MoneyBox GetByKey(string id);
    }
}
