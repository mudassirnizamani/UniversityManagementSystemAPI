using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using UniversityManagementSystemAPI.Models;

namespace UniversityManagementSystemAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserManager<User> _userManager;

        public UserController(UserManager<User> userManager)
        {
            _userManager = userManager;
        }

        // This is Function will return the user by token - Mudasir Ali
        // Route = /api/User/GetAuthenticatedUser/
        [HttpGet]
        [Authorize]
        [Route("GetAuthenticatedUser")]
        public async Task<object> GetAuthenticatedUser()
        {
            string userId = User.Claims.First(i => i.Type == "UserID").Value;
            try
            {
                var user = await _userManager.FindByIdAsync(userId);
                return Ok(user);
            }
            catch (Exception)
            {
                return Ok(new { succeeded = false, code = "ServerError", description = "Something went wrong in Server !" });
            }
        }

        // Route = /api/User/GetUserRoleByEmail/
        [HttpGet]
        [Route("GetUserRoleByEmail/{email}")]
        public async Task<ActionResult> GetUserRole(string email)
        {
            var appuser = await _userManager.FindByEmailAsync(email);
            try
            {
                if (appuser != null)
                {
                    var userRole = await _userManager.GetRolesAsync(appuser);

                    return Ok(new { succeeded = true, roles = userRole });
                }
                else
                {
                    return Ok(new { succeeded = false, code = "EmailNotFound", description = "Email '" + email + "' was not Found" });
                }
            }
            catch (Exception)
            {
                return Ok(new { succeeded = false, code = "ServerError", description = "Something went wrong in the Server !" });
            }
        }

        // Route = /api/user/GetUsers/
        [HttpGet]
        [Route("GetUsers")]
        public ActionResult GetUsers()
        {
            var users = _userManager.Users;
            return Ok(users);
        }

        [HttpGet]
        [Route("GetDeans")]
        public async Task<ActionResult<IEnumerable<User>>> GetDeans()
        {
            var users = await _userManager.GetUsersInRoleAsync("Dean");
            return Ok(users);
        }

        [HttpGet]
        [Route("GetCourseAdvisers")]
        public async Task<ActionResult<IEnumerable<User>>> GetCourseAdvisers()
        {
            var users = await _userManager.GetUsersInRoleAsync("CourseAdviser");
            return Ok(users);
        }

        [HttpGet]
        [Route("GetHeadOfDepartments")]
        public async Task<ActionResult<IEnumerable<User>>> GetHeadOfDepartments()
        {
            var users = await _userManager.GetUsersInRoleAsync("HeadOfDepartment");
            return Ok(users);
        }

        [HttpGet]
        [Route("GetStudents")]
        public async Task<ActionResult<IEnumerable<User>>> GetStudents()
        {
            var students = await _userManager.GetUsersInRoleAsync("Student");
            return Ok(students);
        }
        

        // Route = /api/User/GetUserByUserName/
        [HttpGet]
        [Route("GetUserByUserName/{username}")]
        public async Task<ActionResult> GetUserByUserName(string username)
        {
            var user = await _userManager.FindByNameAsync(username);
            try
            {
                if (user != null)
                {
                    return Ok(new { succeeded = true, user = user });
                }
                else
                {
                    return Ok(new { succeeded = false, code = "UsernameNotFound", description = "Username '" + username + "' was not Found" });
                }
            }
            catch (Exception)
            {
                return Ok(new { succeeded = false, code = "ServerError", description = "Something went wrong in Server !" });
            }
        }

        // Route = /api/User/GetUserById/
        [HttpGet]
        [Route("GetUserById/{id}")]
        public async Task<ActionResult> GetUserById(string id)
        {
            var user = await _userManager.FindByIdAsync(id);

            return Ok(user);
        }

        // Route = /api/Users/GetUsersCount/
        // This method will return a number of total users in DataBase
        [HttpGet]
        [Route("GetUsersCount")]
        public ActionResult GetUsersCount()
        {
            try
            {
                List<User> count = _userManager.Users.ToList();
                return Ok(new { succeeded = true, count = count.Count });
            }
            catch (Exception)
            {
                return Ok(new { succeeded = false, code = "ServerError", description = "Something went wrong in Server !" });
            }
        }

    }
}