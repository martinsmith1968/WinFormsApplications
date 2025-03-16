namespace Toaster;

public partial class ToastMessageForm : Form
{
    public Point TargetLocation = Point.Empty;

    public ToastMessageForm()
    {
        InitializeComponent();
    }

    private void ToastMessageForm_Load(object sender, EventArgs e)
    {
        //
    }

    private void ToastMessageForm_Shown(object sender, EventArgs e)
    {
        timRevealer.Enabled = true;
    }

    private void timRevealer_Tick(object sender, EventArgs e)
    {
        Location = new Point(
            Location.X,
            Location.Y - 20
        );

        if (Location.Y <= TargetLocation.Y)
        {
            timRevealer.Enabled = false;
            timCloser.Enabled = true;
        }
    }

    private void timCloser_Tick(object sender, EventArgs e)
    {
        Close();
    }
}
