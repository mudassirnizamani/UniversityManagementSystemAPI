using System.Collections.Generic;
using UniversityManagementSystemAPI.Models;
using UniversityManagementSystemAPI.ViewModels;

namespace UniversityManagementSystemAPI.Interfaces
{
    public interface IDepartment
    {
        IEnumerable<Department> GetDepartments();
        Department GetDepartmentById(string id);

        void CreateDepartment(DepartmentModel model);

        bool SaveChanges();
    }
}