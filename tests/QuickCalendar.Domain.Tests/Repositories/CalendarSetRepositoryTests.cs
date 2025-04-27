using AutoFixture;
using QuickCalendar.Domain.Repositories;
using QuickCalendar.Domain.Tests.Models;
using Shouldly;
using Xunit;
using Xunit.Abstractions;

#pragma warning disable CS8604 // Possible null reference argument.

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
        CalendarSetRepository.DefaultFileExtension.ShouldNotBeNullOrWhiteSpace($"{nameof(CalendarSetRepository.DefaultFileExtension)} must be set");
    }

    [Fact]
    public void BuildFileDialogFileFilters_returns_usable_values()
    {
        // Act
        var result = CalendarSetRepository.BuildFileDialogFileFilters();

        // Assert
        result.ShouldNotBeNullOrWhiteSpace();

        var items = result.Split(CalendarSetRepository.FileDialogFilterJoinChar);
        items.ShouldNotBeEmpty();
        items.Length.ShouldBeGreaterThan(0);
        (items.Length % 2).ShouldBe(0);
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
        fileInfo.Exists.ShouldBeTrue();
        fileInfo.Length.ShouldBeGreaterThan(0);
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
        instance.ShouldNotBeNull();
        CalendarSetTests.AssertAreEqual(calendarSet, instance);
    }
}
