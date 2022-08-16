using Projects_and_tasks_manager.DTOs;
using Projects_and_tasks_manager.Models;
using Projects_and_tasks_manager.Repositories;

namespace Projects_and_tasks_manager.Services;

public class TaskService : ITaskService
{
    private readonly ITaskRepository _taskRepository;

    public TaskService(ITaskRepository taskRepository)
    {
        _taskRepository = taskRepository;
    }

    public Task CreateAsync(TaskDTO taskDTO)
    {
        TaskEntity task = new TaskEntity()
        {
            Id = taskDTO.Id,
            Name = taskDTO.Name,
            Status = taskDTO.Status,
            Description = taskDTO.Description,
            Priority = taskDTO.Priority
        };
        return _taskRepository.CreateAsync(task);
    }

    public Task<List<TaskEntity>> GetAllTasksAsync()
    {
        return _taskRepository.GetAllTasksAsync();
    }

    public Task<List<TaskEntity>> GetAllTasksByProjectIdAsync(int projectId)
    {
        return _taskRepository.GetAllTasksByProjectIdAsync(projectId);
    }

    public Task<TaskEntity> GetTaskByIdAsync(int id)
    {
        return _taskRepository.GetTaskByIdAsync(id);
    }

    public Task<TaskEntity> UpdateTaskByIdAsync(int id, TaskDTO taskDTO)
    {
        return _taskRepository.UpdateTaskByIdAsync(id, taskDTO);
    }

    public Task DeleteTaskByIdAsync(int id)
    {
        return _taskRepository.DeleteTaskByIdAsync(id);
    }
}