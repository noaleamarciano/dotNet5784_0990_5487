using Dal;
using DalApi;
using DO;

namespace DalTest
{
    internal class Program
    {
        //static readonly IDal s_dal = new DalList();
        //static readonly IDal s_dal = new Dal.DalXml(); //stage 3
        static readonly IDal s_dal = Factory.Get; //stage 4
        static void Main(string[] args)
        {
            Console.Write("Would you like to create Initial data? (Y/N)"); //stage 3
            string? ans = Console.ReadLine() ?? throw new FormatException("Wrong input"); //stage 3
            if (ans == "Y") //stage 3
                Initialization.Do(); //stage 2
            Console.WriteLine("Wich entity would you like to try?");
            Console.WriteLine("Exit main menu 0");
            Console.WriteLine("For engineer press 1");
            Console.WriteLine("For task press 2");
            Console.WriteLine("For dependency press 3");
            int choose = int.Parse(Console.ReadLine()!);
            switch (choose)
            {
                case 0:

                    break;
                case 1:// The engineer entity.
                    Console.WriteLine("0 Exit main menu");
                    Console.WriteLine("Add 1");
                    Console.WriteLine("Display 2");
                    Console.WriteLine("View the full list 3");
                    Console.WriteLine("Update 4");
                    Console.WriteLine("Delete 5");
                    Console.WriteLine("Reset 6");
                    int choose1 = 1;
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
                                    Engineer eng1 = new(id, name, email, cost, exp);
                                    s_dal.Engineer.Create(eng1);
                                }
                                catch (Exception ex)
                                {
                                    Console.WriteLine(ex.Message);
                                }
                                break;
                            case 2://Display an engineer
                                Console.WriteLine("Enter an ID number");
                                int id2 = int.Parse(Console.ReadLine()!);
                                Engineer? eng = s_dal.Engineer.Read(id2);
                                Console.WriteLine(eng);
                                break;
                            case 3://Display all the list engineers
                                s_dal.Engineer.
                                    ReadAll()
                                    .ToList()
                                    .ForEach(s => Console.WriteLine(s));
                                break;
                            case 4://Update an exist engineer
                                Console.WriteLine("Enter an ID number");
                                int id3 = int.Parse(Console.ReadLine()!);
                                Console.WriteLine(s_dal.Engineer.Read(id3));
                                Console.WriteLine("Enter details to update");
                                string name2 = (Console.ReadLine()!);
                                string email2 = (Console.ReadLine()!);
                                int cost2 = int.Parse(Console.ReadLine()!);
                                EngineerExperience exp2 = (EngineerExperience)int.Parse(Console.ReadLine()!);
                                Engineer eng2 = new(id3, name2, email2, cost2, exp2);
                                try
                                {
                                    s_dal.Engineer.Update(eng2);
                                }
                                catch (Exception ex)
                                {
                                    Console.WriteLine(ex.Message);
                                }
                                Console.WriteLine(s_dal.Engineer.Read(id3));
                                break;
                            case 5://Delete an exist engineer
                                Console.WriteLine("Enter an ID number");
                                int id5 = int.Parse(Console.ReadLine()!);
                               
                                break;
                            case 6://Reset the list
                                s_dal.Engineer.Reset();
                                break;
                        }

                    }
                    break;
                case 2://Task entity
                    Console.WriteLine("0 Exit main menu");
                    Console.WriteLine("Add 1");
                    Console.WriteLine("Display 2");
                    Console.WriteLine("View the full list 3");
                    Console.WriteLine("Update 4");
                    Console.WriteLine("Delete 5");
                    Console.WriteLine("Reset 6");
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
                                TimeSpan time= TimeSpan.FromSeconds(1);
                                DO.Task tas = new(0, description, alias, milestone, productionDate, startDate, estimComplete, finalDate, complete, product, remarks, engineerId, exp,time);
                                s_dal.Task.Create(tas);
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
                                string alias1 = (Console.ReadLine()!)    ;
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
                                    DO.Task tas2 = new(id3, description1, alias1, milestone1, productionDate1, startDate1, estimComplete1, finalDate1, complete1, product1, remarks1, engineerId1, exp1, TimeSpan.Zero);
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
                    break;
                case 3://Dependence entity
                    Console.WriteLine("0 Exit main menu");
                    Console.WriteLine("Add 1");
                    Console.WriteLine("Display 2");
                    Console.WriteLine("View the full list 3");
                    Console.WriteLine("Update 4");
                    Console.WriteLine("Delete 5");
                    Console.WriteLine("Reset 6");
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
                                Dependence dep = new(0, pendingTaskId, previousTaskId);
                                s_dal.Dependence.Create(dep);
                                break;
                            case 2: //Display a dependence
                                Console.WriteLine("Enter an ID number");
                                int id2 = int.Parse(Console.ReadLine()!);
                                Dependence? dep1 = s_dal.Dependence.Read(id2);
                                Console.WriteLine(dep1);
                                break;
                            case 3://Display all the dependences
                                s_dal.Dependence
                                   .ReadAll()
                                   .ToList()
                                   .ForEach(s => Console.WriteLine(s));
                                break;
                            case 4://Update a dependence
                                Console.WriteLine("Enter an ID number");
                                int id3 = int.Parse(Console.ReadLine()!);
                                Console.WriteLine(s_dal.Dependence.Read(id3));
                                Console.WriteLine("Enter details to update");
                                int pendingTaskId1 = int.Parse(Console.ReadLine()!);
                                int previousTaskId1 = int.Parse(Console.ReadLine()!);
                                try
                                {
                                    Dependence dep2 = new(id3, pendingTaskId1, previousTaskId1);
                                    s_dal.Dependence.Update(dep2);
                                }
                                catch (Exception ex)
                                {
                                    Console.WriteLine(ex.Message);
                                }
                                Console.WriteLine(s_dal.Dependence.Read(id3));
                                break;
                            case 5://Delete a dependence
                                Console.WriteLine("Enter an ID number");
                                try
                                {
                                    int id5 = int.Parse(Console.ReadLine()!);
                                }
                                catch (Exception ex)
                                {
                                    Console.WriteLine(ex.Message);
                                }
                                break;
                            case 6://Reset the list
                                s_dal.Dependence.Reset();
                                break;
                        }
                    }
                    break;
            }
        }
    }
}
