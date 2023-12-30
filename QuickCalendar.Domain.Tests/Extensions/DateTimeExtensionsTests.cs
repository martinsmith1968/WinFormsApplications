using FluentAssertions;
using QuickCalendar.Domain.Extensions;
using Xunit;

namespace QuickCalendar.Domain.Tests.Extensions;

public class DateTimeExtensionsTests
{
    [Theory]
    [MemberData(nameof(MinOf_Data))]
    public void MinOf_returns_the_expected_value(DateTime dt1, DateTime dt2, DateTime expected)
    {
        var result = DateTimeExtensions.MinOf(dt1, dt2);

        result.Should().Be(expected);
    }

    [Theory]
    [MemberData(nameof(MaxOf_Data))]
    public void MaxOf_returns_the_expected_value(DateTime dt1, DateTime dt2, DateTime expected)
    {
        var result = DateTimeExtensions.MaxOf(dt1, dt2);

        result.Should().Be(expected);
    }

    public static TheoryData<DateTime, DateTime, DateTime> MinOf_Data()
    {
        var data = new TheoryData<DateTime, DateTime, DateTime>();

        var today = DateTime.UtcNow.Date;

        data.Add(today, today, today);
        data.Add(today.AddHours(12), today, today);
        data.Add(today.AddHours(12), today.AddHours(14), today.AddHours(12));
        data.Add(today.AddHours(12), today.AddHours(4), today.AddHours(4));
        data.Add(today, DateTimeExtensions.CalendarMinValue, DateTimeExtensions.CalendarMinValue);
        data.Add(today, DateTimeExtensions.CalendarMaxValue, today);

        return data;
    }

    public static TheoryData<DateTime, DateTime, DateTime> MaxOf_Data()
    {
        var data = new TheoryData<DateTime, DateTime, DateTime>();

        var today = DateTime.UtcNow.Date;

        data.Add(today, today, today);
        data.Add(today.AddHours(12), today, today.AddHours(12));
        data.Add(today.AddHours(12), today.AddHours(14), today.AddHours(14));
        data.Add(today.AddHours(12), today.AddHours(4), today.AddHours(12));
        data.Add(today, DateTimeExtensions.CalendarMaxValue, DateTimeExtensions.CalendarMaxValue);
        data.Add(today, DateTimeExtensions.CalendarMinValue, today);

        return data;
    }
}
