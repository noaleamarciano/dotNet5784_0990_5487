using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace BO;

public static class Tools
{

    public static string GenericToString(this object p)
    {
        var prop = p.GetType().GetProperties();
        string str = "";
        foreach (var property in prop)
        {
            str += property.Name + ":" + property.GetValue(p);
        }
        return str;
    }

}
