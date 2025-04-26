using AutoFixture;
using Bogus;
using Shouldly;
using QuickCalendar.Domain.Generators;
using QuickCalendar.Domain.Models;
using Xunit;

namespace QuickCalendar.Domain.Tests.Models;

public class CalendarSetTests
{
    private static readonly Fixture AutoFixture = new();
    private static readonly Faker Faker = new();
    private static readonly Random Randomizer = new();

    internal static CalendarSet CreateRandomInstance()
    {
        var now = DateTime.UtcNow;

        var datesInstance = CalendarSetDatesTests.CreateRandomInstance();

        return AutoFixture.Build<CalendarSet>()
            .With(x => x.Description, Faker.Commerce.ProductDescription)
            .With(x => x.Version, Randomizer.Next(1, 10))
            .With(x => x.DateDisplayFormat, "o")
            .With(x => x.MinimumDate, now.Date.Subtract(TimeSpan.FromDays(14)))
            .With(x => x.MaximumDate, now.Date.Add(TimeSpan.FromDays(14)))
            .With(x => x.VisualDetails, CalendarSetVisualsTests.CreateRandomInstance())
            .Do(x => datesInstance.AnnualDatesGenerators.ToList().ForEach(i => x.Dates.AnnualDatesGenerators.Add(i)))
            .Do(x => datesInstance.MonthlyDatesGenerators.ToList().ForEach(i => x.Dates.MonthlyDatesGenerators.Add(i)))
            .Do(x => datesInstance.DatesGenerators.ToList().ForEach(i => x.Dates.DatesGenerators.Add(i)))
            .Create();
    }

    internal static void AssertAreEqual(CalendarSet instance1, CalendarSet instance2)
    {
        instance1.ShouldNotBeNull();
        instance2.ShouldNotBeNull();

        instance2.Version.ShouldBe(instance1.Version);
        instance2.FileName.ShouldBe(instance1.FileName);
        instance2.FullFileName.ShouldBe(instance1.FullFileName);
        instance2.Description.ShouldBe(instance1.Description);
        instance2.DisplayFontName.ShouldBe(instance1.DisplayFontName);
        instance2.DisplayFontSize.ShouldBe(instance1.DisplayFontSize);
        instance2.MinimumDate.ShouldBe(instance1.MinimumDate);
        instance2.MaximumDate.ShouldBe(instance1.MaximumDate);
        instance2.DateDisplayFormat.ShouldBe(instance1.DateDisplayFormat);
    }

    [Fact]
    public void Constructor_for_FileInfo_and_description_only_populates_properties_correctly()
    {
        var fileName = Path.GetTempFileName();
        File.WriteAllText(fileName, null);
        var fileInfo = new FileInfo(fileName);

        var description = Faker.Commerce.ProductDescription();

        // Act
        var instance = new CalendarSet(fileInfo, description);

        // Assert
        instance.ShouldNotBeNull();
        instance.FileInfo.ShouldBe(fileInfo);
        instance.Description.ShouldBe(description);
        instance.MaximumDate.ShouldBe(DateTime.MaxValue);
        instance.MinimumDate.ShouldBe(DateTime.MinValue);
        instance.VisualDetails.ShouldNotBeNull();
        instance.Dates.ShouldNotBeNull();
    }

    [Fact]
    public void Constructor_for_FileInfo_only_populates_properties_correctly()
    {
        var fileName = Path.GetTempFileName();
        File.WriteAllText(fileName, null);
        var fileInfo = new FileInfo(fileName);

        // Act
        var instance = new CalendarSet(fileInfo);

        // Assert
        instance.ShouldNotBeNull();
        instance.FileInfo.ShouldBe(fileInfo);
        instance.Description.ShouldBeNull();
        instance.MaximumDate.ShouldBe(DateTime.MaxValue);
        instance.MinimumDate.ShouldBe(DateTime.MinValue);
        instance.VisualDetails.ShouldNotBeNull();
        instance.Dates.ShouldNotBeNull();
    }

    [Fact]
    public void Constructor_for_description_only_populates_properties_correctly()
    {
        var description = Faker.Commerce.ProductDescription();

        // Act
        var instance = new CalendarSet(description);

        // Assert
        instance.ShouldNotBeNull();
        instance.FileInfo.ShouldBeNull();
        instance.Description.ShouldBe(description);
        instance.MaximumDate.ShouldBe(DateTime.MaxValue);
        instance.MinimumDate.ShouldBe(DateTime.MinValue);
        instance.VisualDetails.ShouldNotBeNull();
        instance.Dates.ShouldNotBeNull();
    }

    [Fact]
    public void CopyFrom_can_copy_all_properties_correctly()
    {
        var source = CreateRandomInstance();

        // Act
        var target = new CalendarSet(CalendarSet.DefaultDescription);
        target.CopyFrom(source);

        // Assert
        AssertAreEqual(source, target);
        CalendarSetVisualsTests.AssertAreEqual(source.VisualDetails, target.VisualDetails);
        CalendarSetDatesTests.AssertAreEqual(source.Dates, target.Dates);
    }

    [Fact]
    public void Clone_can_copy_all_properties_correctly()
    {
        var source = CreateRandomInstance();

        // Act
        var target = source.Clone();

        // Assert
        AssertAreEqual(source, target);
        CalendarSetVisualsTests.AssertAreEqual(source.VisualDetails, target.VisualDetails);
        CalendarSetDatesTests.AssertAreEqual(source.Dates, target.Dates);
    }

    [Theory]
    [MemberData(nameof(FindNextMarkedDate_Data))]
    public void FindNextMarkedDate_finds_valid_next_DateTime_correctly(IList<DateTime> dates, DateTime searchDate, DateTime? expectedResult)
    {
        var instance = new CalendarSet(CalendarSet.DefaultDescription);
        foreach (var date in dates)
        {
            instance.Dates.DatesGenerators.Add(
                new NotableDatesFixedDateGenerator()
                {
                    Date = date,
                    DescriptionTemplate = BaseNotableDatesGenerator.Default_DescriptionTemplate,
                }
                );
        }

        // Act
        var result = instance.FindNextMarkedDate(searchDate);

        // Assert
        result.HasValue.ShouldBe(expectedResult.HasValue);
        result.ShouldBe(expectedResult);
    }

    [Theory]
    [MemberData(nameof(FindPreviousMarkedDate_Data))]
    public void FindPreviousMarkedDate_finds_valid_next_DateTime_correctly(IList<DateTime> dates, DateTime searchDate, DateTime? expectedResult)
    {
        var instance = new CalendarSet(CalendarSet.DefaultDescription);
        foreach (var date in dates)
        {
            instance.Dates.DatesGenerators.Add(
                new NotableDatesFixedDateGenerator()
                {
                    Date = date,
                    DescriptionTemplate = BaseNotableDatesGenerator.Default_DescriptionTemplate,
                }
            );
        }

        // Act
        var result = instance.FindPreviousMarkedDate(searchDate);

        // Assert
        result.HasValue.ShouldBe(expectedResult.HasValue);
        result.ShouldBe(expectedResult);
    }

    public static TheoryData<IList<DateTime>, DateTime, DateTime?> FindNextMarkedDate_Data()
    {
        var list = new TheoryData<IList<DateTime>, DateTime, DateTime?>();

        var dateTime1 = new DateTime(2000, 06, 01);
        var dateTime2 = new DateTime(2000, 07, 01);
        var dateTime3 = new DateTime(2000, 08, 01);

        var datesList = new List<DateTime>()
        {
            dateTime1,
            dateTime2,
            dateTime3,
        };

        list.Add(datesList, new DateTime(2000, 01, 01), dateTime1);
        list.Add(datesList, new DateTime(2000, 06, 15), dateTime2);
        list.Add(datesList, new DateTime(2000, 07, 15), dateTime3);
        list.Add(datesList, new DateTime(2000, 08, 15), null);

        return list;
    }

    public static TheoryData<IList<DateTime>, DateTime, DateTime?> FindPreviousMarkedDate_Data()
    {
        var list = new TheoryData<IList<DateTime>, DateTime, DateTime?>();

        var dateTime1 = new DateTime(2000, 06, 01);
        var dateTime2 = new DateTime(2000, 07, 01);
        var dateTime3 = new DateTime(2000, 08, 01);

        var datesList = new List<DateTime>()
        {
            dateTime1,
            dateTime2,
            dateTime3,
        };

        list.Add(datesList, new DateTime(2000, 01, 01), null);
        list.Add(datesList, new DateTime(2000, 06, 15), dateTime1);
        list.Add(datesList, new DateTime(2000, 07, 15), dateTime2);
        list.Add(datesList, new DateTime(2000, 08, 15), dateTime3);

        return list;
    }
}
