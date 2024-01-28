using System.Reflection;
using System.Runtime.CompilerServices;

namespace QuickCalendar.Domain.Debugging;

public enum LogLevel
{
    Trace,
    Debug,
    Info,
    Warning,
    Error,
    Fatal,
}

public class Logger
{
    public static readonly string SeparatorLine = new('-', 120);

    public static string FileName = Path.Combine(Path.GetTempPath(), Path.GetFileNameWithoutExtension(Assembly.GetEntryAssembly().Location) + (System.Diagnostics.Debugger.IsAttached ? ".Debug" : "") + ".log");

    private static readonly int MaxLogLevelLength = Enum.GetNames(typeof(LogLevel)).Max(s => s.Length);

    public static void Reset()
    {
        File.WriteAllText(FileName, null);
    }

    public static void Log(LogLevel logLevel, string text, [CallerMemberName]string? source = null)
    {
        var messageText = string.IsNullOrWhiteSpace(source)
            ? text
            : $"{source} - {text}";

        File.AppendAllText(
            FileName,
            $"{DateTime.UtcNow:s} {logLevel.ToString().PadRight(MaxLogLevelLength, ' ')} {messageText}{Environment.NewLine}"
        );
    }

    public static void Log(LogLevel logLevel, IEnumerable<string> lines, [CallerMemberName] string? source = null)
    {
        foreach(var line in lines)
        {
            Log(logLevel, line, source);
        }
    }

    public static void Trace(string text, [CallerMemberName] string? source = null) => Log(LogLevel.Trace, text, source);

    public static void Debug(string text, [CallerMemberName] string? source = null) => Log(LogLevel.Debug, text, source);

    public static void Info(string text, [CallerMemberName] string? source = null) => Log(LogLevel.Info, text, source);

    public static void Warning(string text, [CallerMemberName] string? source = null) => Log(LogLevel.Warning, text, source);

    public static void Error(string text, [CallerMemberName] string? source = null) => Log(LogLevel.Error, text, source);

    public static void Fatal(string text, [CallerMemberName] string? source = null) => Log(LogLevel.Fatal, text, source);

    public static void Exception(Exception exception, [CallerMemberName] string? source = null) => Log(
        LogLevel.Error,
        new[]
        {
            exception.Message, $"  {nameof(exception.StackTrace)}: {exception.StackTrace}", $"  {nameof(exception.Source)}: {exception.Source}",
        },
        source
    );
}
