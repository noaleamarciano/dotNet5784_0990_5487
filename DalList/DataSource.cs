
namespace Dal;

internal static class DataSource
{

    internal static List<DO.Dependence> Dependences { get; } = new();//List of dependences
    internal static List<DO.Engineer> Engineers { get; } = new();//List of engineers
    internal static List<DO.Task> Tasks { get; } = new();//List of tasks
    internal static class Config//A class that do an automatic id
    {
        internal const int startDependenceId = 1000;
        private static int nextDependenceId = startDependenceId;
        internal static int NextDependenceId { get => nextDependenceId++; }

        internal const int startTaskId = 1000;
        private static int nextTaskId = startTaskId;
        internal static int NextTaskId { get => nextTaskId++; }
    }
}
