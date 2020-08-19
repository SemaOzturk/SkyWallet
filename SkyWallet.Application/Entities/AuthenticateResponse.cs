using System;
using System.Collections.Generic;
using System.Text;

namespace SkyWallet.Application.Entities
{
    public class AuthenticateResponse
    {
        public string FullName { get; set; }
        public string UserName { get; set; }
        public string Token { get; set; }
        public DateTime ExpiresDate { get; set; }
    }
}
