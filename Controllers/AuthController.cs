using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using UniversityManagementSystemAPI.Models;
using UniversityManagementSystemAPI.ViewModels;

namespace UniversityManagementSystemAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public AuthController(UserManager<User> userManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
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
                IsActive = false,
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
                // IdentityRole newRole = new IdentityRole()
                // {
                //     Name = "Student"
                // };
                if (result.Succeeded)
                {
                    // await _roleManager.CreateAsync(newRole);
                    var role = await _userManager.AddToRoleAsync(user, "Student");
                }

                return Ok(result);
            }
            catch (Exception)
            {
                return BadRequest(new { succeeded = false, error = "ServerError", description = "Something went wrong in the Server !" });
            }
        }


    }
}