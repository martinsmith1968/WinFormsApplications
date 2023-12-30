using QuickCalendar.Domain.Models.Types;
using QuickCalendar.Properties;

namespace QuickCalendar.Extensions
{
    internal static class UserSettingsExtensions
    {
        public static CalendarSetDisplayNameType GetShowCalendarNameInStatusBarType(this UserSettings userSettings)
        {
            return Enum.TryParse<CalendarSetDisplayNameType>(userSettings.ShowCalendarNameInStatusBar, out var value)
                ? value
                : CalendarSetDisplayNameType.None;
        }

        public static CalendarSetDisplayNameType GetShowCalendarNameInWindowTitleType(this UserSettings userSettings)
        {
            return Enum.TryParse<CalendarSetDisplayNameType>(userSettings.ShowCalendarNameInWindowTitle, out var value)
                ? value
                : CalendarSetDisplayNameType.None;
        }
    }
}
