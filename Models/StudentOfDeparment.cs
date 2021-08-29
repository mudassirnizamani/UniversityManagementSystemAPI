using System.ComponentModel.DataAnnotations.Schema;

namespace UniversityManagementSystemAPI.Models
{
    public class StudentOfDepartment
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; }
        public string DepartmentId { get; set; }
        public string StudentId { get; set; }
    }
}