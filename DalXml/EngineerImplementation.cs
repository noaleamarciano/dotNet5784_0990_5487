using DalApi;
using DO;
namespace Dal;

internal class EngineerImplementation : IEngineer
{
    public int Create(Engineer item)
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

    public void Delete(int id)
    {
       throw new DalDeletionImpossible("Its impossible to delete this engineer");
        //List<Engineer> engineerList = XMLTools.LoadListFromXMLSerializer<Engineer>("engineers");
        //List<DO.Task> taskList = XMLTools.LoadListFromXMLSerializer<DO.Task>("tasks");
        //if (taskList.FirstOrDefault(ta => ta.engineerId == id) == null)
        //{
        //    throw new DalDeletionImpossible("Its impossible to delete this engineer");
        //}
        //else
        //{
        //    Engineer? copyEng = engineerList.FirstOrDefault(eng => eng.engineerId == id);
        //    if (copyEng != null)
        //    {
        //        engineerList.Remove(copyEng);
        //        XMLTools.SaveListToXMLSerializer<Engineer>(engineerList, "engineers");
        //    }
        //    else
        //    {
        //        throw new DalDeletionImpossible("Can not delete the engineer");
        //    }
        //}
    }

    public Engineer? Read(int id)
    {
        List<Engineer> engineerList = XMLTools.LoadListFromXMLSerializer<Engineer>("engineers");
        return engineerList.FirstOrDefault(eng => eng.engineerId == id);
    }

    public Engineer? Read(Func<Engineer, bool> filter)
    {
        List<Engineer> engineerList = XMLTools.LoadListFromXMLSerializer<Engineer>("engineers");
        return engineerList.FirstOrDefault(d => filter(d));
    }

    public IEnumerable<Engineer?> ReadAll(Func<Engineer, bool>? filter = null)
    {
        List<Engineer> engineerList = XMLTools.LoadListFromXMLSerializer<Engineer>("engineers");
        if (filter == null)
            return engineerList.Select(item => item);
        else
            return engineerList.Where(item => filter(item));
    }

    public void Update(Engineer item)
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
}
