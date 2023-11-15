

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
        if (DataSource.Tasks.Find(ta => ta.engineerId == id) != null)
        {
            throw new Exception("לא ניתן למחוק את האובייקט");
        }
        else
        {
            Engineer? copyEng = DataSource.Engineers.Find(eng => eng.engineerId == id);
            if (copyEng != null)
            {
                DataSource.Engineers.Remove(copyEng);
            }
            else
            {
                throw new Exception("אובייקט מסוג Engineer עם ID כזה כבר קיים");
            }
        }
    }

    public Dependence? Read(int id) //A function that  display an exist dependence with an id
    {
        return DataSource.Dependences.Find(dep => dep.dependenceId == id);
    }

    public List<Dependence> ReadAll() //A function that display all the dependences
    {
        List<Dependence> copyDependences = DataSource.Dependences;
        return copyDependences;
    }

    public void Update(Dependence item) //A function that update an exist dependence with an id
    {
        Dependence? copyDep = DataSource.Dependences.Find(dep => dep.dependenceId == item.dependenceId);
        if (copyDep != null)
        {
            DataSource.Dependences.Remove(copyDep);
            DataSource.Dependences.Add(item);
        }
        else
        {
            throw new Exception("אובייקט מסוג Dependence עם ID כזה לא קיים");
        }
    }
}
