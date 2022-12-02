using DNX.Helpers.Reflection;

namespace QuickCalendar.Domain.Generators;

public class NotableDateGeneratorFactory
{
    internal static IList<Type> FactoryCandidateTypes => typeof(NotableDateGeneratorFactory).Assembly
        .GetTypes()
        .Where(t => !t.IsAbstract)
        .Where(t => !t.IsInterface)
        .Where(t => t.GetInterfaces().Contains(typeof(INotableDatesGenerator)))
        .ToList();

    public INotableDatesGenerator? Create(string name, IDictionary<string, object> properties)
    {
        var targetType = FactoryCandidateTypes.FirstOrDefault(t => string.Equals(t.Name, name, StringComparison.OrdinalIgnoreCase))
                         ?? FactoryCandidateTypes.FirstOrDefault(t => string.Equals(t.Name, $"NotableDates{name}", StringComparison.OrdinalIgnoreCase))
                         ?? FactoryCandidateTypes.FirstOrDefault(t => string.Equals(t.Name, $"{name}Generator", StringComparison.OrdinalIgnoreCase))
                         ?? FactoryCandidateTypes.FirstOrDefault(t => string.Equals(t.Name, $"NotableDates{name}Generator", StringComparison.OrdinalIgnoreCase))
            ;

        if (targetType == null)
            return null;

        var instance = Activator.CreateInstance(targetType);

        instance.PopulateFrom(properties);

        return instance as INotableDatesGenerator;
    }
}
