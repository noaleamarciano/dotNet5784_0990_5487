
namespace Dal;
using DalApi;
using DO;
using System.Collections.Generic;

public class EngineerImplementation : IEngineer
{
    public int Create(Engineer item) //A function that create a new Engineer.
    {
        if (DataSource.Engineers.Find(eng => eng.engineerId == item.engineerId) == null)
        {
            DataSource.Engineers.Add(item);
            return item.engineerId;
        }
        else
        {
            throw new Exception("אובייקט מסוג Engineer עם ID כזה כבר קיים");
        }
    }

    public void Delete(int id) //A function that delete an exist Engineer.
    {
        if (DataSource.Tasks.Find(ta => ta.engineerId == id) == null)
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

    public Engineer? Read(int id) //A function that  display an exist Engineer with an id
    {
        return DataSource.Engineers.Find(eng => eng.engineerId == id);
    }

    public List<Engineer> ReadAll() //A function that display all the Engineers
    {
        List<Engineer> copyEngineer = DataSource.Engineers;
        return copyEngineer;
    }

    public void Update(Engineer item) //A function that update an exist Engineer with an id
    {
        Engineer? copyEng = DataSource.Engineers.Find(eng => eng.engineerId == item.engineerId);
        if (copyEng != null)
        {
            DataSource.Engineers.Remove(copyEng);
            DataSource.Engineers.Add(item);
        }
        else
        {
            throw new Exception("אובייקט מסוג Engineer עם ID כזה לא קיים");
        }
    }
}