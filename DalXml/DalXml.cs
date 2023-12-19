using DalApi;
using System.Diagnostics;

namespace Dal;

sealed internal class DalXml : IDal
{
    public static IDal Instance { get; } = new DalXml();
    private DalXml() { }

    public IEngineer Engineer => new EngineerImplementation();
    public ITask Task => new TaskImplementation();
    public IDependence Dependence => new DependenceImplementation();

    public void Reset()//A function that clear all the data
    {
        Task.Reset();
        Dependence.Reset();
        Engineer.Reset();
    }
    public DateTime? projectBegining => Config.projectBegining;
    public DateTime? projectFinishing => Config.projectFinishing;
}
