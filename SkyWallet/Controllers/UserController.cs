using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SkyWallet.Application.Services.Interfaces;
using SkyWallet.Dal.Entities;

namespace SkyWallet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        [HttpGet]
        public IActionResult GetAll()
        {

            _userService.CreateUser(new User()
            {
                FirstName = "Sema",
                LastName = "İstifa",
                IsDeleted = false,
                Password = "122345",
                Username = "sky",
            });
            return  Ok(_userService.GetAll());
        }
    }
}
