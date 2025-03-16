namespace Toaster;

internal static class Program
{
    /// <summary>
    ///  The main entry point for the application.
    /// </summary>
    [STAThread]
    static void Main()
    {
        // To customize application configuration such as set high DPI settings or default font,
        // see https://aka.ms/applicationconfiguration.
        ApplicationConfiguration.Initialize();

        var monitor = Screen.PrimaryScreen
                      ?? Screen.AllScreens.First();


        var toastMessageForm = new ToastMessageForm()
        {
            Size = new Size(400, 200),
            BackColor = Color.FromKnownColor(KnownColor.CornflowerBlue),
            TopMost = true,
            TopLevel = true,

        };

        toastMessageForm.Location = new Point(
            monitor.Bounds.Size.Width - toastMessageForm.Width,
            monitor.Bounds.Size.Height // - toastMessageForm.Height
        );

        toastMessageForm.TargetLocation = new Point(
            monitor.Bounds.Size.Width - toastMessageForm.Width,
            monitor.Bounds.Size.Height - toastMessageForm.Height
        );





        Application.Run(toastMessageForm);
    }
}
