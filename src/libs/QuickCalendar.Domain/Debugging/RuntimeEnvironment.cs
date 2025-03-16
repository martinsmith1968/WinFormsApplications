namespace QuickCalendar.Domain.Debugging;

public static class RuntimeEnvironment
{
    public static bool IsRunningInsideVisualStudioIDE => System.Diagnostics.Debugger.IsAttached;
}
