using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DalApi;

internal interface IDal
{
    IEngineer Engineer { get; }
    ITask Task { get; }
    IDependence Dependence { get; }
}
