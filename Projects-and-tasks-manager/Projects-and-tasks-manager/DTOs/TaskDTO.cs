using Projects_and_tasks_manager.Models;

namespace Projects_and_tasks_manager.DTOs;

public class TaskDTO
{
    public int Id { get; set; }
    public string Name { get; set; }
    public Status Status { get; set; }
    public string Description { get; set; }
    public int Priority { get; set; }
}