using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks; 

namespace Dal;
using DalApi;
using static Dal.DataSource;

sealed internal class DalList : IDal
{
    public static IDal Instance { get; } = new DalList();
    private DalList() { }

    public IEngineer Engineer => new EngineerImplementation();

    public ITask Task => new TaskImplementation();

    public IDependence Dependence =>  new DependenceImplementation();

    public DateTime? projectBegining => Config.projectBegining; 
    public DateTime? projectFinishing => Config.projectFinishing;
    public void Reset() //clear all the data
    {
        Task.Reset();
        Engineer.Reset();
        Dependence.Reset();
    }

}



