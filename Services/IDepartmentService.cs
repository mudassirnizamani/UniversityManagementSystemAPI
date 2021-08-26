using System;
using System.Collections.Generic;
using System.Linq;
using UniversityManagementSystemAPI.Contexts;
using UniversityManagementSystemAPI.Interfaces;
using UniversityManagementSystemAPI.Models;
using UniversityManagementSystemAPI.ViewModels;

namespace UniversityManagementSystemAPI.Services
{
    public class IDepartmentService : IDepartment
    {
        private readonly APIContext _apiContext;

        public IDepartmentService(APIContext apiContext)
        {
            _apiContext = apiContext;
        }
        public bool SaveChanges()
        {
            return (_apiContext.SaveChanges() >= 0);
        }
        public void CreateDepartment(DepartmentModel model)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model));
            }

            var department = new Department
            {
                CourseAdvicerId = model.CourseAdvicerId,
                HeadOfDepartmentId = model.HeadOfDepartmentId,
                Name = model.Name
            };

            _apiContext.Departments.Add(department);
        }

        public Department GetDepartmentById(string id)
        {
            return _apiContext.Departments.FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<Department> GetDepartments()
        {
            return _apiContext.Departments.ToList();
        }
    }
}