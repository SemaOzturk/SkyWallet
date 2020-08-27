using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using SkyWallet.Dal.Entities;

namespace SkyWallet.Shared.Models
{
    public class UserAuthenticateRequestModel
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
