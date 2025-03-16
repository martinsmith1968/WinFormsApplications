namespace QuickCalendar.Extensions;

public static class SelectionRangeExtensions
{
    public static int GetMonthRange(this SelectionRange dateRange)
    {
        var count = 0;

        var dt = dateRange.Start;
        while (dt < dateRange.End)
        {
            ++count;
            dt = dt.AddMonths(1);
        }

        return count;
    }
}
