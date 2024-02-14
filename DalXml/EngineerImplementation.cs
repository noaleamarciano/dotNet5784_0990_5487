using DalApi;
using DO;
namespace Dal;

internal class EngineerImplementation : IEngineer
{
    public int Create(Engineer item)//A function that create a new Engineer.
    {
        List<Engineer> engineerList = XMLTools.LoadListFromXMLSerializer<Engineer>("engineers");
        if (engineerList.FirstOrDefault(eng => eng.engineerId == item.engineerId) == null)
        {
            engineerList.Add(item);
            XMLTools.SaveListToXMLSerializer<Engineer>(engineerList, "engineers");
            return item.engineerId;
        }
        else
        {
            throw new DalAlreadyExistsException($"engineer with ID={item.engineerId} already exist");
        }
    }

    public Engineer? Read(int id)//A function that  display an exist Engineer with an id
    {
        List<Engineer> engineerList = XMLTools.LoadListFromXMLSerializer<Engineer>("engineers");
        return engineerList.FirstOrDefault(eng => eng.engineerId == id);
    }

    public Engineer? Read(Func<Engineer, bool> filter)//A function that display an exist engineer with a filter
    {
        List<Engineer> engineerList = XMLTools.LoadListFromXMLSerializer<Engineer>("engineers");
        return engineerList.FirstOrDefault(d => filter(d));
    }

    public IEnumerable<Engineer?> ReadAll(Func<Engineer, bool>? filter = null)//display all the list with a filter
    {
        List<Engineer> engineerList = XMLTools.LoadListFromXMLSerializer<Engineer>("engineers");
        if (filter == null)
            return engineerList.Select(item => item);
        else
            return engineerList.Where(item => filter(item));
    }

    public void Update(Engineer item) //A function that update an exist Engineer with an id
    {
        List<Engineer> engineerList = XMLTools.LoadListFromXMLSerializer<Engineer>("engineers");
        Engineer? copyEng = engineerList.FirstOrDefault(eng => eng.engineerId == item.engineerId);
        if (copyEng != null)
        {
            engineerList.Remove(copyEng);
            engineerList.Add(item);
            XMLTools.SaveListToXMLSerializer<Engineer>(engineerList, "engineers");
        }
        else
        {
            throw new DalDoesNotExistException($"Engineer with ID={item.engineerId} does not exist");
        }
    }

    public void Reset()//clear all the engineers
    {
        List<Engineer> engineerList = XMLTools.LoadListFromXMLSerializer<Engineer>("engineers");
        if(engineerList.Count > 0)
        {
            engineerList.Clear();
            XMLTools.SaveListToXMLSerializer<Engineer>(engineerList, "engineers");
        }
    }
}
