using DalApi;
using DO;
using System.Diagnostics;
using System.Reflection.Emit;
using System.Reflection.Metadata.Ecma335;

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
        static readonly BlApi.IBl s_bl = BlApi.Factory.Get();
        static void Main(string[] args)
        {
            Console.Write("Would you like to create Initial data? (Y/N)");
            string? ans = Console.ReadLine() ?? throw new FormatException("Wrong input");
            if (ans == "Y")
                DalTest.Initialization.Do();
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
                    choose1=int.Parse(Console.ReadLine()!);
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
                                EngineerExperience exp = (EngineerExperience)int.Parse(Console.ReadLine()!);
                                try
                                {
                                    s_bl.Engineer.Create(new BO.Engineer()
                                    {
                                        engineerId = id,
                                        name = name,
                                        email = email,
                                        costPerHour = cost,
                                        exp = (BO.EngineerExperience)exp,
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
                                EngineerExperience exp2 = (EngineerExperience)int.Parse(Console.ReadLine()!);
                                try
                                {
                                    s_bl.Engineer.Update(new BO.Engineer()
                                    {
                                        engineerId = id3,
                                        name = name2,
                                        email = email2,
                                        costPerHour = cost2,
                                        exp = (BO.EngineerExperience)exp2,
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
                                DateTime? startDate = Convert.ToDateTime(Console.ReadLine());
                                DateTime? estimComplete = Convert.ToDateTime(Console.ReadLine());
                                DateTime? finalDate = Convert.ToDateTime(Console.ReadLine());
                                DateTime? complete = Convert.ToDateTime(Console.ReadLine());
                                string product = (Console.ReadLine()!);
                                string remarks = (Console.ReadLine()!);
                                int engineerId = int.Parse(Console.ReadLine()!);
                                EngineerExperience exp = (EngineerExperience)int.Parse(Console.ReadLine()!);
                                DO.Task tas = new(0, description, alias, milestone, productionDate, startDate, estimComplete, finalDate, complete, product, remarks, engineerId, exp);
                                s_bl.Task.Create(tas);
                                break;
                            case 2://Display an exist task
                                Console.WriteLine("Enter an ID number");
                                int id2 = int.Parse(Console.ReadLine()!);
                                DO.Task? tas1 = s_dal.Task.Read(id2);
                                Console.WriteLine(tas1);
                                break;
                            case 3://Display all the tasks
                                s_dal.Task.
                                   ReadAll()
                                   .ToList()
                                   .ForEach(s => Console.WriteLine(s));
                                break;
                            case 4://Update a task
                                Console.WriteLine("Enter an ID number");
                                int id3 = int.Parse(Console.ReadLine()!);
                                Console.WriteLine(s_dal.Task.Read(id3));
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
                                EngineerExperience exp1 = (EngineerExperience)int.Parse(Console.ReadLine()!);
                                try
                                {
                                    DO.Task tas2 = new(id3, description1, alias1, milestone1, productionDate1, startDate1, estimComplete1, finalDate1, complete1, product1, remarks1, engineerId1, exp1);
                                    s_dal.Task.Update(tas2);
                                }
                                catch (Exception ex)
                                {
                                    Console.WriteLine(ex.Message);
                                }
                                Console.WriteLine(s_dal.Task.Read(id3));
                                break;
                            case 5://Delete a task
                                Console.WriteLine("Enter an ID number");

                                try
                                {
                                    int id5 = int.Parse(Console.ReadLine()!);
                                    s_dal.Task.Delete(id5);
                                }
                                catch (Exception ex)
                                {
                                    Console.WriteLine(ex.Message);
                                }
                                break;
                            case 6://Reset the list
                                s_dal.Task.Reset();
                                break;
                        }

                    }

            }
            break;
            }
                  
                  
                  
        }
    }
}