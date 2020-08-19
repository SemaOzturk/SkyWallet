using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace SkyWallet.Shared.Models
{
    public class UserCreateModel
    {
        public string Username { get; set; }
        [JsonIgnore]
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

    }
    public class UserUpdateModel
    {

    }
}
