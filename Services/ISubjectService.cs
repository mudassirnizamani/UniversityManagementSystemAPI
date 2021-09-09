using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using UniversityManagementSystemAPI.Contexts;
using UniversityManagementSystemAPI.Interfaces;
using UniversityManagementSystemAPI.Models;

namespace UniversityManagementSystemAPI.Services
{
    public class ISubjectService : ISubject
    {
        private readonly APIContext _apiContext;

        public ISubjectService(APIContext apiContext)
        {
            _apiContext = apiContext;
        }

        public bool SaveChanges()
        {
            return (_apiContext.SaveChanges() >= 0);
        }

        public void CreateSubject(SubjectModel model)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model));
            }

            var subject = new Subject
            {
                Name = model.Name
            };

            _apiContext.Subjects.Add(subject);
        }

        public Subject GetSubjectById(string id)
        {
            return _apiContext.Subjects.FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<Subject> GetSubjects()
        {
            return _apiContext.Subjects.ToList();
        }

        public void DeleteSubject(Subject model)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model));
            }

            _apiContext.Subjects.Remove(model);
        }

        public void AddSubjectToDepartment(SubjectOfDepartment model)
        {
            _apiContext.DepartmentSubjects.Add(model);
        }

        public async Task<IEnumerable<SubjectOfDepartment>> GetDepartmentSubjectsIdsAsync(string id)
        {
            return await _apiContext.DepartmentSubjects.Where(x => x.DepartmentId == id).ToListAsync();
        }
    }
}