using System.Reflection;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using QuickCalendar.Domain.Generators;
using QuickCalendar.Domain.Models;

namespace QuickCalendar.Domain.Formatters;

public class CalendarSetContractResolver : DefaultContractResolver
{
    private readonly Dictionary<string, Type> _ignoreProps = new()
    {
        { nameof(CalendarSet.Dates.Dates), typeof(IList<NotableDate>) },
        { nameof(CalendarSet.Dates.MonthlyDates), typeof(IList<NotableDate>) },
        { nameof(CalendarSet.Dates.AnnualDates), typeof(IList<NotableDate>) },
        { nameof(CalendarSet.Dates.AllDates), typeof(IList<NotableDate>) },
        { nameof(CalendarSet.Dates.AllDatesGenerators), typeof(IList<Tuple<string, INotableDatesGenerator>>) },
    };

    protected override JsonProperty CreateProperty(MemberInfo member, MemberSerialization memberSerialization)
    {
        var property = base.CreateProperty(member, memberSerialization);
        if (_ignoreProps.Any(ip => ip.Key == property.PropertyName && ip.Value == property.PropertyType))
        {
            property.ShouldSerialize = _ => false;
        }

        return property;
    }
}
