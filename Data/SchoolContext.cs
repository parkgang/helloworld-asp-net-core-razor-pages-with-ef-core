using Microsoft.EntityFrameworkCore;

namespace HelloworldAspNetCoreRazorPagesWithEfCore.Data
{
    public class SchoolContext : DbContext
    {
        public SchoolContext(DbContextOptions<SchoolContext> options) : base(options)
        {
        }

        public DbSet<HelloworldAspNetCoreRazorPagesWithEfCore.Models.Student> Student { get; set; }
    }
}
