using System.Drawing;
using DNX.Common.Interfaces;
using QuickCalendar.Domain.Models.Types;

namespace QuickCalendar.Domain.Models;

public class CalendarSetVisuals : ICopyable<CalendarSetVisuals>
{
    public bool ShowWeekNumbers { get; set; }

    public bool ShowToday { get; set; }

    public bool ShowTodayCircle { get; set; }

    public DayOfWeek? FirstDayOfWeek { get; set; }

    public Size VisibleDimensions { get; set; } = new(3, 1);

    private int? _firstVisibleMonth;

    public int? FirstVisibleMonth
    {
        get => _firstVisibleMonth;
        set => _firstVisibleMonth = value is >= 1 and <= 12 ? value : null;
    }

    public WindowStartLocationType WindowStartLocation { get; set; } = WindowStartLocationType.PrimaryScreenCentre;

    private Point? _manualWindowLocation;
    public Point? ManualWindowLocation
    {
        get => _manualWindowLocation;
        set => _manualWindowLocation = IsValid(value) ? value : null;
    }

    internal static bool IsValid(Point? point)
    {
        if (point == null)
        {
            return false;
        }

        if (point.Value.X < 0)
        {
            return false;
        }

        if (point.Value.Y < 0)
        {
            return false;
        }

        return true;
    }

    public void CopyFrom(CalendarSetVisuals other)
    {
        ShowWeekNumbers = other.ShowWeekNumbers;
        ShowToday = other.ShowToday;
        ShowTodayCircle = other.ShowTodayCircle;
        FirstDayOfWeek = other.FirstDayOfWeek;
        VisibleDimensions = other.VisibleDimensions;
        FirstVisibleMonth = other.FirstVisibleMonth;
        WindowStartLocation = other.WindowStartLocation;
        ManualWindowLocation = other.ManualWindowLocation;
    }
}
