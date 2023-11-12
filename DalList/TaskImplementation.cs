
namespace Dal;
using DalApi;
using DO;
using System.Collections.Generic;

public class TaskImplementation : ITask
{
    public int Create(Task item)
    {
        int newId = DataSource.Config.NextDependenceId;
        Task copyItem = item with { taskId = newId };
        DataSource.Tasks.Add(copyItem);
        return newId;
    }

    public void Delete(int id)
    {
        if (DataSource.Dependences.Find(dep => dep.pendingTaskId == id) == null)
        {
            throw new Exception("לא ניתן למחוק את האובייקט");
        }
        else
        {
            Task? copyDep2 = DataSource.Tasks.Find(ta => ta.taskId == id);
            Dependence? copyDep = DataSource.Dependences.Find(dep => dep.pendingTaskId == id);
            if (copyDep2 != null)
            {
                DataSource.Tasks.Remove(copyDep2);
                DataSource.Dependences.Remove(copyDep);
            }
            else
            {
                throw new Exception("אובייקט מסוג Engineer עם ID כזה כבר קיים");//to check
            }

        }
    }

    public Task? Read(int id)
    {
        return DataSource.Tasks.Find(dep => dep.taskId == id);
    }

    public List<Task> ReadAll()
    {
        List<Task> copyTasks = DataSource.Tasks;
        return copyTasks;
    }

    public void Update(Task item)
    {
        Task? copyTa = DataSource.Tasks.Find(ta => ta.taskId == item.taskId);//לברר!!!!!!!!!!!
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
