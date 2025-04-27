using DNX.Extensions.Strings;

namespace DNX.Common.Extensions;

public static class StringExtensions
{
    public static string JoinAndSurround(this IEnumerable<string> items,
        string? separator = ",",
        string? prefix = "[",
        string? suffix = "]"
        )
    {
        return string.Join(separator, items).EnsureStartsAndEndsWith(prefix, suffix);
    }
}
