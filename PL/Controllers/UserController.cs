﻿using System.Collections.Generic;
using System.Threading.Tasks;
using BLL.DTO;
using BLL.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using PL.ViewModels;

namespace PL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService userService;
        private readonly IConfiguration config;

        public UserController(IUserService userService, IConfiguration config)
        {
            this.userService = userService;
            this.config = config;
        }

        [HttpPost("login")]
        public async Task<ActionResult<UserDTO>> LoginAsync([FromBody]UserLoginVM userLoginVM)
        {
            var user = await userService.LogInAsync(userLoginVM.UserName, userLoginVM.Password, config["Jwt:Key"]);
            if (user == null)
            {
                return Unauthorized();
            }
            return user;
        }

        [HttpPost("registration")]
        public ActionResult<IdentityResult> Register(UserRegisterVM userVM)
        {
            var result = userService.Register(userVM.UserName, userVM.Email, userVM.Password);
            if (result.Succeeded)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [Authorize(Roles = "Administrator")]
        [HttpGet("moders")]
        public async Task<ActionResult<IEnumerable<string>>> GetModersAsync()
        {
            return Ok(await userService.GetAllModersAsync());
        }

        [Authorize(Roles = "Administrator")]
        [HttpPost("addToModers")]
        public async Task<IActionResult> AddUserToModersAsync([FromBody]string username)
        {
            await userService.AddUserToModersAsync(username);
            return Ok();
        }



    }
}