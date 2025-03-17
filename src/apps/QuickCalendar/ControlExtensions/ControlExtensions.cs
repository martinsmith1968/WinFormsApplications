using System.Text.Json;
using Serilog;
using static System.Net.Mime.MediaTypeNames;

namespace QuickCalendar.ControlExtensions;

public static class ControlExtensions
{
    private static readonly ILogger Logger = Log.ForContext(typeof(ControlExtensions));

    public static string GenerateSizeValueText(this Control control)
    {
        var text = JsonSerializer.Serialize(control.Size);
        Logger.Information($"Recording {nameof(Control)} {control.Name} - Size: {text}");

        return text;
    }

    public static void ApplySizeValueText(this Control control, string sizeValueText)
    {
        if (string.IsNullOrEmpty(sizeValueText))
        {
            return;
        }

        try
        {
            Logger.Information($"Parsing {nameof(Control)} {control.Name} - Size: {sizeValueText}");
            var size = JsonSerializer.Deserialize<Size>(sizeValueText);

            control.Size = size;
        }
        catch (Exception ex)
        {
            Logger.Error(ex, ex.Message);
        }
    }
}
