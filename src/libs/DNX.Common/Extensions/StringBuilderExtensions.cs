using System.Text;

namespace DNX.Common.Extensions;

public static class StringBuilderExtensions
{
    public static void AppendSpace(this StringBuilder stringBuilder)
    {
        if (stringBuilder.Length > 0 && stringBuilder[^1] != ' ')
        {
            stringBuilder.Append(' ');
        }
    }
}
