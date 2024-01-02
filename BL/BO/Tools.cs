
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
