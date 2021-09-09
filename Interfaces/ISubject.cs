using System.Collections.Generic;
using System.Threading.Tasks;
using UniversityManagementSystemAPI.Models;
using UniversityManagementSystemAPI.ViewModels;

namespace UniversityManagementSystemAPI.Interfaces
{
    public interface ISubject
    {
        IEnumerable<Subject> GetSubjects();
        Subject GetSubjectById(string id);

        void CreateSubject(SubjectModel model);

        bool SaveChanges();

        void DeleteSubject(Subject model);

        void AddSubjectToDepartment(SubjectOfDepartment model);

        Task<IEnumerable<SubjectOfDepartment>> GetDepartmentSubjectsIdsAsync(string id);
    }
}

