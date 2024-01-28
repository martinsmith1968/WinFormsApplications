using System.Reflection;
using DNX.Helpers.Assemblies;
using Ookii.CommandLine;
using QuickCalendar.Domain.Debugging;
using QuickCalendar.Domain.Models;
using QuickCalendar.Domain.Repositories;
using QuickCalendar.Properties;

#pragma warning disable IL3000 // Assembly.Location unreliable for self-contained apps

namespace QuickCalendar;

internal static class Program
{
    public static IAssemblyDetails AssemblyDetails = new AssemblyDetails(Assembly.GetEntryAssembly());

    /// <summary>
    ///  The main entry point for the application.
    /// </summary>
    [STAThread]
    private static void Main(string[] args)
    {
        try
        {
            Logger.Reset();
            Logger.Info(Logger.SeparatorLine, null);
            Logger.Info($"Location: {Assembly.GetEntryAssembly()?.Location}");
            Logger.Info($"BaseDirectory: {AppContext.BaseDirectory}");

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
            Logger.Trace($"{nameof(Main)}: Loading {nameof(fileName)}: {fileName}");
            var initialCalendarSet = LoadOrCreateCalendarSet(fileName);

            // Setup Main Form
            var mainForm = new MainForm();
            mainForm.LoadCalendarSet(initialCalendarSet);

            Application.Run(mainForm);
        }
        catch (Exception ex)
        {
            Logger.Exception(ex);
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
