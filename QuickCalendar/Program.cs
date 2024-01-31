using System.Reflection;
using DNX.Helpers.Assemblies;
using Ookii.CommandLine;
using QuickCalendar.Domain.Debugging;
using QuickCalendar.Domain.Models;
using QuickCalendar.Domain.Repositories;
using QuickCalendar.Properties;
using Serilog;

#pragma warning disable IL3000 // Assembly.Location unreliable for self-contained apps

namespace QuickCalendar;

internal static class Program
{
    public static IAssemblyDetails AssemblyDetails = new AssemblyDetails(Assembly.GetEntryAssembly());

    private static ILogger GetLogger() => Log.ForContext(typeof(Program));

    /// <summary>
    ///  The main entry point for the application.
    /// </summary>
    [STAThread]
    private static void Main(string[] args)
    {
        try
        {
            Logging.Configure();

            var logger = GetLogger();
            logger.Information($"Location: {Assembly.GetEntryAssembly()?.Location}");
            logger.Information($"BaseDirectory: {AppContext.BaseDirectory}");

            LoadUserSettings();

            var arguments = Arguments.Parse(args, Arguments.Options)
                            ?? throw new CommandLineArgumentException("Unable to parse Program Arguments");

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
            logger.Debug($"{nameof(Main)}: Loading {nameof(fileName)}: {fileName}");
            var initialCalendarSet = LoadOrCreateCalendarSet(fileName);

            // Setup Main Form
            var mainForm = new MainForm();
            mainForm.LoadCalendarSet(initialCalendarSet);

            Application.Run(mainForm);
        }
        catch (Exception ex)
        {
            GetLogger().Fatal(ex, ex.Message);
            if (Win32.ApplicationHasConsole)
            {
                Console.Error.WriteLine($"Error: {ex.Message}");
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
            calendarSet = CalendarSetRepository.LoadFromFile(fileName);
        }

        calendarSet ??= CalendarSetBuilder.BuildMyCustomCalendarSet();

        return calendarSet;
    }
}
