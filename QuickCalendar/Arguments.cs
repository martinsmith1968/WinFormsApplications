using System.ComponentModel;
using Ookii.CommandLine;
using Ookii.CommandLine.Terminal;

namespace QuickCalendar;

[GeneratedParser]
[Description("Reads a file and displays the contents on the command line.")]
public partial class Arguments
{
    [Alias("f")]
    [Alias("file")]
    [Description("The name of a calendar to open with")]
    [CommandLineArgument(IsRequired = false)]
    public string? FileName { get; set; }

    public bool HasFileName => !string.IsNullOrEmpty(FileName);

    public void Validate()
    {
        if (HasFileName)
        {
            if (!File.Exists(FileName))
            {
                throw new ArgumentOutOfRangeException(nameof(FileName), $"File: '{FileName}' does not exist");
            }
        }
    }

    public static readonly ParseOptions Options = new()
    {
        ArgumentNameComparison = StringComparison.OrdinalIgnoreCase,
        AutoHelpArgument       = true,
        AutoVersionArgument    = true,
        DuplicateArguments     = ErrorMode.Allow,
        ErrorColor             = TextFormat.BrightForegroundRed,
        ShowUsageOnError       = UsageHelpRequest.Full,
        WarningColor           = TextFormat.BrightForegroundYellow,
    };
}
