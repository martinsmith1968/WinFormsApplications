using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;
using QuickCalendar.Domain.Formatters;
using QuickCalendar.Domain.Models;
using QuickCalendar.Domain.Parsers.Converters;

namespace QuickCalendar.Domain.Parsers;

public class CalendarSetParser
{
    private static readonly JsonSerializerSettings Settings = new()
    {
        ContractResolver = new CalendarSetContractResolver(),
        Formatting = Formatting.Indented,
        TypeNameHandling = TypeNameHandling.None,
        Converters =
        {
            new StringEnumConverter()
            {
                AllowIntegerValues = false,
                NamingStrategy = new DefaultNamingStrategy()
            },
            new CalendarSetDatesJsonConverter(),
        }
    };

    public static CalendarSet? ParseFromJson(string json)
    {
        try
        {
            var calendarSet = JsonConvert.DeserializeObject<CalendarSet>(json, Settings);

            return calendarSet;
        }
        catch
        {
            return null;
        }
    }

    public static string? GenerateJson(CalendarSet calendarSet)
    {
        try
        {
            var json = JsonConvert.SerializeObject(calendarSet, Settings);

            return json;
        }
        catch
        {
            return null;
        }
    }
}
