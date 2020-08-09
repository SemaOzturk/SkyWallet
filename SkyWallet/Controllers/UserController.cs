using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SkyWallet.Application.Helper;
using SkyWallet.Application.Services.Interfaces;
using SkyWallet.Dal.Entities;
using SkyWallet.Shared.Models;

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
        [HttpPost("authenticate")]
        public IActionResult Authenticate(AuthenticateRequest authenticateModel)
        {
            var authenticateResponse = _userService.Authenticate(authenticateModel);
            if (authenticateResponse == null)
            {
                return BadRequest(new {message = "Username or  password is incorrect"});
            }

            return Ok(authenticateResponse);
        }
        [Authorizeatt]
          [HttpGet]
        public IActionResult GetAll()
        {

            //_userService.CreateUser(new User()
            //{
            //    FirstName = "Florya",
            //    LastName = "Gloria",
            //    IsDeleted = false,
            //    Password = "852369",
            //    Username = "coffee",
            //});
            return  Ok(_userService.GetAll());
        }
    }
}
