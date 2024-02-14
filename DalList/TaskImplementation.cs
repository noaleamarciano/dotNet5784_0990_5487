
namespace Dal;
using DalApi;
using DO;
using System.Collections.Generic;

internal class TaskImplementation : ITask
{
    public int Create(Task item)  //A function that create a new Task.
    {
        int newId = DataSource.Config.NextDependenceId;
        Task copyItem = item with { taskId = newId };
        DataSource.Tasks.Add(copyItem);
        return newId;
    }

    public Task? Read(int id) //A function that  display an exist Task with an id
    {
        return DataSource.Tasks.FirstOrDefault(dep => dep.taskId == id);
    }
    public Task? Read(Func<Task, bool> filter)//A function that display an exist dependence with a filter
    {
        return DataSource.Tasks.FirstOrDefault(d => filter(d));
    }
    public IEnumerable<Task?> ReadAll(Func<Task, bool>? filter = null) //display all the list with a filter
    {
        if (filter == null)
            return DataSource.Tasks.Select(item => item);
        else
            return DataSource.Tasks.Where(item=>filter(item));
    }

    public void Update(Task item) //A function that update an exist Task with an id
    {
        Task? copyTa = DataSource.Tasks.FirstOrDefault(ta => ta.taskId == item.taskId);
        if (copyTa != null)
        {
            DataSource.Tasks.Remove(copyTa);
            DataSource.Tasks.Add(item);
        }
        else
        {
            throw new DalDoesNotExistException($"Task with ID={item.taskId} does not exist");
        }
    }

    public void Reset() //clear all the tasks
    {
        if (DataSource.Tasks.Count > 0)
        {
            DataSource.Tasks.Clear();
        }
    }
}
