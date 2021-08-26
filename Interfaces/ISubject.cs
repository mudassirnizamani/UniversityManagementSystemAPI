using System.Collections.Generic;
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
    }
}

