using QuickCalendar.Domain.Models;

#pragma warning disable IDE1006

namespace QuickCalendar;

public partial class CalendarSizeForm : Form
{
    private CalendarSize CalendarSize { get; set; } = CalendarSize.Default;

    public static CalendarSize? EditCalendarSize(CalendarSize defaultValue, Form? form = null)
    {
        var instance = new CalendarSizeForm();
        instance.CalendarSize = defaultValue;

        if (form != null)
        {
            instance.Parent = form;
        }

        var result = instance.ShowDialog();

        return result == DialogResult.OK
            ? instance.CalendarSize
            : null;
    }

    public CalendarSizeForm()
    {
        InitializeComponent();
    }

    private void CalendarSizeForm_Load(object sender, EventArgs e)
    {
        pnlSettings.Dock = DockStyle.Fill;

        foreach (var calendarSize in CalendarSize.AllowedCalendarSizes)
        {
            var index = cboCalendarSize.Items.Add(calendarSize);

            if (calendarSize.Width == CalendarSize.Width && calendarSize.Height == CalendarSize.Height)
                cboCalendarSize.SelectedIndex = index;
        }
    }

    private void cboCalendarSize_SelectedIndexChanged(object sender, EventArgs e)
    {
        var item = (CalendarSize)cboCalendarSize.SelectedItem;

        DrawPreview(new Size(item.Width, item.Height));
    }

    private void cboCalendarSize_SelectedValueChanged(object sender, EventArgs e)
    {
        var item = (CalendarSize)cboCalendarSize.SelectedItem;

        DrawPreview(new Size(item.Width, item.Height));
    }

    private void btnOK_Click(object sender, EventArgs e)
    {
        if (cboCalendarSize.SelectedItem != null)
        {
            CalendarSize = (CalendarSize)cboCalendarSize.SelectedItem;

            DialogResult = DialogResult.OK;
        }
    }

    private void DrawPreview(Size size)
    {
        try
        {
            pnlPreview.SuspendLayout();

            while (pnlPreview.Controls.Count > 0)
            {
                pnlPreview.Controls.RemoveAt(0);
            }

            var pictureCount = size.Width * size.Height;

            var positions = new List<Point>();
            for (var row = 1; row <= size.Height; ++row)
            {
                for (var column = 1; column <= size.Width; ++column)
                {
                    var point = new Point(pnlPreview.Width - (column  * picSampleCalendarMonth.Height), (row - 1) * picSampleCalendarMonth.Width);
                    positions.Add(point);
                }
            }

            foreach (var index in Enumerable.Range(0, pictureCount))
            {
                var picture = new PictureBox();
                picture.Name = $"picPreview{index}";
                picture.Visible = false;
                picture.Size = picSampleCalendarMonth.Size;
                picture.Image = picSampleCalendarMonth.Image;
                picture.SizeMode = picSampleCalendarMonth.SizeMode;
                picture.Padding = picSampleCalendarMonth.Padding;
                picture.Parent = pnlPreview;
                picture.Location = positions[index];
                picture.Visible = true;

                pnlPreview.Controls.Add(picture);
            }
        }
        finally
        {
            pnlPreview.ResumeLayout();
            pnlPreview.Update();
        }
    }
}
