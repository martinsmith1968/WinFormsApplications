using Newtonsoft.Json;

#pragma warning disable CS8604 // Possible null reference argument.

namespace DNX.Common.Services;

public class JsonService
{
    public static T? DeserializeSafely<T>(string? text, T? defaultValue = default)
    {
        try
        {
            return JsonConvert.DeserializeObject<T>(text);
        }
        catch
        {
            return defaultValue;
        }
    }

    public static string? SerializeSafely<T>(T? instance, string? defaultValue = null)
    {
        try
        {
            return JsonConvert.SerializeObject(instance);
        }
        catch
        {
            return defaultValue;
        }
    }
}
