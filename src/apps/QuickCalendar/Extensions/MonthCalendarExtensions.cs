namespace QuickCalendar.Extensions;

public static class MonthCalendarExtensions
{
    public static DateTime SetFirstVisibleMonth(this MonthCalendar monthCalendar, int firstVisibleMonth)
    {
        var currentSelectionRange = monthCalendar.SelectionRange;

        try
        {
            var targetFirstVisibleDate = new DateTime(DateTime.UtcNow.Year, firstVisibleMonth, 1);

            while (monthCalendar.GetActiveDisplayRange().Start > targetFirstVisibleDate)
            {
                monthCalendar.SetDate(monthCalendar.GetActiveDisplayRange().Start.AddMonths(-1));
            }

            while (monthCalendar.GetActiveDisplayRange().Start < targetFirstVisibleDate)
            {
                monthCalendar.SetDate(monthCalendar.GetActiveDisplayRange().End.AddMonths(1));
            }
        }
        catch
        {
            // ignored
        }
        finally
        {
            monthCalendar.SetSelectionRange(currentSelectionRange);

            monthCalendar.ResumeLayout();
            monthCalendar.Update();
        }

        return monthCalendar.GetActiveDisplayRange().Start;
    }

    public static void SetSelectionRange(this MonthCalendar calendar, SelectionRange selectionRange)
    {
        calendar.SetSelectionRange(selectionRange.Start, selectionRange.End);
    }

    public static SelectionRange GetActiveDisplayRange(this MonthCalendar monthCalendar)
    {
        return monthCalendar.GetDisplayRange(true);
    }
}
