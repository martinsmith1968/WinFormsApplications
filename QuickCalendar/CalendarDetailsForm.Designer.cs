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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CalendarDetailsForm));
            this.panButtonBar = new System.Windows.Forms.Panel();
            this.lblErrorText = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.tbcEditor = new System.Windows.Forms.TabControl();
            this.tabDetails = new System.Windows.Forms.TabPage();
            this.lblDetailsExampleDateDisplayFormat = new System.Windows.Forms.Label();
            this.txtDetailsDateDisplayFormat = new System.Windows.Forms.TextBox();
            this.lblDetailsDateDisplayFormat = new System.Windows.Forms.Label();
            this.dtpDetailsMaximumDate = new System.Windows.Forms.DateTimePicker();
            this.dtpDetailsMinimumDate = new System.Windows.Forms.DateTimePicker();
            this.lblDetailsMaximumDate = new System.Windows.Forms.Label();
            this.lblDetailsMinimumDate = new System.Windows.Forms.Label();
            this.txtDetailsDescription = new System.Windows.Forms.TextBox();
            this.lblDetailsDescription = new System.Windows.Forms.Label();
            this.txtDetailsName = new System.Windows.Forms.TextBox();
            this.lblDetailsName = new System.Windows.Forms.Label();
            this.tabVisualDetails = new System.Windows.Forms.TabPage();
            this.cboVisualsFirstVisibleMonth = new System.Windows.Forms.ComboBox();
            this.lblVisualsFirstVisibleMonth = new System.Windows.Forms.Label();
            this.chkVisualsCloseOnEscape = new System.Windows.Forms.CheckBox();
            this.cboVisualsFirstDayOfWeek = new System.Windows.Forms.ComboBox();
            this.lblVisualsFirstDayOfWeek = new System.Windows.Forms.Label();
            this.chkVisualsShowTodayCircle = new System.Windows.Forms.CheckBox();
            this.chkVisualsShowToday = new System.Windows.Forms.CheckBox();
            this.chkVisualsShowWeekNumbers = new System.Windows.Forms.CheckBox();
            this.tabDates = new System.Windows.Forms.TabPage();
            this.lvwDatesNotableDates = new System.Windows.Forms.ListView();
            this.colDatesColGeneratorType = new System.Windows.Forms.ColumnHeader();
            this.colDatesGeneratedCount = new System.Windows.Forms.ColumnHeader();
            this.colDatesDefinition = new System.Windows.Forms.ColumnHeader();
            this.tsDatesContext = new System.Windows.Forms.ToolStrip();
            this.tsctxDatesAdd = new System.Windows.Forms.ToolStripButton();
            this.tsctxDatesRemove = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tsctxDatesEdit = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsctxDatesMoveUp = new System.Windows.Forms.ToolStripButton();
            this.tsctxDatesMoveDown = new System.Windows.Forms.ToolStripButton();
            this.timerErrorMessageReset = new System.Windows.Forms.Timer(this.components);
            this.panButtonBar.SuspendLayout();
            this.tbcEditor.SuspendLayout();
            this.tabDetails.SuspendLayout();
            this.tabVisualDetails.SuspendLayout();
            this.tabDates.SuspendLayout();
            this.tsDatesContext.SuspendLayout();
            this.SuspendLayout();
            // 
            // panButtonBar
            // 
            this.panButtonBar.Controls.Add(this.lblErrorText);
            this.panButtonBar.Controls.Add(this.btnCancel);
            this.panButtonBar.Controls.Add(this.btnOK);
            this.panButtonBar.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panButtonBar.Location = new System.Drawing.Point(0, 327);
            this.panButtonBar.Name = "panButtonBar";
            this.panButtonBar.Size = new System.Drawing.Size(587, 38);
            this.panButtonBar.TabIndex = 0;
            // 
            // lblErrorText
            // 
            this.lblErrorText.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblErrorText.ForeColor = System.Drawing.Color.Red;
            this.lblErrorText.Location = new System.Drawing.Point(4, 10);
            this.lblErrorText.Name = "lblErrorText";
            this.lblErrorText.Size = new System.Drawing.Size(418, 19);
            this.lblErrorText.TabIndex = 2;
            this.lblErrorText.Text = "Error Message";
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.Location = new System.Drawing.Point(509, 8);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.Location = new System.Drawing.Point(428, 8);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 0;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // tbcEditor
            // 
            this.tbcEditor.Controls.Add(this.tabDetails);
            this.tbcEditor.Controls.Add(this.tabVisualDetails);
            this.tbcEditor.Controls.Add(this.tabDates);
            this.tbcEditor.Dock = System.Windows.Forms.DockStyle.Top;
            this.tbcEditor.Location = new System.Drawing.Point(0, 0);
            this.tbcEditor.Name = "tbcEditor";
            this.tbcEditor.SelectedIndex = 0;
            this.tbcEditor.Size = new System.Drawing.Size(587, 274);
            this.tbcEditor.TabIndex = 1;
            // 
            // tabDetails
            // 
            this.tabDetails.Controls.Add(this.lblDetailsExampleDateDisplayFormat);
            this.tabDetails.Controls.Add(this.txtDetailsDateDisplayFormat);
            this.tabDetails.Controls.Add(this.lblDetailsDateDisplayFormat);
            this.tabDetails.Controls.Add(this.dtpDetailsMaximumDate);
            this.tabDetails.Controls.Add(this.dtpDetailsMinimumDate);
            this.tabDetails.Controls.Add(this.lblDetailsMaximumDate);
            this.tabDetails.Controls.Add(this.lblDetailsMinimumDate);
            this.tabDetails.Controls.Add(this.txtDetailsDescription);
            this.tabDetails.Controls.Add(this.lblDetailsDescription);
            this.tabDetails.Controls.Add(this.txtDetailsName);
            this.tabDetails.Controls.Add(this.lblDetailsName);
            this.tabDetails.Location = new System.Drawing.Point(4, 24);
            this.tabDetails.Name = "tabDetails";
            this.tabDetails.Padding = new System.Windows.Forms.Padding(3);
            this.tabDetails.Size = new System.Drawing.Size(579, 246);
            this.tabDetails.TabIndex = 0;
            this.tabDetails.Text = "Details";
            this.tabDetails.UseVisualStyleBackColor = true;
            // 
            // lblDetailsExampleDateDisplayFormat
            // 
            this.lblDetailsExampleDateDisplayFormat.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblDetailsExampleDateDisplayFormat.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblDetailsExampleDateDisplayFormat.Location = new System.Drawing.Point(285, 219);
            this.lblDetailsExampleDateDisplayFormat.Name = "lblDetailsExampleDateDisplayFormat";
            this.lblDetailsExampleDateDisplayFormat.Size = new System.Drawing.Size(286, 23);
            this.lblDetailsExampleDateDisplayFormat.TabIndex = 10;
            this.lblDetailsExampleDateDisplayFormat.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtDetailsDateDisplayFormat
            // 
            this.txtDetailsDateDisplayFormat.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtDetailsDateDisplayFormat.Location = new System.Drawing.Point(137, 219);
            this.txtDetailsDateDisplayFormat.Name = "txtDetailsDateDisplayFormat";
            this.txtDetailsDateDisplayFormat.Size = new System.Drawing.Size(142, 23);
            this.txtDetailsDateDisplayFormat.TabIndex = 9;
            this.txtDetailsDateDisplayFormat.TextChanged += new System.EventHandler(this.txtDateDisplayFormat_TextChanged);
            // 
            // lblDetailsDateDisplayFormat
            // 
            this.lblDetailsDateDisplayFormat.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblDetailsDateDisplayFormat.AutoSize = true;
            this.lblDetailsDateDisplayFormat.Location = new System.Drawing.Point(12, 222);
            this.lblDetailsDateDisplayFormat.Name = "lblDetailsDateDisplayFormat";
            this.lblDetailsDateDisplayFormat.Size = new System.Drawing.Size(119, 15);
            this.lblDetailsDateDisplayFormat.TabIndex = 8;
            this.lblDetailsDateDisplayFormat.Text = "Date Display &Format :";
            // 
            // dtpDetailsMaximumDate
            // 
            this.dtpDetailsMaximumDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.dtpDetailsMaximumDate.Location = new System.Drawing.Point(137, 190);
            this.dtpDetailsMaximumDate.Name = "dtpDetailsMaximumDate";
            this.dtpDetailsMaximumDate.Size = new System.Drawing.Size(142, 23);
            this.dtpDetailsMaximumDate.TabIndex = 7;
            // 
            // dtpDetailsMinimumDate
            // 
            this.dtpDetailsMinimumDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.dtpDetailsMinimumDate.Location = new System.Drawing.Point(137, 161);
            this.dtpDetailsMinimumDate.Name = "dtpDetailsMinimumDate";
            this.dtpDetailsMinimumDate.Size = new System.Drawing.Size(142, 23);
            this.dtpDetailsMinimumDate.TabIndex = 6;
            // 
            // lblDetailsMaximumDate
            // 
            this.lblDetailsMaximumDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblDetailsMaximumDate.AutoSize = true;
            this.lblDetailsMaximumDate.Location = new System.Drawing.Point(12, 196);
            this.lblDetailsMaximumDate.Name = "lblDetailsMaximumDate";
            this.lblDetailsMaximumDate.Size = new System.Drawing.Size(95, 15);
            this.lblDetailsMaximumDate.TabIndex = 5;
            this.lblDetailsMaximumDate.Text = "Maximum Date :";
            // 
            // lblDetailsMinimumDate
            // 
            this.lblDetailsMinimumDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblDetailsMinimumDate.AutoSize = true;
            this.lblDetailsMinimumDate.Location = new System.Drawing.Point(12, 167);
            this.lblDetailsMinimumDate.Name = "lblDetailsMinimumDate";
            this.lblDetailsMinimumDate.Size = new System.Drawing.Size(93, 15);
            this.lblDetailsMinimumDate.TabIndex = 4;
            this.lblDetailsMinimumDate.Text = "Minimum Date :";
            // 
            // txtDetailsDescription
            // 
            this.txtDetailsDescription.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDetailsDescription.Location = new System.Drawing.Point(91, 48);
            this.txtDetailsDescription.Multiline = true;
            this.txtDetailsDescription.Name = "txtDetailsDescription";
            this.txtDetailsDescription.Size = new System.Drawing.Size(480, 104);
            this.txtDetailsDescription.TabIndex = 3;
            // 
            // lblDetailsDescription
            // 
            this.lblDetailsDescription.AutoSize = true;
            this.lblDetailsDescription.Location = new System.Drawing.Point(12, 51);
            this.lblDetailsDescription.Name = "lblDetailsDescription";
            this.lblDetailsDescription.Size = new System.Drawing.Size(73, 15);
            this.lblDetailsDescription.TabIndex = 2;
            this.lblDetailsDescription.Text = "&Description :";
            // 
            // txtDetailsName
            // 
            this.txtDetailsName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDetailsName.Location = new System.Drawing.Point(91, 18);
            this.txtDetailsName.Name = "txtDetailsName";
            this.txtDetailsName.ReadOnly = true;
            this.txtDetailsName.Size = new System.Drawing.Size(480, 23);
            this.txtDetailsName.TabIndex = 1;
            this.txtDetailsName.Enter += new System.EventHandler(this.txtDetailsName_Enter);
            // 
            // lblDetailsName
            // 
            this.lblDetailsName.AutoSize = true;
            this.lblDetailsName.Location = new System.Drawing.Point(12, 21);
            this.lblDetailsName.Name = "lblDetailsName";
            this.lblDetailsName.Size = new System.Drawing.Size(45, 15);
            this.lblDetailsName.TabIndex = 0;
            this.lblDetailsName.Text = "&Name :";
            // 
            // tabVisualDetails
            // 
            this.tabVisualDetails.Controls.Add(this.cboVisualsFirstVisibleMonth);
            this.tabVisualDetails.Controls.Add(this.lblVisualsFirstVisibleMonth);
            this.tabVisualDetails.Controls.Add(this.chkVisualsCloseOnEscape);
            this.tabVisualDetails.Controls.Add(this.cboVisualsFirstDayOfWeek);
            this.tabVisualDetails.Controls.Add(this.lblVisualsFirstDayOfWeek);
            this.tabVisualDetails.Controls.Add(this.chkVisualsShowTodayCircle);
            this.tabVisualDetails.Controls.Add(this.chkVisualsShowToday);
            this.tabVisualDetails.Controls.Add(this.chkVisualsShowWeekNumbers);
            this.tabVisualDetails.Location = new System.Drawing.Point(4, 24);
            this.tabVisualDetails.Name = "tabVisualDetails";
            this.tabVisualDetails.Padding = new System.Windows.Forms.Padding(3);
            this.tabVisualDetails.Size = new System.Drawing.Size(579, 246);
            this.tabVisualDetails.TabIndex = 1;
            this.tabVisualDetails.Text = "Visual Details";
            this.tabVisualDetails.UseVisualStyleBackColor = true;
            // 
            // cboVisualsFirstVisibleMonth
            // 
            this.cboVisualsFirstVisibleMonth.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboVisualsFirstVisibleMonth.FormattingEnabled = true;
            this.cboVisualsFirstVisibleMonth.Location = new System.Drawing.Point(162, 143);
            this.cboVisualsFirstVisibleMonth.Name = "cboVisualsFirstVisibleMonth";
            this.cboVisualsFirstVisibleMonth.Size = new System.Drawing.Size(138, 23);
            this.cboVisualsFirstVisibleMonth.TabIndex = 7;
            // 
            // lblVisualsFirstVisibleMonth
            // 
            this.lblVisualsFirstVisibleMonth.AutoSize = true;
            this.lblVisualsFirstVisibleMonth.Location = new System.Drawing.Point(12, 146);
            this.lblVisualsFirstVisibleMonth.Name = "lblVisualsFirstVisibleMonth";
            this.lblVisualsFirstVisibleMonth.Size = new System.Drawing.Size(111, 15);
            this.lblVisualsFirstVisibleMonth.TabIndex = 6;
            this.lblVisualsFirstVisibleMonth.Text = "First Visible &Month :";
            // 
            // chkVisualsCloseOnEscape
            // 
            this.chkVisualsCloseOnEscape.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkVisualsCloseOnEscape.Location = new System.Drawing.Point(12, 121);
            this.chkVisualsCloseOnEscape.Name = "chkVisualsCloseOnEscape";
            this.chkVisualsCloseOnEscape.Size = new System.Drawing.Size(166, 19);
            this.chkVisualsCloseOnEscape.TabIndex = 5;
            this.chkVisualsCloseOnEscape.Text = "Close on &Escape :";
            this.chkVisualsCloseOnEscape.UseVisualStyleBackColor = true;
            // 
            // cboVisualsFirstDayOfWeek
            // 
            this.cboVisualsFirstDayOfWeek.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboVisualsFirstDayOfWeek.FormattingEnabled = true;
            this.cboVisualsFirstDayOfWeek.Location = new System.Drawing.Point(162, 93);
            this.cboVisualsFirstDayOfWeek.Name = "cboVisualsFirstDayOfWeek";
            this.cboVisualsFirstDayOfWeek.Size = new System.Drawing.Size(138, 23);
            this.cboVisualsFirstDayOfWeek.TabIndex = 4;
            // 
            // lblVisualsFirstDayOfWeek
            // 
            this.lblVisualsFirstDayOfWeek.AutoSize = true;
            this.lblVisualsFirstDayOfWeek.Location = new System.Drawing.Point(12, 96);
            this.lblVisualsFirstDayOfWeek.Name = "lblVisualsFirstDayOfWeek";
            this.lblVisualsFirstDayOfWeek.Size = new System.Drawing.Size(104, 15);
            this.lblVisualsFirstDayOfWeek.TabIndex = 3;
            this.lblVisualsFirstDayOfWeek.Text = "&First Day of Week :";
            // 
            // chkVisualsShowTodayCircle
            // 
            this.chkVisualsShowTodayCircle.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkVisualsShowTodayCircle.Location = new System.Drawing.Point(12, 71);
            this.chkVisualsShowTodayCircle.Name = "chkVisualsShowTodayCircle";
            this.chkVisualsShowTodayCircle.Size = new System.Drawing.Size(166, 19);
            this.chkVisualsShowTodayCircle.TabIndex = 2;
            this.chkVisualsShowTodayCircle.Text = "Show Today &Circle :";
            this.chkVisualsShowTodayCircle.UseVisualStyleBackColor = true;
            // 
            // chkVisualsShowToday
            // 
            this.chkVisualsShowToday.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkVisualsShowToday.Location = new System.Drawing.Point(12, 46);
            this.chkVisualsShowToday.Name = "chkVisualsShowToday";
            this.chkVisualsShowToday.Size = new System.Drawing.Size(166, 19);
            this.chkVisualsShowToday.TabIndex = 1;
            this.chkVisualsShowToday.Text = "Show &Today :";
            this.chkVisualsShowToday.UseVisualStyleBackColor = true;
            // 
            // chkVisualsShowWeekNumbers
            // 
            this.chkVisualsShowWeekNumbers.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkVisualsShowWeekNumbers.Location = new System.Drawing.Point(12, 21);
            this.chkVisualsShowWeekNumbers.Name = "chkVisualsShowWeekNumbers";
            this.chkVisualsShowWeekNumbers.Size = new System.Drawing.Size(166, 19);
            this.chkVisualsShowWeekNumbers.TabIndex = 0;
            this.chkVisualsShowWeekNumbers.Text = "Show &Week Numbers :";
            this.chkVisualsShowWeekNumbers.UseVisualStyleBackColor = true;
            // 
            // tabDates
            // 
            this.tabDates.Controls.Add(this.lvwDatesNotableDates);
            this.tabDates.Controls.Add(this.tsDatesContext);
            this.tabDates.Location = new System.Drawing.Point(4, 24);
            this.tabDates.Name = "tabDates";
            this.tabDates.Padding = new System.Windows.Forms.Padding(3);
            this.tabDates.Size = new System.Drawing.Size(579, 246);
            this.tabDates.TabIndex = 2;
            this.tabDates.Text = "Dates";
            this.tabDates.UseVisualStyleBackColor = true;
            // 
            // lvwDatesNotableDates
            // 
            this.lvwDatesNotableDates.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colDatesColGeneratorType,
            this.colDatesGeneratedCount,
            this.colDatesDefinition});
            this.lvwDatesNotableDates.Dock = System.Windows.Forms.DockStyle.Top;
            this.lvwDatesNotableDates.FullRowSelect = true;
            this.lvwDatesNotableDates.Location = new System.Drawing.Point(3, 3);
            this.lvwDatesNotableDates.MultiSelect = false;
            this.lvwDatesNotableDates.Name = "lvwDatesNotableDates";
            this.lvwDatesNotableDates.Size = new System.Drawing.Size(550, 190);
            this.lvwDatesNotableDates.TabIndex = 1;
            this.lvwDatesNotableDates.UseCompatibleStateImageBehavior = false;
            this.lvwDatesNotableDates.View = System.Windows.Forms.View.Details;
            this.lvwDatesNotableDates.DoubleClick += new System.EventHandler(this.lvwDatesNotableDates_DoubleClick);
            // 
            // colDatesColGeneratorType
            // 
            this.colDatesColGeneratorType.Text = "Type";
            this.colDatesColGeneratorType.Width = 90;
            // 
            // colDatesGeneratedCount
            // 
            this.colDatesGeneratedCount.Text = "Count";
            this.colDatesGeneratedCount.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // colDatesDefinition
            // 
            this.colDatesDefinition.Text = "Definition";
            this.colDatesDefinition.Width = 330;
            // 
            // tsDatesContext
            // 
            this.tsDatesContext.Dock = System.Windows.Forms.DockStyle.Right;
            this.tsDatesContext.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsctxDatesAdd,
            this.tsctxDatesRemove,
            this.toolStripSeparator2,
            this.tsctxDatesEdit,
            this.toolStripSeparator1,
            this.tsctxDatesMoveUp,
            this.tsctxDatesMoveDown});
            this.tsDatesContext.Location = new System.Drawing.Point(553, 3);
            this.tsDatesContext.Name = "tsDatesContext";
            this.tsDatesContext.Padding = new System.Windows.Forms.Padding(0);
            this.tsDatesContext.Size = new System.Drawing.Size(23, 240);
            this.tsDatesContext.TabIndex = 2;
            this.tsDatesContext.Text = "toolStrip1";
            // 
            // tsctxDatesAdd
            // 
            this.tsctxDatesAdd.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsctxDatesAdd.Image = global::QuickCalendar.Properties.Resources.add1;
            this.tsctxDatesAdd.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsctxDatesAdd.Name = "tsctxDatesAdd";
            this.tsctxDatesAdd.Size = new System.Drawing.Size(22, 20);
            this.tsctxDatesAdd.ToolTipText = "Add...";
            this.tsctxDatesAdd.Click += new System.EventHandler(this.tsctxDatesAdd_Click);
            // 
            // tsctxDatesRemove
            // 
            this.tsctxDatesRemove.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsctxDatesRemove.Image = global::QuickCalendar.Properties.Resources.remove1;
            this.tsctxDatesRemove.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsctxDatesRemove.Name = "tsctxDatesRemove";
            this.tsctxDatesRemove.Size = new System.Drawing.Size(22, 20);
            this.tsctxDatesRemove.ToolTipText = "Remove";
            this.tsctxDatesRemove.Click += new System.EventHandler(this.tsctxDatesRemove_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(22, 6);
            // 
            // tsctxDatesEdit
            // 
            this.tsctxDatesEdit.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsctxDatesEdit.Image = global::QuickCalendar.Properties.Resources.edit3;
            this.tsctxDatesEdit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsctxDatesEdit.Name = "tsctxDatesEdit";
            this.tsctxDatesEdit.Size = new System.Drawing.Size(22, 20);
            this.tsctxDatesEdit.ToolTipText = "Edit";
            this.tsctxDatesEdit.Click += new System.EventHandler(this.tsctxDatesEdit_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(22, 6);
            // 
            // tsctxDatesMoveUp
            // 
            this.tsctxDatesMoveUp.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsctxDatesMoveUp.Image = global::QuickCalendar.Properties.Resources.up1;
            this.tsctxDatesMoveUp.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsctxDatesMoveUp.Name = "tsctxDatesMoveUp";
            this.tsctxDatesMoveUp.Size = new System.Drawing.Size(22, 20);
            this.tsctxDatesMoveUp.ToolTipText = "Move Up";
            this.tsctxDatesMoveUp.Click += new System.EventHandler(this.tsctxDatesMoveUp_Click);
            // 
            // tsctxDatesMoveDown
            // 
            this.tsctxDatesMoveDown.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsctxDatesMoveDown.Image = global::QuickCalendar.Properties.Resources.down1;
            this.tsctxDatesMoveDown.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsctxDatesMoveDown.Name = "tsctxDatesMoveDown";
            this.tsctxDatesMoveDown.Size = new System.Drawing.Size(22, 20);
            this.tsctxDatesMoveDown.ToolTipText = "Move Down";
            this.tsctxDatesMoveDown.Click += new System.EventHandler(this.tsctxDatesMoveDown_Click);
            // 
            // timerErrorMessageReset
            // 
            this.timerErrorMessageReset.Tick += new System.EventHandler(this.timerErrorMessageReset_Tick);
            // 
            // CalendarDetailsForm
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(587, 365);
            this.Controls.Add(this.tbcEditor);
            this.Controls.Add(this.panButtonBar);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CalendarDetailsForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Calendar Details";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.CalendarDetailsForm_FormClosed);
            this.Load += new System.EventHandler(this.CalendarDetailsForm_Load);
            this.panButtonBar.ResumeLayout(false);
            this.tbcEditor.ResumeLayout(false);
            this.tabDetails.ResumeLayout(false);
            this.tabDetails.PerformLayout();
            this.tabVisualDetails.ResumeLayout(false);
            this.tabVisualDetails.PerformLayout();
            this.tabDates.ResumeLayout(false);
            this.tabDates.PerformLayout();
            this.tsDatesContext.ResumeLayout(false);
            this.tsDatesContext.PerformLayout();
            this.ResumeLayout(false);

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
        private CheckBox chkVisualsCloseOnEscape;
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
    }
}
