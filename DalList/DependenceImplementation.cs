

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
                throw new Exception("אובייקט מסוג Engineer עם ID כזה כבר קיים");//to check
            }
        }
    }

    public Dependence? Read(int id)
    {
        return DataSource.Dependences.Find(dep => dep.dependenceId == id);
    }

    public List<Dependence> ReadAll()
    {
        List<Dependence>copyDependences = DataSource.Dependences;
        return copyDependences;
    }

    public void Update(Dependence item)
    {
        Dependence? copyDep = DataSource.Dependences.Find(dep => dep.dependenceId == item.dependenceId);//לברר!!!!!!!!!!!
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
