using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using UniversityManagementSystemAPI.Interfaces;
using UniversityManagementSystemAPI.Models;
using UniversityManagementSystemAPI.ViewModels;

namespace UniversityManagementSystemAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly IDepartment _departmentService;
        private readonly IFaculty _facultyService;

        public DepartmentController(IDepartment departmentService, IFaculty facultyService)
        {
            _departmentService = departmentService;
            _facultyService = facultyService;
        }

        [HttpGet]
        [Route("GetDepartments")]
        public ActionResult GetDepartments()
        {
            return Ok(_departmentService.GetDepartments());
        }

        [HttpGet]
        [Route("GetDepartmentById/{id}")]
        public ActionResult GetDepartmentById(string id)
        {
            return Ok(_departmentService.GetDepartmentById(id));
        }

        [HttpPost]
        [Route("CreateDepartment")]
        public ActionResult CreateDepartment(DepartmentModel model)
        {
            _departmentService.CreateDepartment(model);
            _departmentService.SaveChanges();
            return Ok("created");
        }

        [HttpGet]
        [Route("DeleteDepartmentById/{id}")]
        public ActionResult DeleteDepartmentById(string id)
        {
            var department = _departmentService.GetDepartmentById(id);
            _departmentService.DeleteDepartment(department);
            _departmentService.SaveChanges();
            return Ok("deleted");
        }

        [HttpPost]
        [Route("AddFacultyDepartments")]
        public ActionResult AddFacultyDepartments(FacultyDepartments model)
        {
            var department = new DepartmentOfFaculty
            {
                DepartmentId = model.DepartmentId,
                FacultyId = model.FacultyId
            };

            _departmentService.AddDepartmentToFaculty(department);
            _departmentService.SaveChanges();
            return Ok("created");
        }

        [HttpGet]
        [Route("GetDepartmentsOfFaculty/{id}")]
        public async Task<ActionResult> GetDepartmentsOfFaculty(string id)
        {
            IEnumerable<DepartmentOfFaculty> departmentIds = await _departmentService.GetFacultyDepartmentsIdsAsync(id);
            List<Department> departments = new List<Department>();

            foreach (var myId in departmentIds)
            {
                departments.Add(_departmentService.GetDepartmentById(myId.DepartmentId));
            }

            return Ok(departments);
        }
    }
}