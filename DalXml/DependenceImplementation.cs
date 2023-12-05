

using DalApi;
using DO;

namespace Dal;

internal class DependenceImplementation : IDependence
{
    public int Create(Dependence item)
    {
        List<Dependence> dependenceList = XMLTools.LoadListFromXMLSerializer<Dependence>("dependences");
        dependenceList.Add(item);
        XMLTools.SaveListToXMLSerializer<Dependence>(dependenceList, "dependences");
        return item.dependenceId;





    }

    public void Delete(int id)
    {

        List<Dependence> dependenceList = XMLTools.LoadListFromXMLSerializer<Dependence>("dependences");
        Dependence? copyDep = dependenceList.FirstOrDefault(dep => dep.dependenceId == id);
        if (copyDep != null)
        {
            throw new DalDeletionImpossible($"No dependence with ID={copyDep.dependenceId}");
        }
        else
        {
            dependenceList.Remove(copyDep!);
            XMLTools.SaveListToXMLSerializer<Dependence>(dependenceList, "dependences");
        }
    }

    public Dependence? Read(int id)
    {
        List<Dependence> dependenceList = XMLTools.LoadListFromXMLSerializer<Dependence>("dependences");
        return dependenceList.FirstOrDefault(dep => dep.dependenceId == id);
    }

    public Dependence? Read(Func<Dependence, bool> filter)
    {
        List<Dependence> dependenceList = XMLTools.LoadListFromXMLSerializer<Dependence>("dependences");
        return dependenceList.FirstOrDefault(d => filter(d));
    }

    public IEnumerable<Dependence?> ReadAll(Func<Dependence, bool>? filter = null)
    {
        List<Dependence> dependenceList = XMLTools.LoadListFromXMLSerializer<Dependence>("dependences");
        if (filter == null)
            return dependenceList.Select(item => item);
        else
            return dependenceList.Where(item => filter(item));
    }

    public void Update(Dependence item)
    {
        List<Dependence> dependenceList = XMLTools.LoadListFromXMLSerializer<Dependence>("dependences");
        Dependence? copyDep = dependenceList.FirstOrDefault(dep => dep.dependenceId == item.dependenceId);
        if (copyDep != null)
        {
            dependenceList.Remove(copyDep);
            dependenceList.Add(item);
            XMLTools.SaveListToXMLSerializer<Dependence>(dependenceList, "dependences");
        }
        else
        {
            throw new DalDoesNotExistException($"Dependence with ID={item.dependenceId} does not exist");
        }
    }
}
