using System.Runtime.InteropServices;

namespace DNX.Common.OS;

public class Win32
{
    [DllImport("kernel32.dll")]
    internal static extern IntPtr GetConsoleWindow();

    public static bool ApplicationHasConsole => GetConsoleWindow() != IntPtr.Zero;
    //public static bool ApplicationHasConsole3 => RunSafely.Execute(() => Console.CursorVisible, false);
    //public static bool ApplicationHasConsole => !string.IsNullOrEmpty(Process.GetCurrentProcess().MainWindowTitle);
}
