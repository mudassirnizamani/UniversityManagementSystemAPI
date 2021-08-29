using Microsoft.EntityFrameworkCore;
using UniversityManagementSystemAPI.Models;

namespace UniversityManagementSystemAPI.Contexts
{
    public class APIContext : DbContext
    {
        public APIContext(DbContextOptions<APIContext> opt) : base(opt)
        {

        }

        public DbSet<Subject> Subjects { get; set; }
        public DbSet<Faculty> Faculties { get; set; }
        public DbSet<Department> Departments { get; set; }

        public DbSet<DepartmentOfFaculty> FacultyDepartments { get; set; }
        public DbSet<SubjectOfDepartment> DepartmentSubjects { get; set; }
        public DbSet<StudentOfDepartment> DepartmentStudents { get; set; }
    }
}