using System.Text.Json;
using System.Windows.Forms;
using Serilog;

namespace QuickCalendar.ControlExtensions;

internal class ListViewColumnDetails
{
    private static readonly ILogger Logger = Log.ForContext(typeof(ListViewColumnDetails));

    public ListViewColumnDetails()
    {
    }

    public ListViewColumnDetails(ColumnHeader columnHeader)
    {
        Index = columnHeader.Index;
        DisplayIndex = columnHeader.DisplayIndex;
        Text = columnHeader.Text;
        Width = columnHeader.Width;
    }

    public int Index { get; set; }
    public int DisplayIndex { get; set; }
    public string Text { get; set; } = string.Empty;
    public int Width { get; set; }

    public string GetDefinitionText()
    {
        var text = JsonSerializer.Serialize(this);
        Logger.Information($"Recording {nameof(ListViewColumnDetails)} {Index}:{Text} - Definition: {text}");

        return text;
    }

    public static ListViewColumnDetails? FromDefinitionText(string definitionText)
    {
        try
        {
            Logger.Information($"Parsing {nameof(ListViewColumnDetails)} - Definition: {definitionText}");
            return JsonSerializer.Deserialize<ListViewColumnDetails>(definitionText);
        }
        catch (Exception ex)
        {
            Logger.Error(ex, ex.Message);
            return null;
        }
    }
}
