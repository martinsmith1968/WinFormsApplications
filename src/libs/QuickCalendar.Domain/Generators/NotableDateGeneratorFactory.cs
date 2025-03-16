using System.Reflection;
using QuickCalendar.Domain.Extensions;

namespace QuickCalendar.Domain.Generators;

public class NotableDateGeneratorFactory
{
    internal static IList<Type> FactoryCandidateTypes => typeof(NotableDateGeneratorFactory).Assembly
        .GetTypes()
        .Where(t => !t.IsAbstract)
        .Where(t => !t.IsInterface)
        .Where(t => t.GetInterfaces().Contains(typeof(INotableDatesGenerator)))
        .ToList();

    public INotableDatesGenerator? Create(string name, IDictionary<string, object>? properties)
    {
        var targetType = FactoryCandidateTypes.FirstOrDefault(t => string.Equals(t.Name, name, StringComparison.OrdinalIgnoreCase))
                         ?? FactoryCandidateTypes.FirstOrDefault(t => string.Equals(t.Name, $"NotableDates{name}", StringComparison.OrdinalIgnoreCase))
                         ?? FactoryCandidateTypes.FirstOrDefault(t => string.Equals(t.Name, $"{name}Generator", StringComparison.OrdinalIgnoreCase))
                         ?? FactoryCandidateTypes.FirstOrDefault(t => string.Equals(t.Name, $"NotableDates{name}Generator", StringComparison.OrdinalIgnoreCase))
            ;

        if (targetType == null)
        {
            return null;
        }

        var instance = Activator.CreateInstance(targetType);

        if (properties != null)
        {
            const BindingFlags flags = BindingFlags.Instance | BindingFlags.Public | BindingFlags.SetProperty | BindingFlags.FlattenHierarchy;

            instance.PopulateFromDictionary(properties, flags, targetType);
        }

        return instance as INotableDatesGenerator;
    }
}
