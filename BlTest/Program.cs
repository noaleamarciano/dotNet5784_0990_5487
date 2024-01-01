using BO;
using DalApi;
using DO;
using System.Diagnostics;
using System.Reflection.Emit;
using System.Reflection.Metadata.Ecma335;
using DalTest;
using System.Threading.Tasks;
using BlApi;

namespace BlTest
{
    internal class Program
    {
        static void menuEngineer()
        {
            Console.WriteLine("Return to the main menu press 0");
            Console.WriteLine("For adding an engineer press 1");
            Console.WriteLine("For displaying an engineer press 2");
            Console.WriteLine("View the full list of engineers press 3");
            Console.WriteLine("For updating an engineer press 4");
            Console.WriteLine("For deleting an engineer press 5");
            Console.WriteLine("Reset the all list press 6");
        }
        static void menuTask()
        {
            Console.WriteLine("Return to the main menu press 0");
            Console.WriteLine("For adding a task press 1");
            Console.WriteLine("For displaying a task press 2");
            Console.WriteLine("View the full list of tasks press 3");
            Console.WriteLine("For updating a task press 4");
            Console.WriteLine("For deleting a task press 5");
            Console.WriteLine("Reset the all list press 6");
        }
        static void menuMilestone()
        {
            Console.WriteLine("Return to the main menu press 0");
            Console.WriteLine("For adding a task press 1");
            Console.WriteLine("For displaying a task press 2");
            Console.WriteLine("For updating a task press 3");
        }
        static readonly BlApi.IBl s_bl = BlApi.Factory.Get();
        static void Main(string[] args)
        {
            Console.Write("Would you like to create Initial data? (Y/N)");
            string? ans = Console.ReadLine() ?? throw new FormatException("Wrong input");
            if (ans == "Y")
                Initialization.Do();
            Console.WriteLine("Wich entity would you like to try?");
            Console.WriteLine("Exit main menu 0");
            Console.WriteLine("For engineer press 1");
            Console.WriteLine("For task press 2");
            Console.WriteLine("For milestone press 3");
            int choose;
            choose = int.Parse(Console.ReadLine()!);
            switch (choose)
            {
                case 0:
                    break;
                case 1:
                    menuEngineer();
                    int choose1;
                    choose1 = int.Parse(Console.ReadLine()!);
                    while (choose1 != 0)
                    {
                        Console.WriteLine("Enter your choice");
                        choose1 = int.Parse(Console.ReadLine()!);
                        switch (choose1)
                        {
                            case 0:
                                break;
                            case 1://Add a new engineer
                                Console.WriteLine("Enter all engineer details");
                                int id = int.Parse(Console.ReadLine()!);
                                string name = (Console.ReadLine()!);
                                string email = (Console.ReadLine()!);
                                int cost = int.Parse(Console.ReadLine()!);
                                int taskId= int.Parse(Console.ReadLine()!);
                                BO.EngineerExperience exp = (BO.EngineerExperience)int.Parse(Console.ReadLine()!);
                                try
                                {
                                    s_bl.Engineer.Create(new BO.Engineer()
                                    {
                                        engineerId = id,
                                        name = name,
                                        email = email,
                                        costPerHour = cost,
                                        exp = exp,
                                        task = new BO.TaskInEngineer()
                                        {
                                            id = taskId,
                                            alias = s_bl.Task.Read(taskId)!.alias,
                                        }
                                    });
                                }
                                catch (Exception ex)
                                {
                                    Console.WriteLine(ex.Message);
                                }
                                break;
                            case 2://Display an engineer
                                Console.WriteLine("Enter an ID number");
                                int id2 = int.Parse(Console.ReadLine()!);
                                BO.Engineer? eng = s_bl.Engineer.Read(id2);
                                Console.WriteLine(eng);
                                break;
                            case 3://Display all the list engineers
                                s_bl.Engineer.
                                    ReadAll()
                                    .ToList()
                                    .ForEach(s => Console.WriteLine(s));
                                break;
                            case 4://Update an exist engineer
                                Console.WriteLine("Enter an ID number");
                                int id3 = int.Parse(Console.ReadLine()!);
                                Console.WriteLine(s_bl.Engineer.Read(id3));
                                Console.WriteLine("Enter details to update");
                                string name2 = (Console.ReadLine()!);
                                string email2 = (Console.ReadLine()!);
                                int cost2 = int.Parse(Console.ReadLine()!);
                                int taskId2 = int.Parse(Console.ReadLine()!);
                                BO.EngineerExperience exp2 = (BO.EngineerExperience)int.Parse(Console.ReadLine()!);
                                try
                                {
                                    s_bl.Engineer.Update(new BO.Engineer()
                                    {
                                        engineerId = id3,
                                        name = name2,
                                        email = email2,
                                        costPerHour = cost2,
                                        exp = exp2,
                                        task = new BO.TaskInEngineer()
                                        {
                                            id = taskId2,
                                            alias = s_bl.Task.Read(taskId2)!.alias,
                                        }
                                    });
                                }
                                catch (Exception ex)
                                {
                                    Console.WriteLine(ex.Message);
                                }
                                Console.WriteLine(s_bl.Engineer.Read(id3));
                                break;
                            case 5://Delete an exist engineer
                                Console.WriteLine("Enter an ID number");
                                int id5 = int.Parse(Console.ReadLine()!);
                                try
                                {
                                    s_bl.Engineer.Delete(id5);
                                }
                                catch (Exception ex)
                                {
                                    Console.WriteLine(ex.Message);
                                }
                                break;
                                //case 6://Reset the list
                                //    s_bl.Engineer.Reset();
                                //    break;
                        }

                    }
                    break;
                case 2:
                    menuTask();
                    int choose2 = 1;
                    while (choose2 != 0)
                    {
                        Console.WriteLine("Enter your choice");
                        choose2 = int.Parse(Console.ReadLine()!);
                        switch (choose2)
                        {
                            case 0:
                                break;
                            case 1://Add a new task
                                Console.WriteLine("Enter all task details");
                                string description = (Console.ReadLine()!);
                                string alias = (Console.ReadLine()!);
                                bool milestone = bool.Parse(Console.ReadLine()!);
                                DateTime productionDate = Convert.ToDateTime(Console.ReadLine());
                                //DateTime? startDate = Convert.ToDateTime(Console.ReadLine());
                                //DateTime? estimComplete = Convert.ToDateTime(Console.ReadLine());
                                //DateTime? finalDate = Convert.ToDateTime(Console.ReadLine());
                                //DateTime? complete = Convert.ToDateTime(Console.ReadLine());
                                //DateTime? forecastDate=Convert.ToDateTime(Console.ReadLine());
                                string product = (Console.ReadLine()!);
                                string remarks = (Console.ReadLine()!);
                                BO.EngineerExperience exp = (BO.EngineerExperience)int.Parse(Console.ReadLine()!);
                                Console.WriteLine("Enter a list of dependencies for this task to finish press 0");
                                List<TaskInList>? dependencies =new List<TaskInList>();
                                int dependentId=1;
                                while(dependentId!=0)
                                {
                                    dependentId = int.Parse(Console.ReadLine()!);
                                    dependencies.Add(new BO.TaskInList()
                                    {
                                        status = (Status)s_bl.Task.Read(dependentId)!.status!,
                                        taskId = dependentId,
                                        description=s_bl.Task.Read(dependentId)!.description,
                                        alias=s_bl.Task.Read(dependentId)!.alias,
                                    });
                                }
                                s_bl.Task.Create(new BO.Task()
                                {
                                    description= description,
                                    alias= alias,
                                    createdAtDate = productionDate,
                                    status=(BO.Status)0,
                                    dependencies= dependencies,
                                    milestone =null,
                                    scheduledStartDate = null,
                                    startDate= null,
                                    forecastDate = null,
                                    deadLine = null,
                                    completeDate = null,
                                    deliverables = product,
                                    remarks =remarks,
                                    engineer =null,
                                    exp = exp,
                                });
                                break;
                            case 2://Display an exist task
                                Console.WriteLine("Enter an ID number");
                                int id2 = int.Parse(Console.ReadLine()!);
                                BO.Task? tas1 = s_bl.Task.Read(id2);
                                Console.WriteLine(tas1);
                                break;
                            case 3://Display all the tasks
                                s_bl.Task.
                                   ReadAll()
                                   .ToList()
                                   .ForEach(s => Console.WriteLine(s));
                                break;
                            case 4://Update a task
                                Console.WriteLine("Enter an ID number");
                                int id3 = int.Parse(Console.ReadLine()!);
                                Console.WriteLine(s_bl.Task.Read(id3));
                                Console.WriteLine("Enter details to update");
                                string description1 = (Console.ReadLine()!);
                                string alias1 = (Console.ReadLine()!);
                                bool milestone1 = bool.Parse(Console.ReadLine()!);
                                DateTime productionDate1 = Convert.ToDateTime(Console.ReadLine());
                                DateTime? startDate1 = Convert.ToDateTime(Console.ReadLine());
                                DateTime? estimComplete1 = Convert.ToDateTime(Console.ReadLine());
                                DateTime? finalDate1 = Convert.ToDateTime(Console.ReadLine());
                                DateTime? complete1 = Convert.ToDateTime(Console.ReadLine());
                                string product1 = (Console.ReadLine()!);
                                string remarks1 = (Console.ReadLine()!);
                                int engineerId1 = int.Parse(Console.ReadLine()!);
                                BO.EngineerExperience exp1 = (BO.EngineerExperience)int.Parse(Console.ReadLine()!);
                                try
                                {
                                    BO.Task tas2 = new();
                                    s_bl.Task.Update(tas2);
                                }
                                catch (Exception ex)
                                {
                                    Console.WriteLine(ex.Message);
                                }
                                Console.WriteLine(s_bl.Task.Read(id3));
                                break;
                            case 5://Delete a task
                                Console.WriteLine("Enter an ID number");

                                try
                                {
                                    int id5 = int.Parse(Console.ReadLine()!);
                                    s_bl.Task.Delete(id5);
                                }
                                catch (Exception ex)
                                {
                                    Console.WriteLine(ex.Message);
                                }
                                break;
                                //case 6://Reset the list
                                //    s_dal.Task.Reset();
                                //    break;
                        }
                    }
                    break;
                case 3:
                    menuMilestone();
                    int choose3 = 1;
                    while (choose3 != 0)
                    {
                        Console.WriteLine("Enter your choice");
                        choose3 = int.Parse(Console.ReadLine()!);
                        switch (choose3)
                        {
                            case 0:
                                break;
                            case 1://Add a new dependence
                                Console.WriteLine("Enter all dependenece details");
                                int pendingTaskId = int.Parse(Console.ReadLine()!);
                                int previousTaskId = int.Parse(Console.ReadLine()!);
                                BO.Milestone dep = new();
                                s_bl.Milestone.Create(dep);
                                break;
                            case 2: //Display a dependence
                                Console.WriteLine("Enter an ID number");
                                int id2 = int.Parse(Console.ReadLine()!);
                                BO.Milestone? dep1 = s_bl.Milestone.Read(id2);
                                Console.WriteLine(dep1);
                                break;
                            case 4://Update a dependence
                                Console.WriteLine("Enter an ID number");
                                int id3 = int.Parse(Console.ReadLine()!);
                                Console.WriteLine(s_bl.Milestone.Read(id3));
                                Console.WriteLine("Enter details to update");
                                int pendingTaskId1 = int.Parse(Console.ReadLine()!);
                                int previousTaskId1 = int.Parse(Console.ReadLine()!);
                                try
                                {
                                    BO.Milestone dep2 = new();
                                    s_bl.Milestone.Update(dep2);
                                }
                                catch (Exception ex)
                                {
                                    Console.WriteLine(ex.Message);
                                }
                                Console.WriteLine(s_bl.Milestone.Read(id3));
                                break;
                        }
                    }
                    break;
            }
        }
    }
}
