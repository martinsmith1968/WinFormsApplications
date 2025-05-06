using System.ComponentModel;
using DNX.Common.IO;
using DNX.Extensions.Strings;
using Ookii.CommandLine;
using Ookii.CommandLine.Terminal;

namespace TaskbarAlert;

[GeneratedParser]
[Description("Executes a target application or file by association")]
public partial class ProgramArguments
{

















    public void Validate()
    {
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
