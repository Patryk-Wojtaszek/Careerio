using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Careerio.Interfaces;
using Careerio.Dtos;

namespace Careerio.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccount _account;
        public AccountController (IAccount account)
        {
            _account = account;
        }

        [HttpPost("register")]
        public ActionResult RegisterUser([FromBody] RegisterUserDto dto)
        {
          string token =  _account.RegisterUser(dto);
            return Ok(token);
        }
        [HttpPost("login")]
        public ActionResult Login([FromBody] LoginDto dto)
        {
            string token = _account.GenerateJwt(dto);
            return Ok(token);
        }
    }
}
