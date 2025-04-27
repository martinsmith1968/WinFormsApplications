using System.Diagnostics;

namespace DNX.Common.Debugging;

public class CodeTimer : IDisposable
{
    public Stopwatch Stopwatch { get; } = new();

    public CodeTimer()
    {
        Stopwatch.Start();
    }

    public void Dispose()
    {
        Stopwatch.Stop();
    }
}
