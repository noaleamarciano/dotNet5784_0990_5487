
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

    public void Delete(int id) //A function that delete an exist Task.
    {
        if (DataSource.Dependences.FirstOrDefault(dep => dep.previousTaskId == id) != null)
        {
            throw new Exception("לא ניתן למחוק את האובייקט");
        }
        else
        {
            Task? copyDep2 = DataSource.Tasks.FirstOrDefault(ta => ta.taskId == id);
            Dependence? copyDep = DataSource.Dependences.FirstOrDefault(dep => dep.pendingTaskId == id);
            if (copyDep2 != null)
            {
                DataSource.Tasks.Remove(copyDep2);
                DataSource.Dependences.Remove(copyDep);
            }
            else
            {
                throw new Exception("אובייקט מסוג Engineer עם ID כזה כבר קיים");
            }

        }
    }

    public Task? Read(int id) //A function that  display an exist Task with an id
    {
        return DataSource.Tasks.FirstOrDefault(dep => dep.taskId == id);
    }

    public IEnumerable<Task?> ReadAll(Func<Task?, bool>? filter = null) //stage 2
    {
        if (filter == null)
            return DataSource.Tasks.Select(item => item);
        else
            return DataSource.Tasks.Where(filter);
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
            throw new Exception("אובייקט מסוג Tasks עם ID כזה לא קיים");
        }
    }
}
