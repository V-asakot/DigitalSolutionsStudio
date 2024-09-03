using DigitalSolutionsStudio.Api.Db.Entities;
using Microsoft.EntityFrameworkCore;

namespace DigitalSolutionsStudio.Api.Db
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<TaskEntity> Tasks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {   
            modelBuilder.Entity<TaskEntity>().HasData(
                new TaskEntity { Id = 1, Name = "First task", Description = "First task", Status = TaskCompletionStatus.Open, CreationDate = DateTime.Now, LastModifiedDate = DateTime.Now },
                new TaskEntity { Id = 2, Name = "First task", Description = "Second task", Status = TaskCompletionStatus.Open, CreationDate = DateTime.Now, LastModifiedDate = DateTime.Now },
                new TaskEntity { Id = 3, Name = "First task", Description = "Third task", Status = TaskCompletionStatus.Open, CreationDate = DateTime.Now, LastModifiedDate = DateTime.Now }
                );

            base.OnModelCreating(modelBuilder);
        }
    }
}
