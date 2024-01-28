using AutoFixture;
using FluentAssertions;
using QuickCalendar.Domain.Repositories;
using QuickCalendar.Domain.Tests.Models;
using Xunit;
using Xunit.Abstractions;

namespace QuickCalendar.Domain.Tests.Repositories;

public class CalendarSetRepositoryTests
{
    private static readonly Fixture AutoFixture = new();

    private readonly ITestOutputHelper _outputHelper;

    public CalendarSetRepositoryTests(ITestOutputHelper outputHelper)
    {
        _outputHelper = outputHelper;
    }

    [Fact]
    public void Static_Data_is_valid()
    {
        CalendarSetRepository.DefaultFileExtension.Should().NotBeNullOrWhiteSpace($"{nameof(CalendarSetRepository.DefaultFileExtension)} must be set");
    }

    [Fact]
    public void BuildFileDialogFileFilters_returns_usable_values()
    {
        // Act
        var result = CalendarSetRepository.BuildFileDialogFileFilters();

        // Assert
        result.Should().NotBeNullOrWhiteSpace();

        var items = result.Split("|");
        items.Should().NotBeEmpty();
        items.Length.Should().BeGreaterThan(0);
        (items.Length % 2).Should().Be(0);
    }

    [Fact]
    public void SaveToFile_writes_file_with_content()
    {
        var fileName = Path.GetTempFileName();

        var calendarSet = CalendarSetTests.CreateRandomInstance();

        // Act
        _outputHelper.WriteLine($"Saving file: {fileName}");
        CalendarSetRepository.SaveToFile(calendarSet, fileName);

        // Assert
        var fileInfo = new FileInfo(fileName);
        fileInfo.Exists.Should().BeTrue();
        fileInfo.Length.Should().BeGreaterThan(0);
    }

    [Fact]
    public void LoadToFile_reads_all_content_correctly()
    {
        var fileName = Path.GetTempFileName();

        var calendarSet = CalendarSetTests.CreateRandomInstance();

        _outputHelper.WriteLine($"Saving file: {fileName}");
        CalendarSetRepository.SaveToFile(calendarSet, fileName);

        // Act
        _outputHelper.WriteLine($"Loading file: {fileName}");
        var instance = CalendarSetRepository.LoadFromFile(fileName);

        // Assert
        instance.Should().NotBeNull();
        CalendarSetTests.AssertAreEqual(calendarSet, instance);
    }
}
