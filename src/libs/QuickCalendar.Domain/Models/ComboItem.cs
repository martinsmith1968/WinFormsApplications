namespace QuickCalendar.Domain.Models;

public class ComboItem<T>
{
    public T Value { get; }

    public string DisplayName { get; }

    public ComboItem(T value, string? displayName = null)
    {
        if (value == null)
        {
            throw new ArgumentNullException(nameof(value));
        }

        Value       = value;
        DisplayName = displayName ?? value.ToString();
    }

    public override string ToString()
    {
        return DisplayName;
    }
}
