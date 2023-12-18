using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks; 

namespace Dal;
using DalApi;
sealed public class DalList : IDal
{
    public IEngineer Engineer => new EngineerImplementation();

    public ITask Task => new TaskImplementation();

    public IDependence Dependence =>  new DependenceImplementation();

    public void Reset()
    {
        Task.Reset();
        Engineer.Reset();
        Dependence.Reset();
    }
}



