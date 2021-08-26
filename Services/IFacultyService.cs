using System;
using System.Collections.Generic;
using System.Linq;
using UniversityManagementSystemAPI.Contexts;
using UniversityManagementSystemAPI.Interfaces;
using UniversityManagementSystemAPI.Models;
using UniversityManagementSystemAPI.ViewModels;

namespace UniversityManagementSystemAPI.Services
{
    public class IFacultyService : IFaculty
    {
        private readonly APIContext _apiContext;

        public IFacultyService(APIContext apiContext)
        {
            _apiContext = apiContext;
        }
        public void CreateFaculty(FacultyModel model)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model));
            }

            var faculty = new Faculty
            {
                Name = model.Name,
                DeanId = model.DeanId
            };

            _apiContext.Faculties.Add(faculty);
        }

        public bool SaveChanges()
        {
            return (_apiContext.SaveChanges() >= 0);
        }

        public IEnumerable<Faculty> GetFaculties()
        {
            return _apiContext.Faculties.ToList();

        }

        public Faculty GetFacultyById(string id)
        {
            return _apiContext.Faculties.FirstOrDefault(x => x.Id == id);
        }

        public void DeleteFaculty(Faculty model)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model));
            }

            _apiContext.Faculties.Remove(model);
        }
    }
}