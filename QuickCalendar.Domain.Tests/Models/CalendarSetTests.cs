using AutoFixture;
using FluentAssertions;
using QuickCalendar.Domain.Models;
using Xunit;

namespace QuickCalendar.Domain.Tests.Models;

public class CalendarSetTests
{
    private static readonly Fixture AutoFixture = new();

    [Fact]
    public void Constructor_populates_properties_correctly()
    {
        var name = AutoFixture.Create<string>();

        // Act
        var instance = new CalendarSet(name);

        // Assert
        instance.Should().NotBeNull();
        instance.Name.Should().Be(name);
        instance.Description.Should().BeNull();
        instance.MaximumDate.Should().Be(DateTime.MaxValue);
        instance.MinimumDate.Should().Be(DateTime.MinValue);
        instance.VisualDetails.Should().NotBeNull();
        instance.Dates.Should().NotBeNull();
    }
}
