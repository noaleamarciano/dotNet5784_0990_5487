

using DalApi;
using DO;
using System.Diagnostics;

namespace Dal;

internal class TaskImplementation : ITask
{
    public int Create(DO.Task item)
    {
        List<DO.Task> taskList = XMLTools.LoadListFromXMLSerializer<DO.Task>("tasks");
        int newId = Config.NextTaskId;
        DO.Task copyItem = item with { taskId = newId };
        taskList.Add(copyItem);
        XMLTools.SaveListToXMLSerializer<DO.Task>(taskList, "tasks");
        return newId;
    }

    public void Delete(int id)
    {
        throw new DalDeletionImpossible("Its impossible to delete this task");
        //List<DO.Task> taskList = XMLTools.LoadListFromXMLSerializer<DO.Task>("tasks");
        //List<Dependence> dependenceList = XMLTools.LoadListFromXMLSerializer<Dependence>("dependences");

        //if (dependenceList.FirstOrDefault(dep => dep.previousTaskId == id) != null)
        //{
        //    throw new DalDeletionImpossible("Its impossible to delete this task");
        //}
        //else
        //{
        //    DO.Task? copyTask = taskList.FirstOrDefault(ta => ta.taskId == id);
        //    Dependence? copyDep = dependenceList.FirstOrDefault(dep => dep.pendingTaskId == id);
        //    if (copyTask != null)
        //    {
        //        taskList.Remove(copyTask);
        //        XMLTools.SaveListToXMLSerializer<DO.Task>(taskList, "tasks");
        //    }
        //    else
        //    {
        //        throw new DalDeletionImpossible($"No task with ID={copyTask?.engineerId}");
        //    }

        //}
    }

    public DO.Task? Read(int id)
    {
        List<DO.Task> taskList = XMLTools.LoadListFromXMLSerializer<DO.Task>("tasks");
        return taskList.FirstOrDefault(dep => dep.taskId == id);
    }

    public DO.Task? Read(Func<DO.Task, bool> filter)
    {
        List<DO.Task> taskList = XMLTools.LoadListFromXMLSerializer<DO.Task>("tasks");
        return taskList.FirstOrDefault(d => filter(d));
    }

    public IEnumerable<DO.Task?> ReadAll(Func<DO.Task, bool>? filter = null)
    {
        List<DO.Task> taskList = XMLTools.LoadListFromXMLSerializer<DO.Task>("tasks");
        if (filter == null)
            return taskList.Select(item => item);
        else
            return taskList.Where(item => filter(item));
    }

    public void Update(DO.Task item)
    {
        List<DO.Task> taskList = XMLTools.LoadListFromXMLSerializer<DO.Task>("tasks");
        DO.Task? copyTa = taskList.FirstOrDefault(ta => ta.taskId == item.taskId);
        if (copyTa != null)
        {
            taskList.Remove(copyTa);
            taskList.Add(item);
            XMLTools.SaveListToXMLSerializer<DO.Task>(taskList, "tasks");
        }
        else
        {
            throw new DalDoesNotExistException($"Task with ID={item.taskId} does not exist");
        }
    }
    public void Reset()
    {

    }
}
