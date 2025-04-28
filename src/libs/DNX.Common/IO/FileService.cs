using DNX.Extensions.Strings;

namespace DNX.Common.IO;

public class FileService
{
    public static string? ReadAllTextSafely(string fileName, string? defaultValue = null)
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

    public static bool WriteAllTextSafely(string fileName, string? contents)
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

    public static FileInfo? FindAppOnPath(string fileName, string? workingDirectory)
    {
        var executableExtensions = new[] { "exe", "com", "bat", "cmd", "vbs", "scr" };

        var paths = (Environment.GetEnvironmentVariable("PATH") ?? string.Empty)
            .Split(";");

        var directories = new List<string>(paths);
        directories.Insert(
            0,
            workingDirectory.IsNullOrWhiteSpace()
                ? Directory.GetCurrentDirectory()
                : workingDirectory!
        );

        return FindFileInDirectories(fileName, directories, executableExtensions);
    }

    public static FileInfo? FindFileInDirectories(string fileName, IList<string>? directories = null, IList<string>? alternateExtensions = null)
    {
        if (fileName.IsNullOrWhiteSpace())
        {
            return null;
        }

        if (File.Exists(fileName))
        {
            return new FileInfo(fileName);
        }

        if (directories != null)
        {
            foreach (var dir in directories)
            {
                var file = Path.Combine(dir, fileName);
                if (File.Exists(file))
                {
                    return new FileInfo(file);
                }

                if (alternateExtensions != null)
                {
                    foreach (var ext in alternateExtensions)
                    {
                        file = Path.Combine(dir, Path.ChangeExtension(fileName, ext));
                        if (File.Exists(file))
                        {
                            return new FileInfo(file);
                        }

                        file = Path.Combine(dir, fileName + "." + ext);
                        if (File.Exists(file))
                        {
                            return new FileInfo(file);
                        }
                    }
                }
            }
        }

        return null;
    }
}
