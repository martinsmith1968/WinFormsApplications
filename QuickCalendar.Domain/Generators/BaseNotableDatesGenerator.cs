using System.Globalization;
using DNX.Helpers.Reflection;
using DNX.Helpers.Strings;
using Newtonsoft.Json;
using QuickCalendar.Domain.Interfaces;
using QuickCalendar.Domain.Models;

// ReSharper disable InconsistentNaming

namespace QuickCalendar.Domain.Generators;

public abstract class BaseNotableDatesGenerator : INotableDatesGenerator, ICopyable<BaseNotableDatesGenerator>
{
    public const string Default_DescriptionTemplate = "{o}";

    public string GeneratorTypeName => GetType().Name.RemoveStartsAndEndsWith("NotableDates", "Generator");

    public string? DescriptionTemplate { get; set; }

    protected string InterpolateTemplate(string? descriptionTemplate, DateTime date, int sequence)
    {
        var template = (descriptionTemplate ?? string.Empty)
                .Replace("{", "{0:")
                .Replace("{0:sequence:", "{1:")
                .Replace("{0:sequence", "{1:")
            ;

        var description = string.Format(template, date, sequence);

        return description;
    }

    public abstract IList<NotableDate> Generate();

    public string GetDefinitionValue()
    {
        var propertyValues = ReflectionExtensions.GetPropertiesDictionary(this);

        var text = JsonConvert.SerializeObject(propertyValues);

        return text;
    }

    public string GetDefinitionText()
    {
        var interfaceProperties = ReflectionExtensions.GetPropertiesForType(typeof(INotableDatesGenerator))
            .Select(pi => pi.Name)
            .ToArray();

        var instanceProperties = ReflectionExtensions.GetPropertiesDictionary(this)
            .Where(kvp => !interfaceProperties.Contains(kvp.Key));


        var propertyValues = instanceProperties
            .Select(ip =>
            {
                var displayValue = ip.Value switch
                {
                    DateTime dt => dt.ToString(CultureInfo.CurrentCulture),
                    TimeSpan ts => ts.TotalDays.ToString(CultureInfo.CurrentCulture),
                    _ => ip.Value.ToString()
                };

                return $"{ip.Key}: {displayValue}";
            }).ToList();

        return string.Join(", ", propertyValues);
    }

    public void PopulateFromDefinitionValue(string text)
    {
        JsonConvert.PopulateObject(text, this);
    }

    public void CopyFrom(BaseNotableDatesGenerator other)
    {
        DescriptionTemplate = other.DescriptionTemplate;
    }
}
