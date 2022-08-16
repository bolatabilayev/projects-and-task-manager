using Projects_and_tasks_manager.DTOs;
using Projects_and_tasks_manager.Models;
using Projects_and_tasks_manager.Repositories;

namespace Projects_and_tasks_manager.Services;

public class ProjectService : IProjectService
{
    private readonly IProjectRepository _projectRepository;

    public ProjectService(IProjectRepository projectRepository)
    {
        _projectRepository = projectRepository;
    }

    public Task CreateAsync(ProjectDTO projectDTO)
    {
        Project project = new Project()
        {
            Id = projectDTO.Id,
            Name = projectDTO.Name,
            Priority = projectDTO.Priority,
            Tasks = projectDTO.Tasks,
            Status = projectDTO.Status,
            StartDate = projectDTO.StartDate,
            CompletionDate = projectDTO.CompletionDate
        };

        return _projectRepository.CreateAsync(project);
    }

    public Task<List<Project>> GetAllProjectsAsync()
    {
        return _projectRepository.GetAllProjectsAsync();
    }

    public Task<Project> GetProjectByIdAsync(int id)
    {
        return _projectRepository.GetProjectByIdAsync(id);
    }

    public Task<Project> UpdateProjectByIdAsync(int id, ProjectDTO projectDTO)
    {
        return _projectRepository.UpdateProjectByIdAsync(id, projectDTO);
    }

    public Task DeleteProjectByIdAsync(int id)
    {
        return _projectRepository.DeleteProjectByIdAsync(id);
    }
}