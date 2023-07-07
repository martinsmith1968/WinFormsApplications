using System.Diagnostics;
using DNX.Helpers.Assemblies;
using QuickCalendar.Domain.Models;
using QuickCalendar.Extensions;

// ReSharper disable LocalizableElement
// ReSharper disable IdentifierTypo

#pragma warning disable IDE1006

namespace QuickCalendar;

public partial class MainForm : Form
{
    public CalendarSet CalendarSet { get; private set; } = new(CalendarSet.DefaultName);

    public MainForm()
    {
        InitializeComponent();
    }

    private void SetupFormControls()
    {
        mcalCalendar.Dock = DockStyle.Fill;
        mcalCalendar.MaxSelectionCount = int.MaxValue;

        tsbtnFileExit.ToolTipText = tsmnuFileExit.ToolTipText;
        tsbtnEditCalendar.ToolTipText = tsmnuEditCalendar.ToolTipText;
        tsbtnEditProgramOptions.ToolTipText = tsmnuEditProgramOptions.ToolTipText;
        tsbtnViewToday.ToolTipText = tsmnuViewToday.ToolTipText;
        tsbtnViewJumpToDate.ToolTipText = tsmnuViewJumpToDate.ToolTipText;
        tsbtnViewResize.ToolTipText = tsmnuViewResize.ToolTipText;
        tsbtnHelpAbout.ToolTipText = tsmnuHelpAbout.ToolTipText;
    }

    public void SetCalendarSet(CalendarSet calendarSet)
    {
        CalendarSet = calendarSet;
    }

    public void LoadCalendarSet(CalendarSet calendarSet)
    {
        ShowInfoText($"Loading {nameof(CalendarSet)}: {calendarSet.Name}");

        CalendarSet = calendarSet;

        mcalCalendar.Font = calendarSet.GetFont();

        tslblCalendarSetName.Text = CalendarSet.Name;
        tslblCalendarSetName.ToolTipText = calendarSet.Description;

        LoadCalendarSetVisuals(CalendarSet.VisualDetails);
        LoadCalendarSetDates(CalendarSet.Dates);

        ShowInfoText();
    }

    private void LoadCalendarSetVisuals(CalendarSetVisuals calendarSetVisuals)
    {
        mcalCalendar.ShowToday = calendarSetVisuals.ShowToday;
        mcalCalendar.ShowTodayCircle = calendarSetVisuals.ShowTodayCircle;
        mcalCalendar.ShowWeekNumbers = calendarSetVisuals.ShowWeekNumbers;

        SetCalendarDimensions(calendarSetVisuals.VisibleDimensions);

        if (calendarSetVisuals.FirstVisibleMonth.HasValue)
        {
            mcalCalendar.SuspendLayout();
            var firstDate = new DateTime(DateTime.UtcNow.Year, calendarSetVisuals.FirstVisibleMonth.Value, 1);
            SetFirstShownDate(firstDate);
            SetFirstShownDate(DateTime.UtcNow.Date);
            mcalCalendar.ResumeLayout();
        }

        if (calendarSetVisuals.FirstDayOfWeek.HasValue)
        {
            mcalCalendar.FirstDayOfWeek = Enum.Parse<Day>(calendarSetVisuals.FirstDayOfWeek.Value.ToString());
        }

        if (calendarSetVisuals.ManualWindowLocation.HasValue)
        {
            Location = calendarSetVisuals.ManualWindowLocation.Value;
        }
    }

    private void SetCalendarDimensions(Size dimensions)
    {
        ClientSize = new Size(
            (mcalCalendar.SingleMonthSize.Width * dimensions.Width) + mcalCalendar.Margin.Horizontal,
            (mcalCalendar.SingleMonthSize.Height * dimensions.Height) + tsMain.Height + ssMain.Height + mcalCalendar.Margin.Vertical
        );

        mcalCalendar.SetCalendarDimensions(dimensions.Width, dimensions.Height);
    }

    private void LoadCalendarSetDates(CalendarSetDates calendarSetDates)
    {
        mcalCalendar.BoldedDates = calendarSetDates.Dates
            .Select(d => d.Date)
            .ToArray();

        mcalCalendar.MonthlyBoldedDates = calendarSetDates.MonthlyDates
            .Select(d => d.Date)
            .ToArray();

        mcalCalendar.AnnuallyBoldedDates = calendarSetDates.AnnualDates
            .Select(d => d.Date)
            .ToArray();
    }

    private void ApplicationOnIdle(object? sender, EventArgs e)
    {
        ShowSelection();
    }

    private void ShowSelection()
    {
        var selectionCount = (mcalCalendar.SelectionRange.End - mcalCalendar.SelectionRange.Start).Days + 1;

        // Selected Day(s)
        tslblSelectedDaysRange.Text = selectionCount switch
        {
            0 => null,
            1 => $"Day {mcalCalendar.SelectionRange.Start.DayOfYear}",
            _ => $"Day {mcalCalendar.SelectionRange.Start.DayOfYear} - {mcalCalendar.SelectionRange.End.DayOfYear}"
        };
        tslblSelectedDaysRange.ToolTipText = selectionCount switch
        {
            0 => null,
            1 => $"{mcalCalendar.SelectionRange.Start.ToString(CalendarSet.DateDisplayFormat)}",
            _ => $"{mcalCalendar.SelectionRange.Start.ToString(CalendarSet.DateDisplayFormat)} - {mcalCalendar.SelectionRange.End.ToString(CalendarSet.DateDisplayFormat)}"
        };

        // Selection Count
        tslblSelectedDaysCount.Text = $"{selectionCount} Days Selected";
        tslblSelectedDaysCount.Visible = (selectionCount > 1);

        // Selected Date Descriptions
        var notableDates = CalendarSet.Dates.AllDates
            .Where(nd => nd.Date >= mcalCalendar.SelectionRange.Start && nd.Date <= mcalCalendar.SelectionRange.End)
            .ToList();

        tslblSelectedDatesDescriptions.Text = notableDates.Count switch
        {
            0 => null,
            1 => notableDates.FirstOrDefault()?.Description,
            _ => $"{notableDates.Count} Dates Selected"
        };

        tslblSelectedDatesDescriptions.ToolTipText = string.Join(
            Environment.NewLine,
            notableDates.Select(nd => $"{nd.Date.ToString(CalendarSet.DateDisplayFormat)} - {nd.Description}")
        );
    }

    private void SelectDate(DateTime dt)
    {
        SelectDates(dt, dt);
    }

    private void SelectDates(DateTime from, DateTime to)
    {
        mcalCalendar.SelectionRange = new SelectionRange(
            from < to ? from : to,
            to > from ? to : from
        );
    }

    private void SetFirstShownDate(DateTime dt)
    {
        mcalCalendar.SetDate(dt);
    }

    private void ShowInfoText(string? text = null)
    {
        tslblInfo.Text = text;
        tslblInfo.Owner.Update();
    }

    private void MainForm_Load(object sender, EventArgs e)
    {
        Application.Idle += ApplicationOnIdle;

        Text = $"{Program.AssemblyDetails.Product} v{Program.AssemblyDetails.Version.Simplify(2)}";

        SetupFormControls();

        LoadCalendarSet(CalendarSet);
    }

    private void tsmnuFileExit_Click(object sender, EventArgs e)
    {
        Close();
    }

    private void MainForm_KeyPress(object sender, KeyPressEventArgs e)
    {
        if (e.KeyChar == (char)Keys.Escape)
        {
            if (CalendarSet.VisualDetails.CloseOnEscape)
            {
                tsmnuFileExit.PerformClick();
            }
        }
    }

    private void tsmnuHelpAbout_Click(object sender, EventArgs e)
    {
        using var form = new AboutBoxForm();
        form.ShowDialog();
    }

    private void tsmnuViewToday_Click(object sender, EventArgs e)
    {
        SelectDate(DateTime.UtcNow.Date);
    }

    private void tsmnuViewJumpToDate_Click(object sender, EventArgs e)
    {
        var dateRange = new DateRange(mcalCalendar.SelectionRange.Start, mcalCalendar.SelectionRange.End);
        dateRange = DateSelectionForm.EditDateRange(dateRange);
        if (dateRange != null)
        {
            SelectDates(dateRange.StartDate, dateRange.EndDate);
        }
    }

    private void tsmnuViewResize_Click(object sender, EventArgs e)
    {
        var calendarSize = new CalendarSize(mcalCalendar.CalendarDimensions.Width, mcalCalendar.CalendarDimensions.Height, "Current");
        calendarSize = CalendarSizeForm.EditCalendarSize(calendarSize);
        if (calendarSize != null)
        {
            SetCalendarDimensions(new Size(calendarSize.Width, calendarSize.Height));
        }
    }

    private void tsmnuEditCalendar_Click(object sender, EventArgs e)
    {
        var result = CalendarDetailsForm.EditCalendarSet(CalendarSet);
        if (result)
        {
            // Reload Details
            LoadCalendarSet(CalendarSet);
        }
    }

    private void tsmnuEditProgramOptions_Click(object sender, EventArgs e)
    {
        // Show Form and react
    }

    private void tsmnuHelpUsageGuide_Click(object sender, EventArgs e)
    {
        var usageGuideUrl = "https://github.com/martinsmith1968/WinFormApplications/QuickCalendar/usage-guide";
        var ps = new ProcessStartInfo(usageGuideUrl)
        {
            UseShellExecute = true,
            Verb = "open"
        };
        Process.Start(ps);
    }
}
