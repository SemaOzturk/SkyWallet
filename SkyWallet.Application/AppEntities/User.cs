using System;
using System.Collections.Generic;
using System.Text;

namespace SkyWallet.Application.AppEntities
{
    public class User
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool IsDeleted { get; set; }
    }
}
