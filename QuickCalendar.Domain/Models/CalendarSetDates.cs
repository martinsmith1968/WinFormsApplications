using QuickCalendar.Domain.Generators;
using QuickCalendar.Domain.Interfaces;

namespace QuickCalendar.Domain.Models;

public class CalendarSetDates : ICopyable<CalendarSetDates>
{
    public IList<INotableDatesGenerator> DatesGenerators { get; } = new List<INotableDatesGenerator>();

    public IList<INotableDatesGenerator> MonthlyDatesGenerators { get; } = new List<INotableDatesGenerator>();

    public IList<INotableDatesGenerator> AnnualDatesGenerators { get; } = new List<INotableDatesGenerator>();

    public IList<Tuple<string, INotableDatesGenerator>> AllDatesGenerators =>
        DatesGenerators.Select(x => new Tuple<string, INotableDatesGenerator>("Dates", x))
            .Union(
                MonthlyDatesGenerators.Select(x => new Tuple<string, INotableDatesGenerator>("Monthly Dates", x))
            )
            .Union(
                AnnualDatesGenerators.Select(x => new Tuple<string, INotableDatesGenerator>("Annual Dates", x))
            )
            .ToList();

    public IList<NotableDate> Dates => DatesGenerators.SelectMany(g => g.Generate())
        .OrderBy(nd => nd.Date)
        .ToList();

    public IList<NotableDate> MonthlyDates => MonthlyDatesGenerators.SelectMany(g => g.Generate())
        .OrderBy(nd => nd.Date)
        .ToList();

    public IList<NotableDate> AnnualDates => AnnualDatesGenerators.SelectMany(g => g.Generate())
        .OrderBy(nd => nd.Date)
        .ToList();

    public IList<NotableDate> AllDates => Dates
        .Union(MonthlyDates)
        .Union(AnnualDates)
        .OrderBy(nd => nd.Date)
        .ToList();

    public void CopyFrom(CalendarSetDates other)
    {
        var factory = new NotableDateGeneratorFactory();

        DatesGenerators.Clear();
        foreach (var g in other.DatesGenerators)
        {
            //
        }
    }
}
