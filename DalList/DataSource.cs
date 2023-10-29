

namespace Dal;

internal static class DataSource
{

    internal static List<DO.Dependence> Dependences { get; } = new();
    internal static List<DO.Engineer> Engineers { get; } = new();
    internal static List<DO.Task> Tasks { get; } = new();
    internal static class Config
    {
        internal const int startDependenceId = 1000;//להחליף מספר
        private static int nextDependenceId = startDependenceId;
        internal static int NextDependenceId { get => nextDependenceId++; }

        internal const int startTaskId = 1000;//להחליף מספר
        private static int nextTaskId = startTaskId;
        internal static int NextTaskId { get => nextTaskId++; }

    }
}
