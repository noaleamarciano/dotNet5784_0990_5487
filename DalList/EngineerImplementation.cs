
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
            throw new Exception("אובייקט מסוג Engineer עם ID כזה כבר קיים");
        }
    }

    public void Delete(int id) //A function that delete an exist Engineer.
    {
        if (DataSource.Tasks.FirstOrDefault(ta => ta.engineerId == id) == null)
        {
            throw new Exception("לא ניתן למחוק את האובייקט");
        }
        else
        {
            Engineer? copyEng = DataSource.Engineers.FirstOrDefault(eng => eng.engineerId == id);
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
        return DataSource.Engineers.FirstOrDefault(eng => eng.engineerId == id);
    }

    public IEnumerable<Engineer?> ReadAll(Func<Engineer?, bool>? filter = null) //stage 2
    {
        if (filter == null)
            return DataSource.Engineers.Select(item => item);
        else
            return DataSource.Engineers.Where(filter);
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
            throw new Exception("אובייקט מסוג Engineer עם ID כזה לא קיים");
        }
    }
}