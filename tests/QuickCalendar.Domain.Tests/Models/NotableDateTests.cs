using AutoFixture;
using Shouldly;
using QuickCalendar.Domain.Models;
using Xunit;

namespace QuickCalendar.Domain.Tests.Models;

public class NotableDateTests
{
    private static readonly Fixture AutoFixture = new();

    [Fact]
    public void Full_Constructor_populates_properties_correctly()
    {
        var date = AutoFixture.Create<DateTime>();
        var description = AutoFixture.Create<string>();

        // Act
        var instance = new NotableDate(date, description);

        // Assert
        instance.ShouldNotBeNull();
        instance.Date.ShouldBe(date);
        instance.Description.ShouldBe(description);
    }

    [Fact]
    public void Simplified_Constructor_populates_properties_correctly()
    {
        var date = AutoFixture.Create<DateTime>();

        // Act
        var instance = new NotableDate(date);

        // Assert
        instance.ShouldNotBeNull();
        instance.Date.ShouldBe(date);
        instance.Description.ShouldBeNull();
    }
}
