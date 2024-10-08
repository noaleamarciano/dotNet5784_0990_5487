﻿using BlApi;
using BO;
using DalApi;
using DO;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.Arm;
using System.Threading.Tasks;

namespace BlImplementation;
internal class TaskImplementation : BlApi.ITask
{
    private DalApi.IDal _dal = Factory.Get;
    public List<TaskInList> calculateDependenciesList(int id) //Calculate all the dependenciesof the current task
    {
        List<BO.TaskInList> taskInList = new List<BO.TaskInList>();
        foreach(var dep in _dal.Dependence.ReadAll()) {
            if(dep!.pendingTaskId==id)
            {
                BO.Task task=Read(dep.previousTaskId)!;
                BO.TaskInList t = new BO.TaskInList() { status = (Status)task.status!,taskId = task.taskId,description = task.description,alias = task.alias };
                taskInList.Add(t);
            }
        }
        return taskInList;
    }
    public Status CalculateStatus(DO.Task task) //Calculate the status of the current task
    {
        if (task.scheduledStartDate==null && task.startDate == null && task.deadLine == null && task.completeDate == null)
        {
            return Status.unscheduled;
        }

        if (task.startDate == null && DateTime.Now < task.scheduledStartDate)
        {
            return Status.scheduled;
        }

        if (task.startDate == null && DateTime.Now >= task.scheduledStartDate)
        {
            return Status.onTrack;
        }

        if (task.completeDate!=null)
        {
            return Status.completed;
        }

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
        DO.Task doTask = new DO.Task(task.taskId, task.description!, task.alias!, isMilestone, task.createdAtDate, task.scheduledStartDate,
          task.startDate, task.deadLine, task.completeDate, task.deliverables, task.remarks, task.engineer!.engineerId, DO.EngineerExperience.expert,task.RequiredTime);
        try
        {
            int idTask = _dal.Task.Create(doTask);
            if(task.dependencies != null)
            {
                foreach (var dependency in task.dependencies)
                {
                    try
                    {
                        _dal.Task.Read(dependency.taskId);
                        _dal.Dependence.Create(new DO.Dependence(0, idTask, dependency.taskId));
                    }
                    catch (DO.DalDoesNotExistException ex)
                    {
                        throw new BO.BlDoesNotExistException("you cant add dependency when the depandsOnTask does not exist", ex);
                    }
                
                }
            }
            return idTask;
        }
        catch (BO.BlAlreadyExistsException ex)
        {
            throw new BO.BlAlreadyExistsException("This task is already exception");
        }
    }


    public BO.Task? Read(int id) //A function that  display an exist Task with an id
    {
        DO.Task? doTask = _dal.Task.Read(id);
        DO.Engineer? doEngineer = _dal.Engineer.Read(doTask!.engineerId);
        EngineerInTask engineer1 = new BO.EngineerInTask()
        {
            engineerId = doTask!.engineerId,
            name = doEngineer!.engineerName,
        };
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
            dependencies = calculateDependenciesList(doTask.taskId),
            milestone = mil,
            scheduledStartDate = doTask.scheduledStartDate,
            startDate = doTask.startDate,
            forecastDate = doTask.startDate + doTask.RequiredTime,
            deadLine = doTask.deadLine,
            completeDate = doTask.completeDate,
            deliverables = doTask.product,
            remarks = doTask.remarks,
            engineer =engineer1,
            exp = (BO.EngineerExperience)doTask.exp,
            RequiredTime = doTask.RequiredTime,
        };
    }
    public IEnumerable<BO.Task> ReadAll(Func<BO.Task, bool>? filter = null)//display all the list of tasks
    {
        IEnumerable<BO.Task>tasks = _dal.Task.ReadAll().Select(doTask => Read(doTask!.taskId)!).ToList(); ;
        if (filter == null)
            return tasks;
        else
            return tasks.Where(filter!);
    }

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
          task.startDate, task.deadLine, task.completeDate, task.deliverables, task.remarks, task.engineer.engineerId, DO.EngineerExperience.expert, task.RequiredTime);
        try
        {
            _dal.Task.Update(doTask);
            if (task.dependencies != null)
                foreach (var dep in task.dependencies!)
                {
                    if (dep != null)
                        _dal.Dependence.Create(new DO.Dependence(0, task.taskId, dep.taskId));
                }
        }
        catch (BO.BlDoesNotExistException ex)
        {
            throw new BO.BlDoesNotExistException("The task you want to update is not exist");
        }
    }
}
