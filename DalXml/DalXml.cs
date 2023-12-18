﻿using DalApi;
namespace Dal;

sealed public class DalXml : IDal
{
    public IEngineer Engineer => new EngineerImplementation();
    public ITask Task => new TaskImplementation();
    public IDependence Dependence => new DependenceImplementation();

    public void Reset()
    {
        Task.Reset();
        Dependence.Reset();
        Engineer.Reset();   
    }
}
