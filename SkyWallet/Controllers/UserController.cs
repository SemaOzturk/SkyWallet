using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
        private readonly IMapper _mapper;

        public UserController(IUserService userService, IMapper mapper)
        {
            _mapper = mapper;
            _userService = userService;
        }
        [HttpPost("authenticate")]
        public IActionResult Authenticate([FromBody] UserAuthenticateRequestModel loginRequest)
        {
            var authenticateResponse = _userService.Authenticate(_mapper.Map<User>(loginRequest));
            return Ok(_mapper.Map<UserAuthenticateResponse>(authenticateResponse));
        }
        [HttpGet]
      //  [Authorize]
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
        [HttpPost]
        public IActionResult CreateUser([FromBody] UserCreateModel userCreate)
        {
            return Ok(_userService.CreateUser(_mapper.Map<User>(userCreate)));
        }

        [HttpPut]
        public IActionResult UpdateUser([FromBody] UserUpdateModel userUpdate)
        {
            return Ok(_userService.UpdateUser(_mapper.Map<User>(userUpdate)));
        }

        [HttpDelete]
        public IActionResult DeleteUser(string id)
        {
            try
            {
                _userService.SoftDelete(id);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest("an occur error when deleting the object");
            }
           
        }

        [HttpGet("{id}")]

        public IActionResult GetByKey(string id)
        {
            var user = _userService.GetByKey(id);
            return Ok(user);
        }
    }
}
