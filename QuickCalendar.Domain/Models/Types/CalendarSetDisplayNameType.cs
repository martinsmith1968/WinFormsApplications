using System.ComponentModel;

namespace QuickCalendar.Domain.Models.Types;

public enum CalendarSetDisplayNameType
{
    None = 0,

    [Description("File Name Only")]
    FileNameOnly,

    [Description("Full File Name")]
    FullFileName,

    Description
}

public class FileNameDisplayTypeComboItem : ComboItem<CalendarSetDisplayNameType>
{
    public FileNameDisplayTypeComboItem(CalendarSetDisplayNameType value, string? displayName = null)
        : base(value, displayName)
    {
    }
}
