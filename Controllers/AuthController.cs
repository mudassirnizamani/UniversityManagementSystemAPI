using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using NomadDashboardAPI.Models;
using UniversityManagementSystemAPI.Models;
using UniversityManagementSystemAPI.ViewModels;

namespace UniversityManagementSystemAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<User> _userManager;
        private readonly IOptions<AppSettings> _appSettings;
        private readonly RoleManager<IdentityRole> _roleManager;

        public AuthController(UserManager<User> userManager, RoleManager<IdentityRole> roleManager, IOptions<AppSettings> appSettings)
        {
            _userManager = userManager;
            _appSettings = appSettings;
            _roleManager = roleManager;
        }

        // Creating Student User
        // Route = /api/Auth/Student
        [Route("Student")]
        [HttpPost]
        public async Task<ActionResult> Student(StudentAuth model)
        {
            string currentDate = DateTime.Now.ToString("d/M/yyyy");
            var user = new User()
            {
                CreatedAt = currentDate,
                Email = model.Email,
                IsActive = true,
                FirstName = model.FirstName,
                LastName = model.LastName,
                ProfilePic = model.ProfilePic,
                RegNumber = model.RegNumber,
                PhoneNumber = model.PhoneNumber,
                UserName = model.UserName
            };
            try
            {
                var result = await _userManager.CreateAsync(user, model.Password);
                // To Create a new Student Role - Mudasir Ali
                IdentityRole newRole = new IdentityRole()
                {
                    Name = "Student"
                };
                if (result.Succeeded)
                {
                    await _roleManager.CreateAsync(newRole);
                    var role = await _userManager.AddToRoleAsync(user, "Student");
                }

                return Ok(result);
            }
            catch (Exception)
            {
                return BadRequest(new { succeeded = false, error = "ServerError", description = "Something went wrong in the Server !" });
            }
        }

        // Creating Course Adviser User
        // Route = /api/Auth/CourseAdviser
        [Route("CourseAdviser")]
        [HttpPost]
        public async Task<ActionResult> CourseAdviser(CourseAdviserAuth model)
        {
            string currentDate = DateTime.Now.ToString("d/M/yyyy");
            var user = new User()
            {
                CreatedAt = currentDate,
                Email = model.Email,
                IsActive = true,
                FirstName = model.FirstName,
                LastName = model.LastName,
                ProfilePic = model.ProfilePic,
                PhoneNumber = model.PhoneNumber,
                UserName = model.UserName
            };
            try
            {
                var result = await _userManager.CreateAsync(user, model.Password);
                // To Create a new CourseAdviser Role - Mudasir Ali
                IdentityRole newRole = new IdentityRole()
                {
                    Name = "CourseAdviser"
                };
                if (result.Succeeded)
                {
                    await _roleManager.CreateAsync(newRole);
                    var role = await _userManager.AddToRoleAsync(user, "CourseAdviser");
                }
                return Ok(result);
            }
            catch (Exception)
            {
                return BadRequest(new { succeeded = false, error = "ServerError", description = "Something went wrong in the Server !" });
            }
        }

        // Creating It Administrator User
        // Route = /api/Auth/ItAdministrator
        [Route("ItAdministrator")]
        [HttpPost]
        public async Task<ActionResult> ItAdministrator(ItAdministratorAuth model)
        {
            string currentDate = DateTime.Now.ToString("d/M/yyyy");
            var user = new User()
            {
                CreatedAt = currentDate,
                Email = model.Email,
                IsActive = true,
                FirstName = model.FirstName,
                LastName = model.LastName,
                ProfilePic = model.ProfilePic,
                PhoneNumber = model.PhoneNumber,
                UserName = model.UserName
            };
            try
            {
                var result = await _userManager.CreateAsync(user, model.Password);
                // To Create a new CourseAdviser Role - Mudasir Ali
                IdentityRole newRole = new IdentityRole()
                {
                    Name = "ItAdministrator"
                };
                if (result.Succeeded)
                {
                    await _roleManager.CreateAsync(newRole);
                    var role = await _userManager.AddToRoleAsync(user, "ItAdministrator");
                }
                return Ok(result);
            }
            catch (Exception)
            {
                return BadRequest(new { succeeded = false, error = "ServerError", description = "Something went wrong in the Server !" });
            }
        }

        // Creating Dean User
        // Route = /api/Auth/Dean
        [Route("Dean")]
        [HttpPost]
        public async Task<ActionResult> Dean(DeanAuth model)
        {
            string currentDate = DateTime.Now.ToString("d/M/yyyy");
            var user = new User()
            {
                CreatedAt = currentDate,
                Email = model.Email,
                IsActive = true,
                FirstName = model.FirstName,
                LastName = model.LastName,
                ProfilePic = model.ProfilePic,
                PhoneNumber = model.PhoneNumber,
                UserName = model.UserName
            };
            try
            {
                var result = await _userManager.CreateAsync(user, model.Password);
                // To Create a new Dean Role - Mudasir Ali
                IdentityRole newRole = new IdentityRole()
                {
                    Name = "Dean"
                };
                if (result.Succeeded)
                {
                    await _roleManager.CreateAsync(newRole);
                    var role = await _userManager.AddToRoleAsync(user, "Dean");
                }
                return Ok(result);
            }
            catch (Exception)
            {
                return BadRequest(new { succeeded = false, error = "ServerError", description = "Something went wrong in the Server !" });
            }
        }

        // Creating HeadOfDepartment User
        // Route = /api/Auth/HeadOfDepartment
        [Route("HeadOfDepartment")]
        [HttpPost]
        public async Task<ActionResult> HeadOfDepartment(HeadOfDepartmentAuth model)
        {
            string currentDate = DateTime.Now.ToString("d/M/yyyy");
            var user = new User()
            {
                CreatedAt = currentDate,
                Email = model.Email,
                IsActive = true,
                FirstName = model.FirstName,
                LastName = model.LastName,
                ProfilePic = model.ProfilePic,
                PhoneNumber = model.PhoneNumber,
                UserName = model.UserName
            };
            try
            {
                var result = await _userManager.CreateAsync(user, model.Password);
                // To Create a new HeadOfDepartment Role - Mudasir Ali
                IdentityRole newRole = new IdentityRole()
                {
                    Name = "HeadOfDepartment"
                };
                if (result.Succeeded)
                {
                    await _roleManager.CreateAsync(newRole);
                    var role = await _userManager.AddToRoleAsync(user, "HeadOfDepartment");
                }
                return Ok(result);
            }
            catch (Exception)
            {
                return BadRequest(new { succeeded = false, error = "ServerError", description = "Something went wrong in the Server !" });
            }
        }

        // Creating Admin User
        // Route = /api/Auth/Admin
        [Route("Admin")]
        [HttpPost]
        public async Task<ActionResult> Admin(HeadOfDepartmentAuth model)
        {
            string currentDate = DateTime.Now.ToString("d/M/yyyy");
            var user = new User()
            {
                CreatedAt = currentDate,
                Email = model.Email,
                IsActive = true,
                FirstName = model.FirstName,
                LastName = model.LastName,
                ProfilePic = model.ProfilePic,
                PhoneNumber = model.PhoneNumber,
                UserName = model.UserName
            };
            try
            {
                var result = await _userManager.CreateAsync(user, model.Password);
                // To Create a new Admin Role - Mudasir Ali
                IdentityRole newRole = new IdentityRole()
                {
                    Name = "Admin"
                };
                if (result.Succeeded)
                {
                    await _roleManager.CreateAsync(newRole);
                    var role = await _userManager.AddToRoleAsync(user, "Admin");
                }
                return Ok(result);
            }
            catch (Exception)
            {
                return BadRequest(new { succeeded = false, error = "ServerError", description = "Something went wrong in the Server !" });
            }
        }

        // Creating SuperAdmin User
        // Route = /api/Auth/SuperAdmin
        [Route("SuperAdmin")]
        [HttpPost]
        public async Task<ActionResult> SuperAdmin(HeadOfDepartmentAuth model)
        {
            string currentDate = DateTime.Now.ToString("d/M/yyyy");
            var user = new User()
            {
                CreatedAt = currentDate,
                Email = model.Email,
                IsActive = true,
                FirstName = model.FirstName,
                LastName = model.LastName,
                ProfilePic = model.ProfilePic,
                PhoneNumber = model.PhoneNumber,
                UserName = model.UserName
            };
            try
            {
                var result = await _userManager.CreateAsync(user, model.Password);
                // To Create a new SuperAdmin Role - Mudasir Ali
                IdentityRole newRole = new IdentityRole()
                {
                    Name = "SuperAdmin"
                };
                if (result.Succeeded)
                {
                    await _roleManager.CreateAsync(newRole);
                    var role = await _userManager.AddToRoleAsync(user, "SuperAdmin");
                }
                return Ok(result);
            }
            catch (Exception)
            {
                return BadRequest(new { succeeded = false, error = "ServerError", description = "Something went wrong in the Server !" });
            }
        }

        // Authenticating User
        // Route = /api/Auth/Signin
        [HttpPost]
        [Route("Signin")]
        public async Task<ActionResult> Signin(SigninModel model)
        {
            var user = await _userManager.FindByEmailAsync(model.Email);
            var password = await _userManager.CheckPasswordAsync(user, model.Password);
            try
            {
                if (user == null)
                {
                    return Ok(new { succeeded = false, code = "EmailNotFound", description = "Email '" + model.Email + "' was not Found" });
                }
                else if (user != null && !user.IsActive)
                {
                    return Ok(new { succeeded = false, code = "NotActivated", description = "Your Account is not Activated '" + model.Email + "'" });
                }
                else if (user != null && !password)
                {
                    return Ok(new { succeeded = false, code = "IncorrectPassword", description = "Incorrect Password for '" + model.Email + "'" });
                }
                else if (user != null && password && user.IsActive)
                {
                    var tokenDescription = new SecurityTokenDescriptor
                    {
                        Subject = new ClaimsIdentity(new Claim[]
                        {
                          new Claim("UserID", user.Id.ToString())
                        }),
                        Expires = DateTime.UtcNow.AddDays(336),
                        SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_appSettings.Value.JET_SECRECT_KEY)), SecurityAlgorithms.HmacSha256Signature)
                    };

                    var tokenHandler = new JwtSecurityTokenHandler();
                    var secuarityToken = tokenHandler.CreateToken(tokenDescription);
                    var token = tokenHandler.WriteToken(secuarityToken);

                    return Ok(new { succeeded = true, description = "Successfully Authenticated", token = token });
                }
                else
                {
                    return Ok(new { succeeded = false, code = "InvalidCredentials", description = "Email or Password in Incorrect" });
                }
            }
            catch (Exception)
            {
                return Ok(new { succeeded = false, code = "ServerError", description = "Something went wrong in the Server !" });
            }
        }

    }

}