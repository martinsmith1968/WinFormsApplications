 using System.Diagnostics;
using DNX.Helpers.Assemblies;
using QuickCalendar.Domain.Models;
using QuickCalendar.Domain.Models.Types;
using QuickCalendar.Domain.Repositories;
using QuickCalendar.Extensions;
using QuickCalendar.Properties;
using Timer = System.Windows.Forms.Timer;

// ReSharper disable LocalizableElement
// ReSharper disable IdentifierTypo

#pragma warning disable IDE1006

namespace QuickCalendar;

public partial class MainForm : Form
{
    public CalendarSet CalendarSet { get; private set; } = CalendarSet.Default;

    public MainForm()
    {
        InitializeComponent();
    }

    private void SetupFormControls()
    {
        mcalCalendar.Dock = DockStyle.Fill;
        mcalCalendar.MaxSelectionCount = int.MaxValue;

        // Can't set these via the UI :-(
        tsmnuViewToday.ShortcutKeys                                  = Keys.Home | Keys.Control;
        tsmnuViewJumpToPreviousMarkedDate.ShortcutKeys               = Keys.OemOpenBrackets | Keys.Control;
        tsmnuViewJumpToPreviousMarkedDate.ShortcutKeyDisplayString   = "Ctrl+[";
        tsmnuViewJumpToNextMarkedDate.ShortcutKeys                   = Keys.OemCloseBrackets | Keys.Control;
        tsmnuViewJumpToNextMarkedDate.ShortcutKeyDisplayString       = "Ctrl+]";
        tsmnuViewSelectToPreviousMarkedDate.ShortcutKeys             = Keys.OemOpenBrackets | Keys.Control | Keys.Shift;
        tsmnuViewSelectToPreviousMarkedDate.ShortcutKeyDisplayString = "Ctrl+Shift+[";
        tsmnuViewSelectToNextMarkedDate.ShortcutKeys                 = Keys.OemCloseBrackets | Keys.Control | Keys.Shift;
        tsmnuViewSelectToNextMarkedDate.ShortcutKeyDisplayString     = "Ctrl+Shift+]";

        SetupToolbarButtonFromMenuItem(tsbtnFileOpen,                     tsmnuFileOpen);
        SetupToolbarButtonFromMenuItem(tsbtnFileSave,                     tsmnuFileSave);
        SetupToolbarButtonFromMenuItem(tsbtnFileProgramOptions,           tsmnuFileProgramOptions);
        SetupToolbarButtonFromMenuItem(tsbtnFileExit,                     tsmnuFileExit);
        SetupToolbarButtonFromMenuItem(tsbtnEditCalendar,                 tsmnuEditCalendar);
        SetupToolbarButtonFromMenuItem(tsbtnViewToday,                    tsmnuViewToday);
        SetupToolbarButtonFromMenuItem(tsbtnViewJumpToDate,               tsmnuViewJumpToDate);
        SetupToolbarButtonFromMenuItem(tsbtnViewJumpToPreviousMarkedDate, tsmnuViewJumpToPreviousMarkedDate);
        SetupToolbarButtonFromMenuItem(tsbtnViewJumpToNextMarkedDate,     tsmnuViewJumpToNextMarkedDate);
        SetupToolbarButtonFromMenuItem(tsbtnViewResize,                   tsmnuViewResize);
        SetupToolbarButtonFromMenuItem(tsbtnHelpAbout,                    tsmnuHelpAbout);
    }

    private void LoadProgramOptions()
    {
        tsmnuFileExit.ShortcutKeyDisplayString = UserSettings.Default.CloseOnEscape
            ? Keys.Escape.ToString()
            : "";
    }

    private static void SetupToolbarButtonFromMenuItem(ToolStripButton button, ToolStripMenuItem menuItem)
    {
        button.Text = menuItem.Text;
        button.ToolTipText = menuItem.ToolTipText;
        button.Image = menuItem.Image;
    }

    public void LoadCalendarSet(CalendarSet calendarSet)
    {
        ShowInfoText($"Loading {nameof(CalendarSet)}: {calendarSet.Name}");

        CalendarSet = calendarSet;

        mcalCalendar.Font = calendarSet.GetFont();

        tslblCalendarSetName.Text = CalendarSet.Name;
        tslblCalendarSetName.ToolTipText = calendarSet.Description;

        switch (UserSettings.Default.GetShowCalendarNameInStatusBarType())
        {
            case CalendarSetDisplayNameType.FileNameOnly:
                tslblFileName.Text = CalendarSet.Name;                  // TODO:
                tslblFileName.ToolTipText = CalendarSet.Description;    // TODO:
                tslblFileName.Visible = true;
                break;
            case CalendarSetDisplayNameType.FullFileName:
                tslblFileName.Text = CalendarSet.Description;   // TODO:
                tslblFileName.ToolTipText = CalendarSet.Name;   // TODO:
                tslblFileName.Visible = true;
                break;
            case CalendarSetDisplayNameType.Description:
                tslblFileName.Text = CalendarSet.Description;   // TODO:
                tslblFileName.ToolTipText = CalendarSet.Name;   // TODO:
                tslblFileName.Visible = true;
                break;
            default:
                tslblFileName.Text = string.Empty;
                tslblFileName.ToolTipText = string.Empty;
                tslblFileName.Visible = false;
                break;
        }

        Text = UserSettings.Default.GetShowCalendarNameInWindowTitleType() switch
        {
            CalendarSetDisplayNameType.FileNameOnly => $"{Tag} - {CalendarSet.Name}",           // TODO:
            CalendarSetDisplayNameType.FullFileName => $"{Tag} - {CalendarSet.Description}",    // TODO:
            CalendarSetDisplayNameType.Description => $"{Tag} - {CalendarSet.Description}",
            _ => Text = Tag?.ToString()
        };

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
        EnableNavigation();
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

    private void EnableNavigation()
    {
        var hasNextMarkedDate = CalendarSet.FindNextMarkedDate(mcalCalendar.SelectionRange.End).HasValue;
        var hasPreviousMarkedDate = CalendarSet.FindPreviousMarkedDate(mcalCalendar.SelectionRange.Start).HasValue;

        tsmnuViewJumpToNextMarkedDate.Enabled       = hasNextMarkedDate;
        tsmnuViewJumpToPreviousMarkedDate.Enabled   = hasPreviousMarkedDate;
        tsmnuViewSelectToNextMarkedDate.Enabled     = hasNextMarkedDate;
        tsmnuViewSelectToPreviousMarkedDate.Enabled = hasPreviousMarkedDate;

        tsbtnViewJumpToNextMarkedDate.Enabled     = tsmnuViewJumpToNextMarkedDate.Enabled;
        tsbtnViewJumpToPreviousMarkedDate.Enabled = tsmnuViewJumpToPreviousMarkedDate.Enabled;
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

    private void ShowInfoText(string? text = null, TimeSpan? clearAfter = null)
    {
        tslblInfo.Text = text;
        tslblInfo.Owner.Update();

        if (clearAfter != null)
        {
            tmrResetStatusBar.Interval = Convert.ToInt32(clearAfter.Value.TotalMilliseconds);
            tmrResetStatusBar.Enabled = true;
        }
    }

    private void MainForm_Load(object sender, EventArgs e)
    {
        Application.Idle += ApplicationOnIdle;

        Tag = $"{Program.AssemblyDetails.Product} v{Program.AssemblyDetails.Version.Simplify(2)}";

        LoadProgramOptions();
        SetupFormControls();

        LoadCalendarSet(CalendarSet);
    }

    private void MainForm_KeyPress(object sender, KeyPressEventArgs e)
    {
        if (e.KeyChar == (char)Keys.Escape)
        {
            if (UserSettings.Default.CloseOnEscape)
            {
                tsmnuFileExit.PerformClick();
                e.Handled = true;
            }
        }
    }

    private void tsmnuFileOpen_Click(object sender, EventArgs e)
    {
        dlgOpenFile.DefaultExt                   = CalendarSetRepository.DefaultFileExtension;
        dlgOpenFile.AddExtension                 = true;
        dlgOpenFile.RestoreDirectory             = true;
        dlgOpenFile.SupportMultiDottedExtensions = true;
        dlgOpenFile.Multiselect                  = false;
        dlgOpenFile.CheckFileExists              = true;
        dlgOpenFile.CheckPathExists              = true;
        dlgOpenFile.ShowHelp                     = true;
        dlgOpenFile.AutoUpgradeEnabled           = true;
        dlgOpenFile.Filter                       = CalendarSetRepository.BuildFileDialogFileFilters();
        dlgOpenFile.FilterIndex                  = 0;

        if (dlgOpenFile.ShowDialog() != DialogResult.OK)
            return;

        var fileName = dlgOpenFile.FileName;

        try
        {
            var calendarSet = CalendarSetRepository.LoadFromFile(fileName);
            if (calendarSet == null)
                throw new Exception($"Unable to load file : {fileName}");

            LoadCalendarSet(calendarSet);

            UserSettings.Default.Update(x => x.LastOpenedFileName = fileName);
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message, Program.AssemblyDetails.Title, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void tsmnuFileSave_Click(object sender, EventArgs e)
    {
        var fileName = CalendarSet.Name;    // TODO:
        try
        {
            CalendarSetRepository.SaveToFile(CalendarSet, fileName);

            UserSettings.Default.Update(x => x.LastOpenedFileName = fileName);
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message, Program.AssemblyDetails.Title, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void tsmnuFileSaveAs_Click(object sender, EventArgs e)
    {
        dlgSaveFile.DefaultExt                   = CalendarSetRepository.DefaultFileExtension;
        dlgSaveFile.AddExtension                 = true;
        dlgSaveFile.RestoreDirectory             = true;
        dlgSaveFile.SupportMultiDottedExtensions = true;
        dlgSaveFile.CheckFileExists              = false;
        dlgSaveFile.CheckPathExists              = true;
        dlgSaveFile.OverwritePrompt              = true;
        dlgSaveFile.ShowHelp                     = true;
        dlgSaveFile.AutoUpgradeEnabled           = true;
        dlgSaveFile.Filter                       = CalendarSetRepository.BuildFileDialogFileFilters();
        dlgSaveFile.FilterIndex                  = 0;

        if (dlgSaveFile.ShowDialog() != DialogResult.OK)
            return;

        var fileName = dlgSaveFile.FileName;

        try
        {
            CalendarSetRepository.SaveToFile(CalendarSet, fileName);

            UserSettings.Default.Update(x => x.LastOpenedFileName = fileName);
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message, Program.AssemblyDetails.Title, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void tsmnuFileProgramOptions_Click(object sender, EventArgs e)
    {
        var result = ProgramOptionsForm.EditProgramOptions(UserSettings.Default);
        if (result)
        {
            UserSettings.Default.Save();
            LoadProgramOptions();
        }
    }

    private void tsmnuFileExit_Click(object sender, EventArgs e)
    {
        Close();
    }

    private void tsmnuEditCalendar_Click(object sender, EventArgs e)
    {
        var result = CalendarDetailsForm.EditCalendarSet(CalendarSet);
        if (result)
        {
            LoadCalendarSet(CalendarSet);
        }
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

    private void tsmnuViewJumpToPreviousMarkedDate_Click(object sender, EventArgs e)
    {
        var targetDate = CalendarSet.FindPreviousMarkedDate(mcalCalendar.SelectionRange.Start);
        if (targetDate.HasValue)
            SelectDate(targetDate.Value);
    }

    private void tsmnuViewJumpToNextMarkedDate_Click(object sender, EventArgs e)
    {
        var targetDate = CalendarSet.FindNextMarkedDate(mcalCalendar.SelectionRange.Start);
        if (targetDate.HasValue)
            SelectDate(targetDate.Value);
    }

    private void tsmnuViewSelectToPreviousMarkedDate_Click(object sender, EventArgs e)
    {
        var targetDate = CalendarSet.FindPreviousMarkedDate(mcalCalendar.SelectionRange.Start);
        if (targetDate.HasValue)
            SelectDates(targetDate.Value, mcalCalendar.SelectionRange.End);
    }

    private void tsmnuViewSelectToNextMarkedDate_Click(object sender, EventArgs e)
    {
        var targetDate = CalendarSet.FindNextMarkedDate(mcalCalendar.SelectionRange.End);
        if (targetDate.HasValue)
            SelectDates(mcalCalendar.SelectionRange.Start, targetDate.Value);
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

    private void tsmnuHelpUsageGuide_Click(object sender, EventArgs e)
    {
        var usageGuideUrl = ProjectInfo.Docs.UsageGuideUrl;
        var processStartInfo = new ProcessStartInfo(usageGuideUrl)
        {
            UseShellExecute = true,
            Verb = "open"
        };
        Process.Start(processStartInfo);
    }

    private void tsmnuHelpAbout_Click(object sender, EventArgs e)
    {
        using var form = new AboutBoxForm();
        form.ShowDialog();
    }

    private void tmrResetStatusBar_Tick(object sender, EventArgs e)
    {
        if (sender is Timer timer)
            timer.Enabled = false;
        else
            tmrResetStatusBar.Enabled = false;

        ShowInfoText();
    }
}
