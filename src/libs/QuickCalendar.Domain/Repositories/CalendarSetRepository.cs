using DNX.Extensions.Execution;
using QuickCalendar.Domain.Models;

namespace QuickCalendar.Domain.Repositories;

public class CalendarSetRepository
{
    public static readonly string DefaultFileExtension = nameof(CalendarSet).ToLower();

    public const string FileDialogFilterJoinChar = "|";

    public static string BuildFileDialogFileFilters()
    {
        var fileFilters = new Dictionary<string, string>()
        {
            { DefaultFileExtension, $"{nameof(CalendarSet)} file" },
            { "json", "JSON file" },
            { "*", "All Files" }
        };

        var filterStrings = fileFilters
            .Select(ff =>
                {
                    var wildCard = $"*.{ff.Key}";

                    return $"{ff.Value} ({wildCard}){FileDialogFilterJoinChar}{wildCard}";
                }
            );

        return string.Join(FileDialogFilterJoinChar, filterStrings);
    }

    public static CalendarSet? LoadFromFile(string fileName)
    {
        var text = RunSafely.Execute(() => File.ReadAllText(fileName));

        var calendarSet = string.IsNullOrWhiteSpace(text)
            ? null
            : Parsers.CalendarSetParser.ParseFromJson(text);
        calendarSet?.SetFileName(fileName);

        return calendarSet;
    }

    public static void SaveToFile(CalendarSet calendarSet, string fileName)
    {
        var text = Parsers.CalendarSetParser.GenerateJson(calendarSet);

        File.WriteAllText(fileName, text);

        calendarSet.SetFileName(fileName);
    }
}
