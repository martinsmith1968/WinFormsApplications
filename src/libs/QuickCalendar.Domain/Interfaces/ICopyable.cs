namespace QuickCalendar.Domain.Interfaces;

public interface ICopyable<in T>
{
    void CopyFrom(T other);
}
