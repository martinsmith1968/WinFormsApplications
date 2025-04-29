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

// Note yet sure how to implement, should :
// - Each toast message be handled by a separate process instance
//   - Need to send message between instance to alert them to changes
// - Each toast request is forwarded to the current running process
//   - Or handled by the current process if no other is running

// https://stackoverflow.com/questions/15017506/using-filesystemwatcher-to-monitor-a-directory
// https://stackoverflow.com/questions/6392031/how-to-check-if-another-instance-of-the-application-is-running
// https://stackoverflow.com/questions/79467351/pass-a-command-line-argument-to-a-running-instance-of-winform-application   <- THIS
