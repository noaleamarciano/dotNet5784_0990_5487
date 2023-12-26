﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BO;

public class Milestone
{
    public int milestoneId { get; init; }
    public string? description { get; set; }
    public string? alias { get; set; }
    public DateTime createdAtDate { get; set; }
    public Status status { get; set; }
    public DateTime startDate { get; set; }
    public DateTime forecastDate { get; set; }
    public DateTime deadLine { get; set; }
    public DateTime completeDate { get; set; }
    public string? remarks { get; set; }
    public double completionPercentage { get; set; }
    public List<TaskInList>? Dependencies { get; set; }
    public override string? ToString() => $"Milestone (ID:M{Id})";
}
