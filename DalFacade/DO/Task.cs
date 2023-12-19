
namespace DO;
/// <summary>
/// task entity represents a task with all its propreties.
/// </summary>
/// <param name="taskId">Personal unique key of task.</param>
/// <param name="alias">an alias for the task</param>
/// <param name="milestone">יש להסביר</param>
/// <param name="productionDate">the date of the production</param>
/// <param name="startDate">the date that the task start</param>
/// <param name="estimComplete">an estimated date for completing the task</param>
/// <param name="finalDate">the final date for the task</param>
/// <param name="complete">Actual end date of the task</param>
/// <param name="product">a string describing the product</param>
/// <param name="remarks">remarks about the task</param>
/// <param name="engineerId">personal unique id for the  engineer</param>
public record Task
(
    int taskId,
    string taskDescription,
    string alias,
    bool milestone,
    DateTime productionDate,//תאריך מתוכנן לתחילת העבודה
    DateTime? startDate,//תאריך תחילת העבודה על המשימה
    DateTime? estimComplete,//תאריך סיום אחרון אפשרי
    DateTime? finalDate,//תאריך סיום בפועל
    DateTime? complete,
    string? product,
    string? remarks,

    int engineerId,
    EngineerExperience exp,
    //TimeSpan RequiredTime,
    bool isActive = true
)
{
public Task():this(0,"","",true,DateTime.Now,null,null,null,null,"","",0, new EngineerExperience()/*,TimeSpan.Zero*/,true)
{
  
}
}


