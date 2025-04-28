using System.ComponentModel;
using System.Diagnostics;
using DNX.Extensions.Strings;
using Ookii.CommandLine;
using Ookii.CommandLine.Terminal;

namespace WinExec;

[GeneratedParser]
[Description("Executes a target application or file by association")]
public partial class ProgramArguments
{
    [Description("The name of the application to start or the name of a document of a file type that is associated with an application and that has a default open action available to it. The default is an empty string")]
    [CommandLineArgument(Position = 1)]
    public required string FileName { get; set; }

    [Description("The name of the application to start or the name of a document of a file type that is associated with an application and that has a default open action available to it. The default is an empty string")]
    [CommandLineArgument(Position = 2, IsRequired = false)]
    public string[] Arguments { get; set; } = [];

    [Alias("d")]
    [Alias("dir")]
    [Description("When the ProcessStartlnfo.UseShellExecute property is false, gets or sets the working directory for the process to be started. When ProcessStartlnfo.UseShellExecute is true, gets or sets the directory that contains\r\nthe process to be started.")]
    [CommandLineArgument(IsRequired = false, DefaultValue = null)]
    public string? WorkingDirectory { get; set; }

    [Alias("v")]
    [Description("The action to take with the file that the process opens. The default is an empty string which signifies no action.")]
    [CommandLineArgument(IsRequired = false, DefaultValue = "")]
    public string? Verb { get; set; }

    [Alias("use")]
    [Description("true if the shell should be used when starting the process; false if the process should be created directly from the executable file.")]
    [CommandLineArgument(IsRequired = false, DefaultValue = null)]
    public bool? UseShellExecute { get; set; }

    [Alias("ws")]
    [Description("One of the enumeration values that indicates whether the process is stated in a window that is maximized, minimized, normal (neither maximized nor minimized), or not visible. The default is Normal.")]
    [CommandLineArgument(IsRequired = false, DefaultValue = ProcessWindowStyle.Normal)]
    public ProcessWindowStyle WindowStyle { get; set; }

    [Alias("hn")]
    [Alias("nonotify")]
    [Description("Do not show a Toast Notification when launching")]
    [CommandLineArgument(IsRequired = false, DefaultValue = false)]
    public bool NoNotification { get; set; }

    [Alias("na")]
    [Description("Do not play a sound when the notification shows")]
    [CommandLineArgument(IsRequired = false, DefaultValue = false)]
    public bool NoAlert { get; set; }

    public void Validate()
    {
        if (!UseShellExecute.HasValue)
        {
            UseShellExecute = FindAppOnPath(FileName, WorkingDirectory) == null;
        }
    }

    public ProcessStartInfo GetStartInfo()
    {
        return new ProcessStartInfo(FileName)
        {
            Arguments = string.Join(
                " ",
                Arguments
                    .Select(
                        a => a.Contains(' ')
                            ? a.EnsureStartsAndEndsWith("\"")
                            : a
                    )
            ),
            Verb = Verb,
            UseShellExecute = UseShellExecute ?? false,
            WorkingDirectory = WorkingDirectory,
            WindowStyle = WindowStyle,
            // TODO: complete
        };
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

    public static CommandLineParser<ProgramArguments> GetParser() => CreateParser(Options);

    public static UsageWriter? GetUsageWriter(bool useColor)
    {
        return new UsageWriter();
    }

    public static string GetUsage(bool useColor)
    {
        return GetParser().GetUsage(GetUsageWriter(useColor));
    }
}
