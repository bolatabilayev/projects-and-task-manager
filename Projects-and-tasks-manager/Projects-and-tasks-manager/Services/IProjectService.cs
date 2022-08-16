using Projects_and_tasks_manager.DTOs;
using Projects_and_tasks_manager.Models;

namespace Projects_and_tasks_manager.Services;

public interface IProjectService
{
    Task CreateAsync(ProjectDTO projectDTO);
    Task<List<Project>> GetAllProjectsAsync();
    Task<Project> GetProjectByIdAsync(int id);
    Task<Project> UpdateProjectByIdAsync(int id, ProjectDTO projectDTO);
    Task DeleteProjectByIdAsync(int id);
}