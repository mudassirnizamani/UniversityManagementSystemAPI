using System.Collections.Generic;
using UniversityManagementSystemAPI.Models;
using UniversityManagementSystemAPI.ViewModels;

namespace UniversityManagementSystemAPI.Interfaces
{
    public interface IFaculty
    {
        IEnumerable<Faculty> GetFaculties();
        Faculty GetFacultyById(string id);

        void CreateFaculty(FacultyModel model);

        bool SaveChanges();

        void DeleteFaculty(Faculty model);
    }
}