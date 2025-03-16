namespace QuickCalendar.Domain.Models;

public class NotableDate
{
    public NotableDate(DateTime date, string? description = null)
    {
        Date = date;
        Description = description;
    }

    public DateTime Date { get; set; }

    public string? Description { get; set; }
}
