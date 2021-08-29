using System.ComponentModel.DataAnnotations.Schema;

namespace UniversityManagementSystemAPI.Models
{
    public class DepartmentOfFaculty
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; }
        public string FacultyId { get; set; }
        public string DepartmentId { get; set; }
    }
}