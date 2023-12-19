using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BO;

public class TaskInList
{
    public Status status { get; set; }
    public int taskId { get; init; }
    public string? description { get; set; }
    public string? alias { get; set; }
   
}
