using System.ComponentModel.DataAnnotations.Schema;

namespace UniversityManagementSystemAPI.ViewModels
{
    public class FacultyModel
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Name { get; set; }
        public string DeanId { get; set; }

    }
}