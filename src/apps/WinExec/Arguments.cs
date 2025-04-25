using System.ComponentModel;
using Ookii.CommandLine;
using Ookii.CommandLine.Terminal;

namespace WinExec;

[GeneratedParser]
[Description("Executes a target application or file by association")]
public partial class Arguments
{
    [Alias("f")]
    [Alias("file")]
    [Description("The name of the application to start or the name of a document of a file type that is associated with an application and that has a default open action available to it. The default is an empty string")]
    [CommandLineArgument(IsRequired = true)]
    public required string FileName { get; set; }

    [Alias("v")]
    [Description("The action to take with the file that the process opens. The default is an empty string which signifies no action.")]
    [CommandLineArgument(IsRequired = false, DefaultValue = "")]
    public string? Verb { get; set; }

    [Alias("use")]
    [Description("true if the shell should be used when starting the process; false if the process should be created directly from the executable file.")]
    [CommandLineArgument(IsRequired = false, DefaultValue = false)]
    public bool UseShellExecute { get; set; }

    public void Validate()
    {
        // TODO: Implement when necessary
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
