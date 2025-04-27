using DNX.Common.Services;
using DNX.Common.Services.IO;
using Newtonsoft.Json;
using Toaster.Domain.Models;

namespace Toaster.Domain.Services;

/// <summary>
/// Provides functionality to manage toast definitions within the application.
///
/// </summary>
public class ToastManager
{
    private static readonly string FileName = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Toaster", "ToastDefinitions.json");
    public List<ToastDefinition> ToastDefinitions { get; } = [];

    public ToastManager()
    {
        LoadToastDefinitions();
    }

    private void LoadToastDefinitions()
    {
        ToastDefinitions.Clear();

        var contents = FileService.ReadAllTextSafely(FileName);
        var loadedDefinitions = JsonService.DeserializeSafely<IList<ToastDefinition>>(contents);

        if (loadedDefinitions != null)
        {
            ToastDefinitions.AddRange(loadedDefinitions);
        }
    }

    private void SaveToastDefinitions()
    {
        var contents = JsonService.SerializeSafely(ToastDefinitions);

        FileService.WriteAllTextSafely(FileName, contents);
    }

    public void AddToastDefinition(ToastDefinition toastDefinition)
    {
        ToastDefinitions.Add(toastDefinition);

        SaveToastDefinitions();
    }
}
