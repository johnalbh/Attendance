using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Entities.DTO;
using Entities.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace Attendance_GOON.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApplicationUserController : ControllerBase
    {
        private UserManager<ApplicationUser> _userManager;
        private SignInManager<ApplicationUser> _singInManager;
        private readonly ApplicationSettings _appSeettings;

        public ApplicationUserController(UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> singInManager, IOptions<ApplicationSettings> appSettings)
        {
            _userManager = userManager;
            _singInManager = singInManager;
            _appSeettings = appSettings.Value;
        }


        [HttpPost]
        [Route("Registro")]
        //POST : api/ApplicationUser/Registro
        public async Task<Object> PostApplicationUser(ApplicationUserDTO model)

        {
            model.Role = "Invitado";
            var applicationuser = new ApplicationUser()            
            {
                    UserName = model.UserName,
                    Email = model.Email,
                    FullName = model.FullName,
                };
            try
            {
                var result = await _userManager.CreateAsync(applicationuser, model.Password);
                if (result.Succeeded == true)
                {
                    await _userManager.AddToRoleAsync(applicationuser, model.Role);
                    return Ok(result);
                }
                else
                {
                    
                    return BadRequest(result.Errors);
                }



            }
            catch (Exception ex)
            {
                
                throw ex;
            }
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login(LoginDTO model)
        {
            var user = await _userManager.FindByNameAsync(model.UserName);
            if (user != null && await _userManager.CheckPasswordAsync(user, model.Password))
            {
                var role = await _userManager.GetRolesAsync(user);
                IdentityOptions _options = new IdentityOptions();
                var tokenDescription = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new Claim[]
                    {
                        new Claim("UserID", user.Id.ToString()),
                        new Claim(_options.ClaimsIdentity.RoleClaimType, role.FirstOrDefault())
                    }),
                    Expires = DateTime.UtcNow.AddMinutes(5),
                    SigningCredentials = new SigningCredentials(
                        new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_appSeettings.JWTSecret)),
                        SecurityAlgorithms.HmacSha256Signature)
                };
                var tokenHandle = new JwtSecurityTokenHandler();
                var securityToken = tokenHandle.CreateToken(tokenDescription);
                var token = tokenHandle.WriteToken(securityToken);
                return Ok(new { token});
        }
            else
                return BadRequest(new {message = "Usuario o Contraseña Incorrecta"});

        }

    }
}