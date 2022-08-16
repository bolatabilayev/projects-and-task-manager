using Microsoft.AspNetCore.Mvc;
using Projects_and_tasks_manager.DTOs;
using Projects_and_tasks_manager.Models;
using Projects_and_tasks_manager.Services;

namespace Projects_and_tasks_manager.Controllers;

[Route("api/v1/projects")]
[ApiController]
public class ProjectsController : Controller
{
    private readonly IProjectService _projectService;

    public ProjectsController(IProjectService projectService)
    {
        _projectService = projectService;
    }
    
    [HttpPost("create")]
    public async Task<IActionResult> CreateProjectAsync([FromBody] ProjectDTO projectDTO)
    {
        await _projectService.CreateAsync(projectDTO);
        return Ok();
    }

    [HttpGet()]
    public async Task<List<Project>> GetAllProjectsAsync()
    {
        return await _projectService.GetAllProjectsAsync();
    }

    [HttpGet("{projectId:int}")]
    public async Task<Project> GetProjectByIdAsync(int projectId)
    {
        return await _projectService.GetProjectByIdAsync(projectId);
    }

    [HttpPut("{projectId:int}")]
    public async Task<Project> UpdateProjectByIdAsync(int projectId, ProjectDTO projectDTO)
    {
        return await _projectService.UpdateProjectByIdAsync(projectId, projectDTO);
    }

    [HttpDelete("{projectId:int}")]
    public Task DeleteProjectByIdAsync(int projectId)
    {
        return _projectService.DeleteProjectByIdAsync(projectId);
    }
}