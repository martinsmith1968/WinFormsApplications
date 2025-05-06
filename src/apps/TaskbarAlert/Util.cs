using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace TaskbarAlert
{
    public abstract class Util
    {
        enum ShowWindowConstants
        {
            SHOW = 5,
            RESTORE = 9,
            NORMAL = 1,
            MINIMIZE = 6,
            MAXIMIZE = 3,
            MAX = 10
        }

        [DllImport("user32.dll", EntryPoint = "SetForegroundWindow")]
        static private extern int SetForegroundWindow(int hWnd);

        [DllImport("user32.dll", EntryPoint = "IsIconic")]
        static private extern int IsMinimized(int hwnd);

        [DllImport("user32.dll", EntryPoint = "ShowWindow")]
        static private extern int ShowWindow(int hwnd, ShowWindowConstants nCmdShow);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="hwnd"></param>
        static public void ShowWindowRestored(int hwnd)
        {
            int ret = SetForegroundWindow(hwnd);
            if (Convert.ToBoolean(IsMinimized(hwnd)))
                ShowWindow(hwnd, ShowWindowConstants.RESTORE);
            else
                ShowWindow(hwnd, ShowWindowConstants.SHOW);
        }

        static public void AppActivate(Process p)
        {
            ShowWindowRestored(p.MainWindowHandle.ToInt32());
        }
    }
}
