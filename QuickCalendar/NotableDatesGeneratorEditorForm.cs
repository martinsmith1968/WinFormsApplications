using System.Text;
using QuickCalendar.Domain.Extensions;
using QuickCalendar.Domain.Generators;
using QuickCalendar.Domain.Models.Types;

// ReSharper disable IdentifierTypo

#pragma warning disable IDE1006

namespace QuickCalendar;

public partial class NotableDatesGeneratorEditorForm : Form
{
    private readonly NotableDatesFixedDateGenerator _notableDatesFixedDateGenerator = new();
    private readonly NotableDatesStartDateEndDateGenerator _notableDatesStartDateEndDateGenerator = new();
    private readonly NotableDatesStartDateRepeatCountGenerator _notableDatesStartDateRepeatCountGenerator = new();

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
            _notableDatesFixedDateGenerator.CopyFrom(notableDatesFixedDateGenerator);

            dtpFixedDateGeneratorDate.Value = _notableDatesFixedDateGenerator.Date;
        }
        else if (NotableDatesGenerator is NotableDatesStartDateEndDateGenerator notableDatesStartDateEndDateGenerator)
        {
            _notableDatesStartDateEndDateGenerator.CopyFrom(notableDatesStartDateEndDateGenerator);

            dtpStartDateEndDateGeneratorStartDate.Value = _notableDatesStartDateEndDateGenerator.StartDate;
            dtpStartDateEndDateGeneratorEndDate.Value = _notableDatesStartDateEndDateGenerator.EndDate;
            nudStartDateEndDateGeneratorIntervalValue.Value = _notableDatesStartDateEndDateGenerator.IntervalPeriod.Value;
            cboStartDateEndDateGeneratorIntervalType.SelectedItem = _notableDatesStartDateEndDateGenerator.IntervalPeriod.IntervalPeriodType;
        }
        else if (NotableDatesGenerator is NotableDatesStartDateRepeatCountGenerator notableDatesStartDateRepeatCountGenerator)
        {
            _notableDatesStartDateRepeatCountGenerator.CopyFrom(notableDatesStartDateRepeatCountGenerator);

            dtpStartDateRepeatCountGeneratorStartDate.Value = _notableDatesStartDateRepeatCountGenerator.StartDate;
            nudStartDateRepeatCountGeneratorRepeatCount.Value = _notableDatesStartDateRepeatCountGenerator.RepeatCount;
            nudStartDateEndDateGeneratorIntervalValue.Value = _notableDatesStartDateRepeatCountGenerator.IntervalPeriod.Value;
            cboStartDateEndDateGeneratorIntervalType.SelectedItem = _notableDatesStartDateRepeatCountGenerator.IntervalPeriod.IntervalPeriodType;
        }

        tbcEditors.SelectedIndex = 0;
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
        lblGeneratedDatesDisplay.Text = string.Empty;

        INotableDatesGenerator? generator = null;
        if (tbcEditors.SelectedTab == tabEditorFixedDateGenerator)
            generator = _notableDatesFixedDateGenerator;
        else if (tbcEditors.SelectedTab == tabEditorStartDateEndDateGenerator)
            generator = _notableDatesStartDateEndDateGenerator;
        else if (tbcEditors.SelectedTab == tabEditorStartDateRepeatCountGenerator)
            generator = _notableDatesStartDateRepeatCountGenerator;

        if (generator == null)
            return; // TODO: Display error somewhere

        var notableDates = generator.Generate();
        lblGeneratedDatesDisplay.Text = $"{notableDates.Count} Dates generated";

        foreach (var notableDate in notableDates)
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
        lblGeneratedDatesDisplay.BorderStyle = BorderStyle.None;

        tabEditorFixedDateGenerator.Tag = typeof(NotableDatesFixedDateGenerator);
        tabEditorStartDateEndDateGenerator.Tag = typeof(NotableDatesStartDateEndDateGenerator);
        tabEditorStartDateRepeatCountGenerator.Tag = typeof(NotableDatesStartDateRepeatCountGenerator);

        foreach (var intervalType in Enum.GetValues<IntervalPeriodType>())
        {
            cboStartDateEndDateGeneratorIntervalType.Items.Add(intervalType);
        }

        LoadNotableDateGeneratorDetails();
    }

    private void ctxmnuDatesListCopy_Click(object sender, EventArgs e)
    {
        var text = BuildSeparatedText(BuildDatesListData());

        Clipboard.SetText(text);
    }

    private void dtpFixedDateGeneratorDate_ValueChanged(object sender, EventArgs e)
    {
        _notableDatesFixedDateGenerator.Date = dtpFixedDateGeneratorDate.Value;
        PopulateGeneratedDates();
    }

    private void dtpStartDateEndDateGeneratorStartDate_ValueChanged(object sender, EventArgs e)
    {
        _notableDatesStartDateEndDateGenerator.StartDate = dtpStartDateEndDateGeneratorStartDate.Value;
        PopulateGeneratedDates();
    }

    private void dtpStartDateEndDateGeneratorEndDate_ValueChanged(object sender, EventArgs e)
    {
        _notableDatesStartDateEndDateGenerator.EndDate = dtpStartDateEndDateGeneratorEndDate.Value;
        PopulateGeneratedDates();
    }

    private void nudStartDateEndDateGeneratorIntervalValue_ValueChanged(object sender, EventArgs e)
    {
        _notableDatesStartDateEndDateGenerator.IntervalPeriod.Value = nudStartDateEndDateGeneratorIntervalValue.Value.ToUInt32();
        PopulateGeneratedDates();
    }

    private void cboStartDateEndDateGeneratorIntervalType_SelectedIndexChanged(object sender, EventArgs e)
    {
        _notableDatesStartDateEndDateGenerator.IntervalPeriod.IntervalPeriodType = Enum.Parse<IntervalPeriodType>(cboStartDateEndDateGeneratorIntervalType.SelectedItem?.ToString() ?? string.Empty);
        PopulateGeneratedDates();
    }

    private void dtpStartDateRepeatCountGeneratorStartDate_ValueChanged(object sender, EventArgs e)
    {
        _notableDatesStartDateRepeatCountGenerator.StartDate = dtpStartDateRepeatCountGeneratorStartDate.Value;
        PopulateGeneratedDates();
    }

    private void nudStartDateRepeatCountGeneratorRepeatCount_ValueChanged(object sender, EventArgs e)
    {
        _notableDatesStartDateRepeatCountGenerator.RepeatCount = nudStartDateRepeatCountGeneratorRepeatCount.Value.ToInt32();
        PopulateGeneratedDates();
    }

    private void nudStartDateRepeatCountGeneratorInterval_ValueChanged(object sender, EventArgs e)
    {
        _notableDatesStartDateRepeatCountGenerator.IntervalPeriod.Value = nudStartDateRepeatCountGeneratorInterval.Value.ToUInt32();
        PopulateGeneratedDates();
    }

    private void cboStartDateRepeatCountGeneratorInterval_SelectedIndexChanged(object sender, EventArgs e)
    {
        _notableDatesStartDateRepeatCountGenerator.IntervalPeriod.IntervalPeriodType = Enum.Parse<IntervalPeriodType>(cboStartDateRepeatCountGeneratorInterval.SelectedItem?.ToString() ?? string.Empty);
        PopulateGeneratedDates();
    }
}
