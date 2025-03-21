using System.Drawing;
using FluentAssertions;
using QuickCalendar.Domain.Extensions;
using Xunit;

namespace QuickCalendar.Domain.Tests.Extensions;

public class SizeExtensionsTest
{
    [Theory]
    [MemberData(nameof(CentreWithin_Data))]
    public void CentreWithinTests(Size size, Rectangle bounds, Point expectedResult)
    {
        var result = size.CentreWithin(bounds);

        result.Should().NotBeNull();
        result.IsEmpty.Should().Be(expectedResult.IsEmpty);
        result.X.Should().Be(expectedResult.X);
        result.Y.Should().Be(expectedResult.Y);
    }

    public static TheoryData<Size, Rectangle, Point> CentreWithin_Data()
    {
        var list = new TheoryData<Size, Rectangle, Point>
        {
            {
                new Size(100, 100),
                new Rectangle(0, 0, 1000, 1000),
                new Point(450, 450)
            },
            {
                new Size(1000, 1000),
                new Rectangle(0, 0, 1000, 1000),
                new Point(0, 0)
            },
            {
                new Size(400, 300),
                new Rectangle(0, 0, 1920, 1080),
                new Point(760, 390)
            },
            {
                new Size(400, 300),
                new Rectangle(0, 0, 2560, 1440),
                new Point(1080, 570)
            }
        };

        return list;
    }
}
