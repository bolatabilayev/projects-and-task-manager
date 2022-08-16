using Microsoft.EntityFrameworkCore;
using Projects_and_tasks_manager.DataContext;
using Projects_and_tasks_manager.DTOs;
using Projects_and_tasks_manager.Models;

namespace Projects_and_tasks_manager.Repositories;

public class TaskRepository : ITaskRepository
{
    private readonly ProjectDBContext _projectDbContext;

    public TaskRepository(ProjectDBContext projectDbContext)
    {
        _projectDbContext = projectDbContext;
    }

    public Task CreateAsync(TaskEntity task)
    {
        _projectDbContext.Add(task);
        task.Id = _projectDbContext.SaveChanges();

        return _projectDbContext.Tasks.FirstOrDefaultAsync(t => t.Id == task.Id);
    }

    public Task<List<TaskEntity>> GetAllTasksAsync()
    {
        return _projectDbContext.Tasks.Where(t => true).ToListAsync();
    }

    public Task<List<TaskEntity>> GetAllTasksByProjectIdAsync(int projectId)
    {
        var project = _projectDbContext.Projects.FirstOrDefault(p => p.Id == projectId);
        
        
        return Task.FromResult(project.Tasks);
    }

    public Task<TaskEntity> GetTaskByIdAsync(int id)
    {
        return _projectDbContext.Tasks.FirstOrDefaultAsync(t => t.Id == id);
    }

    public Task<TaskEntity> UpdateTaskByIdAsync(int id, TaskDTO taskDTO)
    {
        var task = _projectDbContext.Tasks.FirstOrDefault(t => t.Id == id);

        if (task == null) throw new ArgumentNullException(nameof(taskDTO));
        
        task.Name = taskDTO.Name;
        task.Priority = taskDTO.Priority;
        task.Status = taskDTO.Status;
        task.Description = taskDTO.Description;
        _projectDbContext.SaveChanges();
            
        return _projectDbContext.Tasks.FirstOrDefaultAsync(t => t.Id == id);
    }

    public Task DeleteTaskByIdAsync(int id)
    {
        var taskToDelete = _projectDbContext.Tasks.FirstOrDefault(task => task.Id == id);
        if (taskToDelete != null) _projectDbContext.Remove(taskToDelete);
        return _projectDbContext.SaveChangesAsync();
    }
}