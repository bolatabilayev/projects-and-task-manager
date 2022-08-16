namespace Projects_and_tasks_manager.Models;

public class TaskEntity
{
    public int Id { get; set; }
    public string Name { get; set; }
    public Status Status { get; set; }
    public string Description { get; set; }
    public int Priority { get; set; }
    
    public int ProjectId { get; set; }
}