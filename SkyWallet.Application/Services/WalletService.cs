using System;
using System.Collections.Generic;
using System.Text;
using SkyWallet.Dal.Entities;
using SkyWallet.Dal.IRepositories;

namespace SkyWallet.Application.Services.Interfaces
{
    public class WalletService :IWalletService
    {
        private readonly IMongoRepository<MoneyBox> _moneyRepository;

        public WalletService(IMongoRepository<MoneyBox> moneyRepository)
        {
            _moneyRepository = moneyRepository;
        }

        public IEnumerable<MoneyBox> GetAll()
        {
            throw new NotImplementedException();
        }

        public MoneyBox CreateMoneyBox(MoneyBox moneyBox)
        {
            throw new NotImplementedException();
        }

        public MoneyBox UpdateMoneyBox(MoneyBox moneyBox)
        {
            throw new NotImplementedException();
        }

        public void HardDelete(string id)
        {
            throw new NotImplementedException();
        }

        public void SoftDelete(string id)
        {
            throw new NotImplementedException();
        }

        public MoneyBox GetByKey(string id)
        {
            throw new NotImplementedException();
        }
    }
}
