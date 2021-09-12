using System.ComponentModel.DataAnnotations.Schema;

namespace UniversityManagementSystemAPI.Models
{
    public class Result
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; }

        public string StudentId { get; set; }
        public string StudentName { get; set; }

        public string Semester { get; set; }

        public string Year { get; set; }

        public string DepartmentId { get; set; }

        public string DepartmentName { get; set; }

        public string SubjectName { get; set; }
        public string SubjectId { get; set; }

        public string Marks { get; set; }

        public string Percentage { get; set; }

        public string Grade { get; set; }

    }
}