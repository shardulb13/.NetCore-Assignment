using GenericRepositoryWebApi.Data;
using GenericRepositoryWebApi.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GenericRepositoryWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly UserManager<ApplicationDbContext> userManager;
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly IConfiguration configuration;


        public AuthenticationController(UserManager<ApplicationDbContext> _usermanager, RoleManager<IdentityRole> _roleManager, IConfiguration _configuration)
        {
            userManager = _usermanager;
            roleManager = _roleManager;
            configuration = _configuration;
        }

        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> Register([FromBody] Register model)
        {
            var userExists = await userManager.FindByNameAsync(model.Username);
            IdentityUser user = new IdentityUser()
            {
                Email = model.Email,
                SecurityStamp = Guid.NewGuid().ToString(),
                UserName = model.Username,
                //PasswordHash = model.Password

            };
                //var result = await userManager.CreateAsync(user, model.Password);

            return Ok();
        }


    }
}
