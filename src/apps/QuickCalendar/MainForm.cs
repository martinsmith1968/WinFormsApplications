using System.Diagnostics;
using DNX.Common.Extensions;
using DNX.Extensions.Assemblies;
using QuickCalendar.Domain.Models;
using QuickCalendar.Domain.Models.Types;
using QuickCalendar.Domain.Repositories;
using QuickCalendar.Extensions;
using QuickCalendar.Properties;
using Serilog;
using Timer = System.Windows.Forms.Timer;

// ReSharper disable LocalizableElement
// ReSharper disable IdentifierTypo

#pragma warning disable IDE1006

namespace QuickCalendar;

public partial class MainForm : Form
{
    private static readonly ILogger Logger = Log.ForContext(typeof(MainForm));

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
        tsmnuViewJumpToPreviousMarkedDate.ShortcutKeys = Keys.OemOpenBrackets | Keys.Control;
        tsmnuViewJumpToPreviousMarkedDate.ShortcutKeyDisplayString = "Ctrl+[";
        tsmnuViewJumpToNextMarkedDate.ShortcutKeys = Keys.OemCloseBrackets | Keys.Control;
        tsmnuViewJumpToNextMarkedDate.ShortcutKeyDisplayString = "Ctrl+]";
        tsmnuViewResetFirstVisibleMonth.ShortcutKeys = Keys.Home | Keys.Control;
        tsmnuViewSelectToPreviousMarkedDate.ShortcutKeys = Keys.OemOpenBrackets | Keys.Control | Keys.Shift;
        tsmnuViewSelectToPreviousMarkedDate.ShortcutKeyDisplayString = "Ctrl+Shift+[";
        tsmnuViewSelectToNextMarkedDate.ShortcutKeys = Keys.OemCloseBrackets | Keys.Control | Keys.Shift;
        tsmnuViewSelectToNextMarkedDate.ShortcutKeyDisplayString = "Ctrl+Shift+]";

        SetupToolbarButtonFromMenuItem(tsbtnFileOpen, tsmnuFileOpen);
        SetupToolbarButtonFromMenuItem(tsbtnFileSave, tsmnuFileSave);
        SetupToolbarButtonFromMenuItem(tsbtnFileProgramOptions, tsmnuFileProgramOptions);
        SetupToolbarButtonFromMenuItem(tsbtnFileExit, tsmnuFileExit);
        SetupToolbarButtonFromMenuItem(tsbtnEditCalendar, tsmnuEditCalendar);
        SetupToolbarButtonFromMenuItem(tsbtnViewToday, tsmnuViewToday);
        SetupToolbarButtonFromMenuItem(tsbtnViewJumpToDate, tsmnuViewJumpToDate);
        SetupToolbarButtonFromMenuItem(tsbtnViewJumpToPreviousMarkedDate, tsmnuViewJumpToPreviousMarkedDate);
        SetupToolbarButtonFromMenuItem(tsbtnViewJumpToNextMarkedDate, tsmnuViewJumpToNextMarkedDate);
        SetupToolbarButtonFromMenuItem(tsbtnViewResetFirstVisibleMonth, tsmnuViewResetFirstVisibleMonth);
        SetupToolbarButtonFromMenuItem(tsbtnViewResize, tsmnuViewResize);
        SetupToolbarButtonFromMenuItem(tsbtnViewSaveWindowPosition, tsmnuViewSaveWindowPosition);
        SetupToolbarButtonFromMenuItem(tsbtnHelpAbout, tsmnuHelpAbout);
    }

    private void LoadProgramOptions()
    {
        tsmnuFileExit.ShortcutKeyDisplayString = UserSettings.Default.CloseOnEscape
            ? Keys.Escape.ToString()
            : string.Empty;
    }

    private static void SetupToolbarButtonFromMenuItem(ToolStripButton button, ToolStripMenuItem menuItem)
    {
        button.Text = menuItem.Text;
        button.ToolTipText = menuItem.ToolTipText;
        button.Image = menuItem.Image;
    }

    public void LoadCalendarSet(CalendarSet calendarSet)
    {
        var calendarDetails = $"{nameof(CalendarSet)}: {calendarSet.FileName}";
        ShowInfoText($"Loading: {calendarDetails}");

        CalendarSet = calendarSet;

        mcalCalendar.Font = calendarSet.GetFont();

        switch (UserSettings.Default.GetShowCalendarNameInStatusBarType())
        {
            case CalendarSetDisplayNameType.FileNameOnly:
                tslblFileName.Text = CalendarSet.FileName;
                tslblFileName.ToolTipText = CalendarSet.Description;
                tslblFileName.Visible = true;
                break;
            case CalendarSetDisplayNameType.FullFileName:
                tslblFileName.Text = CalendarSet.Description;
                tslblFileName.ToolTipText = CalendarSet.FullFileName;
                tslblFileName.Visible = true;
                break;
            case CalendarSetDisplayNameType.Description:
                tslblFileName.Text = CalendarSet.Description;
                tslblFileName.ToolTipText = CalendarSet.FullFileName;
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
            CalendarSetDisplayNameType.FileNameOnly => $"{Tag} - {CalendarSet.FileName}",
            CalendarSetDisplayNameType.FullFileName => $"{Tag} - {CalendarSet.Description}",
            CalendarSetDisplayNameType.Description => $"{Tag} - {CalendarSet.Description}",
            _ => Text = Tag?.ToString()
        };

        LoadCalendarSetVisuals(CalendarSet.VisualDetails);
        LoadCalendarSetDates(CalendarSet.Dates);

        ShowInfoText($"Loaded: {calendarDetails}", TimeSpan.FromSeconds(2));
    }

    private void LoadCalendarSetVisuals(CalendarSetVisuals calendarSetVisuals)
    {
        mcalCalendar.ShowToday = calendarSetVisuals.ShowToday;
        mcalCalendar.ShowTodayCircle = calendarSetVisuals.ShowTodayCircle;
        mcalCalendar.ShowWeekNumbers = calendarSetVisuals.ShowWeekNumbers;

        SetCalendarDimensions(calendarSetVisuals.VisibleDimensions);
        SetCalendarPosition(calendarSetVisuals.WindowStartLocation, calendarSetVisuals.ManualWindowLocation);

        if (calendarSetVisuals.FirstVisibleMonth.HasValue)
        {
            mcalCalendar.SetFirstVisibleMonth(calendarSetVisuals.FirstVisibleMonth.Value);
        }

        if (calendarSetVisuals.FirstDayOfWeek.HasValue)
        {
            mcalCalendar.FirstDayOfWeek = Enum.Parse<Day>(calendarSetVisuals.FirstDayOfWeek.Value.ToString());
        }

        SetCalendarPosition(calendarSetVisuals.WindowStartLocation, calendarSetVisuals.ManualWindowLocation);
    }

    private void SetCalendarDimensions(Size dimensions)
    {
        Logger.Debug($"{nameof(dimensions)}: {nameof(Size.Width)}={dimensions.Width}, {nameof(Size.Height)}={dimensions.Height}");

        ClientSize = new Size(
            (mcalCalendar.SingleMonthSize.Width * dimensions.Width) + mcalCalendar.Margin.Horizontal,
            (mcalCalendar.SingleMonthSize.Height * dimensions.Height) + tsMain.Height + ssMain.Height + mcalCalendar.Margin.Vertical
        );
        Logger.Debug($"{nameof(ClientSize)}: {nameof(Size.Width)}={ClientSize.Width}, {nameof(Size.Height)}={ClientSize.Height}");

        mcalCalendar.SetCalendarDimensions(dimensions.Width, dimensions.Height);
    }

    private void SetCalendarPosition(WindowStartLocationType windowStartLocation, Point? manualWindowLocation)
    {
        Logger.Debug($"{nameof(windowStartLocation)}={windowStartLocation}");
        if (manualWindowLocation.HasValue)
        {
            Logger.Debug($"{nameof(SetCalendarPosition)}: {nameof(manualWindowLocation)}: {nameof(Point.X)}={manualWindowLocation.Value.X}, {nameof(Point.Y)}={manualWindowLocation.Value.Y}");
        }

        Location = windowStartLocation switch
        {
            WindowStartLocationType.DesktopCentre => ClientSize.CentreWithin(WinForms.GetDesktopBounds()),
            WindowStartLocationType.PrimaryScreenCentre => ClientSize.CentreWithin(WinForms.GetPrimaryWindowBounds()),
            _ => manualWindowLocation ?? new Point(100, 100)
        };
        Logger.Debug($"{nameof(ClientSize)}: {nameof(Size.Width)}={ClientSize.Width}, {nameof(Size.Height)}={ClientSize.Height}");
        Logger.Debug($"{nameof(Location)}: {nameof(Point.X)}={Location.X}, {nameof(Point.Y)}={Location.Y}");
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
        var firstSelectedDate = mcalCalendar.SelectionRange.Start;
        var selectionCount = (mcalCalendar.SelectionRange.End - mcalCalendar.SelectionRange.Start).Days + 1;
        var firstVisibleMonth = mcalCalendar.GetActiveDisplayRange().Start.Month;

        var hasNextMarkedDate = CalendarSet.FindNextMarkedDate(mcalCalendar.SelectionRange.End).HasValue;
        var hasPreviousMarkedDate = CalendarSet.FindPreviousMarkedDate(mcalCalendar.SelectionRange.Start).HasValue;

        // Menus
        tsmnuViewToday.Enabled = !(selectionCount == 1 && firstSelectedDate == DateTime.UtcNow.Date);
        tsmnuViewJumpToNextMarkedDate.Enabled = hasNextMarkedDate;
        tsmnuViewJumpToPreviousMarkedDate.Enabled = hasPreviousMarkedDate;
        tsmnuViewSelectToNextMarkedDate.Enabled = hasNextMarkedDate;
        tsmnuViewSelectToPreviousMarkedDate.Enabled = hasPreviousMarkedDate;

        tsmnuViewResetFirstVisibleMonth.Enabled = CalendarSet.VisualDetails.FirstVisibleMonth.HasValue && (firstVisibleMonth != CalendarSet.VisualDetails.FirstVisibleMonth.Value);

        // Buttons
        tsbtnViewToday.Enabled = tsmnuViewToday.Enabled;
        tsbtnViewJumpToNextMarkedDate.Enabled = tsmnuViewJumpToNextMarkedDate.Enabled;
        tsbtnViewJumpToPreviousMarkedDate.Enabled = tsmnuViewJumpToPreviousMarkedDate.Enabled;

        tsbtnViewResetFirstVisibleMonth.Enabled = tsmnuViewResetFirstVisibleMonth.Enabled;
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

    private void ShowInfoText(string? text = null, TimeSpan? clearAfter = null)
    {
        Logger.Information(text ?? string.Empty);

        tslblInfo.Text = text;
        tslblInfo.Owner?.Update();

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

    private void tmrResetStatusBar_Tick(object sender, EventArgs e)
    {
        if (sender is not Timer timer)
        {
            timer = tmrResetStatusBar;
        }

        timer.Enabled = false;

        ShowInfoText();
    }

    private void tsmnuFileOpen_Click(object sender, EventArgs e)
    {
        dlgOpenFile.DefaultExt = CalendarSetRepository.DefaultFileExtension;
        dlgOpenFile.AddExtension = true;
        dlgOpenFile.RestoreDirectory = true;
        dlgOpenFile.SupportMultiDottedExtensions = true;
        dlgOpenFile.Multiselect = false;
        dlgOpenFile.CheckFileExists = true;
        dlgOpenFile.CheckPathExists = true;
        dlgOpenFile.ShowHelp = true;
        dlgOpenFile.AutoUpgradeEnabled = true;
        dlgOpenFile.Filter = CalendarSetRepository.BuildFileDialogFileFilters();
        dlgOpenFile.FilterIndex = 0;

        if (dlgOpenFile.ShowDialog() != DialogResult.OK)
        {
            return;
        }

        var fileName = dlgOpenFile.FileName;

        try
        {
            var calendarSet = CalendarSetRepository.LoadFromFile(fileName);
            if (calendarSet == null)
            {
                throw new Exception($"Unable to load file : {fileName}");
            }

            LoadCalendarSet(calendarSet);

            UserSettings.Default.Update(x => x.LastOpenedFileName = fileName);
        }
        catch (Exception ex)
        {
            Logger.Fatal(ex, ex.Message);
            MessageBox.Show(ex.Message, Program.AssemblyDetails.Title, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void tsmnuFileSave_Click(object sender, EventArgs e)
    {
        if (CalendarSet.FileInfo == null)
        {
            tsmnuFileSaveAs.PerformClick();
            return;
        }

        var fileName = CalendarSet.FullFileName;

        try
        {
            CalendarSetRepository.SaveToFile(CalendarSet, fileName);

            UserSettings.Default.Update(x => x.LastOpenedFileName = fileName);

            ShowInfoText($"File: {CalendarSet.FileName} saved", TimeSpan.FromSeconds(5));
        }
        catch (Exception ex)
        {
            Logger.Fatal(ex, ex.Message);
            MessageBox.Show(ex.Message, Program.AssemblyDetails.Title, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void tsmnuFileSaveAs_Click(object sender, EventArgs e)
    {
        dlgSaveFile.DefaultExt = CalendarSetRepository.DefaultFileExtension;
        dlgSaveFile.AddExtension = true;
        dlgSaveFile.RestoreDirectory = true;
        dlgSaveFile.SupportMultiDottedExtensions = true;
        dlgSaveFile.CheckFileExists = false;
        dlgSaveFile.CheckPathExists = true;
        dlgSaveFile.OverwritePrompt = true;
        dlgSaveFile.ShowHelp = true;
        dlgSaveFile.AutoUpgradeEnabled = true;
        dlgSaveFile.Filter = CalendarSetRepository.BuildFileDialogFileFilters();
        dlgSaveFile.FilterIndex = 0;

        if (dlgSaveFile.ShowDialog() != DialogResult.OK)
        {
            return;
        }

        var fileName = dlgSaveFile.FileName;

        try
        {
            CalendarSetRepository.SaveToFile(CalendarSet, fileName);

            UserSettings.Default.Update(x => x.LastOpenedFileName = fileName);

            ShowInfoText($"File: {CalendarSet.FileName} saved", TimeSpan.FromSeconds(5));
        }
        catch (Exception ex)
        {
            Logger.Fatal(ex, ex.Message);
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
        {
            SelectDate(targetDate.Value);
        }
    }

    private void tsmnuViewJumpToNextMarkedDate_Click(object sender, EventArgs e)
    {
        var targetDate = CalendarSet.FindNextMarkedDate(mcalCalendar.SelectionRange.Start);
        if (targetDate.HasValue)
        {
            SelectDate(targetDate.Value);
        }
    }

    private void tsmnuViewSelectToPreviousMarkedDate_Click(object sender, EventArgs e)
    {
        var targetDate = CalendarSet.FindPreviousMarkedDate(mcalCalendar.SelectionRange.Start);
        if (targetDate.HasValue)
        {
            SelectDates(targetDate.Value, mcalCalendar.SelectionRange.End);
        }
    }

    private void tsmnuViewSelectToNextMarkedDate_Click(object sender, EventArgs e)
    {
        var targetDate = CalendarSet.FindNextMarkedDate(mcalCalendar.SelectionRange.End);
        if (targetDate.HasValue)
        {
            SelectDates(mcalCalendar.SelectionRange.Start, targetDate.Value);
        }
    }

    private void tsmnuViewResetFirstVisibleMonth_Click(object sender, EventArgs e)
    {
        if (CalendarSet.VisualDetails.FirstVisibleMonth.HasValue)
        {
            var firstVisibleDate = mcalCalendar.SetFirstVisibleMonth(CalendarSet.VisualDetails.FirstVisibleMonth.Value);

            ShowInfoText($"Calendar View Reset to {firstVisibleDate:MMMM yyyy}", TimeSpan.FromSeconds(2));
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

    private void tsmnuViewRefresh_Click(object sender, EventArgs e)
    {
        this.Refresh();
        mcalCalendar.Refresh();
    }

    private void tsmnuHelpUsageGuide_Click(object sender, EventArgs e)
    {
        const string targetUrl = ProjectInfo.Docs.UsageGuideUrl;

        var processStartInfo = new ProcessStartInfo(targetUrl)
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

    private void tsmnuViewSaveWindowPosition_Click(object sender, EventArgs e)
    {
        CalendarSet.VisualDetails.WindowStartLocation = WindowStartLocationType.Manual;
        CalendarSet.VisualDetails.ManualWindowLocation = Location;

        if (CalendarSet.FileInfo != null)
        {
            CalendarSetRepository.SaveToFile(CalendarSet, CalendarSet.FullFileName);
        }
    }
}
