namespace BO;
/// <summary>
/// 
/// </summary>
/// <param name="milestoneId">Personal unique key of a milestone.</param>
/// <param name="description">a description of the milestone</param>
/// <param name="alias">an alias for the milestone</param>
/// <param name="createdAtDate">the date of the production</param>
/// <param name="status">the status of the milestone</param>
/// <param name="startDate">an estimated date for completing the task</param>
/// <param name="forecastDate">Estimated completion date</param>
/// <param name="deadLine">the final date for the task</param>
/// <param name="completeDate">Actual end date of the task</param>
/// <param name="remarks">remarks about the task</param>
/// <param name="completionPercentage">Progress percentage of the task</param>
/// <param name="dependencies">a list of all the milestones that dependent on this milestone</param>
public class Milestone
{
    public int milestoneId { get; init; }
    public string? description { get; set; }
    public string? alias { get; set; }
    public DateTime createdAtDate { get; set; }
    public Status status { get; set; }
    public DateTime startDate { get; set; }
    public DateTime forecastDate { get; set; }
    public DateTime deadLine { get; set; }
    public DateTime completeDate { get; set; }
    public string? remarks { get; set; }
    public double completionPercentage { get; set; }
    public List<TaskInList>? dependencies { get; set; }
    public override string? ToString() => $"Milestone (ID:M{milestoneId})";
}
