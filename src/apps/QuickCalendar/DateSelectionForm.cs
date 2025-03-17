using QuickCalendar.Domain.Models;

#pragma warning disable IDE1006

namespace QuickCalendar;

public partial class DateSelectionForm : Form
{
    private DateRange DateRange { get; set; } = DateRange.Default;

    public static DateRange? EditDateRange(DateRange defaultValue, Form? form = null)
    {
        var instance = new DateSelectionForm
        {
            DateRange = defaultValue
        };

        if (form != null)
        {
            instance.Parent = form;
        }

        var result = instance.ShowDialog();

        return result == DialogResult.OK
            ? instance.DateRange
            : null;
    }

    public DateSelectionForm()
    {
        InitializeComponent();
    }

    private void ShowErrorMessage(string? message = null)
    {
        lblErrorMessage.Text = message;

        timerErrorMessageReset.Interval = Convert.ToInt32(TimeSpan.FromSeconds(5).TotalMilliseconds);
        timerErrorMessageReset.Enabled = true;
    }

    private bool ValidateForm()
    {
        if (tbcDateSelection.SelectedTab == tabDateRange)
        {
            if (dtpRangeEndDate.Value < dtpRangeStartDate.Value)
            {
                ShowErrorMessage("End Date cannot be before Start Date");
                return false;
            }
        }

        return true;
    }

    private void DateSelection_Load(object sender, EventArgs e)
    {
        tbcDateSelection.Dock = DockStyle.Fill;

        ShowErrorMessage();

        dtpSpecifiedDate.Value = DateRange.StartDate;
        dtpRangeStartDate.Value = DateRange.StartDate;
        dtpRangeEndDate.Value = DateRange.EndDate;

        tbcDateSelection.SelectedTab = DateRange.IsRange
            ? tabDateRange
            : tabSpecifiedDate;

        ActiveControl = tbcDateSelection.SelectedTab == tabDateRange
            ? dtpRangeStartDate
            : dtpSpecifiedDate;
    }

    private void btnOK_Click(object sender, EventArgs e)
    {
        if (ValidateForm())
        {
            DateRange = tbcDateSelection.SelectedTab == tabSpecifiedDate
                ? new DateRange(dtpSpecifiedDate.Value)
                : tbcDateSelection.SelectedTab == tabDateRange
                    ? new DateRange(dtpRangeStartDate.Value, dtpRangeEndDate.Value)
                    : DateRange.Default;

            DialogResult = DialogResult.OK;
        }
    }

    private void timerErrorMessageReset_Tick(object sender, EventArgs e)
    {
        ShowErrorMessage();
        timerErrorMessageReset.Enabled = false;
    }
}
