using System.ComponentModel;
using QuickCalendar.Domain.Attributes;

namespace QuickCalendar.Domain.Models.Types;

public enum WindowStartLocationType
{
    [CalculatedPosition(false)]
    Manual,

    [CalculatedPosition(true)]
    [Description("Centre of Desktop")]
    DesktopCentre,

    [CalculatedPosition(true)]
    [Description("Centre of Primary Screen")]
    PrimaryScreenCentre
}
