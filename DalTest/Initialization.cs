namespace DalTest;
using DalApi;
using DO;
using System;
using Dal;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Xml.Linq;

public static class Initialization
{
    private static IDal? s_dal;
    private static readonly Random s_rand = new();

    private static void createEngineers() //A function that initialize the engineers list with 10 engineers.
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
            while (s_dal!.Engineer.Read(_id) != null);
            string _mail = _id + "@gmail.com";
            Random rand = new Random();
            int x = rand.Next(0, 3);
            int _costPerHour = 0;
            EngineerExperience _experience = (EngineerExperience)x;
            switch (_experience)
            {
                case EngineerExperience.expert:
                    _costPerHour = 400;
                    break;
                case EngineerExperience.junior:
                    _costPerHour = 230;
                    break;
                case EngineerExperience.rookie:
                    _costPerHour = 101;
                    break;
            }
            Engineer newEng = new(_id, _name, _mail, _costPerHour, _experience);
            s_dal!.Engineer.Create(newEng);
        }
    }

    private static void createTasks() //A function that initialize the tasks list with 10 tasks.
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
            DateTime createdAt = DateTime.Now;
            //List<Engineer> newList = s_dal!.Engineer.ReadAll();
            var engineers = s_dal!.Engineer!.ReadAll().ToList();
            int randomIndex = s_rand.Next(0, engineers.Count);
            int engineerid = engineers[randomIndex]?.engineerId ?? 0;

            Random rand = new Random();
            int x = rand.Next(0, 3);
            EngineerExperience _experience = (EngineerExperience)x;
            Task newTask = new(
                0,
                _task,
                "",
                true,
                createdAt,
                null,
                null,
                null,
                null,
                "",
                "",
                engineerid,
                _experience
             //TimeSpan.FromDays(5)

                );
            s_dal!.Task.Create(newTask);

        }
    }
    private static void createDependences() //A function that initialize the dependences list with the help of the tasks list.
    {
        var tasks = s_dal!.Task!.ReadAll().ToList();
        for (int i = 1; i < tasks.Count; i++)
        {
            Dependence newDep = new(
                0,
                tasks[i]!.taskId,
                tasks[i - 1]!.taskId
                );
            s_dal!.Dependence.Create(newDep);
        }
    }

    public static void Do() //stage 2
    {
        s_dal = Factory.Get;
        createEngineers();
        createTasks();
        createDependences();
    }
}






