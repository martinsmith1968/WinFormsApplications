using System.Text;
using QuickCalendar.Domain.Generators;
using QuickCalendar.Domain.Models;

// ReSharper disable IdentifierTypo

#pragma warning disable IDE1006

namespace QuickCalendar;

public partial class NotableDatesGeneratorEditorForm : Form
{
    public static bool EditNotableDatesGenerator(INotableDatesGenerator notableDatesGenerator, string displayDateTimeFormat, Form? parent = null)
    {
        var instance = new NotableDatesGeneratorEditorForm(notableDatesGenerator, displayDateTimeFormat);

        if (parent != null)
        {
            instance.Parent = parent;
        }

        var result = instance.ShowDialog();

        return result == DialogResult.OK;
    }

    public INotableDatesGenerator NotableDatesGenerator { get; }
    public string DisplayDateTimeFormat { get; }

    private void LoadNotableDateGeneratorDetails()
    {
        if (NotableDatesGenerator is NotableDatesFixedDateGenerator notableDatesFixedDateGenerator)
        {
            dtpFixedDateGeneratorDate.Value = notableDatesFixedDateGenerator.Date;
        }
        else if (NotableDatesGenerator is NotableDatesStartDateEndDateGenerator notableDatesStartDateEndDateGenerator)
        {
            dtpStartDateEndDateGeneratorStartDate.Value = notableDatesStartDateEndDateGenerator.StartDate;
            dtpStartDateEndDateGeneratorEndDate.Value = notableDatesStartDateEndDateGenerator.EndDate;
            nudStartDateEndDateGeneratorIntervalValue.Value = notableDatesStartDateEndDateGenerator.IntervalPeriod.Value;
            cboStartDateEndDateGeneratorIntervalType.SelectedItem = notableDatesStartDateEndDateGenerator.IntervalPeriod.IntervalType;
        }
        else if (NotableDatesGenerator is NotableDatesStartDateRepeatCountGenerator notableDatesStartDateRepeatCountGenerator)
        {
            dtpStartDateRepeatCountGeneratorStartDate.Value = notableDatesStartDateRepeatCountGenerator.StartDate;
            nudStartDateRepeatCountGeneratorRepeatCount.Value = notableDatesStartDateRepeatCountGenerator.RepeatCount;
            nudStartDateEndDateGeneratorIntervalValue.Value = notableDatesStartDateRepeatCountGenerator.IntervalPeriod.Value;
            cboStartDateEndDateGeneratorIntervalType.SelectedItem = notableDatesStartDateRepeatCountGenerator.IntervalPeriod.IntervalType;
        }

        foreach (TabPage tab in tbcEditors.TabPages)
        {
            if ((Type)tab.Tag == NotableDatesGenerator.GetType())
            {
                tbcEditors.SelectedTab  = tab;
                break;
            }
        }

        PopulateGeneratedDates();
    }

    private void PopulateGeneratedDates()
    {
        lvwGeneratedDates.Items.Clear();

        foreach (var notableDate in NotableDatesGenerator.Generate())
        {
            var item = lvwGeneratedDates.Items.Add(notableDate.Date.ToString(DisplayDateTimeFormat));
            item.SubItems.Add(notableDate.Description);
        }
    }

    private IList<string[]> BuildDatesListData()
    {
        var list = new List<string[]>();

        var row = new List<string>();
        foreach (ColumnHeader col in lvwGeneratedDates.Columns)
        {
            row.Add(col.Text);
        }
        list.Add(row.ToArray());

        foreach (ListViewItem item in lvwGeneratedDates.Items)
        {
            row.Clear();
            foreach (ListViewItem.ListViewSubItem subItem in item.SubItems)
            {
                row.Add(subItem.Text);
            }

            list.Add(row.ToArray());
        }

        return list;
    }

    private static string BuildSeparatedText(IEnumerable<string[]> data, char separator=',')
    {
        var text = new StringBuilder();

        foreach (var row in data)
        {
            char? sep = null;
            foreach (var col in row)
            {
                text.Append(sep);
                text.Append(col);

                sep = separator;
            }
            text.AppendLine();
        }

        return text.ToString();
    }

    private NotableDatesGeneratorEditorForm(INotableDatesGenerator notableDatesGenerator, string displayDateTimeFormat)
    {
        NotableDatesGenerator = notableDatesGenerator;
        DisplayDateTimeFormat = displayDateTimeFormat;

        InitializeComponent();
    }

    private void DateGeneratorEditorForm_Load(object sender, EventArgs e)
    {
        tbcEditors.Dock = DockStyle.Fill;
        lvwGeneratedDates.Dock = DockStyle.Fill;

        tabEditorFixedDateGenerator.Tag = typeof(NotableDatesFixedDateGenerator);
        tabEditorStartDateEndDateGenerator.Tag = typeof(NotableDatesStartDateEndDateGenerator);
        tabEditorStartDateRepeatCountGenerator.Tag = typeof(NotableDatesStartDateRepeatCountGenerator);

        foreach (var intervalType in Enum.GetValues<IntervalType>())
        {
            cboStartDateEndDateGeneratorIntervalType.Items.Add(intervalType);
        }

        LoadNotableDateGeneratorDetails();
    }

    private void dtpFixedDateGeneratorDate_ValueChanged(object sender, EventArgs e)
    {
        PopulateGeneratedDates();
    }

    private void dtpStartDateEndDateGeneratorStartDate_ValueChanged(object sender, EventArgs e)
    {
        PopulateGeneratedDates();
    }

    private void dtpStartDateEndDateGeneratorEndDate_ValueChanged(object sender, EventArgs e)
    {
        PopulateGeneratedDates();
    }

    private void nudStartDateEndDateGeneratorIntervalValue_ValueChanged(object sender, EventArgs e)
    {
        PopulateGeneratedDates();
    }

    private void cboStartDateEndDateGeneratorIntervalType_SelectedIndexChanged(object sender, EventArgs e)
    {
        PopulateGeneratedDates();
    }

    private void ctxmnuDatesListCopy_Click(object sender, EventArgs e)
    {
        var text = BuildSeparatedText(BuildDatesListData());

        Clipboard.SetText(text);
    }

    private void dtpStartDateRepeatCountGeneratorStartDate_ValueChanged(object sender, EventArgs e)
    {
        PopulateGeneratedDates();
    }

    private void nudStartDateRepeatCountGeneratorRepeatCount_ValueChanged(object sender, EventArgs e)
    {
        PopulateGeneratedDates();
    }

    private void nudStartDateRepeatCountGeneratorInterval_ValueChanged(object sender, EventArgs e)
    {
        PopulateGeneratedDates();
    }

    private void cboStartDateRepeatCountGeneratorInterval_SelectedIndexChanged(object sender, EventArgs e)
    {
        PopulateGeneratedDates();
    }
}
