namespace UniversityManagementSystemAPI.Models
{
    public class Department
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string HeadOfDepartmentId { get; set; }
        public string CourseAdvicerId { get; set; }
    }
}