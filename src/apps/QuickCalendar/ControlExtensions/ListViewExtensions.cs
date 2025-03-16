using Serilog;

namespace QuickCalendar.ControlExtensions;

public static class ListViewExtensions
{
    private static readonly ILogger Logger = Log.ForContext(typeof(ListViewExtensions));

    private const char ElementSeparator = '|';

    public static string GenerateColumnSizesValueText(this ListView listView)
    {
        var columnDetailsList = listView.Columns
            .Cast<ColumnHeader>()
            .Select(column => new ListViewColumnDetails(column))
            .ToList();

        var text = string.Join(ElementSeparator, columnDetailsList.Select(lvcd => lvcd.GetDefinitionText()));
        Logger.Information($"Recording {nameof(ListView)} {listView.Name} - ColumnSizes: {text}");

        return text;
    }

    public static void ApplyColumnSizesValueText(this ListView listView, string columnSizesValueText)
    {
        if (string.IsNullOrEmpty(columnSizesValueText))
        {
            return;
        }

        Logger.Information($"Parsing {nameof(ListView)} {listView.Name} - ColumnSizes: {columnSizesValueText}");

        var columnDetailsList = columnSizesValueText
            .Split(ElementSeparator)
            .Select(ListViewColumnDetails.FromDefinitionText)
            .Where(x => x != null)
            .ToList();

        foreach (var columnHeader in listView.Columns.Cast<ColumnHeader>())
        {
            var columnDetails = columnDetailsList.FirstOrDefault(cd =>
                cd?.Index == columnHeader.Index
                && cd.Text == columnHeader.Text);
            if (columnDetails == null)
            {
                continue;
            }

            columnHeader.DisplayIndex = columnDetails.DisplayIndex;
            columnHeader.Text = columnDetails.Text;
            columnHeader.Width = columnDetails.Width;
        }
    }
}
