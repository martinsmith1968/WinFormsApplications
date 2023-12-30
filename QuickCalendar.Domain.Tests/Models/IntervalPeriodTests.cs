using AutoFixture;
using FluentAssertions;
using QuickCalendar.Domain.Models;
using QuickCalendar.Domain.Models.Types;
using Xunit;

#pragma warning disable IDE0059

namespace QuickCalendar.Domain.Tests.Models;

public class IntervalPeriodTests
{
    private static readonly Fixture AutoFixture = new();

    [Fact]
    public void Create_wont_accept_an_invalid_IntervalType()
    {
        var intervalPeriodType = (IntervalPeriodType)int.MaxValue;
        var value = (uint)DateTime.UtcNow.Millisecond;

        // Act
        var ex = Assert.Throws<ArgumentOutOfRangeException>(
            () => IntervalPeriod.Create(intervalPeriodType, value)
        );

        // Assert
        ex.Should().NotBeNull();
        ex.ParamName.Should().Be(nameof(intervalPeriodType));
        ex.Message.Should().Contain(nameof(IntervalPeriodType));
    }

    [Fact]
    public void Create_wont_accept_an_invalid_Value()
    {
        var intervalPeriodType = AutoFixture.Create<IntervalPeriodType>();
        var value = (uint)0;

        // Act
        var ex = Assert.Throws<ArgumentOutOfRangeException>(
            () => IntervalPeriod.Create(intervalPeriodType, value)
        );

        // Assert
        ex.Should().NotBeNull();
        ex.ParamName.Should().Be(nameof(value));
        ex.Message.Should().Contain("Value");
    }

    [Fact]
    public void Create_populates_properties_correctly()
    {
        var intervalPeriodType = AutoFixture.Create<IntervalPeriodType>();
        var value = (uint)DateTime.UtcNow.Millisecond;

        // Act
        var instance = IntervalPeriod.Create(intervalPeriodType, value);

        // Assert
        instance.Should().NotBeNull();
        instance.IntervalPeriodType.Should().Be(intervalPeriodType);
        instance.Value.Should().Be(value);
    }

    [Theory]
    [MemberData(nameof(AddTo_Data))]
    public void AddTo_can_return_correct_dates_successfully(DateTime dateTime, IntervalPeriod intervalPeriod, DateTime expectedResult)
    {
        var result = intervalPeriod.AddTo(dateTime);

        result.Should().Be(expectedResult);
    }

    public static TheoryData<DateTime, IntervalPeriod, DateTime> AddTo_Data()
    {
        var data = new TheoryData<DateTime, IntervalPeriod, DateTime>();

        var period7Days = IntervalPeriod.Create(IntervalPeriodType.Days, 7);
        var period2Weeks = IntervalPeriod.Create(IntervalPeriodType.Weeks, 2);
        var period1Month = IntervalPeriod.Create(IntervalPeriodType.Months, 1);
        var period3Years = IntervalPeriod.Create(IntervalPeriodType.Years, 3);
        var badPeriod = new IntervalPeriod { IntervalPeriodType = 0, Value = 10 };

        var today = DateTime.UtcNow.Date;

        data.Add(today, period7Days, today.AddDays(7));
        data.Add(today, period2Weeks, today.AddDays(14));
        data.Add(today, period1Month, today.AddMonths(1));
        data.Add(today, period3Years, today.AddYears(3));
        data.Add(today, badPeriod, today);

        return data;
    }
}
