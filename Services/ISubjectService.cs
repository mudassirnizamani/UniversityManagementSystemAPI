using System;
using System.Collections.Generic;
using System.Linq;
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
    }
}