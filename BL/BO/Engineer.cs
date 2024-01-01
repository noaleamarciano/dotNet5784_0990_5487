using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BO;

public class Engineer
{
    public int engineerId { get; init; }
    public string name { get; set; }
    public string email { get; set; }
    public int costPerHour { get; set; }
    public EngineerExperience exp { get; set; }
    public TaskInEngineer? task { get; set; }
}
