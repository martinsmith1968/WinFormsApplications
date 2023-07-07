using QuickCalendar.Domain.Extensions;
using QuickCalendar.Domain.Generators;
using QuickCalendar.Domain.Models;
using QuickCalendar.Extensions;
using QuickCalendar.Models;

#pragma warning disable IDE1006

namespace QuickCalendar;

public partial class CalendarDetailsForm : Form
{
    private List<ComboboxItem<DayOfWeek?>> _dayOfWeekItems = new();
    private List<ComboboxItem<int?>> _firstVisibleMonthItems = new();

    public CalendarSet CalendarSet { get; private init; } = CalendarSet.Default;

    public CalendarDetailsForm()
    {
        InitializeComponent();
    }

    public static bool EditCalendarSet(CalendarSet calendarSet, Form? form = null)
    {
        var instance = new CalendarDetailsForm()
        {
            CalendarSet = calendarSet
        };

        if (form != null)
        {
            instance.Parent = form;
        }

        var result = instance.ShowDialog();

        return result == DialogResult.OK;
    }

    private void ShowErrorMessage(string? text = null)
    {
        text = string.IsNullOrWhiteSpace(text)
            ? text
            : $"Error: {text}";

        lblErrorText.Text = text;

        timerErrorMessageReset.Interval = Convert.ToInt32(TimeSpan.FromSeconds(5).TotalMilliseconds);
        timerErrorMessageReset.Enabled = true;
    }

    private bool ValidateForm()
    {
        if (string.IsNullOrWhiteSpace(txtDetailsName.Text))
        {
            ShowErrorMessage($"{lblDetailsName.Text} must be specified");
            txtDetailsName.SetFocusTo();
            return false;
        }

        return true;
    }

    private void LoadStaticData()
    {
        _dayOfWeekItems = Enum.GetValues<DayOfWeek>()
            .Select(e => new ComboboxItem<DayOfWeek?>(e.ToString(), e))
            .ToList();
        _dayOfWeekItems.Insert(0, new ComboboxItem<DayOfWeek?>("(Locale Default)", null));

        _firstVisibleMonthItems = Enumerable.Range(1, 12)
            .Select(v =>
            {
                var dt = new DateTime(DateTime.UtcNow.Year, v, 1);
                return new ComboboxItem<int?>(dt.ToString("MMMM"), dt.Month);
            })
            .ToList();
        _firstVisibleMonthItems.Insert(0, new ComboboxItem<int?>("(Not Set)", null));

        cboVisualsFirstDayOfWeek.Items.Clear();
        _dayOfWeekItems.ForEach(i => cboVisualsFirstDayOfWeek.Items.Add(i));

        cboVisualsFirstVisibleMonth.Items.Clear();
        _firstVisibleMonthItems.ForEach(i => cboVisualsFirstVisibleMonth.Items.Add(i));
    }

    private void LoadCalendarSetToForm(CalendarSet calendarSet)
    {
        // Details
        txtDetailsName.Text = calendarSet.Name;
        txtDetailsDescription.Text = calendarSet.Description;
        txtDisplayFont.Font = calendarSet.GetFont();
        txtDisplayFont.Text = $"{txtDisplayFont.Font.Name}, {txtDisplayFont.Font.Size} pt";
        dtpDetailsMinimumDate.Value = DateTimeExtensions.MaxOf(calendarSet.MinimumDate, dtpDetailsMinimumDate.MinDate);
        dtpDetailsMaximumDate.Value = DateTimeExtensions.MinOf(calendarSet.MaximumDate, dtpDetailsMaximumDate.MaxDate);
        txtDetailsDateDisplayFormat.Text = calendarSet.DateDisplayFormat;

        // Visual Details
        chkVisualsShowWeekNumbers.Checked = calendarSet.VisualDetails.ShowWeekNumbers;
        chkVisualsShowToday.Checked = calendarSet.VisualDetails.ShowToday;
        chkVisualsShowTodayCircle.Checked = calendarSet.VisualDetails.ShowTodayCircle;

        cboVisualsFirstDayOfWeek.SelectedItem = _dayOfWeekItems
                                                    .FirstOrDefault(x => x.Value == calendarSet.VisualDetails.FirstDayOfWeek)
                                                ?? cboVisualsFirstDayOfWeek.Items[0];

        chkVisualsCloseOnEscape.Checked = calendarSet.VisualDetails.CloseOnEscape;

        cboVisualsFirstVisibleMonth.SelectedItem = _firstVisibleMonthItems
                                                       .FirstOrDefault(x => x.Value == calendarSet.VisualDetails.FirstVisibleMonth)
                                                   ?? cboVisualsFirstVisibleMonth.Items[0];

        // Dates
        lvwDatesNotableDates.Items.Clear();
        foreach (var notableDatesGenerator in calendarSet.Dates.AllDatesGenerators)
        {
            var item = lvwDatesNotableDates.Items.Add(notableDatesGenerator.Item1);
            item.SubItems.Add(notableDatesGenerator.Item2.Generate().Count.ToString());
            item.SubItems.Add(notableDatesGenerator.Item2.GetDefinitionText());
            item.Tag = notableDatesGenerator.Item2;
        }
    }

    private void SaveFormToCalendarSet(CalendarSet calendarSet)
    {
        // Details
        calendarSet.Description = txtDetailsDescription.Text;
        calendarSet.DisplayFontName = txtDisplayFont.Font.Name;
        calendarSet.DisplayFontSize = txtDisplayFont.Font.Size;
        calendarSet.MinimumDate = dtpDetailsMinimumDate.Value;
        calendarSet.MaximumDate = dtpDetailsMaximumDate.Value;
        calendarSet.DateDisplayFormat = txtDetailsDateDisplayFormat.Text;

        // Visual Details
        calendarSet.VisualDetails.ShowWeekNumbers = chkVisualsShowWeekNumbers.Checked;
        calendarSet.VisualDetails.ShowToday = chkVisualsShowToday.Checked;
        calendarSet.VisualDetails.ShowTodayCircle = chkVisualsShowTodayCircle.Checked;
        calendarSet.VisualDetails.FirstDayOfWeek = (cboVisualsFirstDayOfWeek.SelectedItem as ComboboxItem<DayOfWeek?>)?.Value;
        calendarSet.VisualDetails.CloseOnEscape = chkVisualsCloseOnEscape.Checked;
        calendarSet.VisualDetails.FirstVisibleMonth = (cboVisualsFirstVisibleMonth.SelectedItem as ComboboxItem<int?>)?.Value;
    }

    private void ApplicationOnIdle(object? sender, EventArgs e)
    {
        var isItemSelected = lvwDatesNotableDates.SelectedIndices.Count > 0;
        var isTop = lvwDatesNotableDates.SelectedIndices.Count == 1 && lvwDatesNotableDates.SelectedIndices[0] == 0;
        var isBottom = lvwDatesNotableDates.SelectedIndices.Count == 1 && lvwDatesNotableDates.SelectedIndices[0] == lvwDatesNotableDates.Items.Count - 1;

        tsctxDatesRemove.Enabled = isItemSelected;
        tsctxDatesEdit.Enabled = isItemSelected;
        tsctxDatesMoveUp.Enabled = isItemSelected && !isTop;
        tsctxDatesMoveDown.Enabled = isItemSelected && !isBottom;
    }

    private void CalendarDetailsForm_Load(object sender, EventArgs e)
    {
        Application.Idle += ApplicationOnIdle;

        lblErrorText.BorderStyle = BorderStyle.None;
        ShowErrorMessage();

        tbcEditor.Dock = DockStyle.Fill;
        lvwDatesNotableDates.Dock = DockStyle.Fill;

        tbcEditor.SelectedTab = tbcEditor.TabPages[0];

        lblDetailsExampleDateDisplayFormat.BorderStyle = BorderStyle.None;
        dtpDetailsMinimumDate.MinDate = DateTime.MinValue;
        dtpDetailsMinimumDate.MaxDate = DateTime.MaxValue;
        dtpDetailsMaximumDate.MinDate = DateTime.MinValue;
        dtpDetailsMaximumDate.MaxDate = DateTime.MaxValue;

        LoadStaticData();

        LoadCalendarSetToForm(CalendarSet);
    }

    private void CalendarDetailsForm_FormClosed(object sender, FormClosedEventArgs e)
    {
        Application.Idle -= ApplicationOnIdle;
    }

    private void txtDetailsName_Enter(object sender, EventArgs e)
    {
        txtDetailsName.SelectAll();
    }

    private void txtDateDisplayFormat_TextChanged(object sender, EventArgs e)
    {
        try
        {
            lblDetailsExampleDateDisplayFormat.Text = DateTime.UtcNow.ToString(txtDetailsDateDisplayFormat.Text);
        }
        catch (Exception ex)
        {
            ShowErrorMessage(ex.Message);
        }
    }

    private void lvwDatesNotableDates_DoubleClick(object sender, EventArgs e)
    {
        tsctxDatesEdit.PerformClick();
    }

    private void btnOK_Click(object sender, EventArgs e)
    {
        if (!ValidateForm())
        {
            return;
        }

        SaveFormToCalendarSet(CalendarSet);

        DialogResult = DialogResult.OK;
    }

    private void tsctxDatesAdd_Click(object sender, EventArgs e)
    {
        //
    }

    private void tsctxDatesRemove_Click(object sender, EventArgs e)
    {
        if (lvwDatesNotableDates.SelectedItems.Count != 1)
            return;

        var item = lvwDatesNotableDates.SelectedItems[0];
        lvwDatesNotableDates.Items.Remove(item);
    }

    private void tsctxDatesEdit_Click(object sender, EventArgs e)
    {
        if (lvwDatesNotableDates.SelectedItems.Count != 1)
            return;

        var item = (lvwDatesNotableDates.SelectedItems[0].Tag as INotableDatesGenerator);
        if (item == null)
            return;

        var result = NotableDatesGeneratorEditorForm.EditNotableDatesGenerator(item, CalendarSet.DateDisplayFormat);
    }

    private void tsctxDatesMoveUp_Click(object sender, EventArgs e)
    {
        if (lvwDatesNotableDates.SelectedItems.Count != 1)
            return;

        var item = lvwDatesNotableDates.SelectedItems[0];
        var index = item.Index - 1;
        lvwDatesNotableDates.Items.RemoveAt(item.Index);
        lvwDatesNotableDates.Items.Insert(index, item);
    }

    private void tsctxDatesMoveDown_Click(object sender, EventArgs e)
    {
        if (lvwDatesNotableDates.SelectedItems.Count != 1)
            return;

        var item = lvwDatesNotableDates.SelectedItems[0];
        var index = item.Index + 1;
        lvwDatesNotableDates.Items.RemoveAt(item.Index);
        lvwDatesNotableDates.Items.Insert(index, item);
    }

    private void timerErrorMessageReset_Tick(object sender, EventArgs e)
    {
        ShowErrorMessage();
        timerErrorMessageReset.Enabled = false;
    }

    private void btnSetDisplayFont_Click(object sender, EventArgs e)
    {
        dlgFontBrowser.Font = txtDisplayFont.Font;
        if (dlgFontBrowser.ShowDialog() == DialogResult.OK)
        {
            CalendarSet.DisplayFontName = dlgFontBrowser.Font.Name;
            CalendarSet.DisplayFontSize = dlgFontBrowser.Font.Size;
            txtDisplayFont.Font = CalendarSet.GetFont();
        }
    }
}
