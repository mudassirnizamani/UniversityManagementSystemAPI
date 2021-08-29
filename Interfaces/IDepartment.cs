using System.Collections.Generic;
using System.Threading.Tasks;
using UniversityManagementSystemAPI.Models;
using UniversityManagementSystemAPI.ViewModels;

namespace UniversityManagementSystemAPI.Interfaces
{
    public interface IDepartment
    {
        IEnumerable<Department> GetDepartments();
        Department GetDepartmentById(string id);

        void CreateDepartment(DepartmentModel model);

        void DeleteDepartment(Department model);

        void AddDepartmentToFaculty(DepartmentOfFaculty model);

        IEnumerable<DepartmentOfFaculty> GetFacultyDepartmentsIds(string id);

        Task<IEnumerable<DepartmentOfFaculty>> GetFacultyDepartmentsIdsAsync(string id);

        bool SaveChanges();
    }
}