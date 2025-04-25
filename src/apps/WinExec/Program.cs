using System.Diagnostics;
using System.Reflection;
using DNX.Common;
using DNX.Common.Debugging;
using DNX.Helpers.Assemblies;
using Ookii.CommandLine;
using Serilog;

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

            var arguments = Arguments.Parse(args, Arguments.Options)
                            ?? throw new CommandLineArgumentException("Unable to parse Program Arguments");
            arguments.Validate();

            var startInfo = new ProcessStartInfo(arguments.FileName)
            {
                Verb = arguments.Verb,
                UseShellExecute = arguments.UseShellExecute,
            };

            Process.Start(startInfo);
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
}
