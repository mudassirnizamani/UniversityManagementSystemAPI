using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using UniversityManagementSystemAPI.Interfaces;
using UniversityManagementSystemAPI.Models;
using UniversityManagementSystemAPI.ViewModels;

namespace UniversityManagementSystemAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ResultController : ControllerBase
    {
        private readonly IResult _resultService;

        public ResultController(IResult resultService)
        {
            _resultService = resultService;
        }

        [HttpGet]
        [Route("GetResults")]
        public ActionResult GetSubjects()
        {
            return Ok(_resultService.GetResults());
        }

        [HttpPost]
        [Route("CreateResult")]
        public ActionResult CreateResult(ResultModel model)
        {
            _resultService.CreateResult(model);
            _resultService.SaveChanges();
            return Ok("created");
        }

        [HttpGet]
        [Route("GetResultById/{id}")]
        public ActionResult GetResultById(string id)
        {
            return Ok(_resultService.GetResultById(id));
        }

        [HttpGet]
        [Route("DeleteResultById/{id}")]
        public ActionResult DeleteResultById(string id)
        {
            var result = _resultService.GetResultById(id);
            _resultService.DeleteResult(result);
            _resultService.SaveChanges();
            return Ok("deleted");
        }

        [HttpGet]
        [Route("GetResultsCount")]
        public ActionResult GetResultsCount()
        {
            List<Result> results = _resultService.GetResults().ToList();
            return Ok(results.Count);
        }
    }
}