using Newtonsoft.Json;
using QuickCalendar.Domain.Models;

namespace QuickCalendar.Domain.Parsers;

public class CalendarSetParser
{
    public static CalendarSet? ParseFromJson(string json)
    {
        try
        {
            var calendarSet = JsonConvert.DeserializeObject<CalendarSet>(json);

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
            var json = JsonConvert.SerializeObject(calendarSet, Formatting.Indented);

            return json;
        }
        catch
        {
            return null;
        }
    }
}
