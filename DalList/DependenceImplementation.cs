

namespace Dal;
using DalApi;
using DO;
using System.Data.Common;

//using System.Collections.Generic;

public class DependenceImplementation : IDependence
{
    //public class T
    public int Create(Dependence item)
    {
        int newId = DataSource.Config.NextDependenceId;
        Dependence copyItem =item with { dependenceId= newId };
        DataSource.Dependences.Add(copyItem);
        return newId;
    }

    public void Delete(int id)
    {
        throw new NotImplementedException();
    }

    public Dependence? Read(int id)
    {
        return DataSource.Dependences.Find(dep => dep.dependenceId == id);
      
    }

    public List<Dependence> ReadAll()
    {
        throw new NotImplementedException();
    }

    public void Update(Dependence item)
    {
        throw new NotImplementedException();
    }
}
