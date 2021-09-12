using System;
using System.Collections.Generic;
using System.Linq;
using UniversityManagementSystemAPI.Contexts;
using UniversityManagementSystemAPI.Interfaces;
using UniversityManagementSystemAPI.Models;
using UniversityManagementSystemAPI.ViewModels;

namespace UniversityManagementSystemAPI.Services
{
    public class IResultService : IResult
    {
        private readonly APIContext _apiContext;

        public IResultService(APIContext apiContext)
        {
            _apiContext = apiContext;
        }
        public void CreateResult(ResultModel model)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model));
            }

            var result = new Result
            {
                DepartmentId = model.DepartmentId,
                DepartmentName = model.DepartmentName,
                Grade = model.Grade,
                Marks = model.Marks,
                Percentage = model.Percentage,
                Semester = model.Semester,
                StudentId = model.StudentId,
                StudentName = model.StudentName,
                SubjectId = model.SubjectId,
                SubjectName = model.SubjectName,
                Year = model.Year
            };

            _apiContext.Results.Add(result);
        }

        public void DeleteResult(Result model)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model));
            }

            _apiContext.Results.Remove(model);
        }

        public Result GetResultById(string id)
        {
            return _apiContext.Results.FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<Result> GetResults()
        {
            return _apiContext.Results.ToList();
        }

        public bool SaveChanges()
        {
            return (_apiContext.SaveChanges() >= 0);
        }
    }
}