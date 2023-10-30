
namespace DO;
/// <summary>
/// dependense entity represents a dependense with all its propreties.
/// </summary>
/// <param name="dependenceId">Personal unique key of a dependense.</param>
/// <param name="pendingTaskId">Personal unique id for a pending task.</param>
/// <param name="previousTaskId">Personal unique id for aprevious task.</param>
public record Dependence
{
    public
    int dependenceId;
    int pendingTaskId;
    int previousTaskId;
}
