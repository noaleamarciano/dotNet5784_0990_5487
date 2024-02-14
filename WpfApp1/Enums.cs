using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PL;

// Class for handling enumeration of EngineerExperience values
internal class EngineerExperience:IEnumerable
{
    // Static readonly IEnumerable for EngineerExperience enum values
    static readonly IEnumerable<BO.EngineerExperience> e_enums =
        (Enum.GetValues(typeof(BO.EngineerExperience)) as IEnumerable<BO.EngineerExperience>)!;
    // Implementing the GetEnumerator method for iteration
    public IEnumerator GetEnumerator() => e_enums.GetEnumerator();
}
// Class for handling enumeration of Status values
internal class Status : IEnumerable
{
    // Static readonly IEnumerable for Status enum values
    static readonly IEnumerable<BO.Status> e_enums =
        (Enum.GetValues(typeof(BO.Status)) as IEnumerable<BO.Status>)!;

    // Implementing the GetEnumerator method for iteration
    public IEnumerator GetEnumerator() => e_enums.GetEnumerator();
}