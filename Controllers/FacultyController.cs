using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using UniversityManagementSystemAPI.Interfaces;
using UniversityManagementSystemAPI.Models;
using UniversityManagementSystemAPI.ViewModels;

namespace UniversityManagementSystemAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FacultyController : ControllerBase
    {
        private readonly IFaculty _facultyService;

        public FacultyController(IFaculty facultyService)
        {
            _facultyService = facultyService;
        }

        [HttpGet]
        [Route("GetFaculties")]
        public ActionResult<IEnumerable<Faculty>> GetFaculties()
        {
            return Ok(_facultyService.GetFaculties());
        }

        [HttpGet]
        [Route("GetFacultyById/{id}")]
        public ActionResult<Faculty> GetFacultyById(string id)
        {
            return Ok(_facultyService.GetFacultyById(id));
        }

        [HttpPost]
        [Route("CreateFaculty")]
        public ActionResult CreateFaculty(FacultyModel model)
        {
            _facultyService.CreateFaculty(model);
            _facultyService.SaveChanges();
            return Ok("created");
        }

        [HttpGet]
        [Route("DeleteFacultyById/{id}")]
        public ActionResult DeleteFacultyById(string id)
        {
            var faculty = _facultyService.GetFacultyById(id);
            _facultyService.DeleteFaculty(faculty);
            _facultyService.SaveChanges();
            return Ok("deleted");
        }

        [HttpGet]
        [Route("GetFacultiesCount")]
        public ActionResult GetFacultiesCount()
        {
            List<Faculty> faculties = _facultyService.GetFaculties().ToList();
            return Ok(faculties.Count);
        }
    }
}