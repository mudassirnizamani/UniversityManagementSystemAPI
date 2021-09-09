using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using UniversityManagementSystemAPI.Interfaces;
using UniversityManagementSystemAPI.Models;
using UniversityManagementSystemAPI.ViewModels;

namespace UniversityManagementSystemAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SubjectController : ControllerBase
    {
        private readonly ISubject _subjectService;

        public SubjectController(ISubject subjectService)
        {
            _subjectService = subjectService;
        }

        [HttpGet]
        [Route("GetSubjects")]
        public ActionResult<IEnumerable<Subject>> GetSubjects()
        {
            return Ok(_subjectService.GetSubjects());
        }

        [HttpGet]
        [Route("GetSubjectById/{id}")]
        public ActionResult<Subject> GetSubjectById(string id)
        {
            return Ok(_subjectService.GetSubjectById(id));
        }

        [HttpPost]
        [Route("CreateSubject")]
        public ActionResult CreateFaculty(SubjectModel model)
        {
            _subjectService.CreateSubject(model);
            _subjectService.SaveChanges();
            return Ok("created");
        }

        [HttpGet]
        [Route("DeleteSubjectById/{id}")]
        public ActionResult DeleteSubjectById(string id)
        {
            var subject = _subjectService.GetSubjectById(id);
            _subjectService.DeleteSubject(subject);
            _subjectService.SaveChanges();
            return Ok("deleted");
        }

        [HttpGet]
        [Route("GetSubjectsCount")]
        public ActionResult GetFacultiesCount()
        {
            List<Subject> subjects = _subjectService.GetSubjects().ToList();
            return Ok(subjects.Count);
        }

        [HttpPost]
        [Route("AddDepartmentSubjects")]
        public ActionResult AddDepartmentSubjects(DepartmentSubject model)
        {
            var subject = new SubjectOfDepartment
            {
                DepartmentId = model.DepartmentId,
                SubjectId = model.SubjectId
            };

            _subjectService.AddSubjectToDepartment(subject);
            _subjectService.SaveChanges();
            return Ok("created");
        }

        [HttpGet]
        [Route("GetSubjectsOfDepartment/{id}")]
        public async Task<ActionResult> GetSubjectsOfDepartment(string id)
        {
            IEnumerable<SubjectOfDepartment> subjectsIds = await _subjectService.GetDepartmentSubjectsIdsAsync(id);
            List<Subject> subjects = new List<Subject>();

            foreach (var myId in subjectsIds)
            {
                subjects.Add(_subjectService.GetSubjectById(myId.SubjectId));
            }

            return Ok(subjects);
        }
    }
}