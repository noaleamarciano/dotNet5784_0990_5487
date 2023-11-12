
namespace DalTest;
using DalApi;
using DO;
using System;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Xml.Linq;

public static class Initialization
{
    private static IDependence? s_dalDependence;
    private static ITask? s_dalTask;
    private static IEngineer? s_dalEngineer;
    private static readonly Random s_rand = new();
    private static void createEngineers()
    {
        string[] engineerNames =
             {"Efrat Yshai",
         "Noa Marciano",
         "Tamar Levi",
         "Michal Cohen",
         "Esti Israel",
         "Shlomo Segal",
         "David Aharoni",
         "Moshe Toledano",
         "Yoni Roll",
         "Arieh Sofer"
    };

        int MIN_ID = 200000000;
        int MAX_ID = 400000000;

        foreach (var _name in engineerNames)
        {
            int _id;
            do
                _id = s_rand.Next(MIN_ID, MAX_ID);
            while (s_dalEngineer!.Read(_id) != null);
            string _mail = _id + "@gmail.com";
            Random rand = new Random();
            int x = rand.Next(0, 3);
            int _costPerHour=0;
            EngineerExperience _experience = (EngineerExperience)x;
            switch (_experience)
            {
                case EngineerExperience.expert:
                    _costPerHour=400;
                    break;
                case EngineerExperience.junior:
                    _costPerHour = 230;
                    break;
                case EngineerExperience.rookie:
                    _costPerHour = 101;
                    break;
            }
            Engineer newEng = new(_id, _name, _mail, _costPerHour, _experience);
            s_dalEngineer!.Create(newEng);
        }
    }

    private static void createTasks()
    {
        string[] tasksNames =
        {
            "שלד והכנות",
            "בניית מעטפת בלוקים",
            "בניית קומת קרקע",
            "טייח פנים",
            "הכנות אינסטלאציה בקירות",
            "יציקת קירות",
            "יציקת ריצפה",
            "איטום רצפה",
            "משטחים",
            "אלומיניום, התקנת משקופים עיוורים"
        };

        foreach (var _task in tasksNames)
        {

            List<Engineer> newList = s_dalEngineer!.ReadAll();
            for (int i = 0; i < tasksNames.Length; i++)
            {
                Random rand = new Random();
                int x = rand.Next(0, 3);
                EngineerExperience _experience = (EngineerExperience)x;
                Task newTask = new(
                    0,
                    tasksNames[0],
                    "",
                    true,
                    null,
                    null,
                    null,
                    null,
                    null,
                    "",
                    "",
                    newList[0].engineerId,
                    _experience
                    );
                s_dalTask!.Create(newTask);
                
            }
            
        }

    }
    private static void createDependences()
    {
        List <Task> newList = s_dalTask!.ReadAll();
        for (int i = 1; i <= newList.Count; i++)
        {
            Dependence newDep = new(
                0,
                newList[i].taskId,
                newList[i-1].taskId
                );
            s_dalDependence!.Create(newDep);
        }
    }

    public static void Do(IEngineer s_dalEngineer, ITask s_dalTask, IDependence s_dalDependence)
    {
       IEngineer? dalEngineer;
       ITask? dalTask;
       IDependence? dalDependence;
       dalEngineer = s_dalEngineer ?? throw new NullReferenceException("DAL can not be null!");
       dalTask = s_dalTask ?? throw new NullReferenceException("DAL can not be null!");
       dalDependence = s_dalDependence ?? throw new NullReferenceException("DAL can not be null!");
       createDependences();
       createTasks();
       createEngineers();
    }
     
}

 




