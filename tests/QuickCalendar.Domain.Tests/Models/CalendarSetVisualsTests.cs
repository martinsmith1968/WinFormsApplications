using System.Drawing;
using AutoFixture;
using Bogus;
using Shouldly;
using QuickCalendar.Domain.Models;
using QuickCalendar.Domain.Models.Types;
using Xunit;

namespace QuickCalendar.Domain.Tests.Models
{
    public class CalendarSetVisualsTests
    {
        private static readonly Fixture AutoFixture = new() { Behaviors =
        {
            new OmitOnRecursionBehavior()
        }};
        private static readonly Faker Faker = new();
        private static readonly Random Randomizer = new();

        internal static bool TrueOrFalse() => (Randomizer.Next(1, 10) % 2) == 0;

        internal static CalendarSetVisuals CreateRandomInstance()
        {
            int? month = Randomizer.Next(0, 12);
            if (month == 0)
                month = null;

            return AutoFixture.Build<CalendarSetVisuals>()
                .With(x => x.FirstDayOfWeek, AutoFixture.Create<DayOfWeek?>())
                .With(x => x.FirstVisibleMonth, month)
                .With(x => x.ManualWindowLocation,  AutoFixture.Create<Point>())
                .With(x => x.ShowToday, TrueOrFalse())
                .With(x => x.ShowTodayCircle, TrueOrFalse())
                .With(x => x.ShowWeekNumbers, TrueOrFalse())
                .With(x => x.VisibleDimensions, AutoFixture.Create<Size>())
                .With(x => x.WindowStartLocation, AutoFixture.Create<WindowStartLocationType>())
                .Create();
        }

        internal static void AssertAreEqual(CalendarSetVisuals instance1, CalendarSetVisuals instance2)
        {
            instance1.ShouldNotBeNull();
            instance2.ShouldNotBeNull();

            instance2.FirstDayOfWeek.ShouldBe(instance1.FirstDayOfWeek);
            instance2.FirstVisibleMonth.ShouldBe(instance1.FirstVisibleMonth);
            instance2.ManualWindowLocation.ShouldBe(instance1.ManualWindowLocation);
            instance2.ShowToday.ShouldBe(instance1.ShowToday);
            instance2.ShowTodayCircle.ShouldBe(instance1.ShowTodayCircle);
            instance2.ShowWeekNumbers.ShouldBe(instance1.ShowWeekNumbers);
            instance2.VisibleDimensions.ShouldBe(instance1.VisibleDimensions);
            instance2.WindowStartLocation.ShouldBe(instance1.WindowStartLocation);
        }

        [Theory]
        [MemberData(nameof(IsValid_Data))]
        public void IsPoint_can_detect_values_correctly(Point? point, bool expectedResult)
        {
            // Act
            var result = CalendarSetVisuals.IsValid(point);

            // Assert
            result.ShouldBe(expectedResult);
        }

        public static TheoryData<Point?, bool> IsValid_Data()
        {
            var list = new TheoryData<Point?, bool>
            {
                { new Point(0, 0), true },
                { new Point(10, 0), true },
                { new Point(0, 10), true },
                { new Point(10, 10), true },
                { new Point(-10, 10), false },
                { new Point(10, -10), false },
                { null, false },
            };

            return list;
        }
    }
}
