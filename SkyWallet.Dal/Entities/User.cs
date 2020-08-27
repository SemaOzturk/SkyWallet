using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace SkyWallet.Dal.Entities
{
    [BsonCollection("User")]
    public class User  : Document
    {
        public string Username { get; set; }
        [JsonIgnore]
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }

  
}
