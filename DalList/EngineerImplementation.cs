
namespace Dal;
using DalApi;
using DO;
using System.Collections.Generic;

internal class EngineerImplementation : IEngineer
{
    public int Create(Engineer item) //A function that create a new Engineer.
    {
        if (DataSource.Engineers.FirstOrDefault(eng => eng.engineerId == item.engineerId) == null)
        {
            DataSource.Engineers.Add(item);
            return item.engineerId;
        }
        else
        {
            throw new DalAlreadyExistsException($"engineer with ID={item.engineerId} already exist");
        }
    }

    public Engineer? Read(int id) //A function that  display an exist Engineer with an id
    {
        return DataSource.Engineers.FirstOrDefault(eng => eng.engineerId == id);
    }
    public Engineer? Read(Func<Engineer, bool> filter)//A function that display an exist dependence with a filter
    {
        return DataSource.Engineers.FirstOrDefault(d => filter(d));
    }
    public IEnumerable<Engineer?> ReadAll(Func<Engineer, bool>? filter = null)//display all the list with a filter
    {
        if (filter == null)
            return DataSource.Engineers.Select(item => item);
        else
            return DataSource.Engineers.Where(item => filter(item));
    }

    public void Update(Engineer item) //A function that update an exist Engineer with an id
    {
        Engineer? copyEng = DataSource.Engineers.FirstOrDefault(eng => eng.engineerId == item.engineerId);
        if (copyEng != null)
        {
            DataSource.Engineers.Remove(copyEng);
            DataSource.Engineers.Add(item);
        }
        else
        {
            throw new DalDoesNotExistException($"Engineer with ID={item.engineerId} does not exist");
        }
    }

    public void Reset()//clear all the engineers
    {
        if (DataSource.Engineers.Count > 0)
        {
            DataSource.Engineers.Clear();
        }
       
    }
}