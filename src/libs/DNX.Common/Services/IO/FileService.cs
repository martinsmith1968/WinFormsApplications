namespace DNX.Common.Services.IO;

public class FileService
{
    public static string? ReadAllTextSafely(string? fileName, string? defaultValue = null)
    {
        try
        {
            return File.ReadAllText(fileName ?? string.Empty);
        }
        catch
        {
            return defaultValue;
        }
    }

    public static bool WriteAllTextSafely(string? fileName, string? contents)
    {
        try
        {
            File.WriteAllText(fileName, contents);
            return true;
        }
        catch
        {
            return false;
        }
    }
}
