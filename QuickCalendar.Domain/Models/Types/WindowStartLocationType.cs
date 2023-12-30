using System.ComponentModel;

namespace QuickCalendar.Domain.Models.Types;

public enum WindowStartLocationType
{
    Manual,

    [Description("Centre of Screen")]
    ScreenCentre
}
