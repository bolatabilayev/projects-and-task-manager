using Microsoft.AspNetCore.Mvc;
using Projects_and_tasks_manager.DTOs;
using Projects_and_tasks_manager.Models;
using Projects_and_tasks_manager.Services;

namespace Projects_and_tasks_manager.Controllers;

[Route("api/v1/projects")]
[ApiController]
public class TasksController : Controller
{
    private readonly ITaskService _taskService;

    public TasksController(ITaskService taskService)
    {
        _taskService = taskService;
    }

    [HttpPost("tasks/create")]
    public async Task<IActionResult> CreateTaskAsync([FromBody] TaskDTO taskDTO)
    {
        await _taskService.CreateAsync(taskDTO);
        return Ok();
    }

    [HttpGet("tasks")]
    public async Task<List<TaskEntity>> GetAllTasksAsync()
    {
        return await _taskService.GetAllTasksAsync();
    }

    [HttpGet("{projectId:int}/tasks")]
    public async Task<List<TaskEntity>> GetAllTasksByProjectIdAsync(int projectId)
    {
        return await _taskService.GetAllTasksByProjectIdAsync(projectId);
    }

    [HttpGet("tasks/{taskId:int}")]
    public async Task<TaskEntity> GetTaskByIdAsync(int taskId)
    {
        return await _taskService.GetTaskByIdAsync(taskId);
    }

    [HttpPut("tasks/{taskId:int}")]
    public async Task<TaskEntity> UpdateTaskByIdAsync(int taskId, TaskDTO taskDto)
    {
        return await _taskService.UpdateTaskByIdAsync(taskId, taskDto);
    }

    [HttpDelete("tasks/{taskId:int}")]
    public Task DeleteTaskByIdAsync(int taskId)
    {
        return _taskService.DeleteTaskByIdAsync(taskId);
    }
}