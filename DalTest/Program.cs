using Dal;
using DalApi;
using DalTest;
using DO;
using System.Diagnostics.Metrics;
using System.Globalization;
using System.Numerics;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace DalTest
{
    internal class Program
    {
        private static IEngineer? s_dalEngineer = new EngineerImplementation();
        private static ITask? s_dalTask = new TaskImplementation();
        private static IDependence? s_dalDependence = new DependenceImplementation();
        static void Main(string[] args)
        {
            try
            {
                Initialization.Do(s_dalEngineer, s_dalTask, s_dalDependence);
                Console.WriteLine("Exit main menu 0");
                Console.WriteLine("entity 1");
                Console.WriteLine("entity 2");
                Console.WriteLine("entity 3");
                int choose = int.Parse(Console.ReadLine());

                switch (choose)
                {
                    case 0:

                        break;
                    case 1:
                        Console.WriteLine("0 Exit main menu");
                        Console.WriteLine("Add 1");
                        Console.WriteLine("Display 2");
                        Console.WriteLine("View the full list 3");
                        Console.WriteLine("Update 4");
                        Console.WriteLine("Delete 5");
                        int choose1 = int.Parse(Console.ReadLine());
                        while (choose1 != 0)
                        {
                            switch (choose1)
                            {
                                case 0:
                                    break;
                                case 1:
                                    Console.WriteLine("Enter all engineer details");
                                    int id = int.Parse(Console.ReadLine());
                                    string name = (Console.ReadLine());
                                    string email = (Console.ReadLine());
                                    int cost = int.Parse(Console.ReadLine());
                                    EngineerExperience exp = (EngineerExperience)int.Parse(Console.ReadLine());
                                    Engineer gth = new(id, name, email, cost, exp);
                                    s_dalEngineer.Create(gth);
                                    Console.WriteLine(s_dalEngineer.Read(id));
                                    break;
                                case 2:
                                    Console.WriteLine("Enter an ID number");
                                    int id2 = int.Parse(Console.ReadLine());
                                    Engineer? eng = s_dalEngineer.Read(id2);
                                    Console.WriteLine(eng);
                                    //Console.WriteLine(eng.engineerName);
                                    //Console.WriteLine(eng.engineerEmail);
                                    //Console.WriteLine(eng.costPerHour);
                                    //Console.WriteLine(eng.experience);
                                    break;
                                case 3:
                                    List<Engineer> copyEngineer = s_dalEngineer.ReadAll();
                                    copyEngineer.ForEach(s => Console.WriteLine(s));
                                    break;
                                case 4:
                                    Console.WriteLine("Enter an ID number");
                                    int id3 = int.Parse(Console.ReadLine());
                                    Console.WriteLine(s_dalEngineer.Read(id3));
                                    Console.WriteLine("Enter details to update");
                                    string name2 = (Console.ReadLine());
                                    string email2 = (Console.ReadLine());
                                    int cost2 = int.Parse(Console.ReadLine());
                                    EngineerExperience exp2 = (EngineerExperience)int.Parse(Console.ReadLine());
                                    Engineer eng2 = new(id3, name2, email2, cost2, exp2);
                                    s_dalEngineer.Update(eng2);
                                    Console.WriteLine(s_dalEngineer.Read(id3));
                                    break;
                                case 5:
                                    Console.WriteLine("Enter an ID number");
                                    int id5 = int.Parse(Console.ReadLine());
                                    s_dalEngineer.Delete(id5);
                                    List<Engineer> copyEngineer1 = s_dalEngineer.ReadAll();
                                    copyEngineer1.ForEach(s => Console.WriteLine(s));
                                    break;
                            }
                        }
                        break;
                    case 2:
                        Console.WriteLine("0 Exit main menu");
                        Console.WriteLine("Add 1");
                        Console.WriteLine("Display 2");
                        Console.WriteLine("View the full list 3");
                        Console.WriteLine("Update 4");
                        Console.WriteLine("Delete 5");
                        int choose2 = int.Parse(Console.ReadLine());
                        while (choose2 != 0)
                        {
                            switch (choose2)
                            {
                                case 0:
                                    break;
                                case 1:
                                    Console.WriteLine("Enter all task details");
                                    string description = (Console.ReadLine());
                                    string alias = (Console.ReadLine());
                                    bool milestone = bool.Parse(Console.ReadLine());
                                    DateTime? productionDate = Convert.ToDateTime(Console.ReadLine());
                                    DateTime? startDate = Convert.ToDateTime(Console.ReadLine());
                                    DateTime? estimComplete = Convert.ToDateTime(Console.ReadLine());
                                    DateTime? finalDate = Convert.ToDateTime(Console.ReadLine());
                                    DateTime? complete = Convert.ToDateTime(Console.ReadLine());
                                    string product = (Console.ReadLine());
                                    string remarks = (Console.ReadLine());
                                    int engineerId = int.Parse(Console.ReadLine());
                                    EngineerExperience exp = (EngineerExperience)int.Parse(Console.ReadLine());
                                    DO.Task tas = new(0, description, alias, milestone, productionDate, startDate, estimComplete, finalDate, complete, product, remarks, engineerId, exp);
                                    s_dalTask.Create(tas);
                                    break;
                                case 2:
                                    Console.WriteLine("Enter an ID number");
                                    int id2 = int.Parse(Console.ReadLine());
                                    DO.Task? tas1 = s_dalTask.Read(id2);
                                    Console.WriteLine(tas1);
                                    // Console.WriteLine(eng.engineerName);
                                    //Console.WriteLine(eng.engineerEmail);
                                    //Console.WriteLine(eng.costPerHour);
                                    //Console.WriteLine(eng.experience);
                                    break;
                                case 3:
                                    List<DO.Task> copyTask = s_dalTask.ReadAll();
                                    copyTask.ForEach(s => Console.WriteLine(s));
                                    break;
                                case 4:
                                    Console.WriteLine("Enter an ID number");
                                    int id3 = int.Parse(Console.ReadLine());
                                    Console.WriteLine(s_dalDependence.Read(id3));
                                    Console.WriteLine("Enter details to update");
                                    string description1 = (Console.ReadLine());
                                    string alias1 = (Console.ReadLine());
                                    bool milestone1 = bool.Parse(Console.ReadLine());
                                    DateTime? productionDate1 = Convert.ToDateTime(Console.ReadLine());
                                    DateTime? startDate1 = Convert.ToDateTime(Console.ReadLine());
                                    DateTime? estimComplete1 = Convert.ToDateTime(Console.ReadLine());
                                    DateTime? finalDate1 = Convert.ToDateTime(Console.ReadLine());
                                    DateTime? complete1 = Convert.ToDateTime(Console.ReadLine());
                                    string product1 = (Console.ReadLine());
                                    string remarks1 = (Console.ReadLine());
                                    int engineerId1 = int.Parse(Console.ReadLine());
                                    EngineerExperience exp1 = (EngineerExperience)int.Parse(Console.ReadLine());
                                    DO.Task tas2 = new(id3, description1, alias1, milestone1, productionDate1, startDate1, estimComplete1, finalDate1, complete1, product1, remarks1, engineerId1, exp1);
                                    s_dalTask.Update(tas2);
                                    Console.WriteLine(s_dalTask.Read(id3));
                                    break;
                                case 5:
                                    Console.WriteLine("Enter an ID number");
                                    int id5 = int.Parse(Console.ReadLine());
                                    s_dalTask.Delete(id5);
                                    break;
                            }
                        }
                        break;

                    case 3:
                        Console.WriteLine("0 יציאה מתפריט ראשי");
                        Console.WriteLine("הוספה 1");
                        Console.WriteLine("תצוגה 2");
                        Console.WriteLine("תצוגת הרשימה המלאה 3");
                        Console.WriteLine("עדכון 3");
                        Console.WriteLine("מחיקה 4");
                        int choose3 = int.Parse(Console.ReadLine());
                        while (choose3 != 0)
                        {
                            switch (choose3)
                            {
                                case 0:
                                    break;
                                case 1:
                                    Console.WriteLine("Enter all engineer details");
                                    int pendingTaskId = int.Parse(Console.ReadLine());
                                    int previousTaskId = int.Parse(Console.ReadLine());
                                    Dependence dep = new(0, pendingTaskId, previousTaskId);
                                    s_dalDependence.Create(dep);
                                    break;
                                case 2: 
                                    Console.WriteLine("Enter an ID number");
                                    int id2 = int.Parse(Console.ReadLine());
                                    Dependence? dep1 = s_dalDependence.Read(id2);
                                    Console.WriteLine(dep1);
                                    // Console.WriteLine(eng.engineerName);
                                    //Console.WriteLine(eng.engineerEmail);
                                    //Console.WriteLine(eng.costPerHour);
                                    //Console.WriteLine(eng.experience);
                                    break;
                                case 3:
                                    List<Dependence> copyDependence = s_dalDependence.ReadAll();
                                    copyDependence.ForEach(s => Console.WriteLine(s));
                                    break;
                                case 4:
                                    Console.WriteLine("Enter an ID number");
                                    int id3 = int.Parse(Console.ReadLine());
                                    Console.WriteLine(s_dalDependence.Read(id3));
                                    Console.WriteLine("Enter details to update");
                                    int pendingTaskId1 = int.Parse(Console.ReadLine());
                                    int previousTaskId1 = int.Parse(Console.ReadLine());
                                    Dependence dep2 = new(0, pendingTaskId1, previousTaskId1);
                                    s_dalDependence.Update(dep2);
                                    Console.WriteLine(s_dalDependence.Read(id3));
                                    break;
                                case 5:
                                    Console.WriteLine("Enter an ID number");
                                    int id5 = int.Parse(Console.ReadLine());
                                    s_dalDependence.Delete(id5);
                                    List<Dependence> copyDependence1 = s_dalDependence.ReadAll();
                                    copyDependence1.ForEach(s => Console.WriteLine(s));
                                    break;
                            }
                        }
                        break;
                }

                }
                catch (Exception)
                {

    throw;
}
            }
        
    }  
}
