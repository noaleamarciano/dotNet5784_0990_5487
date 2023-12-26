using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BO;

public class Task
{
    public int taskId { get; init; }
    public string? description { get; set; }
    public string? alias { get; set; }
    public DateTime createdAtDate { get; set; }
    public Status status { get; set; }
    //רשימה של תלויות מסוג TaskInList
    public MilestoneInTask? milestone { get; set; }
    public DateTime scheduledStartDate { get; set; }
    public DateTime startDate { get; set; }
    public DateTime forecastDate { get; set; }
    public DateTime deadLine { get; set; }
    public DateTime completeDate { get; set; }
    public string? deliverables { get; set; }
    public string? remarks { get; set; }
    public EngineerInTask? engineer { get; set; }
    public EngineerExperience exp { get; set; }
    public override string? ToString() => base.ToString();
}
