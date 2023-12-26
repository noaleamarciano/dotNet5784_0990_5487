using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BO;

public class MilestoneInList
{
    public int id { get; init; }
    public string? description { get; set; }
    public string? alias { get; set; }
    public Status status { get; set; }
    public double completionPercentage { get; set; }
    public override string? ToString() => base.ToString();
}
