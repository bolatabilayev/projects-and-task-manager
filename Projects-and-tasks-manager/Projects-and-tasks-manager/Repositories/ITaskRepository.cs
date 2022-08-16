using Projects_and_tasks_manager.DTOs;
using Projects_and_tasks_manager.Models;

namespace Projects_and_tasks_manager.Repositories;

public interface ITaskRepository
{
    Task CreateAsync(TaskEntity task);
    Task<List<TaskEntity>> GetAllTasksAsync();
    Task<List<TaskEntity>> GetAllTasksByProjectIdAsync(int projectId);
    Task<TaskEntity> GetTaskByIdAsync(int id);
    Task<TaskEntity> UpdateTaskByIdAsync(int id, TaskDTO taskDTO);
    Task DeleteTaskByIdAsync(int id);
}