namespace QuickCalendar
{
    partial class CalendarDetailsForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            var resources = new System.ComponentModel.ComponentResourceManager(typeof(CalendarDetailsForm));
            panButtonBar = new Panel();
            lblErrorText = new Label();
            btnCancel = new Button();
            btnOK = new Button();
            tbcEditor = new TabControl();
            tabDetails = new TabPage();
            btnSetDisplayFont = new Button();
            txtDisplayFont = new TextBox();
            lblDisplayFont = new Label();
            lblDetailsExampleDateDisplayFormat = new Label();
            txtDetailsDateDisplayFormat = new TextBox();
            lblDetailsDateDisplayFormat = new Label();
            dtpDetailsMaximumDate = new DateTimePicker();
            dtpDetailsMinimumDate = new DateTimePicker();
            lblDetailsMaximumDate = new Label();
            lblDetailsMinimumDate = new Label();
            txtDetailsDescription = new TextBox();
            lblDetailsDescription = new Label();
            txtDetailsName = new TextBox();
            lblDetailsName = new Label();
            tabVisualDetails = new TabPage();
            cboVisualsFirstVisibleMonth = new ComboBox();
            lblVisualsFirstVisibleMonth = new Label();
            cboVisualsFirstDayOfWeek = new ComboBox();
            lblVisualsFirstDayOfWeek = new Label();
            chkVisualsShowTodayCircle = new CheckBox();
            chkVisualsShowToday = new CheckBox();
            chkVisualsShowWeekNumbers = new CheckBox();
            tabDates = new TabPage();
            lvwDatesNotableDates = new ListView();
            colDatesColGeneratorType = new ColumnHeader();
            colDatesGeneratedCount = new ColumnHeader();
            colDatesDefinition = new ColumnHeader();
            tsDatesContext = new ToolStrip();
            tsctxDatesAdd = new ToolStripButton();
            tsctxDatesRemove = new ToolStripButton();
            toolStripSeparator2 = new ToolStripSeparator();
            tsctxDatesEdit = new ToolStripButton();
            toolStripSeparator1 = new ToolStripSeparator();
            tsctxDatesMoveUp = new ToolStripButton();
            tsctxDatesMoveDown = new ToolStripButton();
            timerErrorMessageReset = new System.Windows.Forms.Timer(components);
            dlgFontBrowser = new FontDialog();
            panButtonBar.SuspendLayout();
            tbcEditor.SuspendLayout();
            tabDetails.SuspendLayout();
            tabVisualDetails.SuspendLayout();
            tabDates.SuspendLayout();
            tsDatesContext.SuspendLayout();
            SuspendLayout();
            // 
            // panButtonBar
            // 
            panButtonBar.Controls.Add(lblErrorText);
            panButtonBar.Controls.Add(btnCancel);
            panButtonBar.Controls.Add(btnOK);
            panButtonBar.Dock = DockStyle.Bottom;
            panButtonBar.Location = new Point(0, 327);
            panButtonBar.Name = "panButtonBar";
            panButtonBar.Size = new Size(587, 38);
            panButtonBar.TabIndex = 0;
            // 
            // lblErrorText
            // 
            lblErrorText.BorderStyle = BorderStyle.FixedSingle;
            lblErrorText.ForeColor = Color.Red;
            lblErrorText.Location = new Point(4, 10);
            lblErrorText.Name = "lblErrorText";
            lblErrorText.Size = new Size(418, 19);
            lblErrorText.TabIndex = 2;
            lblErrorText.Text = "Error Message";
            // 
            // btnCancel
            // 
            btnCancel.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnCancel.Location = new Point(509, 8);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(75, 23);
            btnCancel.TabIndex = 1;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnOK
            // 
            btnOK.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnOK.Location = new Point(428, 8);
            btnOK.Name = "btnOK";
            btnOK.Size = new Size(75, 23);
            btnOK.TabIndex = 0;
            btnOK.Text = "OK";
            btnOK.UseVisualStyleBackColor = true;
            btnOK.Click += btnOK_Click;
            // 
            // tbcEditor
            // 
            tbcEditor.Controls.Add(tabDetails);
            tbcEditor.Controls.Add(tabVisualDetails);
            tbcEditor.Controls.Add(tabDates);
            tbcEditor.Dock = DockStyle.Top;
            tbcEditor.Location = new Point(0, 0);
            tbcEditor.Name = "tbcEditor";
            tbcEditor.SelectedIndex = 0;
            tbcEditor.Size = new Size(587, 305);
            tbcEditor.TabIndex = 1;
            // 
            // tabDetails
            // 
            tabDetails.Controls.Add(btnSetDisplayFont);
            tabDetails.Controls.Add(txtDisplayFont);
            tabDetails.Controls.Add(lblDisplayFont);
            tabDetails.Controls.Add(lblDetailsExampleDateDisplayFormat);
            tabDetails.Controls.Add(txtDetailsDateDisplayFormat);
            tabDetails.Controls.Add(lblDetailsDateDisplayFormat);
            tabDetails.Controls.Add(dtpDetailsMaximumDate);
            tabDetails.Controls.Add(dtpDetailsMinimumDate);
            tabDetails.Controls.Add(lblDetailsMaximumDate);
            tabDetails.Controls.Add(lblDetailsMinimumDate);
            tabDetails.Controls.Add(txtDetailsDescription);
            tabDetails.Controls.Add(lblDetailsDescription);
            tabDetails.Controls.Add(txtDetailsName);
            tabDetails.Controls.Add(lblDetailsName);
            tabDetails.Location = new Point(4, 24);
            tabDetails.Name = "tabDetails";
            tabDetails.Padding = new Padding(3);
            tabDetails.Size = new Size(579, 277);
            tabDetails.TabIndex = 0;
            tabDetails.Text = "Details";
            tabDetails.UseVisualStyleBackColor = true;
            // 
            // btnSetDisplayFont
            // 
            btnSetDisplayFont.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnSetDisplayFont.Location = new Point(496, 144);
            btnSetDisplayFont.Name = "btnSetDisplayFont";
            btnSetDisplayFont.Size = new Size(75, 23);
            btnSetDisplayFont.TabIndex = 6;
            btnSetDisplayFont.Text = "&Font...";
            btnSetDisplayFont.UseVisualStyleBackColor = true;
            btnSetDisplayFont.Click += btnSetDisplayFont_Click;
            // 
            // txtDisplayFont
            // 
            txtDisplayFont.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            txtDisplayFont.Location = new Point(91, 145);
            txtDisplayFont.Name = "txtDisplayFont";
            txtDisplayFont.ReadOnly = true;
            txtDisplayFont.Size = new Size(399, 23);
            txtDisplayFont.TabIndex = 5;
            // 
            // lblDisplayFont
            // 
            lblDisplayFont.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            lblDisplayFont.AutoSize = true;
            lblDisplayFont.Location = new Point(12, 148);
            lblDisplayFont.Name = "lblDisplayFont";
            lblDisplayFont.Size = new Size(78, 15);
            lblDisplayFont.TabIndex = 4;
            lblDisplayFont.Text = "Display Font :";
            // 
            // lblDetailsExampleDateDisplayFormat
            // 
            lblDetailsExampleDateDisplayFormat.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            lblDetailsExampleDateDisplayFormat.BorderStyle = BorderStyle.FixedSingle;
            lblDetailsExampleDateDisplayFormat.Location = new Point(287, 243);
            lblDetailsExampleDateDisplayFormat.Name = "lblDetailsExampleDateDisplayFormat";
            lblDetailsExampleDateDisplayFormat.Size = new Size(286, 23);
            lblDetailsExampleDateDisplayFormat.TabIndex = 10;
            lblDetailsExampleDateDisplayFormat.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // txtDetailsDateDisplayFormat
            // 
            txtDetailsDateDisplayFormat.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            txtDetailsDateDisplayFormat.Location = new Point(139, 244);
            txtDetailsDateDisplayFormat.Name = "txtDetailsDateDisplayFormat";
            txtDetailsDateDisplayFormat.Size = new Size(142, 23);
            txtDetailsDateDisplayFormat.TabIndex = 9;
            txtDetailsDateDisplayFormat.TextChanged += txtDateDisplayFormat_TextChanged;
            // 
            // lblDetailsDateDisplayFormat
            // 
            lblDetailsDateDisplayFormat.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            lblDetailsDateDisplayFormat.AutoSize = true;
            lblDetailsDateDisplayFormat.Location = new Point(12, 247);
            lblDetailsDateDisplayFormat.Name = "lblDetailsDateDisplayFormat";
            lblDetailsDateDisplayFormat.Size = new Size(119, 15);
            lblDetailsDateDisplayFormat.TabIndex = 8;
            lblDetailsDateDisplayFormat.Text = "Date Display Format :";
            // 
            // dtpDetailsMaximumDate
            // 
            dtpDetailsMaximumDate.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            dtpDetailsMaximumDate.Location = new Point(139, 214);
            dtpDetailsMaximumDate.Name = "dtpDetailsMaximumDate";
            dtpDetailsMaximumDate.Size = new Size(142, 23);
            dtpDetailsMaximumDate.TabIndex = 7;
            // 
            // dtpDetailsMinimumDate
            // 
            dtpDetailsMinimumDate.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            dtpDetailsMinimumDate.Location = new Point(139, 185);
            dtpDetailsMinimumDate.Name = "dtpDetailsMinimumDate";
            dtpDetailsMinimumDate.Size = new Size(142, 23);
            dtpDetailsMinimumDate.TabIndex = 6;
            // 
            // lblDetailsMaximumDate
            // 
            lblDetailsMaximumDate.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            lblDetailsMaximumDate.AutoSize = true;
            lblDetailsMaximumDate.Location = new Point(12, 220);
            lblDetailsMaximumDate.Name = "lblDetailsMaximumDate";
            lblDetailsMaximumDate.Size = new Size(95, 15);
            lblDetailsMaximumDate.TabIndex = 5;
            lblDetailsMaximumDate.Text = "Maximum Date :";
            // 
            // lblDetailsMinimumDate
            // 
            lblDetailsMinimumDate.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            lblDetailsMinimumDate.AutoSize = true;
            lblDetailsMinimumDate.Location = new Point(12, 191);
            lblDetailsMinimumDate.Name = "lblDetailsMinimumDate";
            lblDetailsMinimumDate.Size = new Size(93, 15);
            lblDetailsMinimumDate.TabIndex = 4;
            lblDetailsMinimumDate.Text = "Minimum Date :";
            // 
            // txtDetailsDescription
            // 
            txtDetailsDescription.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            txtDetailsDescription.Location = new Point(91, 48);
            txtDetailsDescription.Multiline = true;
            txtDetailsDescription.Name = "txtDetailsDescription";
            txtDetailsDescription.Size = new Size(480, 91);
            txtDetailsDescription.TabIndex = 3;
            // 
            // lblDetailsDescription
            // 
            lblDetailsDescription.AutoSize = true;
            lblDetailsDescription.Location = new Point(12, 51);
            lblDetailsDescription.Name = "lblDetailsDescription";
            lblDetailsDescription.Size = new Size(73, 15);
            lblDetailsDescription.TabIndex = 2;
            lblDetailsDescription.Text = "Description :";
            // 
            // txtDetailsName
            // 
            txtDetailsName.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtDetailsName.Location = new Point(91, 18);
            txtDetailsName.Name = "txtDetailsName";
            txtDetailsName.ReadOnly = true;
            txtDetailsName.Size = new Size(480, 23);
            txtDetailsName.TabIndex = 1;
            txtDetailsName.Enter += txtDetailsName_Enter;
            // 
            // lblDetailsName
            // 
            lblDetailsName.AutoSize = true;
            lblDetailsName.Location = new Point(12, 21);
            lblDetailsName.Name = "lblDetailsName";
            lblDetailsName.Size = new Size(45, 15);
            lblDetailsName.TabIndex = 0;
            lblDetailsName.Text = "Name :";
            // 
            // tabVisualDetails
            // 
            tabVisualDetails.Controls.Add(cboVisualsFirstVisibleMonth);
            tabVisualDetails.Controls.Add(lblVisualsFirstVisibleMonth);
            tabVisualDetails.Controls.Add(cboVisualsFirstDayOfWeek);
            tabVisualDetails.Controls.Add(lblVisualsFirstDayOfWeek);
            tabVisualDetails.Controls.Add(chkVisualsShowTodayCircle);
            tabVisualDetails.Controls.Add(chkVisualsShowToday);
            tabVisualDetails.Controls.Add(chkVisualsShowWeekNumbers);
            tabVisualDetails.Location = new Point(4, 24);
            tabVisualDetails.Name = "tabVisualDetails";
            tabVisualDetails.Padding = new Padding(3);
            tabVisualDetails.Size = new Size(579, 277);
            tabVisualDetails.TabIndex = 1;
            tabVisualDetails.Text = "Visual Details";
            tabVisualDetails.UseVisualStyleBackColor = true;
            // 
            // cboVisualsFirstVisibleMonth
            // 
            cboVisualsFirstVisibleMonth.DropDownStyle = ComboBoxStyle.DropDownList;
            cboVisualsFirstVisibleMonth.FormattingEnabled = true;
            cboVisualsFirstVisibleMonth.Location = new Point(162, 128);
            cboVisualsFirstVisibleMonth.Name = "cboVisualsFirstVisibleMonth";
            cboVisualsFirstVisibleMonth.Size = new Size(138, 23);
            cboVisualsFirstVisibleMonth.TabIndex = 7;
            // 
            // lblVisualsFirstVisibleMonth
            // 
            lblVisualsFirstVisibleMonth.AutoSize = true;
            lblVisualsFirstVisibleMonth.Location = new Point(12, 131);
            lblVisualsFirstVisibleMonth.Name = "lblVisualsFirstVisibleMonth";
            lblVisualsFirstVisibleMonth.Size = new Size(111, 15);
            lblVisualsFirstVisibleMonth.TabIndex = 6;
            lblVisualsFirstVisibleMonth.Text = "First Visible &Month :";
            // 
            // cboVisualsFirstDayOfWeek
            // 
            cboVisualsFirstDayOfWeek.DropDownStyle = ComboBoxStyle.DropDownList;
            cboVisualsFirstDayOfWeek.FormattingEnabled = true;
            cboVisualsFirstDayOfWeek.Location = new Point(162, 96);
            cboVisualsFirstDayOfWeek.Name = "cboVisualsFirstDayOfWeek";
            cboVisualsFirstDayOfWeek.Size = new Size(138, 23);
            cboVisualsFirstDayOfWeek.TabIndex = 4;
            // 
            // lblVisualsFirstDayOfWeek
            // 
            lblVisualsFirstDayOfWeek.AutoSize = true;
            lblVisualsFirstDayOfWeek.Location = new Point(12, 99);
            lblVisualsFirstDayOfWeek.Name = "lblVisualsFirstDayOfWeek";
            lblVisualsFirstDayOfWeek.Size = new Size(104, 15);
            lblVisualsFirstDayOfWeek.TabIndex = 3;
            lblVisualsFirstDayOfWeek.Text = "&First Day of Week :";
            // 
            // chkVisualsShowTodayCircle
            // 
            chkVisualsShowTodayCircle.CheckAlign = ContentAlignment.MiddleRight;
            chkVisualsShowTodayCircle.Location = new Point(12, 71);
            chkVisualsShowTodayCircle.Name = "chkVisualsShowTodayCircle";
            chkVisualsShowTodayCircle.Size = new Size(166, 19);
            chkVisualsShowTodayCircle.TabIndex = 2;
            chkVisualsShowTodayCircle.Text = "Show Today &Circle :";
            chkVisualsShowTodayCircle.UseVisualStyleBackColor = true;
            // 
            // chkVisualsShowToday
            // 
            chkVisualsShowToday.CheckAlign = ContentAlignment.MiddleRight;
            chkVisualsShowToday.Location = new Point(12, 46);
            chkVisualsShowToday.Name = "chkVisualsShowToday";
            chkVisualsShowToday.Size = new Size(166, 19);
            chkVisualsShowToday.TabIndex = 1;
            chkVisualsShowToday.Text = "Show &Today :";
            chkVisualsShowToday.UseVisualStyleBackColor = true;
            // 
            // chkVisualsShowWeekNumbers
            // 
            chkVisualsShowWeekNumbers.CheckAlign = ContentAlignment.MiddleRight;
            chkVisualsShowWeekNumbers.Location = new Point(12, 21);
            chkVisualsShowWeekNumbers.Name = "chkVisualsShowWeekNumbers";
            chkVisualsShowWeekNumbers.Size = new Size(166, 19);
            chkVisualsShowWeekNumbers.TabIndex = 0;
            chkVisualsShowWeekNumbers.Text = "Show &Week Numbers :";
            chkVisualsShowWeekNumbers.UseVisualStyleBackColor = true;
            // 
            // tabDates
            // 
            tabDates.Controls.Add(lvwDatesNotableDates);
            tabDates.Controls.Add(tsDatesContext);
            tabDates.Location = new Point(4, 24);
            tabDates.Name = "tabDates";
            tabDates.Padding = new Padding(3);
            tabDates.Size = new Size(579, 277);
            tabDates.TabIndex = 2;
            tabDates.Text = "Dates";
            tabDates.UseVisualStyleBackColor = true;
            // 
            // lvwDatesNotableDates
            // 
            lvwDatesNotableDates.Columns.AddRange(new ColumnHeader[] { colDatesColGeneratorType, colDatesGeneratedCount, colDatesDefinition });
            lvwDatesNotableDates.Dock = DockStyle.Top;
            lvwDatesNotableDates.FullRowSelect = true;
            lvwDatesNotableDates.Location = new Point(3, 3);
            lvwDatesNotableDates.MultiSelect = false;
            lvwDatesNotableDates.Name = "lvwDatesNotableDates";
            lvwDatesNotableDates.Size = new Size(550, 190);
            lvwDatesNotableDates.TabIndex = 1;
            lvwDatesNotableDates.UseCompatibleStateImageBehavior = false;
            lvwDatesNotableDates.View = View.Details;
            lvwDatesNotableDates.DoubleClick += lvwDatesNotableDates_DoubleClick;
            // 
            // colDatesColGeneratorType
            // 
            colDatesColGeneratorType.Text = "Type";
            colDatesColGeneratorType.Width = 90;
            // 
            // colDatesGeneratedCount
            // 
            colDatesGeneratedCount.Text = "Count";
            colDatesGeneratedCount.TextAlign = HorizontalAlignment.Center;
            // 
            // colDatesDefinition
            // 
            colDatesDefinition.Text = "Definition";
            colDatesDefinition.Width = 330;
            // 
            // tsDatesContext
            // 
            tsDatesContext.Dock = DockStyle.Right;
            tsDatesContext.Items.AddRange(new ToolStripItem[] { tsctxDatesAdd, tsctxDatesRemove, toolStripSeparator2, tsctxDatesEdit, toolStripSeparator1, tsctxDatesMoveUp, tsctxDatesMoveDown });
            tsDatesContext.Location = new Point(553, 3);
            tsDatesContext.Name = "tsDatesContext";
            tsDatesContext.Padding = new Padding(0);
            tsDatesContext.Size = new Size(23, 271);
            tsDatesContext.TabIndex = 2;
            tsDatesContext.Text = "toolStrip1";
            // 
            // tsctxDatesAdd
            // 
            tsctxDatesAdd.DisplayStyle = ToolStripItemDisplayStyle.Image;
            tsctxDatesAdd.Image = Properties.Resources.add1;
            tsctxDatesAdd.ImageTransparentColor = Color.Magenta;
            tsctxDatesAdd.Name = "tsctxDatesAdd";
            tsctxDatesAdd.Size = new Size(22, 20);
            tsctxDatesAdd.ToolTipText = "Add...";
            tsctxDatesAdd.Click += tsctxDatesAdd_Click;
            // 
            // tsctxDatesRemove
            // 
            tsctxDatesRemove.DisplayStyle = ToolStripItemDisplayStyle.Image;
            tsctxDatesRemove.Image = Properties.Resources.remove1;
            tsctxDatesRemove.ImageTransparentColor = Color.Magenta;
            tsctxDatesRemove.Name = "tsctxDatesRemove";
            tsctxDatesRemove.Size = new Size(22, 20);
            tsctxDatesRemove.ToolTipText = "Remove";
            tsctxDatesRemove.Click += tsctxDatesRemove_Click;
            // 
            // toolStripSeparator2
            // 
            toolStripSeparator2.Name = "toolStripSeparator2";
            toolStripSeparator2.Size = new Size(22, 6);
            // 
            // tsctxDatesEdit
            // 
            tsctxDatesEdit.DisplayStyle = ToolStripItemDisplayStyle.Image;
            tsctxDatesEdit.Image = Properties.Resources.edit3;
            tsctxDatesEdit.ImageTransparentColor = Color.Magenta;
            tsctxDatesEdit.Name = "tsctxDatesEdit";
            tsctxDatesEdit.Size = new Size(22, 20);
            tsctxDatesEdit.ToolTipText = "Edit";
            tsctxDatesEdit.Click += tsctxDatesEdit_Click;
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new Size(22, 6);
            // 
            // tsctxDatesMoveUp
            // 
            tsctxDatesMoveUp.DisplayStyle = ToolStripItemDisplayStyle.Image;
            tsctxDatesMoveUp.Image = Properties.Resources.up1;
            tsctxDatesMoveUp.ImageTransparentColor = Color.Magenta;
            tsctxDatesMoveUp.Name = "tsctxDatesMoveUp";
            tsctxDatesMoveUp.Size = new Size(22, 20);
            tsctxDatesMoveUp.ToolTipText = "Move Up";
            tsctxDatesMoveUp.Click += tsctxDatesMoveUp_Click;
            // 
            // tsctxDatesMoveDown
            // 
            tsctxDatesMoveDown.DisplayStyle = ToolStripItemDisplayStyle.Image;
            tsctxDatesMoveDown.Image = Properties.Resources.down1;
            tsctxDatesMoveDown.ImageTransparentColor = Color.Magenta;
            tsctxDatesMoveDown.Name = "tsctxDatesMoveDown";
            tsctxDatesMoveDown.Size = new Size(22, 20);
            tsctxDatesMoveDown.ToolTipText = "Move Down";
            tsctxDatesMoveDown.Click += tsctxDatesMoveDown_Click;
            // 
            // timerErrorMessageReset
            // 
            timerErrorMessageReset.Tick += timerErrorMessageReset_Tick;
            // 
            // dlgFontBrowser
            // 
            dlgFontBrowser.MinSize = 5;
            // 
            // CalendarDetailsForm
            // 
            AcceptButton = btnOK;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = btnCancel;
            ClientSize = new Size(587, 365);
            Controls.Add(tbcEditor);
            Controls.Add(panButtonBar);
            Icon = (Icon)resources.GetObject("$this.Icon");
            KeyPreview = true;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "CalendarDetailsForm";
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterParent;
            Text = "Calendar Details";
            FormClosed += CalendarDetailsForm_FormClosed;
            Load += CalendarDetailsForm_Load;
            panButtonBar.ResumeLayout(false);
            tbcEditor.ResumeLayout(false);
            tabDetails.ResumeLayout(false);
            tabDetails.PerformLayout();
            tabVisualDetails.ResumeLayout(false);
            tabVisualDetails.PerformLayout();
            tabDates.ResumeLayout(false);
            tabDates.PerformLayout();
            tsDatesContext.ResumeLayout(false);
            tsDatesContext.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panButtonBar;
        private Button btnCancel;
        private Button btnOK;
        private TabControl tbcEditor;
        private TabPage tabDetails;
        private TextBox txtDetailsDescription;
        private Label lblDetailsDescription;
        private TextBox txtDetailsName;
        private Label lblDetailsName;
        private DateTimePicker dtpDetailsMaximumDate;
        private DateTimePicker dtpDetailsMinimumDate;
        private Label lblDetailsMaximumDate;
        private Label lblDetailsMinimumDate;
        private Label lblDetailsExampleDateDisplayFormat;
        private TextBox txtDetailsDateDisplayFormat;
        private Label lblDetailsDateDisplayFormat;
        private TabPage tabVisualDetails;
        private CheckBox chkVisualsShowTodayCircle;
        private CheckBox chkVisualsShowToday;
        private CheckBox chkVisualsShowWeekNumbers;
        private ComboBox cboVisualsFirstDayOfWeek;
        private Label lblVisualsFirstDayOfWeek;
        private ComboBox cboVisualsFirstVisibleMonth;
        private Label lblVisualsFirstVisibleMonth;
        private TabPage tabDates;
        private ListView lvwDatesNotableDates;
        private ColumnHeader colDatesColGeneratorType;
        private ColumnHeader colDatesGeneratedCount;
        private ColumnHeader colDatesDefinition;
        private ToolStrip tsDatesContext;
        private ToolStripButton tsctxDatesAdd;
        private ToolStripButton tsctxDatesRemove;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripButton tsctxDatesMoveUp;
        private ToolStripButton tsctxDatesMoveDown;
        private ToolStripSeparator toolStripSeparator2;
        private ToolStripButton tsctxDatesEdit;
        private Label lblErrorText;
        private System.Windows.Forms.Timer timerErrorMessageReset;
        private Button btnSetDisplayFont;
        private TextBox txtDisplayFont;
        private Label lblDisplayFont;
        private FontDialog dlgFontBrowser;
    }
}
