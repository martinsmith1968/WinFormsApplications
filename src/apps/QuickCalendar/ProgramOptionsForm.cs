using System.Configuration;
using DNX.Extensions.Enumerations;
using DNX.Extensions.Strings;
using QuickCalendar.Domain.Models.Types;
using QuickCalendar.Extensions;
using QuickCalendar.Properties;

#pragma warning disable IDE1006  // Methods starting with lowercase character

namespace QuickCalendar
{
    internal partial class ProgramOptionsForm : Form
    {
        public UserSettings UserSettings { get; private init; } = UserSettings.Default;

        public ProgramOptionsForm()
        {
            InitializeComponent();
        }

        public static bool EditProgramOptions(UserSettings userSettings, Form? form = null)
        {
            var instance = new ProgramOptionsForm()
            {
                UserSettings = userSettings
            };

            if (form != null)
            {
                instance.Parent = form;
            }

            var result = instance.ShowDialog();

            return result == DialogResult.OK;
        }

        private void LoadUserSettingsToForm(UserSettings userSettings)
        {
            chkCloseOnEscape.Checked = userSettings.CloseOnEscape;

            cboShowCalendarNameInStatusBar.SelectedItem = cboShowCalendarNameInStatusBar.GetItems<FileNameDisplayTypeComboItem>()
                                                          .FirstOrDefault(x => x.Value == userSettings.GetShowCalendarNameInStatusBarType())
                                                      ?? cboShowCalendarNameInStatusBar.GetItems<FileNameDisplayTypeComboItem>().FirstOrDefault();

            cboShowCalendarNameInWindowTitle.SelectedItem = cboShowCalendarNameInWindowTitle.GetItems<FileNameDisplayTypeComboItem>()
                                                          .FirstOrDefault(x => x.Value == userSettings.GetShowCalendarNameInWindowTitleType())
                                                      ?? cboShowCalendarNameInWindowTitle.GetItems<FileNameDisplayTypeComboItem>().FirstOrDefault();

            chkLoadLastFileOnStartup.Checked = userSettings.LoadLastOpenedFileOnStartup;

            lblLastOpenedFileName.Text = userSettings.LastOpenedFileName;

            lvwRawProperties.Items.Clear();
            foreach (var propertyItem in UserSettings.PropertyValues)
            {
                if (propertyItem is not SettingsPropertyValue propertyValue)
                {
                    continue;
                }

                var item = lvwRawProperties.Items.Add(propertyValue.Name);
                item.SubItems.Add(propertyValue.PropertyValue.ToString());
            }
        }

        private void SaveFormToUserSettings(UserSettings userSettings)
        {
            userSettings.CloseOnEscape = chkCloseOnEscape.Checked;

            userSettings.ShowCalendarNameInStatusBar = ((cboShowCalendarNameInStatusBar.SelectedItem as FileNameDisplayTypeComboItem)?.Value ?? CalendarSetDisplayNameType.None)
                .ToString();

            userSettings.ShowCalendarNameInWindowTitle = ((cboShowCalendarNameInWindowTitle.SelectedItem as FileNameDisplayTypeComboItem)?.Value ?? CalendarSetDisplayNameType.None)
                .ToString();
        }

        private void ShowErrorMessage(string? text = null, TimeSpan? clearAfter = null)
        {
            text = string.IsNullOrWhiteSpace(text)
                ? text
                : $"Error: {text}";

            lblErrorText.Text = text;

            if (clearAfter.HasValue)
            {
                timerErrorMessageReset.Interval = Convert.ToInt32(clearAfter.Value.TotalMilliseconds);
                timerErrorMessageReset.Enabled = true;
            }
        }

        private bool ValidateForm()
        {
            if (cboShowCalendarNameInStatusBar.SelectedItem == null)
            {
                ShowErrorMessage($"Setting not provided for {nameof(cboShowCalendarNameInStatusBar).RemoveStartsWith("cbo").Wordify()}");
                return false;
            }

            if (cboShowCalendarNameInWindowTitle.SelectedItem == null)
            {
                ShowErrorMessage($"Setting not provided for {nameof(cboShowCalendarNameInWindowTitle).RemoveStartsWith("cbo").Wordify()}");
                return false;
            }

            return true;
        }

        private void ProgramOptionsForm_Load(object sender, EventArgs e)
        {
            tbcOptions.Dock = DockStyle.Fill;
            lblErrorText.Text = "";
            lblErrorText.BorderStyle = BorderStyle.None;
            lvwRawProperties.Dock = DockStyle.Fill;
            lblLastOpenedFileName.BorderStyle = BorderStyle.None;
#if !DEBUG
            tabDebugging.Visible = false;
#endif

            SetupForm();

            LoadUserSettingsToForm(UserSettings);
        }

        private void SetupForm()
        {
            cboShowCalendarNameInWindowTitle.Items.Clear();
            cboShowCalendarNameInStatusBar.Items.Clear();

            foreach (var value in Enum.GetValues<CalendarSetDisplayNameType>())
            {
                var itemText = value.GetDescription().CoalesceNullOrEmptyWith(value.ToString());
                var item = new FileNameDisplayTypeComboItem(value, itemText);

                cboShowCalendarNameInStatusBar.Items.Add(item);
                cboShowCalendarNameInWindowTitle.Items.Add(item);
            }

            ActiveControl = chkCloseOnEscape;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (!ValidateForm())
            {
                return;
            }

            SaveFormToUserSettings(UserSettings);

            DialogResult = DialogResult.OK;
        }

        private void timerErrorMessageReset_Tick(object sender, EventArgs e)
        {
            ShowErrorMessage();
            timerErrorMessageReset.Enabled = false;
        }

        private void chkLoadLastFileOnStartup_CheckedChanged(object sender, EventArgs e)
        {
            lblLastOpenedFileName.Visible = chkLoadLastFileOnStartup.Checked;
        }
    }
}
