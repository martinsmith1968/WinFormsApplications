using AutoFixture;
using FluentAssertions;
using QuickCalendar.Domain.Models;
using Xunit;

#pragma warning disable IDE0059

namespace QuickCalendar.Domain.Tests.Models;

public class IntervalPeriodTests
{
    private static readonly Fixture AutoFixture = new();

    [Fact]
    public void Create_wont_accept_an_invalid_IntervalType()
    {
        var intervalType = (IntervalType)int.MaxValue;
        var value = (uint)DateTime.UtcNow.Millisecond;

        // Act
        var ex = Assert.Throws<ArgumentOutOfRangeException>(
            () => IntervalPeriod.Create(intervalType, value)
        );

        // Assert
        ex.Should().NotBeNull();
        ex.ParamName.Should().Be(nameof(intervalType));
        ex.Message.Should().Contain(nameof(IntervalType));
    }

    [Fact]
    public void Create_wont_accept_an_invalid_Value()
    {
        var intervalType = AutoFixture.Create<IntervalType>();
        var value = (uint)0;

        // Act
        var ex = Assert.Throws<ArgumentOutOfRangeException>(
            () => IntervalPeriod.Create(intervalType, value)
        );

        // Assert
        ex.Should().NotBeNull();
        ex.ParamName.Should().Be(nameof(value));
        ex.Message.Should().Contain("Value");
    }

    [Fact]
    public void Create_populates_properties_correctly()
    {
        var intervalType = AutoFixture.Create<IntervalType>();
        var value = (uint)DateTime.UtcNow.Millisecond;

        // Act
        var instance = IntervalPeriod.Create(intervalType, value);

        // Assert
        instance.Should().NotBeNull();
        instance.IntervalType.Should().Be(intervalType);
        instance.Value.Should().Be(value);
    }

    [Theory]
    [MemberData(nameof(AddTo_Data))]
    public void AddTo_can_return_correct_dates_successfully(DateTime dateTime, IntervalPeriod intervalPeriod, DateTime expectedResult)
    {
        var result = intervalPeriod.AddTo(dateTime);

        result.Should().Be(expectedResult);
    }

    public static IEnumerable<object[]> AddTo_Data()
    {
        var period7Days = IntervalPeriod.Create(IntervalType.Days, 7);
        var period2Weeks = IntervalPeriod.Create(IntervalType.Weeks, 2);
        var period1Month = IntervalPeriod.Create(IntervalType.Months, 1);
        var period3Years = IntervalPeriod.Create(IntervalType.Years, 3);
        var badPeriod = new IntervalPeriod { IntervalType = 0, Value = 10 };

        var today = DateTime.UtcNow.Date;

        yield return new object[] { today, period7Days, today.AddDays(7) };
        yield return new object[] { today, period2Weeks, today.AddDays(14) };
        yield return new object[] { today, period1Month, today.AddMonths(1) };
        yield return new object[] { today, period3Years, today.AddYears(3) };
        yield return new object[] { today, badPeriod, today };
    }
}
