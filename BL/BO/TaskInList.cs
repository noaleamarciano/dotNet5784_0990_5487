
namespace BO;
/// <summary>
/// Represents a task in a list of dependencies
/// </summary>
/// <param name="status">the status of the task</param>
/// <param name="taskId">Personal unique key of task.</param>
/// <param name="description">a description of the task</param>
/// <param name="alias">an alias for the task</param>
public class TaskInList
{
    public Status status { get; set; }
    public int taskId { get; init; }
    public string? description { get; set; }
    public string? alias { get; set; }
   
}
