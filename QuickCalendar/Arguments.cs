using Ookii.CommandLine;

namespace QuickCalendar;

public class Arguments
{
    [Alias("n")]
    [Alias("name")]
    [CommandLineArgument(IsRequired = false, ValueDescription = "The name of a calendar to open with")]
    public string? CalendarName { get; set; }
}
