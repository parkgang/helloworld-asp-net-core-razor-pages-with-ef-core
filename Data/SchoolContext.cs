using Microsoft.EntityFrameworkCore;
using HelloworldAspNetCoreRazorPagesWithEfCore.Models;

namespace HelloworldAspNetCoreRazorPagesWithEfCore.Data
{
    public class SchoolContext : DbContext
    {
        public SchoolContext(DbContextOptions<SchoolContext> options) : base(options)
        {
        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }
        public DbSet<Course> Courses { get; set; }

        /// <summary>
        /// SchoolContext가 초기화되었을 때 모델이 잠기고 컨텍스트를 초기화하는 데 사용되기 전에 호출됩니다.
        /// </summary>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Course>().ToTable("Course");
            modelBuilder.Entity<Enrollment>().ToTable("Enrollment");
            modelBuilder.Entity<Student>().ToTable("Student");
        }
    }
}