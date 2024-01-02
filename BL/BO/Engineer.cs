/// <summary>
/// Engineer entity represents an engineer with all its propreties.
/// </summary>
/// <param name="engineerId">personal unique id for the  engineer</param>
/// <param name="name">the name of the engineer</param>
/// <param name="email">the email of the engineer</param>
/// <param name="costPerHour">cost per hour for the engineer</param>
/// <param name="exp">the exprience level of the engineer</param>
/// <param name="task">the task that have the engineer</param>
namespace BO;

public class Engineer
{
    public int engineerId { get; init; }
    public required string name { get; set; }
    public required string email { get; set; }
    public int costPerHour { get; set; }
    public EngineerExperience exp { get; set; }
    public TaskInEngineer? task { get; set; }
}
