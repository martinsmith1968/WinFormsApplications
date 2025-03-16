namespace QuickCalendar.Extensions;

public static class ControlExtensions
{
    public static void SetFocusTo(this Control ctl)
    {
        ctl.Focus();
        if (ctl.Parent is TabPage { Parent: TabControl tabControl } tabPage)
        {
            tabControl.SelectedTab = tabPage;
        }
    }
}
