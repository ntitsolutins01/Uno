using System.ComponentModel;
using System.Reflection;

public static class EnumExtensions
{
    public static string GetDescription<T>(this T enumValue) where T : Enum
    {
        var field = typeof(T).GetField(enumValue.ToString());
        if (field == null)
            return "No description";

        var attribute = field.GetCustomAttribute<DescriptionAttribute>();
        return attribute == null ? enumValue.ToString() : attribute.Description; 
    }
}
