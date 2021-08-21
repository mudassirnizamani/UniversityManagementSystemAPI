using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using UniversityManagementSystemAPI.Models;

namespace UniversityManagementSystemAPI.Contexts
{
    public class AuthContext : IdentityDbContext
    {
        public AuthContext(DbContextOptions<AuthContext> opt) : base(opt)
        {
        }

        public DbSet<User> Users { get; set; }
    }
}