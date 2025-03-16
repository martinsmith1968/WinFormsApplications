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
