using System.Diagnostics;
using System.Reflection;
using System.Text;
using DNX.Common.Application;
using DNX.Common.Debugging;
using DNX.Common.Extensions;
using DNX.Common.OS;
using DNX.Extensions.Assemblies;
using DNX.Extensions.Strings;
using Microsoft.Toolkit.Uwp.Notifications;
using Ookii.CommandLine;
using Serilog;

// ReSharper disable InconsistentNaming

namespace WinExec;

internal static class Program
{
    private static readonly string ApplicationId = ApplicationDetails.GenerateApplicationId();

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
            Logger.Information($"{nameof(args)}: {string.Join(' ', args)}");

            var parser = ProgramArguments.GetParser();
            var arguments = parser.Parse(args)
                            ?? throw new CommandLineArgumentException("Unable to parse Program Arguments"); // TODO: Generate usage and handle as per exception
            arguments.Validate();

            Execute(arguments);
        }
        catch (Exception ex)
        {
            Logger.Fatal(ex, "{0} {1}", ex.GetType().Name, ex.Message);
            if (Win32.ApplicationHasConsole)
            {
                Console.Error.WriteLine(ProgramArguments.GetUsage(true));
                Console.Error.WriteLine($"{AssemblyDetails.Title} ERROR: {ex.Message}");
            }
            else
            {
                var text = new StringBuilder(ProgramArguments.GetUsage(false))
                    .AppendLine()
                    .AppendFormat($"ERROR: {ex.Message}");

                MessageBox.Show(text.ToString(), AssemblyDetails.Title, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }

    private static void Execute(ProgramArguments arguments)
    {
        var startInfo = arguments.GetStartInfo();
        Logger.Debug("StartInfo: {startInfo}", startInfo.GetFullDescription());

        Logger.Information("Launching: {startInfo}", startInfo.GetShortDescription());
        if (!arguments.NoNotification)
        {
            ShowNotification($"Launching: {startInfo.GetShortDescription()}", alert: !arguments.NoAlert);
        }

        using var timer = new CodeTimer();
        Process.Start(startInfo);
        Logger.Information("Launched in: {seconds} seconds", timer.Stopwatch.Elapsed.TotalSeconds);
    }

    private static void ShowNotification(string messageText, string? title = null, bool alert = true)
    {
        Logger.Information("Showing Toast Notification: {messageText} Title: {title} Alert: {alert}", messageText, title, alert);

        var builder = new ToastContentBuilder();
        if (!title.IsNullOrWhiteSpace())
        {
            builder.AddHeader(ApplicationId, title, new ToastArguments());
        }

        builder.AddText(messageText);
        builder.AddAudio(new ToastAudio() { Silent = !alert });
        builder.Show();
    }
}
