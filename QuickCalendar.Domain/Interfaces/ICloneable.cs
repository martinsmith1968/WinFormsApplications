namespace QuickCalendar.Domain.Interfaces;

public interface ICloneable<T> : ICopyable<T>
{
    T Clone();
}
