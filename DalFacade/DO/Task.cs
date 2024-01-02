
namespace DO;
/// <summary>
/// task entity represents a task with all its propreties.
/// </summary>
/// <param name="taskId">Personal unique key of task.</param>
/// <param name="taskDescription">a description of the task</param>
/// <param name="alias">an alias for the task</param>
/// <param name="milestone">if this task is a milestone or not</param>
/// <param name="createdAtDate">the date of the production</param>
/// <param name="scheduledStartDate">the date that the task start</param>
/// <param name="startDate">an estimated date for completing the task</param>
/// <param name="deadLine">the final date for the task</param>
/// <param name="completeDate">Actual end date of the task</param>
/// <param name="product">a string describing the product</param>
/// <param name="remarks">remarks about the task</param>
/// <param name="engineerId">personal unique id for the  engineer</param>
/// <param name="exp">the exprience level of the engineer</param>
public record Task
(
    int taskId,
    string taskDescription,
    string alias,
    bool milestone,
    DateTime createdAtDate,//תאריך מתוכנן לתחילת העבודה
    DateTime? scheduledStartDate,//תאריך תחילת העבודה על המשימה
    DateTime? startDate,//תאריך סיום אחרון אפשרי
    DateTime? deadLine,//תאריך סיום בפועל
    DateTime? completeDate,//
    string? product,
    string? remarks,
    int engineerId,
    EngineerExperience exp,
    TimeSpan RequiredTime,
    bool isActive = true
)
{
public Task():this(0,"","",true,DateTime.Now,null,null,null,null,"","",0, new EngineerExperience(), TimeSpan.Zero, true)
{
  
}
}


