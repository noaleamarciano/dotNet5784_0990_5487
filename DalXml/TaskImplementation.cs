

using DalApi;
using DO;
using System.Diagnostics;

namespace Dal;

internal class TaskImplementation : ITask
{
    public int Create(DO.Task item)//A function that create a new Task.
    {
        List<DO.Task> taskList = XMLTools.LoadListFromXMLSerializer<DO.Task>("tasks");
        int newId = Config.NextTaskId;
        DO.Task copyItem = item with { taskId = newId };
        taskList.Add(copyItem);
        XMLTools.SaveListToXMLSerializer<DO.Task>(taskList, "tasks");
        return newId;
    }

    public DO.Task? Read(int id)//A function that  display an exist Task with an id
    {
        List<DO.Task> taskList = XMLTools.LoadListFromXMLSerializer<DO.Task>("tasks");
        return taskList.FirstOrDefault(dep => dep.taskId == id);
    }

    public DO.Task? Read(Func<DO.Task, bool> filter)//A function that display an exist task with a filter
    {
        List<DO.Task> taskList = XMLTools.LoadListFromXMLSerializer<DO.Task>("tasks");
        return taskList.FirstOrDefault(d => filter(d));
    }

    public IEnumerable<DO.Task?> ReadAll(Func<DO.Task, bool>? filter = null)//display all the list with a filter
    {
        List<DO.Task> taskList = XMLTools.LoadListFromXMLSerializer<DO.Task>("tasks");
        if (filter == null)
            return taskList.Select(item => item);
        else
            return taskList.Where(item => filter(item));
    }

    public void Update(DO.Task item)//A function that update an exist Task with an id
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
    public void Reset()//clear all the tasks
    {
        List<DO.Task> taskList = XMLTools.LoadListFromXMLSerializer<DO.Task>("tasks");
        if(taskList.Count > 0) 
        {
            taskList.Clear();
            XMLTools.SaveListToXMLSerializer<DO.Task>(taskList, "tasks");
        }
    }
}
