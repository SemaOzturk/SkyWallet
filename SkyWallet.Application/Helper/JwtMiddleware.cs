using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Driver;
using SkyWallet.Application.Settings;
using Microsoft.Extensions.Options;
using SkyWallet.Application.Services.Interfaces;

namespace SkyWallet.Application.Helper
{
    public class JwtMiddleware
    {
        //Bunu yapıyorsam userservice içindeki generattoken a ne gerek var.
        private readonly RequestDelegate _next;
        private readonly TokenSettings _tokenSettings;
        public JwtMiddleware(RequestDelegate next, IOptions<TokenSettings> tokenSettings)
        {
            _next = next;
            _tokenSettings = tokenSettings.Value;
        }

        //public async Task Invoke(HttpContext context, IUserService userService)
        //{
        //    var token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();
        //    if (token != null)
        //    {
        //        AttachUserToContext(context, userService, token);
        //    }
        //}

        //private void AttachUserToContext(HttpContext context, IUserService userService, string token)
        //{
        //    var tokenHandler=new JwtSecurityTokenHandler();
        //   // var key=
        //}
    }
}
