using FluentAssertions;
using QuickCalendar.Domain.Models;
using Xunit;

#pragma warning disable xUnit1026
#pragma warning disable IDE0060  // Unused variables

namespace QuickCalendar.Domain.Tests.Models;

public class DateRangeTests
{
    [Theory]
    [MemberData(nameof(DateRange_constructor_data))]
    public void DateRange_constructor_with_2_dates_sets_all_properties_correctly(DateTime first, DateTime second, bool isRange, DateTime start, DateTime end, int monthRange)
    {
        // Act
        var result = new DateRange(first, second);

        // Assert
        result.Should().NotBeNull();
        result.StartDate.Should().Be(start);
        result.EndDate.Should().Be(end);
        result.IsRange.Should().Be(isRange);
        result.GetMonthRange().Should().Be(monthRange);
    }

    [Theory]
    [MemberData(nameof(DateRange_constructor_data))]
    public void DateRange_constructor_with_1_date_sets_all_properties_correctly(DateTime theDate, DateTime second, bool isRange, DateTime start, DateTime end, int monthRange)
    {
        // Act
        var result = new DateRange(theDate);

        // Assert
        result.Should().NotBeNull();
        result.StartDate.Should().Be(theDate);
        result.EndDate.Should().Be(theDate);
        result.IsRange.Should().BeFalse();
        result.GetMonthRange().Should().Be(1);
    }

    public static TheoryData<DateTime, DateTime, bool, DateTime, DateTime, int> DateRange_constructor_data()
    {
        var dateTime1 = new DateTime(2000, 01, 01);
        var dateTime2 = new DateTime(2000, 02, 01);
        var dateTime3 = new DateTime(2000, 03, 01);
        var dateTime4 = new DateTime(2000, 04, 01);
        var dateTime5 = new DateTime(2000, 05, 01);
        var dateTime6 = new DateTime(2000, 06, 01);

        var list = new TheoryData<DateTime, DateTime, bool, DateTime, DateTime, int>
        {
            { dateTime1, dateTime2, true, dateTime1, dateTime2, 2 },
            { dateTime2, dateTime1, true, dateTime1, dateTime2, 2 },
            { dateTime1, dateTime6, true, dateTime1, dateTime6, 6 },
            { dateTime5, dateTime4, true, dateTime4, dateTime5, 2 },
            { dateTime3, dateTime3, false, dateTime3, dateTime3, 1 },
        };

        return list;
    }
}
