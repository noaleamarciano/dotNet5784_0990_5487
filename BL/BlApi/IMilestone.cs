using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlApi;

public interface IMilestone //statements for the crud functions
{
    public int Create(BO.Milestone mil);
    public void Update(BO.Milestone mil);
    public BO.Milestone? Read(int id);
}
