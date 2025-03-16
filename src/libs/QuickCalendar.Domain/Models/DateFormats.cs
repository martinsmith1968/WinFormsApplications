namespace QuickCalendar.Domain.Models;

public class DateFormats
{
    public static IDictionary<string, string> NamedDateFormats = new Dictionary<string, string>()
    {
        { "yyyy-MM-dd", "ISO 8601" }
    };
}
