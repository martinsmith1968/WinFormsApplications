using FluentAssertions;
using QuickCalendar.Domain.Extensions;
using Xunit;

namespace QuickCalendar.Domain.Tests.Extensions;

public class NumericExtensionsTests
{
    [Theory]
    [InlineData(123.45, 123)]
    [InlineData(123.88, 124)]
    [InlineData(123, 123)]
    [InlineData(0, 0)]
    [InlineData(-1, -1)]
    [InlineData(-1.45, -1)]
    [InlineData(-1.88, -2)]
    public void Decimal_ToInt32_converts_as_expected(decimal value, int expected)
    {
        var result = value.ToInt32();

        result.Should().Be(expected);
    }

    [Theory]
    [InlineData(123.45, 123)]
    [InlineData(123.88, 124)]
    [InlineData(123, 123)]
    [InlineData(0, 0)]
    [InlineData(-1, -1)]
    [InlineData(-1.45, -1)]
    [InlineData(-1.88, -2)]
    public void Double_ToInt32_converts_as_expected(double value, int expected)
    {
        var result = value.ToInt32();

        result.Should().Be(expected);
    }

    [Theory]
    [InlineData(123, 123)]
    [InlineData(12, 12)]
    [InlineData(0, 0)]
    public void Uint_ToInt32_converts_as_expected(uint value, int expected)
    {
        var result = value.ToInt32();

        result.Should().Be(expected);
    }
}