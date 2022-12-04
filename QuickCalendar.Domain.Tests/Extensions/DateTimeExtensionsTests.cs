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

    public static IEnumerable<object[]> MinOf_Data()
    {
        var today = DateTime.UtcNow.Date;

        yield return new object[] { today, today, today };
        yield return new object[] { today.AddHours(12), today, today };
        yield return new object[] { today.AddHours(12), today.AddHours(14), today.AddHours(12) };
        yield return new object[] { today.AddHours(12), today.AddHours(4), today.AddHours(4) };
        yield return new object[] { today, DateTimeExtensions.CalendarMinValue, DateTimeExtensions.CalendarMinValue };
        yield return new object[] { today, DateTimeExtensions.CalendarMaxValue, today };
    }

    public static IEnumerable<object[]> MaxOf_Data()
    {
        var today = DateTime.UtcNow.Date;

        yield return new object[] { today, today, today };
        yield return new object[] { today.AddHours(12), today, today.AddHours(12) };
        yield return new object[] { today.AddHours(12), today.AddHours(14), today.AddHours(14) };
        yield return new object[] { today.AddHours(12), today.AddHours(4), today.AddHours(12) };
        yield return new object[] { today, DateTimeExtensions.CalendarMaxValue, DateTimeExtensions.CalendarMaxValue };
        yield return new object[] { today, DateTimeExtensions.CalendarMinValue, today };
    }
}
