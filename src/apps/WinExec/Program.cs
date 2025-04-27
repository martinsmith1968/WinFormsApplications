using System.Diagnostics;
using System.Reflection;
using System.Text;
using DNX.Common;
using DNX.Common.Debugging;
using DNX.Common.Extensions;
using DNX.Extensions.Assemblies;
using Ookii.CommandLine;
using Serilog;

// ReSharper disable InconsistentNaming

namespace WinExec;

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
                Console.Out.WriteLine("Shit");
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

        using var timer = new CodeTimer();
        Process.Start(startInfo);
        Logger.Information("Launched in: {seconds} seconds", timer.Stopwatch.Elapsed.TotalSeconds);
    }
}
