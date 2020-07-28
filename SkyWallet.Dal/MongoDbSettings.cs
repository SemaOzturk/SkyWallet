using System;
using System.Collections.Generic;
using System.Text;

namespace SkyWallet.Dal
{
    public interface IMongoDbSettings
    {
        string DatabaseName { get; set; }
        string ConnectionString { get; set; }
        string User { get; set; }
        string Pass { get; set; }
    }

    public class MongoDbSettings : IMongoDbSettings
    {
        public string DatabaseName { get; set; }
        public string ConnectionString { get; set; }
        public string User { get; set; }
        public string Pass { get; set; }
    } 
}
