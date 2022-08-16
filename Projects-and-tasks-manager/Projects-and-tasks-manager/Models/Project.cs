namespace Projects_and_tasks_manager.Models;

public class Project
{
    public int Id { get; set; }
    public string Name { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime CompletionDate { get; set; }
    public Status Status { get; set; }
    public int Priority { get; set; }
    public List<TaskEntity> Tasks { get; set; } = new List<TaskEntity>();

    // public Project()
    // {
    //
    // }
    //
    // public Project(int id, string name, int priority, List<TaskEntity> tasks, Status status, DateTime startDate, DateTime completionDate) : this()
    // {
    //     Id = id;
    //     Name = name;
    //     Priority = priority;
    //     Tasks = tasks;
    //     Status = status;
    //     StartDate = startDate;
    //     CompletionDate = completionDate;
    // }
}