using System;

namespace SkyWallet.Shared.Models
{
    public class UserAuthenticateResponse
    {
        public string FullName { get; set; }
        public string UserName { get; set; }
        public string Token { get; set; }
        public DateTime ExpiresDate { get; set; }
    }
}