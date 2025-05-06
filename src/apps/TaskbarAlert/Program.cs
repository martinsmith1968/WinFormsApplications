using TaskbarAlert.Legacy.CommandLine;

namespace TaskbarAlert;

internal static class Program
{
    static Arguments Arguments = new Arguments();

    /// <summary>
    /// The main entry point for the application.
    /// </summary>
    [STAThread]
    static void Main()
    {
        // Parse Command Line
        //Arguments args = Arguments.ParseArgs();
        bool argumentsOK = Parser.ParseArguments(GetCommandLineArgs(), Arguments);

        if (!argumentsOK || Arguments.Help)
        {
            // Usage
            MessageBox.Show(string.Format("Invalid Command Line{0}{0}{1}", Environment.NewLine, Parser.ArgumentsUsage(typeof(Arguments), 300)), "Taskbar Alert");
            return;
        }

        //Application.EnableVisualStyles();
        //Application.SetCompatibleTextRenderingDefault(false);
        //Application.Run(new Form1());

        ParseArguments();

        // Validate again (More than Arguments class parameters support)
        if ((!Arguments.HasConfigFile) && (!Arguments.HasType))
        {
            // Usage
            MessageBox.Show(string.Format("Invalid Command Line{0}{0}{1}", Environment.NewLine, Parser.ArgumentsUsage(typeof(Arguments), 300)), "Taskbar Alert");
            return;
        }

        // Create the Alert
        Alert alert = null;

        try
        {
            if (Arguments.HasConfigFile)
            {
                alert = Alert.CreateFromFile(Arguments.ConfigFile);
            }
            else
            {
                alert = Alert.Create(Arguments.Type, Arguments);
            }

            if (alert == null)
                throw new Exception("Unable to create Alert !");
        }
        catch (Exception ex)
        {
            // Usage
            MessageBox.Show(string.Format("{0}\n\n{1}", ex.Message, Parser.ArgumentsUsage(typeof(Arguments), 300)), "Taskbar Alert Error");
            return;
        }

        // Display
        alert.OnAlertClosed += new Alert.AlertClosed(alert_OnAlertClosed);
        alert.Display();
        Application.Run();
    }

    /// <summary>
    /// Handles the OnAlertClosed event of the alert control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="args">The <see cref="System.EventArgs"/> instance containing the event data.</param>
    static void alert_OnAlertClosed(object sender, EventArgs args)
    {
        Application.Exit();
    }

    /// <summary>
    /// Gets the command line args.
    /// </summary>
    /// <returns></returns>
    static string[] GetCommandLineArgs()
    {
        List<string> args = new List<string>();

        args.AddRange(Environment.GetCommandLineArgs());

        if (args.Count > 0)
            args.RemoveAt(0);

        return args.ToArray();
    }

    /// <summary>
    /// Parses the arguments.
    /// </summary>
    static void ParseArguments()
    {
        Arguments.Text = ParseText(Arguments.Text);
        Arguments.Title = ParseText(Arguments.Title);
    }

    /// <summary>
    /// Parses the text.
    /// </summary>
    /// <param name="text">The text.</param>
    /// <returns></returns>
    static string ParseText(string text)
    {
        if (string.IsNullOrEmpty(text))
            return text;

        text = text.Replace("{stime}", DateTime.Now.ToShortTimeString());
        text = text.Replace("{ltime}", DateTime.Now.ToLongTimeString());
        text = text.Replace("{sdate}", DateTime.Now.ToShortDateString());
        text = text.Replace("{ldate}", DateTime.Now.ToLongDateString());

        return text;
    }
}
