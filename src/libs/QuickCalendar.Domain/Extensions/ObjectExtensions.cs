using System.Reflection;

namespace QuickCalendar.Domain.Extensions;

public static class ObjectExtensions
{
    public static T PopulateFromDictionary<T>(
        this T instance,
        IDictionary<string, object>? dict,
        BindingFlags bindingFlags = BindingFlags.Instance | BindingFlags.Public | BindingFlags.SetProperty,
        Type? instanceType = null)
        where T : new()
    {
        if (dict == null)
        {
            return instance;
        }

        instanceType ??= typeof(T);

        var properties = instanceType.GetProperties(bindingFlags)
            .Where(p => p.CanWrite)
            .ToList();

        foreach (var propertyInfo in properties)
        {
            if (dict.ContainsKey(propertyInfo.Name))
            {
                propertyInfo.SetValue(instance, dict[propertyInfo.Name]);
            }
        }
        return instance;
    }
}
