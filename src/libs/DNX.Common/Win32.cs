using System.Runtime.InteropServices;

namespace DNX.Common;

public class Win32
{
    [DllImport("kernel32.dll")]
    internal static extern IntPtr GetConsoleWindow();

    public static bool ApplicationHasConsole => GetConsoleWindow() != IntPtr.Zero;
}
