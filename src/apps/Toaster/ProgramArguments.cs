using System.ComponentModel;
using DNX.Common.Services.IO;
using DNX.Extensions.Strings;
using Ookii.CommandLine;
using Ookii.CommandLine.Terminal;
using Toaster.Domain.Models.Types;

namespace Toaster;

[GeneratedParser]
[Description("Executes a target application or file by association")]
public partial class ProgramArguments
{
    [Alias("t")]
    [CommandLineArgument(IsRequired = false, DefaultValue = "")]
    public string Title { get; set; } = string.Empty;

    [Alias("m")]
    [CommandLineArgument(IsRequired = false)]
    public required string MessageText { get; set; }

    [Alias("ft")]
    [CommandLineArgument(IsRequired = false, DefaultValue = ToastFormType.BuiltIn)]
    public ToastFormType FormType { get; set; } = ToastFormType.BuiltIn;

    [Alias("dfn")]
    [CommandLineArgument(IsRequired = false)]
    public string? DefinitionFileName { get; set; }

    [Alias("dt")]
    [CommandLineArgument(IsRequired = false)]
    public string? DefinitionText { get; set; }

    public string? CustomDefinitionText => !DefinitionFileName.IsNullOrWhiteSpace()
        ? FileService.ReadAllTextSafely(DefinitionFileName)
        : DefinitionText;
    public void Validate()
    {
        if (FormType == ToastFormType.CustomDraw)
        {
            if (CustomDefinitionText.IsNullOrWhiteSpace())
            {
                throw new ArgumentOutOfRangeException(nameof(DefinitionText), $"When {nameof(FormType)} is {ToastFormType.CustomDraw}, definition must be specified via {nameof(DefinitionText)} or {nameof(DefinitionFileName)}");
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
