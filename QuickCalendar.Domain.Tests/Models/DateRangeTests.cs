using AutoFixture;
using Bogus;
using FluentAssertions;
using QuickCalendar.Domain.Models;
using Xunit;

namespace QuickCalendar.Domain.Tests.Models;

public class DateRangeTests
{
    private static readonly Fixture AutoFixture = new();
    private static readonly Faker Faker = new();
    private static readonly Random Randomizer = new();

    [Theory]
    [MemberData(nameof(DateRange_constructor_data))]
    public void DateRange_constructor__with_2_dates_sets_all_properties_correctly(DateTime first, DateTime second, bool isRange, DateTime start, DateTime end)
    {
        // Act
        var result = new DateRange(first, second);

        // Assert
        result.Should().NotBeNull();
        result.StartDate.Should().Be(start);
        result.EndDate.Should().Be(end);
        result.IsRange.Should().Be(isRange);
    }

    [Theory]
    [MemberData(nameof(DateRange_constructor_data))]
#pragma warning disable xUnit1026   // Unused variables
    public void DateRange_constructor_with_1_date_sets_all_properties_correctly(DateTime theDate, DateTime second, bool isRange, DateTime start, DateTime end)
#pragma warning restore xUnit1026
    {
        // Act
        var result = new DateRange(theDate);

        // Assert
        result.Should().NotBeNull();
        result.StartDate.Should().Be(theDate);
        result.EndDate.Should().Be(theDate);
        result.IsRange.Should().BeFalse();
    }

    public static TheoryData<DateTime, DateTime, bool, DateTime, DateTime> DateRange_constructor_data()
    {
        var dateTime1 = new DateTime(2000, 01, 01);
        var dateTime2 = new DateTime(2000, 02, 01);
        var dateTime3 = new DateTime(2000, 03, 01);
        var dateTime4 = new DateTime(2000, 04, 01);
        var dateTime5 = new DateTime(2000, 05, 01);
        var dateTime6 = new DateTime(2000, 06, 01);

        var list = new TheoryData<DateTime, DateTime, bool, DateTime, DateTime>
        {
            { dateTime1, dateTime2, true, dateTime1, dateTime2 },
            { dateTime2, dateTime1, true, dateTime1, dateTime2 },
            { dateTime1, dateTime6, true, dateTime1, dateTime6 },
            { dateTime5, dateTime4, true, dateTime4, dateTime5 },
            { dateTime3, dateTime3, false, dateTime3, dateTime3 },
        };

        return list;
    }
}
