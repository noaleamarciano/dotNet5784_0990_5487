
namespace BO;
/// <summary>
/// task entity represents a task with all its propreties.
/// </summary>
/// <param name="taskId">Personal unique key of task.</param>
/// <param name="description">a description of the task</param>
/// <param name="alias">an alias for the task</param>
/// <param name="createdAtDate">the date of the production</param>
/// <param name="status">the status of the task</param>
/// <param name="dependencies">a list of all the task that dependent on this task</param>
/// <param name="milestone">the details of the milestone if it is</param>
/// <param name="scheduledStartDate">the date that the task start</param>
/// <param name="startDate">an estimated date for completing the task</param>
/// <param name="forecastDate">Estimated completion date</param>
/// <param name="deadLine">the final date for the task</param>
/// <param name="completeDate">Actual end date of the task</param>
/// <param name="deliverables">a string describing the product</param>
/// <param name="remarks">remarks about the task</param>
/// <param name="engineer">the details of the enguneer of this task</param>
/// <param name="exp">the exprience level of the engineer</param>
public class Task
{
    public int taskId { get; init; }
    public required  string description { get; set; }
    public required string alias { get; set; }
    public DateTime createdAtDate { get; set; }
    public Status ?status { get; set; }
    public List<TaskInList>? dependencies { get; set; }
    public MilestoneInTask? milestone { get; set; }
    public DateTime ?scheduledStartDate { get; set; }
    public DateTime? startDate { get; set; }
    public DateTime? forecastDate { get; set; }
    public DateTime? deadLine { get; set; }
    public DateTime? completeDate { get; set; }
    public string? deliverables { get; set; }
    public string? remarks { get; set; }
    public EngineerInTask engineer { get; set; }
    public EngineerExperience exp { get; set; }
    public override string? ToString() => this.GenericToString();
}
