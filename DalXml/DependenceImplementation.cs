using DalApi;
using DO;
using System.Xml.Linq;

namespace Dal;
internal class DependenceImplementation : IDependence
{
    const string dependencesFile = @"..\xml\dependences.xml";
    XDocument dependencesDocument = XDocument.Load(dependencesFile);
    public int Create(Dependence item)
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

    public void Delete(int id)
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

    public Dependence? Read(int id)
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

    public Dependence? Read(Func<Dependence, bool> filter)
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

    public IEnumerable<Dependence?> ReadAll(Func<Dependence, bool>? filter = null)
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

    public void Update(Dependence item)
    {
        XElement? copyDep = dependencesDocument.Root
                ?.Elements("Dependence")
                .FirstOrDefault(dep => (int)dep.Element("DependenceId")! == item.dependenceId);
        if (copyDep != null)
        {
            //copyDep.Remove();
            //dependencesDocument.Add(item);
            //dependencesDocument.Save(dependencesFile);
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

    public void Reset()
    {

    }
}
