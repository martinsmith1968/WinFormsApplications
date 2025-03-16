namespace QuickCalendar.Models;

public class ComboboxItem<T>
{
    public ComboboxItem(string text, T value)
    {
        Text = text;
        Value = value;
    }

    public string Text { get; set; }
    public T Value { get; set; }

    public override string ToString()
    {
        return Text;
    }
}
