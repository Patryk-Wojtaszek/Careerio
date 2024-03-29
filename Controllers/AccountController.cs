﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Careerio.Interfaces;
using Careerio.Dtos;
using Microsoft.AspNetCore.Cors;
//using System.Web.Http.Cors;

namespace Careerio.Controllers
{
    [EnableCors("AllowAll")]
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
            //Response.Headers.Add("Access-Control-Allow-Origin", "*");
            return Ok(token);
        }
        //[HttpGet("{id}")]
        //public ActionResult GetUser(int id)
        //{
        //    var user = _account.GetUser(id);
        //    return Ok(user);
        //}
        [HttpGet("{token}")]
        public ActionResult GetUserByToken(string token)
        {
            var user = _account.GetUserByToken(token);
            return Ok(user);

        }

       
    }
}
