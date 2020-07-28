using System;
using System.Collections.Generic;
using System.Text;

namespace SkyWallet.Dal.Entities
{
    [BsonCollection("User")]
    public class User  : Document
    {
        public string Username { get; set; }

        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        
    }


    public class MoneyBox
    {
        public int Id { get; set; }
    }
}
