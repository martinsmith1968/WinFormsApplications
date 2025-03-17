namespace QuickCalendar.Domain.Attributes;

public class CalculatedPositionAttribute(bool value) : Attribute
{
    public bool Value { get; } = value;
}
