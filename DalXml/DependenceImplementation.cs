using DalApi;
using DO;
using System.Xml.Linq;

namespace Dal;
internal class DependenceImplementation : IDependence
{
    const string dependencesFile = @"..\xml\dependences.xml";
    XDocument dependencesDocument = XDocument.Load(dependencesFile);//bring the xml file
    public int Create(Dependence item) //A function that create a new dependence.
    {
        int dependenceId = Config.NextDependenceId;
        XElement? dependenceElement = new XElement("Dependence",
            new XElement("DependenceId", dependenceId),
            new XElement("PendingTaskId", item.pendingTaskId),
            new XElement("PreviousTaskId", item.previousTaskId));
        dependencesDocument.Root?.Add(dependenceElement);
        dependencesDocument.Save(dependencesFile);
        
        return dependenceId;
    }

    public void Delete(int id)//A function that delete an exist dependence.
    {
        XElement? copyDep = dependencesDocument.Root
                ?.Elements("Dependence")
                .FirstOrDefault(dep => (int)dep.Element("DependenceId")! == id);

        if (copyDep == null)
        {
            throw new DalDeletionImpossible($"No dependence with this id");
        }
        else
        {
            copyDep.Remove();
            dependencesDocument.Save(dependencesFile);
        }
    }

    public Dependence? Read(int id)//A function that  display an exist dependence with an id
    {
        XElement? copyDep = dependencesDocument.Root
                ?.Elements("Dependence")
                .FirstOrDefault(d => (int)d.Element("DependenceId")! == id);
        if (copyDep != null)
        {
            Dependence? dep = new Dependence((int)copyDep.Element("DependenceId")!,
                (int)copyDep.Element("PendingTaskId")!,
                (int)copyDep.Element("PreviousTaskId")!);
            return dep;
        }
        else
        {
            throw new DalDeletionImpossible($"No dependence with this id");
        }
    }

    public Dependence? Read(Func<Dependence, bool> filter)//A function that update an exist dependence with a filter
    {
        Dependence? dep = dependencesDocument.Root?
     .Elements("Dependence")
     ?.Select(d => new Dependence(
         (int)d.Element("DependenceId")!,
         (int)d.Element("PendingTaskId")!,
         (int)d.Element("PreviousTaskId")!
     ))
     !.FirstOrDefault(filter);

        return dep;
    }

    public IEnumerable<Dependence?> ReadAll(Func<Dependence, bool>? filter = null)//display all the list with a filter
    {
        XElement? dependences = XMLTools.LoadListFromXMLElement("dependences");

        IEnumerable<Dependence> dependencesList = dependences
            .Elements("Dependence")
            .Select(e => new Dependence(
                dependenceId: (int)e.Element("DependenceId")!,
                pendingTaskId: (int)e.Element("PendingTaskId")!,
                previousTaskId: (int)e.Element("PreviousTaskId")!
            ));
        if (filter == null)
            return dependencesList.Select(item => item);
        else
            return dependencesList.Where(item => filter(item));
    }

    public void Update(Dependence item)//A function that update an exist dependence with an id
    {
        XElement? copyDep = dependencesDocument.Root
                ?.Elements("Dependence")
                .FirstOrDefault(dep => (int)dep.Element("DependenceId")! == item.dependenceId);
        if (copyDep != null)
        {
            copyDep.ReplaceWith(
            new XElement("Dependence",
            new XElement("DependenceId", item.dependenceId),
            new XElement("PendingTaskId", item.pendingTaskId),
            new XElement("PreviousTaskId", item.previousTaskId)));
            dependencesDocument.Save(dependencesFile);

        }
        else
        {
            throw new DalDoesNotExistException($"Dependence with ID={item.dependenceId} does not exist");
        }
    }

    public void Reset()//clear all the dependences
    {
        XElement? dependencesElements = dependencesDocument.Root;
        if(dependencesElements != null)
        {
            dependencesElements.Elements().Remove();
            dependencesDocument.Save(dependencesFile);
        }
    }
}
