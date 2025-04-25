using System.Drawing;

namespace DNX.Common.Extensions;

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
