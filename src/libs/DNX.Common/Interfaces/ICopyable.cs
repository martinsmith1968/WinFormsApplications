namespace DNX.Common.Interfaces;

public interface ICopyable<in T>
{
    void CopyFrom(T other);
}
