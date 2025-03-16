namespace QuickCalendar;

internal class WinForms
{
    public static Rectangle GetPrimaryWindowBounds()
    {
        return Screen.PrimaryScreen.Bounds;
    }

    public static Rectangle GetPrimaryWindowWorkingArea()
    {
        return Screen.PrimaryScreen.WorkingArea;
    }

    public static IList<Tuple<int, string, Rectangle>> GetAllScreensBounds()
    {
        var index = 0;

        return Screen.AllScreens
            .Select(
                s => new Tuple<int, string, Rectangle>(
                    index++,
                    s.DeviceName,
                    s.Bounds
                )
            )
            .ToList();
    }

    public static IList<Tuple<int, string, Rectangle>> GetAllScreensWorkingArea()
    {
        var index = 0;

        return Screen.AllScreens
            .Select(
                s => new Tuple<int, string, Rectangle>(
                    index++,
                    s.DeviceName,
                    s.WorkingArea
                )
            )
            .ToList();
    }

    public static Rectangle GetMaxRectangle(IList<Rectangle> rectangles)
    {
        var topLeft = new Point(
            rectangles.Min(x => x.X),
            rectangles.Min(x => x.Y)
        );
        var bottomRight = new Point(
            rectangles.Max(x => x.Right),
            rectangles.Max(x => x.Bottom)
        );

        return new Rectangle(
            topLeft,
            new Size(
                bottomRight.X - topLeft.X,
                bottomRight.Y - topLeft.Y
            )
        );
    }

    public static Rectangle GetDesktopBounds()
    {
        return GetMaxRectangle(
            GetAllScreensBounds()
                .Select(x => x.Item3)
                .ToArray()
        );
    }

    public static Rectangle GetDesktopWorkingArea()
    {
        return GetMaxRectangle(
            GetAllScreensWorkingArea()
                .Select(x => x.Item3)
                .ToArray()
        );
    }
}
