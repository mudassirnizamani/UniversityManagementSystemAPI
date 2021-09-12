using System.Collections.Generic;
using UniversityManagementSystemAPI.Models;
using UniversityManagementSystemAPI.ViewModels;

namespace UniversityManagementSystemAPI.Interfaces
{
    public interface IResult
    {
        IEnumerable<Result> GetResults();
        Result GetResultById(string id);
        void CreateResult(ResultModel model);
        bool SaveChanges();
        void DeleteResult(Result model);
    }
}