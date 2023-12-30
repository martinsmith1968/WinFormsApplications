using System.Configuration;
using DNX.Helpers.Enumerations;
using DNX.Helpers.Strings;
using QuickCalendar.Domain.Models.Types;
using QuickCalendar.Extensions;
using QuickCalendar.Properties;

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

            lvwRawProperties.Items.Clear();
            foreach (var propertyItem in UserSettings.PropertyValues)
            {
                if (propertyItem is not SettingsPropertyValue propertyValue)
                    continue;

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

        private bool ValidateForm()
        {
            // TODO: Add as necessary
            return true;
        }

        private void ProgramOptionsForm_Load(object sender, EventArgs e)
        {
            tbcOptions.Dock = DockStyle.Fill;
            lblErrorText.Text = "";
            lblErrorText.BorderStyle = BorderStyle.None;
            lvwRawProperties.Dock = DockStyle.Fill;
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
                var itemText = StringExtensions.CoalesceNullOrEmpty(value.GetDescription(), value.ToString());
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
    }
}
