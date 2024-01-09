using BlApi;
using BO;

namespace BlImplementation;
internal class TaskImplementation : ITask
{
    private DalApi.IDal _dal = Factory.Get;
    public Status CalculateStatus(DO.Task task)
    {
        // משימה שלא הוזמנה לביצוע
        if (task.scheduledStartDate==null && task.startDate == null && task.deadLine == null && task.completeDate == null)
        {
            return Status.unscheduled;
        }

        // משימה שהוזמנה לביצוע אך עדיין לא התחילה
        if (task.startDate == null && DateTime.Now < task.scheduledStartDate)
        {
            return Status.scheduled;
        }

        // משימה שהוזמנה לביצוע וכבר התחילה
        if (task.startDate == null && DateTime.Now >= task.scheduledStartDate)
        {
            return Status.onTrack;
        }

        // משימה שהושלמה
        if (task.completeDate!=null)
        {
            return Status.completed;
        }

        // סטטוס ברירת מחדל - אם לא נכנסנו לאף אחת מהתנאים הקודמים
        return Status.unscheduled;
    }

    public int Create(BO.Task task)//A function that create a new Task.
    {
        bool isMilestone;
        if (task.milestone != null)
        {
            isMilestone = true;
        }
        else
        {
            isMilestone = false;
        }
        DO.Task doTask = new DO.Task(task.taskId, task.description, task.alias, isMilestone, task.createdAtDate, task.scheduledStartDate,
          task.startDate, task.deadLine, task.completeDate, task.deliverables, task.remarks, task.engineer.engineerId, DO.EngineerExperience.expert, TimeSpan.Zero);
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

    public void Delete(int id) //A function that delete an exist Task.
    {
        throw new NotImplementedException();
    }

    public BO.Task? Read(int id) //A function that  display an exist Task with an id
    {
        DO.Task? doTask = _dal.Task.Read(id);
        BO.MilestoneInTask? mil = null;
        if (doTask == null)
        {
            throw new BO.BlDoesNotExistException($"Student with ID={id} does Not exist");
        }
        if (doTask.milestone == true)
        {
            mil = new BO.MilestoneInTask()
            {
                id = doTask.taskId,
                alias = doTask.alias,
            };
        }
        else
        {
            mil = null;
        }
        return new BO.Task()
        {
            taskId = doTask.taskId,
            description = doTask.taskDescription,
            alias = doTask.alias,
            createdAtDate = doTask.createdAtDate,
            status = CalculateStatus(doTask),
            dependencies = null,
            milestone = mil,
            scheduledStartDate = doTask.scheduledStartDate,
            startDate = doTask.startDate,
            forecastDate = doTask.startDate + doTask.RequiredTime,
            deadLine = doTask.deadLine,
            completeDate = doTask.completeDate,
            deliverables = doTask.product,
            remarks = doTask.remarks,
            engineer = new BO.EngineerInTask()
            {
                engineerId = doTask.engineerId,
                name = _dal.Engineer.Read(doTask.engineerId)!.engineerName,
            },
            exp = (EngineerExperience)doTask.exp,
        };
    }
    public IEnumerable<BO.Task> ReadAll()//display all the list of tasks
    {
        return _dal.Task.ReadAll().Select(doTask => Read(doTask!.taskId)!).ToList();
    }

    //public IEnumerable<BO.Task> ReadAll() 
    //{
    //    List<BO.Task> tasksList = new List<BO.Task>();

    //    tasksList = from DO.Task doTask in _dal.Task.ReadAll()
    //                select new BO.Task
    //                {

    //                    taskId = doTask.taskId,
    //                    description = doTask.taskDescription,
    //                    alias = doTask.alias,
    //                    milestone = { doTask.milestone ? new BO.MilestoneInTask() { id = doTask.taskId, alias = doTask.alias } : null },
    //                    createdAtDate = doTask.createdAtDate,
    //                    scheduledStartDate = doTask.scheduledStartDate,
    //                    startDate = doTask.startDate,
    //                    deadLine = doTask.deadLine,
    //                    completeDate = doTask.completeDate,
    //                    deliverables = doTask.product,
    //                    remarks = doTask.remarks,
    //                    engineer = new BO.EngineerInTask()
    //                    {
    //                        engineerId = doTask.engineerId,
    //                        name = _dal.Engineer.Read(doTask.engineerId)!.engineerName,
    //                    },
    //                    exp = (EngineerExperience)doTask.exp,
    //                };
    //    return tasksList;
    //}

    public void Update(BO.Task task) //A function that update an exist Task with an id
    {
        bool isMilestone;
        if (task.milestone != null)
        {
            isMilestone = true;
        }
        else
        {
            isMilestone = false;
        }
        DO.Task doTask = new DO.Task(task.taskId, task.description, task.alias, isMilestone, task.createdAtDate, task.scheduledStartDate,
          task.startDate, task.deadLine, task.completeDate, task.deliverables, task.remarks, task.engineer.engineerId, DO.EngineerExperience.expert, TimeSpan.Zero);
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
