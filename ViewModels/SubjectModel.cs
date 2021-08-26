using System.ComponentModel.DataAnnotations.Schema;

namespace UniversityManagementSystemAPI.Models
{
    public class SubjectModel
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Name { get; set; }
    }
}