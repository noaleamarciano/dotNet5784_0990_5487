
namespace DO;
/// <summary>
/// dependence entity represents a dependence with all its properties.
/// </summary>
/// <param name="dependenceId">Personal unique key of a dependence.</param>
/// <param name="pendingTaskId">Personal unique id for a pending task.</param>
/// <param name="previousTaskId">Personal unique id for a previous task.</param>
public record Dependence
(
    int dependenceId,
    int pendingTaskId,
    int previousTaskId
);
