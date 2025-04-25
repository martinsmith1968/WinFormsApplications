using DNX.Common.Extensions;
using FluentAssertions;
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

    [Theory]
    [MemberData(nameof(GetMonthsSpan_Data))]
    public void GetMonthsSpan_calculates_as_expected(DateTime dateTime1, DateTime dateTime2, int expectedResult)
    {
        var result = dateTime1.GetMonthsSpan(dateTime2);

        // Assert
        result.Should().Be(expectedResult);
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

    public static TheoryData<DateTime, DateTime, int> GetMonthsSpan_Data()
    {
        var list = new TheoryData<DateTime, DateTime, int>
        {
            { new DateTime(2000, 01, 01), new DateTime(2000, 12, 31), 12 },
            { new DateTime(2000, 12, 31), new DateTime(2000, 01, 01), 12 },
            { new DateTime(2000, 01, 01), new DateTime(2000, 01, 31), 1 },
            { new DateTime(2000, 01, 01), new DateTime(2000, 02, 01), 2 },
            { new DateTime(2000, 01, 01), new DateTime(2000, 01, 01), 1 },
        };


        return list;
    }
}
