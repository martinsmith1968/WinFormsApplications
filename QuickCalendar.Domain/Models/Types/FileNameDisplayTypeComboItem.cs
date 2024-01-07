#pragma warning disable IDE0290 // Primary Constructors

namespace QuickCalendar.Domain.Models.Types;

public class FileNameDisplayTypeComboItem : ComboItem<CalendarSetDisplayNameType>
{
    public FileNameDisplayTypeComboItem(CalendarSetDisplayNameType value, string? displayName = null)
        : base(value, displayName)
    {
    }
}
