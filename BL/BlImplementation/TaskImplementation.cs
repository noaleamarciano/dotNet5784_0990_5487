using BlApi;
using BO;

namespace BlImplementation;
internal class TaskImplementation : ITask
{
    private DalApi.IDal _dal = Factory.Get;
    
    public int Create(BO.Task task)
    {
      DO.Task doTask = new DO.Task(task.taskId, task.description, task.alias, /*task.milestone,*/ task.createdAtDate, task.scheduledStartDate, 
          task.startDate, task.deadLine, task.completeDate, task.deliverables, task.remarks, task.engineer, DO.EngineerExperience.expert);
        try
        {
            int idTask = _dal.Task.Create(doTask);
            return idTask;
        }
        catch (DO.DalAlreadyExistsException ex)
        {
            //throw bl exception
            throw new Exception();
        }
    }

    public void Delete(int id)
    {
        throw new NotImplementedException();
    }

    public BO.Task? Read(int id)
    {
        DO.Task? doTask = _dal.Task.Read(id);
        if (doTask == null)
        {
            throw new BO.BlDoesNotExistException($"Student with ID={id} does Not exist");
        }
        return new BO.Task()
        {
            taskId = doTask.taskId,
            description = doTask.taskDescription,
            alias = doTask.alias, 
            /*milestone = doTask.milestone, */
            createdAtDate = doTask.createdAtDate,
            scheduledStartDate = doTask.scheduledStartDate,
            startDate = doTask.startDate,
            deadLine = doTask.deadLine,
            completeDate = doTask.completeDate,
            deliverables = doTask.product,
            remarks = doTask.remarks,
            engineer = doTask.engineerId,
            exp = (EngineerExperience)doTask.exp,
        };
    }

    public IEnumerable<BO.Task> ReadAll()
    {
        return (from DO.Task doTask in _dal.Engineer.ReadAll()
                select new BO.Task
                {
                    taskId = doTask.taskId,
                    description = doTask.taskDescription,
                    alias = doTask.alias,
                    /*milestone = doTask.milestone, */
                    createdAtDate = doTask.createdAtDate,
                    scheduledStartDate = doTask.scheduledStartDate,
                    startDate = doTask.startDate,
                    deadLine = doTask.deadLine,
                    completeDate = doTask.completeDate,
                    deliverables = doTask.product,
                    remarks = doTask.remarks,
                    engineer = doTask.engineerId,
                    exp = (EngineerExperience)doTask.exp,
                    //task = new TaskInEngineer()
                    //{
                    //    id = _dal.Task.ReadAll().FirstOrDefault(task => task?.taskId == doEngineer.engineerId)!.engineerId,
                    //    alias = _dal.Task.ReadAll().FirstOrDefault(task => task?.taskId == doEngineer.engineerId)!.alias
                    //}
                });
    }

    public void Update(BO.Task task)
    {
        DO.Task doTask = new DO.Task(task.taskId, task.description, task.alias, /*task.milestone,*/ task.createdAtDate, task.scheduledStartDate,
          task.startDate, task.deadLine, task.completeDate, task.deliverables, task.remarks, task.engineer, DO.EngineerExperience.expert);
        try
        {
            _dal.Task.Update(doTask);
        }
        catch (DO.DalAlreadyExistsException ex)
        {
            //throw bl exception
            throw new Exception();
        }
    }
}
