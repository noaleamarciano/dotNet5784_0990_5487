using System.Reflection;
using System.Collections;
using System.Reflection;
namespace BO;

internal static class Tools
{

    public static string GenericToString<T>(this T obj)
    {
        PropertyInfo[] propertiesArr = typeof(T).GetProperties();

        return string.Join(", ", propertiesArr.Select(property =>
        {
            object? propertyValue = property.GetValue(obj);
            string? str;
            if (propertyValue == null)
            {
                str = "null";
            }
            else if (propertyValue is IEnumerable enumerableValue)
            {
                str = string.Join("", enumerableValue.Cast<object>().Select(item => item.ToString()));
            }
            else
            {
                str = propertyValue.ToString()!;
            }

            return property.Name + ": " + str;
        }));


    }
}

