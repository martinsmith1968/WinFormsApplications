namespace QuickCalendar
{
    partial class NotableDatesGeneratorEditorForm
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
            this.panButtonBar = new System.Windows.Forms.Panel();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.tbcEditors = new System.Windows.Forms.TabControl();
            this.tabEditorFixedDateGenerator = new System.Windows.Forms.TabPage();
            this.dtpFixedDateGeneratorDate = new System.Windows.Forms.DateTimePicker();
            this.lblFixedDateGeneratorDate = new System.Windows.Forms.Label();
            this.tabEditorStartDateEndDateGenerator = new System.Windows.Forms.TabPage();
            this.cboStartDateEndDateGeneratorIntervalType = new System.Windows.Forms.ComboBox();
            this.nudStartDateEndDateGeneratorIntervalValue = new System.Windows.Forms.NumericUpDown();
            this.lblStartDateEndDateGeneratorInterval = new System.Windows.Forms.Label();
            this.dtpStartDateEndDateGeneratorEndDate = new System.Windows.Forms.DateTimePicker();
            this.lblStartDateEndDateGeneratorEndDate = new System.Windows.Forms.Label();
            this.dtpStartDateEndDateGeneratorStartDate = new System.Windows.Forms.DateTimePicker();
            this.lblStartDateEndDateGeneratorStartDate = new System.Windows.Forms.Label();
            this.tabEditorStartDateRepeatCountGenerator = new System.Windows.Forms.TabPage();
            this.nudStartDateRepeatCountGeneratorRepeatCount = new System.Windows.Forms.NumericUpDown();
            this.cboStartDateRepeatCountGeneratorInterval = new System.Windows.Forms.ComboBox();
            this.nudStartDateRepeatCountGeneratorInterval = new System.Windows.Forms.NumericUpDown();
            this.lblStartDateRepeatCountGeneratorInterval = new System.Windows.Forms.Label();
            this.lblStartDateRepeatCountGeneratorRepeatCount = new System.Windows.Forms.Label();
            this.dtpStartDateRepeatCountGeneratorStartDate = new System.Windows.Forms.DateTimePicker();
            this.lblStartDateRepeatCountGeneratorStartDate = new System.Windows.Forms.Label();
            this.panGeneratedDates = new System.Windows.Forms.Panel();
            this.lvwGeneratedDates = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.ctxmnuDatesList = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ctxmnuDatesListCopy = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.ctxmnuDatesListExport = new System.Windows.Forms.ToolStripMenuItem();
            this.panButtonBar.SuspendLayout();
            this.tbcEditors.SuspendLayout();
            this.tabEditorFixedDateGenerator.SuspendLayout();
            this.tabEditorStartDateEndDateGenerator.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudStartDateEndDateGeneratorIntervalValue)).BeginInit();
            this.tabEditorStartDateRepeatCountGenerator.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudStartDateRepeatCountGeneratorRepeatCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudStartDateRepeatCountGeneratorInterval)).BeginInit();
            this.panGeneratedDates.SuspendLayout();
            this.ctxmnuDatesList.SuspendLayout();
            this.SuspendLayout();
            // 
            // panButtonBar
            // 
            this.panButtonBar.Controls.Add(this.btnCancel);
            this.panButtonBar.Controls.Add(this.btnOK);
            this.panButtonBar.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panButtonBar.Location = new System.Drawing.Point(0, 270);
            this.panButtonBar.Name = "panButtonBar";
            this.panButtonBar.Size = new System.Drawing.Size(565, 32);
            this.panButtonBar.TabIndex = 0;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(487, 5);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.Location = new System.Drawing.Point(406, 5);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 0;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            // 
            // tbcEditors
            // 
            this.tbcEditors.Controls.Add(this.tabEditorFixedDateGenerator);
            this.tbcEditors.Controls.Add(this.tabEditorStartDateEndDateGenerator);
            this.tbcEditors.Controls.Add(this.tabEditorStartDateRepeatCountGenerator);
            this.tbcEditors.Dock = System.Windows.Forms.DockStyle.Top;
            this.tbcEditors.Location = new System.Drawing.Point(0, 0);
            this.tbcEditors.Name = "tbcEditors";
            this.tbcEditors.SelectedIndex = 0;
            this.tbcEditors.Size = new System.Drawing.Size(325, 201);
            this.tbcEditors.TabIndex = 1;
            // 
            // tabEditorFixedDateGenerator
            // 
            this.tabEditorFixedDateGenerator.Controls.Add(this.dtpFixedDateGeneratorDate);
            this.tabEditorFixedDateGenerator.Controls.Add(this.lblFixedDateGeneratorDate);
            this.tabEditorFixedDateGenerator.Location = new System.Drawing.Point(4, 24);
            this.tabEditorFixedDateGenerator.Name = "tabEditorFixedDateGenerator";
            this.tabEditorFixedDateGenerator.Padding = new System.Windows.Forms.Padding(3);
            this.tabEditorFixedDateGenerator.Size = new System.Drawing.Size(317, 173);
            this.tabEditorFixedDateGenerator.TabIndex = 0;
            this.tabEditorFixedDateGenerator.Text = "Fixed Date";
            this.tabEditorFixedDateGenerator.UseVisualStyleBackColor = true;
            // 
            // dtpFixedDateGeneratorDate
            // 
            this.dtpFixedDateGeneratorDate.Location = new System.Drawing.Point(61, 21);
            this.dtpFixedDateGeneratorDate.Name = "dtpFixedDateGeneratorDate";
            this.dtpFixedDateGeneratorDate.Size = new System.Drawing.Size(156, 23);
            this.dtpFixedDateGeneratorDate.TabIndex = 3;
            this.dtpFixedDateGeneratorDate.ValueChanged += new System.EventHandler(this.dtpFixedDateGeneratorDate_ValueChanged);
            // 
            // lblFixedDateGeneratorDate
            // 
            this.lblFixedDateGeneratorDate.Location = new System.Drawing.Point(10, 21);
            this.lblFixedDateGeneratorDate.Name = "lblFixedDateGeneratorDate";
            this.lblFixedDateGeneratorDate.Size = new System.Drawing.Size(45, 23);
            this.lblFixedDateGeneratorDate.TabIndex = 2;
            this.lblFixedDateGeneratorDate.Text = "&Date :";
            this.lblFixedDateGeneratorDate.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tabEditorStartDateEndDateGenerator
            // 
            this.tabEditorStartDateEndDateGenerator.Controls.Add(this.cboStartDateEndDateGeneratorIntervalType);
            this.tabEditorStartDateEndDateGenerator.Controls.Add(this.nudStartDateEndDateGeneratorIntervalValue);
            this.tabEditorStartDateEndDateGenerator.Controls.Add(this.lblStartDateEndDateGeneratorInterval);
            this.tabEditorStartDateEndDateGenerator.Controls.Add(this.dtpStartDateEndDateGeneratorEndDate);
            this.tabEditorStartDateEndDateGenerator.Controls.Add(this.lblStartDateEndDateGeneratorEndDate);
            this.tabEditorStartDateEndDateGenerator.Controls.Add(this.dtpStartDateEndDateGeneratorStartDate);
            this.tabEditorStartDateEndDateGenerator.Controls.Add(this.lblStartDateEndDateGeneratorStartDate);
            this.tabEditorStartDateEndDateGenerator.Location = new System.Drawing.Point(4, 24);
            this.tabEditorStartDateEndDateGenerator.Name = "tabEditorStartDateEndDateGenerator";
            this.tabEditorStartDateEndDateGenerator.Padding = new System.Windows.Forms.Padding(3);
            this.tabEditorStartDateEndDateGenerator.Size = new System.Drawing.Size(317, 173);
            this.tabEditorStartDateEndDateGenerator.TabIndex = 1;
            this.tabEditorStartDateEndDateGenerator.Text = "Start / End Date";
            this.tabEditorStartDateEndDateGenerator.UseVisualStyleBackColor = true;
            // 
            // cboStartDateEndDateGeneratorIntervalType
            // 
            this.cboStartDateEndDateGeneratorIntervalType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboStartDateEndDateGeneratorIntervalType.FormattingEnabled = true;
            this.cboStartDateEndDateGeneratorIntervalType.Location = new System.Drawing.Point(150, 106);
            this.cboStartDateEndDateGeneratorIntervalType.Name = "cboStartDateEndDateGeneratorIntervalType";
            this.cboStartDateEndDateGeneratorIntervalType.Size = new System.Drawing.Size(89, 23);
            this.cboStartDateEndDateGeneratorIntervalType.TabIndex = 10;
            this.cboStartDateEndDateGeneratorIntervalType.SelectedIndexChanged += new System.EventHandler(this.cboStartDateEndDateGeneratorIntervalType_SelectedIndexChanged);
            // 
            // nudStartDateEndDateGeneratorIntervalValue
            // 
            this.nudStartDateEndDateGeneratorIntervalValue.Location = new System.Drawing.Point(83, 107);
            this.nudStartDateEndDateGeneratorIntervalValue.Name = "nudStartDateEndDateGeneratorIntervalValue";
            this.nudStartDateEndDateGeneratorIntervalValue.Size = new System.Drawing.Size(61, 23);
            this.nudStartDateEndDateGeneratorIntervalValue.TabIndex = 9;
            this.nudStartDateEndDateGeneratorIntervalValue.ValueChanged += new System.EventHandler(this.nudStartDateEndDateGeneratorIntervalValue_ValueChanged);
            // 
            // lblStartDateEndDateGeneratorInterval
            // 
            this.lblStartDateEndDateGeneratorInterval.Location = new System.Drawing.Point(10, 107);
            this.lblStartDateEndDateGeneratorInterval.Name = "lblStartDateEndDateGeneratorInterval";
            this.lblStartDateEndDateGeneratorInterval.Size = new System.Drawing.Size(67, 23);
            this.lblStartDateEndDateGeneratorInterval.TabIndex = 8;
            this.lblStartDateEndDateGeneratorInterval.Text = "&Interval :";
            this.lblStartDateEndDateGeneratorInterval.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // dtpStartDateEndDateGeneratorEndDate
            // 
            this.dtpStartDateEndDateGeneratorEndDate.Location = new System.Drawing.Point(83, 64);
            this.dtpStartDateEndDateGeneratorEndDate.Name = "dtpStartDateEndDateGeneratorEndDate";
            this.dtpStartDateEndDateGeneratorEndDate.Size = new System.Drawing.Size(156, 23);
            this.dtpStartDateEndDateGeneratorEndDate.TabIndex = 7;
            this.dtpStartDateEndDateGeneratorEndDate.ValueChanged += new System.EventHandler(this.dtpStartDateEndDateGeneratorEndDate_ValueChanged);
            // 
            // lblStartDateEndDateGeneratorEndDate
            // 
            this.lblStartDateEndDateGeneratorEndDate.Location = new System.Drawing.Point(10, 64);
            this.lblStartDateEndDateGeneratorEndDate.Name = "lblStartDateEndDateGeneratorEndDate";
            this.lblStartDateEndDateGeneratorEndDate.Size = new System.Drawing.Size(67, 23);
            this.lblStartDateEndDateGeneratorEndDate.TabIndex = 6;
            this.lblStartDateEndDateGeneratorEndDate.Text = "&End Date :";
            this.lblStartDateEndDateGeneratorEndDate.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // dtpStartDateEndDateGeneratorStartDate
            // 
            this.dtpStartDateEndDateGeneratorStartDate.Location = new System.Drawing.Point(83, 21);
            this.dtpStartDateEndDateGeneratorStartDate.Name = "dtpStartDateEndDateGeneratorStartDate";
            this.dtpStartDateEndDateGeneratorStartDate.Size = new System.Drawing.Size(156, 23);
            this.dtpStartDateEndDateGeneratorStartDate.TabIndex = 5;
            this.dtpStartDateEndDateGeneratorStartDate.ValueChanged += new System.EventHandler(this.dtpStartDateEndDateGeneratorStartDate_ValueChanged);
            // 
            // lblStartDateEndDateGeneratorStartDate
            // 
            this.lblStartDateEndDateGeneratorStartDate.Location = new System.Drawing.Point(10, 21);
            this.lblStartDateEndDateGeneratorStartDate.Name = "lblStartDateEndDateGeneratorStartDate";
            this.lblStartDateEndDateGeneratorStartDate.Size = new System.Drawing.Size(67, 23);
            this.lblStartDateEndDateGeneratorStartDate.TabIndex = 4;
            this.lblStartDateEndDateGeneratorStartDate.Text = "&Start Date :";
            this.lblStartDateEndDateGeneratorStartDate.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tabEditorStartDateRepeatCountGenerator
            // 
            this.tabEditorStartDateRepeatCountGenerator.Controls.Add(this.nudStartDateRepeatCountGeneratorRepeatCount);
            this.tabEditorStartDateRepeatCountGenerator.Controls.Add(this.cboStartDateRepeatCountGeneratorInterval);
            this.tabEditorStartDateRepeatCountGenerator.Controls.Add(this.nudStartDateRepeatCountGeneratorInterval);
            this.tabEditorStartDateRepeatCountGenerator.Controls.Add(this.lblStartDateRepeatCountGeneratorInterval);
            this.tabEditorStartDateRepeatCountGenerator.Controls.Add(this.lblStartDateRepeatCountGeneratorRepeatCount);
            this.tabEditorStartDateRepeatCountGenerator.Controls.Add(this.dtpStartDateRepeatCountGeneratorStartDate);
            this.tabEditorStartDateRepeatCountGenerator.Controls.Add(this.lblStartDateRepeatCountGeneratorStartDate);
            this.tabEditorStartDateRepeatCountGenerator.Location = new System.Drawing.Point(4, 24);
            this.tabEditorStartDateRepeatCountGenerator.Name = "tabEditorStartDateRepeatCountGenerator";
            this.tabEditorStartDateRepeatCountGenerator.Padding = new System.Windows.Forms.Padding(3);
            this.tabEditorStartDateRepeatCountGenerator.Size = new System.Drawing.Size(317, 173);
            this.tabEditorStartDateRepeatCountGenerator.TabIndex = 2;
            this.tabEditorStartDateRepeatCountGenerator.Text = "Start Date / Repeat Count";
            this.tabEditorStartDateRepeatCountGenerator.UseVisualStyleBackColor = true;
            // 
            // nudStartDateRepeatCountGeneratorRepeatCount
            // 
            this.nudStartDateRepeatCountGeneratorRepeatCount.Location = new System.Drawing.Point(110, 64);
            this.nudStartDateRepeatCountGeneratorRepeatCount.Name = "nudStartDateRepeatCountGeneratorRepeatCount";
            this.nudStartDateRepeatCountGeneratorRepeatCount.Size = new System.Drawing.Size(61, 23);
            this.nudStartDateRepeatCountGeneratorRepeatCount.TabIndex = 16;
            this.nudStartDateRepeatCountGeneratorRepeatCount.ValueChanged += new System.EventHandler(this.nudStartDateRepeatCountGeneratorRepeatCount_ValueChanged);
            // 
            // cboStartDateRepeatCountGeneratorInterval
            // 
            this.cboStartDateRepeatCountGeneratorInterval.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboStartDateRepeatCountGeneratorInterval.FormattingEnabled = true;
            this.cboStartDateRepeatCountGeneratorInterval.Location = new System.Drawing.Point(177, 107);
            this.cboStartDateRepeatCountGeneratorInterval.Name = "cboStartDateRepeatCountGeneratorInterval";
            this.cboStartDateRepeatCountGeneratorInterval.Size = new System.Drawing.Size(89, 23);
            this.cboStartDateRepeatCountGeneratorInterval.TabIndex = 15;
            this.cboStartDateRepeatCountGeneratorInterval.SelectedIndexChanged += new System.EventHandler(this.cboStartDateRepeatCountGeneratorInterval_SelectedIndexChanged);
            // 
            // nudStartDateRepeatCountGeneratorInterval
            // 
            this.nudStartDateRepeatCountGeneratorInterval.Location = new System.Drawing.Point(110, 107);
            this.nudStartDateRepeatCountGeneratorInterval.Name = "nudStartDateRepeatCountGeneratorInterval";
            this.nudStartDateRepeatCountGeneratorInterval.Size = new System.Drawing.Size(61, 23);
            this.nudStartDateRepeatCountGeneratorInterval.TabIndex = 14;
            this.nudStartDateRepeatCountGeneratorInterval.ValueChanged += new System.EventHandler(this.nudStartDateRepeatCountGeneratorInterval_ValueChanged);
            // 
            // lblStartDateRepeatCountGeneratorInterval
            // 
            this.lblStartDateRepeatCountGeneratorInterval.Location = new System.Drawing.Point(10, 107);
            this.lblStartDateRepeatCountGeneratorInterval.Name = "lblStartDateRepeatCountGeneratorInterval";
            this.lblStartDateRepeatCountGeneratorInterval.Size = new System.Drawing.Size(94, 23);
            this.lblStartDateRepeatCountGeneratorInterval.TabIndex = 13;
            this.lblStartDateRepeatCountGeneratorInterval.Text = "&Interval :";
            this.lblStartDateRepeatCountGeneratorInterval.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblStartDateRepeatCountGeneratorRepeatCount
            // 
            this.lblStartDateRepeatCountGeneratorRepeatCount.Location = new System.Drawing.Point(10, 64);
            this.lblStartDateRepeatCountGeneratorRepeatCount.Name = "lblStartDateRepeatCountGeneratorRepeatCount";
            this.lblStartDateRepeatCountGeneratorRepeatCount.Size = new System.Drawing.Size(94, 23);
            this.lblStartDateRepeatCountGeneratorRepeatCount.TabIndex = 11;
            this.lblStartDateRepeatCountGeneratorRepeatCount.Text = "&Repeat Count :";
            this.lblStartDateRepeatCountGeneratorRepeatCount.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // dtpStartDateRepeatCountGeneratorStartDate
            // 
            this.dtpStartDateRepeatCountGeneratorStartDate.Location = new System.Drawing.Point(110, 21);
            this.dtpStartDateRepeatCountGeneratorStartDate.Name = "dtpStartDateRepeatCountGeneratorStartDate";
            this.dtpStartDateRepeatCountGeneratorStartDate.Size = new System.Drawing.Size(156, 23);
            this.dtpStartDateRepeatCountGeneratorStartDate.TabIndex = 7;
            this.dtpStartDateRepeatCountGeneratorStartDate.ValueChanged += new System.EventHandler(this.dtpStartDateRepeatCountGeneratorStartDate_ValueChanged);
            // 
            // lblStartDateRepeatCountGeneratorStartDate
            // 
            this.lblStartDateRepeatCountGeneratorStartDate.Location = new System.Drawing.Point(10, 21);
            this.lblStartDateRepeatCountGeneratorStartDate.Name = "lblStartDateRepeatCountGeneratorStartDate";
            this.lblStartDateRepeatCountGeneratorStartDate.Size = new System.Drawing.Size(94, 23);
            this.lblStartDateRepeatCountGeneratorStartDate.TabIndex = 6;
            this.lblStartDateRepeatCountGeneratorStartDate.Text = "&Start Date :";
            this.lblStartDateRepeatCountGeneratorStartDate.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // panGeneratedDates
            // 
            this.panGeneratedDates.Controls.Add(this.lvwGeneratedDates);
            this.panGeneratedDates.Dock = System.Windows.Forms.DockStyle.Right;
            this.panGeneratedDates.Location = new System.Drawing.Point(325, 0);
            this.panGeneratedDates.Name = "panGeneratedDates";
            this.panGeneratedDates.Size = new System.Drawing.Size(240, 270);
            this.panGeneratedDates.TabIndex = 2;
            // 
            // lvwGeneratedDates
            // 
            this.lvwGeneratedDates.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.lvwGeneratedDates.ContextMenuStrip = this.ctxmnuDatesList;
            this.lvwGeneratedDates.Dock = System.Windows.Forms.DockStyle.Top;
            this.lvwGeneratedDates.FullRowSelect = true;
            this.lvwGeneratedDates.Location = new System.Drawing.Point(0, 0);
            this.lvwGeneratedDates.Name = "lvwGeneratedDates";
            this.lvwGeneratedDates.Size = new System.Drawing.Size(240, 227);
            this.lvwGeneratedDates.TabIndex = 0;
            this.lvwGeneratedDates.UseCompatibleStateImageBehavior = false;
            this.lvwGeneratedDates.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Date";
            this.columnHeader1.Width = 75;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Description";
            this.columnHeader2.Width = 135;
            // 
            // ctxmnuDatesList
            // 
            this.ctxmnuDatesList.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ctxmnuDatesListCopy,
            this.toolStripSeparator1,
            this.ctxmnuDatesListExport});
            this.ctxmnuDatesList.Name = "ctxmnuDatesList";
            this.ctxmnuDatesList.Size = new System.Drawing.Size(118, 54);
            // 
            // ctxmnuDatesListCopy
            // 
            this.ctxmnuDatesListCopy.Name = "ctxmnuDatesListCopy";
            this.ctxmnuDatesListCopy.Size = new System.Drawing.Size(117, 22);
            this.ctxmnuDatesListCopy.Text = "&Copy";
            this.ctxmnuDatesListCopy.Click += new System.EventHandler(this.ctxmnuDatesListCopy_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(114, 6);
            // 
            // ctxmnuDatesListExport
            // 
            this.ctxmnuDatesListExport.Name = "ctxmnuDatesListExport";
            this.ctxmnuDatesListExport.Size = new System.Drawing.Size(117, 22);
            this.ctxmnuDatesListExport.Text = "&Export...";
            // 
            // NotableDatesGeneratorEditorForm
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(565, 302);
            this.Controls.Add(this.tbcEditors);
            this.Controls.Add(this.panGeneratedDates);
            this.Controls.Add(this.panButtonBar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "NotableDatesGeneratorEditorForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Date Generator Editor";
            this.Load += new System.EventHandler(this.DateGeneratorEditorForm_Load);
            this.panButtonBar.ResumeLayout(false);
            this.tbcEditors.ResumeLayout(false);
            this.tabEditorFixedDateGenerator.ResumeLayout(false);
            this.tabEditorStartDateEndDateGenerator.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.nudStartDateEndDateGeneratorIntervalValue)).EndInit();
            this.tabEditorStartDateRepeatCountGenerator.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.nudStartDateRepeatCountGeneratorRepeatCount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudStartDateRepeatCountGeneratorInterval)).EndInit();
            this.panGeneratedDates.ResumeLayout(false);
            this.ctxmnuDatesList.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Panel panButtonBar;
        private Button btnCancel;
        private Button btnOK;
        private TabControl tbcEditors;
        private TabPage tabEditorFixedDateGenerator;
        private TabPage tabEditorStartDateEndDateGenerator;
        private TabPage tabEditorStartDateRepeatCountGenerator;
        private Panel panGeneratedDates;
        private DateTimePicker dtpFixedDateGeneratorDate;
        private Label lblFixedDateGeneratorDate;
        private DateTimePicker dtpStartDateEndDateGeneratorEndDate;
        private Label lblStartDateEndDateGeneratorEndDate;
        private DateTimePicker dtpStartDateEndDateGeneratorStartDate;
        private Label lblStartDateEndDateGeneratorStartDate;
        private ListView lvwGeneratedDates;
        private ColumnHeader columnHeader1;
        private ColumnHeader columnHeader2;
        private ComboBox cboStartDateEndDateGeneratorIntervalType;
        private NumericUpDown nudStartDateEndDateGeneratorIntervalValue;
        private Label lblStartDateEndDateGeneratorInterval;
        private NumericUpDown nudStartDateRepeatCountGeneratorRepeatCount;
        private ComboBox cboStartDateRepeatCountGeneratorInterval;
        private NumericUpDown nudStartDateRepeatCountGeneratorInterval;
        private Label lblStartDateRepeatCountGeneratorInterval;
        private Label lblStartDateRepeatCountGeneratorRepeatCount;
        private DateTimePicker dtpStartDateRepeatCountGeneratorStartDate;
        private Label lblStartDateRepeatCountGeneratorStartDate;
        private ContextMenuStrip ctxmnuDatesList;
        private ToolStripMenuItem ctxmnuDatesListCopy;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripMenuItem ctxmnuDatesListExport;
    }
}
