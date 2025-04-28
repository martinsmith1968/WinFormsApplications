using System.Drawing;

namespace Toaster.Domain.Models;

public class ToastDefinition
{
    public string? Title { get; set; }

    public string? MessageText { get; set; }



    public Size Size => new Size();
}
