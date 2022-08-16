using Projects_and_tasks_manager.Models;

namespace Projects_and_tasks_manager.DTOs;

public class ProjectDTO
{
    public int Id { get; set; }
    public string Name { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime CompletionDate { get; set; }
    public Status Status { get; set; }
    public int Priority { get; set; }
    public List<TaskEntity> Tasks { get; set; }
}