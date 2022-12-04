namespace QuickCalendar.Domain.Extensions;

public static class NumericExtensions
{
    public static int ToInt32(this uint value)
    {
        return Convert.ToInt32(value);
    }

    public static int ToInt32(this double value)
    {
        return Convert.ToInt32(value);
    }

    public static int ToInt32(this decimal value)
    {
        return Convert.ToInt32(value);
    }

    public static uint ToUInt32(this uint value)
    {
        return Convert.ToUInt32(value);
    }

    public static uint ToUInt32(this double value)
    {
        return Convert.ToUInt32(value);
    }

    public static uint ToUInt32(this decimal value)
    {
        return Convert.ToUInt32(value);
    }
}
