namespace BO;
/// <summary>
/// 
/// </summary>
/// <param name="taskId">Personal unique key of task.</param>
/// <param name="description">a description of the task</param>
/// <param name="alias">an alias for the task</param>
/// <param name="status">the status of the task</param>
/// <param name="completionPercentage">Progress percentage of the task</param>
public class MilestoneInList
{
    public int id { get; init; }
    public string? description { get; set; }
    public string? alias { get; set; }
    public Status status { get; set; }
    public double completionPercentage { get; set; }
    public override string? ToString() => base.ToString();
}
