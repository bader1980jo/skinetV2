using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Infrastrcture.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    public class UserController : ControllerBase
    {
        private readonly AuthContext _authContext;

        public UserController(AuthContext authContext)
        {
            _authContext = authContext;
        }

        [HttpPost("login")]

        public async Task<IActionResult> Authenticate([FromBody] User user)
        {
            if (user == null)
            {
                return BadRequest();
            }
            var u = await _authContext.Users.FirstOrDefaultAsync(x => x.UserName == user.UserName && x.Password == user.Password);
            if (u == null)
            {
                return NotFound(new { Message = "User not found!" });
            }

            return Ok(new { Message = "Login Success!" });
        }

        [HttpPost("register")]

        public async Task<IActionResult> RegisterUser([FromBody] User user)
        {
            if (user == null)
            {
                return BadRequest();
            }
           
            await _authContext.Users.AddAsync(user);
            await _authContext.SaveChangesAsync();

            return Ok(new { Message = "User registred!" });
        }

    }
}