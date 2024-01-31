using System.Reflection;
using Serilog;
using Serilog.Enrichers.CallerInfo;

namespace QuickCalendar.Domain.Debugging;

public class Logging
{
    public static readonly string SeparatorLine = new('-', 120);

    public static readonly string FileName = Path.Combine(
        Path.GetTempPath(),
        Path.GetFileNameWithoutExtension(Assembly.GetEntryAssembly()?.Location)
        + (RuntimeEnvironment.IsRunningInsideVisualStudioIDE ? ".Debug" : "")
        + ".log"
    );

    private const string OutputTemplate = "{Timestamp:yyyy-MM-dd HH:mm:ss.fff zzz} [{Level:u3}] {Method}: {Message:lj}{NewLine}{Exception}";

    private const int MaxLogFileSize = 1024 * 1024 * 10;  // 10MB

    private static IEnumerable<string> GetLoggableAssemblies()
    {
        return new List<string>()
        {
            Path.GetFileNameWithoutExtension(Assembly.GetEntryAssembly()?.Location),
            Path.GetFileNameWithoutExtension(Assembly.GetExecutingAssembly().Location),
        }
        .Where(x => !string.IsNullOrWhiteSpace(x))
        .Distinct();
    }

    public static void Configure()
    {
        var config = new LoggerConfiguration()
            .Enrich.WithAssemblyName()
            .Enrich.WithAssemblyVersion()
            .Enrich.WithCallerInfo(
                true,
                allowedAssemblies: GetLoggableAssemblies()
            )
            .WriteTo.File(
                FileName,
                fileSizeLimitBytes: MaxLogFileSize,
                outputTemplate: OutputTemplate
            );

        if (!RuntimeEnvironment.IsRunningInsideVisualStudioIDE)
        {
            config.Enrich.WithMemoryUsage();
        }

        Log.Logger = config.CreateLogger();

        Log.Information(SeparatorLine);
    }





}