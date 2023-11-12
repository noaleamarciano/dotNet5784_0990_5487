
namespace Dal;
using DalApi;
using DO;
using System.Collections.Generic;

public class EngineerImplementation : IEngineer
{
    public int Create(Engineer item)
    {
        if (DataSource.Engineers.Find(eng => eng.engineerId == item.engineerId) == null)
        {
            DataSource.Engineers.Add(item);
            return item.engineerId;
        }
        else
        {
            throw new Exception("אובייקט מסוג Engineer עם ID כזה כבר קיים");//to check
        }
    }

    public void Delete(int id)
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
                throw new Exception("אובייקט מסוג Engineer עם ID כזה כבר קיים");//to check
            }
        }
    }

    public Engineer? Read(int id)
    {
        return DataSource.Engineers.Find(eng => eng.engineerId == id);
    }

    public List<Engineer> ReadAll()
    {
        List<Engineer> copyEngineer = DataSource.Engineers;
        return copyEngineer;
    }

    public void Update(Engineer item)
    {
        Engineer? copyEng = DataSource.Engineers.Find(eng => eng.engineerId == item.engineerId);//לברר!!!!!!!!!!!
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
