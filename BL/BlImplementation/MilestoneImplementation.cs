using BlApi;
using BO;
using DO;

namespace BlImplementation;

internal class MilestoneImplementation : IMilestone
{

    private DalApi.IDal _dal = Factory.Get;
    public Status CalculateStatus(DO.Task task)
    {
        // משימה שלא הוזמנה לביצוע
        if (task.scheduledStartDate == null && task.startDate == null && task.deadLine == null && task.completeDate == null)
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
        if (task.completeDate != null)
        {
            return Status.completed;
        }

        // סטטוס ברירת מחדל - אם לא נכנסנו לאף אחת מהתנאים הקודמים
        return Status.unscheduled;
    }
    //public int Create(List<Task> dependences)
    //{
    //}

    public int Create(Milestone mil)
    {
        throw new NotImplementedException();
    }

    public Milestone? Read(int id)
    {
        DO.Task? doTask = _dal.Task.Read(id) ?? throw new BO.BlDoesNotExistException($"Milestone with ID{id} does not exist");
        List<DO.Dependence> dependencies=new List<DO.Dependence>(_dal.Dependence.ReadAll(dep=>dep.dependenceId==id)!);
        List<BO.TaskInList> tasks=(from dep in dependencies 
                                         select new BO.TaskInList
                                         {
                                             status = CalculateStatus(_dal.Task.Read(dep.previousTaskId)!),
                                             taskId= _dal.Task.Read(dep.previousTaskId)!.taskId ,
                                             description= _dal.Task.Read(dep.previousTaskId)!.taskDescription,
                                             alias= _dal.Task.Read(dep.previousTaskId)!.alias,
                                         }).ToList();
            
        if (!doTask.milestone)
            throw new BO.BlDoesNotExistException($"Milestone with ID{id} does not exist");
        else
        {
            BO.Milestone milestone = new BO.Milestone()
            {
                milestoneId = id,
                description = doTask.taskDescription,
                alias = doTask.alias,
                createdAtDate = doTask.createdAtDate,
                status = CalculateStatus(doTask),
                startDate = doTask.startDate,
                forecastDate=doTask.startDate + doTask.RequiredTime,
                deadLine=doTask.deadLine,
                completeDate= doTask.completeDate,
                remarks=doTask.remarks,
                completionPercentage= (tasks.Count(task=>task.status==Status.onTrack)/(double) tasks.Count)*100,    
                dependencies= tasks,
            };
            return milestone;
        }
        
    }

    public void Update(Milestone mil)
    {
        if(Read(mil.milestoneId) == null)
            throw new BO.BlDoesNotExistException($"Milestone with ID{mil.milestoneId} does not exist");
        DO.Task? doTask = _dal.Task.Read(mil.milestoneId);
        DO.Task task = new DO.Task()
        {
            taskId = doTask!.taskId,
            taskDescription = mil.description,
            alias = mil.alias,
            milestone = doTask.milestone,
            createdAtDate = doTask.createdAtDate,
            scheduledStartDate = doTask.scheduledStartDate,
            startDate = doTask.startDate,
            deadLine = doTask.deadLine,
            completeDate = doTask.completeDate,
            product = doTask.product,
            remarks = mil.remarks,
            engineerId = doTask.engineerId,
            exp = doTask.exp,
            RequiredTime = doTask.RequiredTime,
        };
        _dal.Task.Update(task);
    }
}
