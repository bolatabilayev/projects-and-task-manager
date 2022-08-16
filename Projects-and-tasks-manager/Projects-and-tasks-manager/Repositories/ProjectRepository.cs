using Microsoft.EntityFrameworkCore;
using Projects_and_tasks_manager.DataContext;
using Projects_and_tasks_manager.DTOs;
using Projects_and_tasks_manager.Models;

namespace Projects_and_tasks_manager.Repositories;

public class ProjectRepository : IProjectRepository
{
    private readonly ProjectDBContext _projectDbContext;

    public ProjectRepository(ProjectDBContext projectDbContext)
    {
        _projectDbContext = projectDbContext;
    }

    public Task CreateAsync(Project project)
    {
        _projectDbContext.Add(project);
        project.Id = _projectDbContext.SaveChanges();

        return _projectDbContext.Projects.FirstOrDefaultAsync(p => p.Id == project.Id);
    }

    public Task<List<Project>> GetAllProjectsAsync()
    {
        return _projectDbContext.Projects.Where(p => true).ToListAsync();
    }

    public Task<Project> GetProjectByIdAsync(int id)
    {
        return _projectDbContext.Projects.FirstOrDefaultAsync(p => p.Id == id);
    }

    public Task<Project> UpdateProjectByIdAsync(int id, ProjectDTO projectDTO)
    {
        var project = _projectDbContext.Projects.FirstOrDefault(p => p.Id == id);

        if (project == null) throw new ArgumentNullException(nameof(projectDTO));
        
        project.Name = projectDTO.Name;
        project.Priority = projectDTO.Priority;
        project.Status = projectDTO.Status;
        project.Tasks = projectDTO.Tasks;
        project.StartDate = projectDTO.StartDate;
        project.CompletionDate = projectDTO.CompletionDate;
        _projectDbContext.SaveChanges();
            
        return _projectDbContext.Projects.FirstOrDefaultAsync(p => p.Id == id);
    }

    public Task DeleteProjectByIdAsync(int id)
    {
        var projectToDelete = _projectDbContext.Projects.FirstOrDefault(p => p.Id == id);
        if (projectToDelete != null) _projectDbContext.Remove(projectToDelete);
        return _projectDbContext.SaveChangesAsync();
    }
}