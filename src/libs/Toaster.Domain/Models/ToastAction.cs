using Toaster.Domain.Models.Types;

namespace Toaster.Domain.Models;

public class ToastAction
{
    public ShowTransitionType ShowTransition { get; set; } = ShowTransitionType.None;
    public TimeSpan ShowTransitionTimeSpan { get; set; } = TimeSpan.FromSeconds(1);
    public HideTransitionType HideTransition { get; set; } = HideTransitionType.None;
    public TimeSpan HideTransitionTimeSpan { get; set; } = TimeSpan.FromSeconds(0.5);
}
