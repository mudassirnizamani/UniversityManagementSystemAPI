using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
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

        public void DeleteDepartment(Department model)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model));
            }

            _apiContext.Departments.Remove(model);
        }

        public void AddDepartmentToFaculty(DepartmentOfFaculty model)
        {
            _apiContext.FacultyDepartments.Add(model);
        }

        public IEnumerable<DepartmentOfFaculty> GetFacultyDepartmentsIds(string id)
        {
            return _apiContext.FacultyDepartments.Where(x => x.FacultyId == id);
        }

        public async Task<IEnumerable<DepartmentOfFaculty>> GetFacultyDepartmentsIdsAsync(string id)
        {
            return await _apiContext.FacultyDepartments.Where(x => x.FacultyId == id).ToListAsync();
        }
    }
}