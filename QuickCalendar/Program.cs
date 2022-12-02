using System.Reflection;
using DNX.Helpers.Assemblies;
using DNX.Helpers.Strings;
using Ookii.CommandLine;
using QuickCalendar.DataAccess;
using QuickCalendar.Domain.Models;
using QuickCalendar.Properties;

namespace QuickCalendar;

internal static class Program
{
    public static IAssemblyDetails AssemblyDetails = new AssemblyDetails(Assembly.GetEntryAssembly());

    private static readonly ICalendarSetsRepository CalendarSetsRepository = new CalendarSetsRepository();

    /// <summary>
    ///  The main entry point for the application.
    /// </summary>
    [STAThread]
    private static void Main(string[] args)
    {
        try
        {
            LoadUserSettings();

            var arguments = CommandLineParser.Parse<Arguments>(args);
            if (arguments == null)
                throw new CommandLineArgumentException("Unable to parse Program Arguments");

            var initialCalendarSet = LoadOrCreateCalendarSet(arguments.CalendarName);

            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();

            var mainForm = new MainForm();
            mainForm.SetCalendarSet(initialCalendarSet);

            Application.Run(mainForm);
        }
        catch (Exception e)
        {
            if (Win32.ApplicationHasConsole)
            {
                Console.Error.WriteLine($"Error: {e.Message}");
            }
            else
            {
                MessageBox.Show(e.Message, AssemblyDetails.Title, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }

    private static CalendarSet LoadOrCreateCalendarSet(string? calendarName)
    {
        if (!string.IsNullOrWhiteSpace(calendarName))
            calendarName = StringExtensions.CoalesceNullOrWhitespace(
                calendarName,
                UserSettings.Default.LastCalendarName,
                CalendarSet.DefaultName
            );

        if (!string.IsNullOrWhiteSpace(calendarName))
        {
            var namedCalendarSet = CalendarSetsRepository.LoadNamedCalendarSet(calendarName);
            if (namedCalendarSet != null)
                return namedCalendarSet;
        }

        var defaultCalendarSet = CalendarSetsRepository.LoadNamedCalendarSet(CalendarSet.DefaultName);
        if (defaultCalendarSet != null)
            return defaultCalendarSet;

        var calendarSet = new CalendarSet(calendarName ?? CalendarSet.DefaultName);
        calendarSet = CalendarSet.BuildMyCustomCalendarSet();   // TODO:
        CalendarSetsRepository.SaveNamedCalendarSet(calendarSet);

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
