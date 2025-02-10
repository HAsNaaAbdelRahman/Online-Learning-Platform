
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Online_Learning_Platform.Core.Models;
using System.Reflection.Emit;

namespace Online_Learning_Platform.Repository.Data
{
    public class ApplicationDbContext : IdentityDbContext<User>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {

            base.OnModelCreating(builder);

            builder.Entity<Enrollment>()
                .HasOne(e => e.User)
                .WithMany(u => u.Enrollments)
                .HasForeignKey(u => u.UserId);

            builder.Entity<Enrollment>()
                .HasOne(e => e.Course)
                .WithMany(u => u.Enrollments)
                .HasForeignKey(u => u.CourseId);

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }
        public DbSet<Course> courses { get; set; }
        public DbSet<Enrollment> enrollments { get; set; }
        public DbSet<Module> modules { get; set; }
        public DbSet<Lesson> lessons { get; set; }

    }



}
