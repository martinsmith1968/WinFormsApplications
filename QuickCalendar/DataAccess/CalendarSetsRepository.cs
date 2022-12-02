using System.Collections.Specialized;
using DNX.Helpers.Strings;
using QuickCalendar.Domain.Models;
using QuickCalendar.Domain.Parsers;
using QuickCalendar.Properties;

namespace QuickCalendar.DataAccess;

public class CalendarSetsRepository : ICalendarSetsRepository
{
    private static IDictionary<string, string> LoadAllCalendarSets()
    {
        var dictionary = new Dictionary<string, string>();

        var calendarSets = UserSettings.Default.CalendarSets
                           ?? new StringCollection();
        foreach (var calendarSet in calendarSets)
        {
            var id = calendarSet.Before(":");
            var details = calendarSet.After(":");

            if (id.IsNullOrWhiteSpace() || details.IsNullOrWhiteSpace())
                continue;

            dictionary.Add(id, details);
        }

        return dictionary;
    }

    private static void SaveAllCalendarSets(IDictionary<string, string> calendarSets)
    {
        var calendarSetDetails = calendarSets
            .Select(kvp => $"{kvp.Key}:{kvp.Value}")
            .ToArray();

        var stringCollection = new StringCollection();
        stringCollection.AddRange(calendarSetDetails);

        UserSettings.Default.CalendarSets = stringCollection;
        UserSettings.Default.Save();
    }

    public CalendarSet? LoadNamedCalendarSet(string name)
    {
        var calendarSets = LoadAllCalendarSets();

        var calendarSet = calendarSets.ContainsKey(name)
            ? CalendarSetParser.ParseFromJson(calendarSets[name])
            : null;

        if (calendarSet != null)
        {
            UserSettings.Default.LastCalendarName = calendarSet.Name;
            UserSettings.Default.Save();
        }

        return calendarSet;
    }

    public void SaveNamedCalendarSet(CalendarSet calendarSet)
    {
        var calendarSets = LoadAllCalendarSets();

        var details = CalendarSetParser.GenerateJson(calendarSet);
        if (!string.IsNullOrWhiteSpace(details))
        {
            calendarSets[calendarSet.Name] = details;
            SaveAllCalendarSets(calendarSets);
        }
    }
}
