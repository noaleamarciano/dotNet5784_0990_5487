using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace BO;

public static class Tools
{
    // דוגמא למתודת הרחבה סטטית - ToStringProperty
    public static string ToStringProperty<T>(this T obj)
    {
        StringBuilder result = new StringBuilder();
        PropertyInfo[] properties = typeof(T).GetProperties();

        foreach (PropertyInfo property in properties)
        {
            // אם התכונה היא אוסף, דאג לטפל בו
            if (property.PropertyType.IsGenericType && property.PropertyType.GetGenericTypeDefinition() == typeof(System.Collections.Generic.IEnumerable<>))
            {
                var collection = property.GetValue(obj) as System.Collections.IEnumerable;

                if (collection != null)
                {
                    result.AppendFormat("{0}: [", property.Name);

                    foreach (var item in collection)
                    {
                        result.AppendFormat("{0}, ", item.ToString());
                    }

                    if (result.Length > 2)
                    {
                        result.Length -= 2; // מחק את הפסיק והרווח האחרונים
                    }

                    result.Append("], ");
                }
            }
            else
            {
                result.AppendFormat("{0}: {1}, ", property.Name, property.GetValue(obj));
            }
        }

        if (result.Length > 2)
        {
            result.Length -= 2; // מחק את הפסיק והרווח האחרונים
        }

        return result.ToString();
    }

    // נוסיף כאן מתודות נוספות כפי שצריך
}
