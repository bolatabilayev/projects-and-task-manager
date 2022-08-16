using Microsoft.EntityFrameworkCore;
using Projects_and_tasks_manager.Models;

namespace Projects_and_tasks_manager.DataContext;

public class ProjectDBContext : DbContext
{
    
    public DbSet<Project> Projects { get; set; }
    public DbSet<TaskEntity> Tasks { get; set; }
    
    public ProjectDBContext(DbContextOptions<ProjectDBContext> options) : base(options)
    {
        Database.EnsureCreated();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TaskEntity>().HasData(
            new TaskEntity()
            {
                Id = 1,
                Name = "Task 1",
                Description = "This is the first task in our Project",
                Status = Status.ToDo,
                Priority = 1,
                ProjectId = 1
            },
            new TaskEntity()
            {
                Id = 2,
                Name = "Task 2",
                Description = "Second task in our Project",
                Status = Status.ToDo,
                Priority = 0,
                ProjectId = 1
            });
        
        modelBuilder.Entity<Project>().HasData(
            new Project
            {
                Id = 1,
                Name = "Project 1",
                StartDate = new DateTime(2022, 8, 15).ToUniversalTime(),
                CompletionDate = new DateTime(2022, 8, 25).ToUniversalTime(),
                Status = Status.ToDo,
                Priority = 1
            });
        
        modelBuilder.Entity<Project>(e =>
        {
            e.HasMany(p => p.Tasks);
        });
    }
}