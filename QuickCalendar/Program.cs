using System.Reflection;
using DNX.Helpers.Assemblies;
using Ookii.CommandLine;
using QuickCalendar.Domain.Debugging;
using QuickCalendar.Domain.Models;
using QuickCalendar.Domain.Repositories;
using QuickCalendar.Properties;
using Serilog;

// ReSharper disable InconsistentNaming

namespace QuickCalendar;

internal static class Program
{
    public static IAssemblyDetails AssemblyDetails = new AssemblyDetails(Assembly.GetEntryAssembly());

    private static ILogger Logger = Log.Logger;

    /// <summary>
    ///  The main entry point for the application.
    /// </summary>
    [STAThread]
    private static void Main(string[] args)
    {
        try
        {
            Logging.Configure();
            Logger = Log.ForContext(typeof(Program));

            Logger.Debug($"{nameof(AssemblyDetails.FileName)}: {AssemblyDetails.FileName}");
            Logger.Debug($"{nameof(AppContext.BaseDirectory)}: {AppContext.BaseDirectory}");

            LoadUserSettings();

            var arguments = Arguments.Parse(args, Arguments.Options)
                            ?? throw new CommandLineArgumentException("Unable to parse Program Arguments");
            arguments.Validate();

            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();

            // Determine FileName to open
            var fileName = arguments.HasFileName
                ? arguments.FileName
                : UserSettings.Default.LoadLastOpenedFileOnStartup
                    ? UserSettings.Default.LastOpenedFileName
                    : string.Empty;

            // Load Calendar
            Logger.Debug($"{nameof(Main)}: Loading {nameof(fileName)}: {fileName}");
            var initialCalendarSet = LoadOrCreateCalendarSet(fileName);

            // Setup Main Form
            var mainForm = new MainForm();
            mainForm.LoadCalendarSet(initialCalendarSet);

            Application.Run(mainForm);
        }
        catch (Exception ex)
        {
            Logger.Fatal(ex, ex.Message);
            if (Win32.ApplicationHasConsole)
            {
                Console.Error.WriteLine($"{AssemblyDetails.Title} Error: {ex.Message}");
            }
            else
            {
                MessageBox.Show(ex.Message, AssemblyDetails.Title, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }

    private static void LoadUserSettings()
    {
        if (UserSettings.Default.App_IsUpgraded)
        {
            Logger.Information($"Upgrading {nameof(UserSettings)}");

            UserSettings.Default.Upgrade();
            UserSettings.Default.App_IsUpgraded = false;
            UserSettings.Default.Save();
        }
    }

    private static CalendarSet LoadOrCreateCalendarSet(string? fileName)
    {
        CalendarSet? calendarSet = null;

        if (!string.IsNullOrWhiteSpace(fileName))
        {
            Logger.Information($"Loading File: {fileName}");

            calendarSet = CalendarSetRepository.LoadFromFile(fileName);
            if (calendarSet != null)
            {
                UserSettings.Default.LastOpenedFileName = fileName;
                UserSettings.Default.Save();
            }
        }

        if (calendarSet == null)
        {
            Logger.Debug($"Defaulting {nameof(CalendarSet)} via {nameof(CalendarSetBuilder)}.{nameof(CalendarSetBuilder.BuildMyCustomCalendarSet)}");
            calendarSet = CalendarSetBuilder.BuildMyCustomCalendarSet();
        }

        return calendarSet;
    }
}
