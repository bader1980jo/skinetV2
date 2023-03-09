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
        private readonly AppDBContext _authContext;

        public UserController(AppDBContext appDBContext){
            _authContext = appDBContext;
        }
        [HttpPost("login")]

        public async Task<IActionResult> Authenticate([FromBody] Userclass userclass )
        {
            if(userclass == null)
            return BadRequest();

            var user = await _authContext.Users.FirstOrDefaultAsync(x => x.Username == userclass.Username 
            && x.Password == userclass.Password );
            if(user == null){
                return NotFound(new{ Message = "Error User notfound"});
            }
            return Ok(new {Message = "Login Succces"}); 

        }
        [HttpPost("register")]
        public async Task<IActionResult> RegisterUser([FromBody] Userclass userclass)
        {
            if (userclass == null)
             {
                return BadRequest();
             }
             await _authContext.Users.AddAsync(userclass);
             await _authContext.SaveChangesAsync();

             return Ok(new { Message = "User Registred"});
        }
    }
}