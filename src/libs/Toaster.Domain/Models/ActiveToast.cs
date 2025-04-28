using System.Drawing;

namespace Toaster.Domain.Models;

public class ActiveToast(int index, int ownerProcessId, ToastDefinition definition, ToastAction action)
{
    public int Index { get; } = index;
    public int OwnerProcessId { get; } = ownerProcessId;
    public  ToastDefinition Definition { get; } = definition;
    public ToastAction Action { get; } = action;
    public Point Location { get; } = Point.Empty;   // TODO: This needs to be computed
}
