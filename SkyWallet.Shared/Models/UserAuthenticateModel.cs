using System;
using System.Text.Json.Serialization;

namespace SkyWallet.Shared
{
    public class UserAuthenticateModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }

        [JsonIgnore]
        public string Password { get; set; }
    }
}
