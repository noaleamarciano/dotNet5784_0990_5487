

namespace Dal;
using DalApi;
using DO;
using System.Data.Common;

internal class DependenceImplementation : IDependence
{
    public int Create(Dependence item) //A function that create a new dependence.
    {
        int newId = DataSource.Config.NextDependenceId;
        Dependence copyItem = item with { dependenceId = newId };
        DataSource.Dependences.Add(copyItem);
        return newId;
    }

    public void Delete(int id) //A function that delete an exist dependence.
    {
        Dependence? copyDep = DataSource.Dependences.FirstOrDefault(dep => dep.dependenceId == id);
        if (copyDep != null)
        {
            DataSource.Dependences.Remove(copyDep!);
        }
        else
        { 
            throw new DalDeletionImpossible($"No dependence with ID={copyDep!.dependenceId}");
        }
    }

    public Dependence? Read(int id) //A function that  display an exist dependence with an id
    {
        return DataSource.Dependences.FirstOrDefault(dep => dep.dependenceId == id);
    }

    public Dependence? Read(Func<Dependence, bool> filter)//A function that update an exist dependence with a filter
    {
        return DataSource.Dependences.FirstOrDefault(d => filter(d));
    }
    public IEnumerable<Dependence?> ReadAll(Func<Dependence, bool>? filter = null) //display all the list with a filter
    {
        if (filter == null)
            return DataSource.Dependences.Select(item => item);
        else
            return DataSource.Dependences.Where(item=>filter(item));
    }

    public void Update(Dependence item) //A function that update an exist dependence with an id
    {
        Dependence? copyDep = DataSource.Dependences.FirstOrDefault(dep => dep.dependenceId == item.dependenceId);
        if (copyDep != null)
        {
            DataSource.Dependences.Remove(copyDep);
            DataSource.Dependences.Add(item);
        }
        else
        {
            throw new DalDoesNotExistException($"Dependence with ID={item.dependenceId} does not exist");
        }
    }

    public void Reset()//clear all the dependences
    {
        if( DataSource.Dependences.Count>0)
        {
            DataSource.Dependences.Clear();
        }
       
    }
}
