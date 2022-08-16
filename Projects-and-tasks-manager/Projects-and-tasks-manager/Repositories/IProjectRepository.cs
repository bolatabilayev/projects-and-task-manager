using Projects_and_tasks_manager.DTOs;
using Projects_and_tasks_manager.Models;

namespace Projects_and_tasks_manager.Repositories;

public interface IProjectRepository
{
    Task CreateAsync(Project project);
    Task<List<Project>> GetAllProjectsAsync();
    Task<Project> GetProjectByIdAsync(int id);
    Task<Project> UpdateProjectByIdAsync(int id, ProjectDTO projectDTO);
    Task DeleteProjectByIdAsync(int id);
}