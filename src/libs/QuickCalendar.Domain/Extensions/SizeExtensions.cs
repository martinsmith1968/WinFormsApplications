using System.Drawing;

namespace QuickCalendar.Domain.Extensions;

public static class SizeExtensions
{
    public static Point CentreWithin(this Size size, Rectangle bounds)
    {
        return new Point(
            (bounds.Width - size.Width) / 2,
            (bounds.Height - size.Height) / 2
        );
    }
}
