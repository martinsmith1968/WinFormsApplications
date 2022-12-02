namespace QuickCalendar.UserControls;

public partial class CalendarSetViewer : UserControl
{
    public void SetCalendarDimensions(Size size)
    {
        mcalCalendar.CalendarDimensions = size;
        ClientSize = mcalCalendar.Size;
    }

    public CalendarSetViewer()
    {
        InitializeComponent();
    }

    private void CalendarSetViewer_Load(object sender, EventArgs e)
    {
        mcalCalendar.Dock = DockStyle.Fill;
    }
}