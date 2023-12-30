using System.Reflection;
using DNX.Helpers.Assemblies;
using Ookii.CommandLine;
using QuickCalendar.Domain.Models;
using QuickCalendar.Domain.Repositories;
using QuickCalendar.Properties;

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
            LoadUserSettings();

            var arguments = Arguments.Parse(args, Arguments.Options);
            if (arguments == null)
                throw new CommandLineArgumentException("Unable to parse Program Arguments");

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
            var initialCalendarSet = LoadOrCreateCalendarSet(fileName);

            // Setup Main Form
            var mainForm = new MainForm();
            mainForm.LoadCalendarSet(initialCalendarSet);

            Application.Run(mainForm);
        }
        catch (Exception ex)
        {
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

    private static CalendarSet LoadOrCreateCalendarSet(string? fileName)
    {
        CalendarSet? calendarSet = null;

        if (!string.IsNullOrWhiteSpace(fileName))
        {
            calendarSet = CalendarSetRepository.LoadFromFile(fileName);
        }

        //calendarSet ??= new CalendarSet(CalendarSet.DefaultName);
        calendarSet ??= CalendarSetBuilder.BuildMyCustomCalendarSet();

        return calendarSet;
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
}
