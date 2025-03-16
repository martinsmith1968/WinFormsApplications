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
            components = new System.ComponentModel.Container();
            panButtonBar = new Panel();
            btnCancel = new Button();
            btnOK = new Button();
            tbcEditors = new TabControl();
            tabEditorFixedDateGenerator = new TabPage();
            dtpFixedDateGeneratorDate = new DateTimePicker();
            lblFixedDateGeneratorDate = new Label();
            tabEditorStartDateEndDateGenerator = new TabPage();
            nudStartDateEndDateGeneratorSequenceIncrementValue = new NumericUpDown();
            lblStartDateEndDateGeneratorSequenceIncrement = new Label();
            nudStartDateEndDateGeneratorSequenceStartValue = new NumericUpDown();
            lblStartDateEndDateGeneratorSequenceStart = new Label();
            cboStartDateEndDateGeneratorIntervalType = new ComboBox();
            nudStartDateEndDateGeneratorIntervalValue = new NumericUpDown();
            lblStartDateEndDateGeneratorInterval = new Label();
            dtpStartDateEndDateGeneratorEndDate = new DateTimePicker();
            lblStartDateEndDateGeneratorEndDate = new Label();
            dtpStartDateEndDateGeneratorStartDate = new DateTimePicker();
            lblStartDateEndDateGeneratorStartDate = new Label();
            tabEditorStartDateRepeatCountGenerator = new TabPage();
            nudStartDateRepeatCountGeneratorSequenceIncrement = new NumericUpDown();
            lblStartDateRepeatCountGeneratorSequenceIncrement = new Label();
            nudStartDateRepeatCountGeneratorSequenceStart = new NumericUpDown();
            lblStartDateRepeatCountGeneratorSequenceStart = new Label();
            nudStartDateRepeatCountGeneratorRepeatCount = new NumericUpDown();
            cboStartDateRepeatCountGeneratorInterval = new ComboBox();
            nudStartDateRepeatCountGeneratorInterval = new NumericUpDown();
            lblStartDateRepeatCountGeneratorInterval = new Label();
            lblStartDateRepeatCountGeneratorRepeatCount = new Label();
            dtpStartDateRepeatCountGeneratorStartDate = new DateTimePicker();
            lblStartDateRepeatCountGeneratorStartDate = new Label();
            panGeneratedDates = new Panel();
            lvwGeneratedDates = new ListView();
            columnHeader1 = new ColumnHeader();
            columnHeader2 = new ColumnHeader();
            ctxmnuDatesList = new ContextMenuStrip(components);
            ctxmnuDatesListCopy = new ToolStripMenuItem();
            toolStripSeparator1 = new ToolStripSeparator();
            ctxmnuDatesListExport = new ToolStripMenuItem();
            lblGeneratedDatesDisplay = new Label();
            panButtonBar.SuspendLayout();
            tbcEditors.SuspendLayout();
            tabEditorFixedDateGenerator.SuspendLayout();
            tabEditorStartDateEndDateGenerator.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nudStartDateEndDateGeneratorSequenceIncrementValue).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudStartDateEndDateGeneratorSequenceStartValue).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudStartDateEndDateGeneratorIntervalValue).BeginInit();
            tabEditorStartDateRepeatCountGenerator.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nudStartDateRepeatCountGeneratorSequenceIncrement).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudStartDateRepeatCountGeneratorSequenceStart).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudStartDateRepeatCountGeneratorRepeatCount).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudStartDateRepeatCountGeneratorInterval).BeginInit();
            panGeneratedDates.SuspendLayout();
            ctxmnuDatesList.SuspendLayout();
            SuspendLayout();
            // 
            // panButtonBar
            // 
            panButtonBar.Controls.Add(btnCancel);
            panButtonBar.Controls.Add(btnOK);
            panButtonBar.Dock = DockStyle.Bottom;
            panButtonBar.Location = new Point(0, 270);
            panButtonBar.Name = "panButtonBar";
            panButtonBar.Size = new Size(621, 32);
            panButtonBar.TabIndex = 0;
            // 
            // btnCancel
            // 
            btnCancel.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnCancel.DialogResult = DialogResult.Cancel;
            btnCancel.Location = new Point(543, 5);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(75, 23);
            btnCancel.TabIndex = 1;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnOK
            // 
            btnOK.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnOK.Location = new Point(462, 5);
            btnOK.Name = "btnOK";
            btnOK.Size = new Size(75, 23);
            btnOK.TabIndex = 0;
            btnOK.Text = "OK";
            btnOK.UseVisualStyleBackColor = true;
            btnOK.Click += btnOK_Click;
            // 
            // tbcEditors
            // 
            tbcEditors.Controls.Add(tabEditorFixedDateGenerator);
            tbcEditors.Controls.Add(tabEditorStartDateEndDateGenerator);
            tbcEditors.Controls.Add(tabEditorStartDateRepeatCountGenerator);
            tbcEditors.Dock = DockStyle.Top;
            tbcEditors.Location = new Point(0, 0);
            tbcEditors.Name = "tbcEditors";
            tbcEditors.SelectedIndex = 0;
            tbcEditors.Size = new Size(381, 251);
            tbcEditors.TabIndex = 1;
            // 
            // tabEditorFixedDateGenerator
            // 
            tabEditorFixedDateGenerator.Controls.Add(dtpFixedDateGeneratorDate);
            tabEditorFixedDateGenerator.Controls.Add(lblFixedDateGeneratorDate);
            tabEditorFixedDateGenerator.Location = new Point(4, 24);
            tabEditorFixedDateGenerator.Name = "tabEditorFixedDateGenerator";
            tabEditorFixedDateGenerator.Padding = new Padding(3);
            tabEditorFixedDateGenerator.Size = new Size(373, 223);
            tabEditorFixedDateGenerator.TabIndex = 0;
            tabEditorFixedDateGenerator.Text = "Fixed Date";
            tabEditorFixedDateGenerator.UseVisualStyleBackColor = true;
            // 
            // dtpFixedDateGeneratorDate
            // 
            dtpFixedDateGeneratorDate.Location = new Point(61, 21);
            dtpFixedDateGeneratorDate.Name = "dtpFixedDateGeneratorDate";
            dtpFixedDateGeneratorDate.Size = new Size(156, 23);
            dtpFixedDateGeneratorDate.TabIndex = 3;
            dtpFixedDateGeneratorDate.ValueChanged += dtpFixedDateGeneratorDate_ValueChanged;
            // 
            // lblFixedDateGeneratorDate
            // 
            lblFixedDateGeneratorDate.Location = new Point(10, 21);
            lblFixedDateGeneratorDate.Name = "lblFixedDateGeneratorDate";
            lblFixedDateGeneratorDate.Size = new Size(45, 23);
            lblFixedDateGeneratorDate.TabIndex = 2;
            lblFixedDateGeneratorDate.Text = "&Date :";
            lblFixedDateGeneratorDate.TextAlign = ContentAlignment.MiddleRight;
            // 
            // tabEditorStartDateEndDateGenerator
            // 
            tabEditorStartDateEndDateGenerator.Controls.Add(nudStartDateEndDateGeneratorSequenceIncrementValue);
            tabEditorStartDateEndDateGenerator.Controls.Add(lblStartDateEndDateGeneratorSequenceIncrement);
            tabEditorStartDateEndDateGenerator.Controls.Add(nudStartDateEndDateGeneratorSequenceStartValue);
            tabEditorStartDateEndDateGenerator.Controls.Add(lblStartDateEndDateGeneratorSequenceStart);
            tabEditorStartDateEndDateGenerator.Controls.Add(cboStartDateEndDateGeneratorIntervalType);
            tabEditorStartDateEndDateGenerator.Controls.Add(nudStartDateEndDateGeneratorIntervalValue);
            tabEditorStartDateEndDateGenerator.Controls.Add(lblStartDateEndDateGeneratorInterval);
            tabEditorStartDateEndDateGenerator.Controls.Add(dtpStartDateEndDateGeneratorEndDate);
            tabEditorStartDateEndDateGenerator.Controls.Add(lblStartDateEndDateGeneratorEndDate);
            tabEditorStartDateEndDateGenerator.Controls.Add(dtpStartDateEndDateGeneratorStartDate);
            tabEditorStartDateEndDateGenerator.Controls.Add(lblStartDateEndDateGeneratorStartDate);
            tabEditorStartDateEndDateGenerator.Location = new Point(4, 24);
            tabEditorStartDateEndDateGenerator.Name = "tabEditorStartDateEndDateGenerator";
            tabEditorStartDateEndDateGenerator.Padding = new Padding(3);
            tabEditorStartDateEndDateGenerator.Size = new Size(373, 223);
            tabEditorStartDateEndDateGenerator.TabIndex = 1;
            tabEditorStartDateEndDateGenerator.Text = "Start / End Date";
            tabEditorStartDateEndDateGenerator.UseVisualStyleBackColor = true;
            // 
            // nudStartDateEndDateGeneratorSequenceIncrementValue
            // 
            nudStartDateEndDateGeneratorSequenceIncrementValue.Location = new Point(150, 193);
            nudStartDateEndDateGeneratorSequenceIncrementValue.Name = "nudStartDateEndDateGeneratorSequenceIncrementValue";
            nudStartDateEndDateGeneratorSequenceIncrementValue.Size = new Size(61, 23);
            nudStartDateEndDateGeneratorSequenceIncrementValue.TabIndex = 14;
            nudStartDateEndDateGeneratorSequenceIncrementValue.TextAlign = HorizontalAlignment.Right;
            nudStartDateEndDateGeneratorSequenceIncrementValue.ValueChanged += nudStartDateEndDateGeneratorSequenceIncrementValue_ValueChanged;
            // 
            // lblStartDateEndDateGeneratorSequenceIncrement
            // 
            lblStartDateEndDateGeneratorSequenceIncrement.Location = new Point(10, 193);
            lblStartDateEndDateGeneratorSequenceIncrement.Name = "lblStartDateEndDateGeneratorSequenceIncrement";
            lblStartDateEndDateGeneratorSequenceIncrement.Size = new Size(121, 23);
            lblStartDateEndDateGeneratorSequenceIncrement.TabIndex = 13;
            lblStartDateEndDateGeneratorSequenceIncrement.Text = "Sequence &Increment :";
            lblStartDateEndDateGeneratorSequenceIncrement.TextAlign = ContentAlignment.MiddleRight;
            // 
            // nudStartDateEndDateGeneratorSequenceStartValue
            // 
            nudStartDateEndDateGeneratorSequenceStartValue.Location = new Point(150, 150);
            nudStartDateEndDateGeneratorSequenceStartValue.Name = "nudStartDateEndDateGeneratorSequenceStartValue";
            nudStartDateEndDateGeneratorSequenceStartValue.Size = new Size(61, 23);
            nudStartDateEndDateGeneratorSequenceStartValue.TabIndex = 12;
            nudStartDateEndDateGeneratorSequenceStartValue.TextAlign = HorizontalAlignment.Right;
            nudStartDateEndDateGeneratorSequenceStartValue.ValueChanged += nudStartDateEndDateGeneratorSequenceStartValue_ValueChanged;
            // 
            // lblStartDateEndDateGeneratorSequenceStart
            // 
            lblStartDateEndDateGeneratorSequenceStart.Location = new Point(10, 150);
            lblStartDateEndDateGeneratorSequenceStart.Name = "lblStartDateEndDateGeneratorSequenceStart";
            lblStartDateEndDateGeneratorSequenceStart.Size = new Size(121, 23);
            lblStartDateEndDateGeneratorSequenceStart.TabIndex = 11;
            lblStartDateEndDateGeneratorSequenceStart.Text = "Sequence St&art :";
            lblStartDateEndDateGeneratorSequenceStart.TextAlign = ContentAlignment.MiddleRight;
            // 
            // cboStartDateEndDateGeneratorIntervalType
            // 
            cboStartDateEndDateGeneratorIntervalType.DropDownStyle = ComboBoxStyle.DropDownList;
            cboStartDateEndDateGeneratorIntervalType.FormattingEnabled = true;
            cboStartDateEndDateGeneratorIntervalType.Location = new Point(217, 107);
            cboStartDateEndDateGeneratorIntervalType.Name = "cboStartDateEndDateGeneratorIntervalType";
            cboStartDateEndDateGeneratorIntervalType.Size = new Size(89, 23);
            cboStartDateEndDateGeneratorIntervalType.TabIndex = 10;
            cboStartDateEndDateGeneratorIntervalType.SelectedIndexChanged += cboStartDateEndDateGeneratorIntervalType_SelectedIndexChanged;
            // 
            // nudStartDateEndDateGeneratorIntervalValue
            // 
            nudStartDateEndDateGeneratorIntervalValue.Location = new Point(150, 107);
            nudStartDateEndDateGeneratorIntervalValue.Name = "nudStartDateEndDateGeneratorIntervalValue";
            nudStartDateEndDateGeneratorIntervalValue.Size = new Size(61, 23);
            nudStartDateEndDateGeneratorIntervalValue.TabIndex = 9;
            nudStartDateEndDateGeneratorIntervalValue.TextAlign = HorizontalAlignment.Right;
            nudStartDateEndDateGeneratorIntervalValue.ValueChanged += nudStartDateEndDateGeneratorIntervalValue_ValueChanged;
            // 
            // lblStartDateEndDateGeneratorInterval
            // 
            lblStartDateEndDateGeneratorInterval.Location = new Point(10, 107);
            lblStartDateEndDateGeneratorInterval.Name = "lblStartDateEndDateGeneratorInterval";
            lblStartDateEndDateGeneratorInterval.Size = new Size(121, 23);
            lblStartDateEndDateGeneratorInterval.TabIndex = 8;
            lblStartDateEndDateGeneratorInterval.Text = "&Interval :";
            lblStartDateEndDateGeneratorInterval.TextAlign = ContentAlignment.MiddleRight;
            // 
            // dtpStartDateEndDateGeneratorEndDate
            // 
            dtpStartDateEndDateGeneratorEndDate.Location = new Point(150, 64);
            dtpStartDateEndDateGeneratorEndDate.Name = "dtpStartDateEndDateGeneratorEndDate";
            dtpStartDateEndDateGeneratorEndDate.Size = new Size(156, 23);
            dtpStartDateEndDateGeneratorEndDate.TabIndex = 7;
            dtpStartDateEndDateGeneratorEndDate.ValueChanged += dtpStartDateEndDateGeneratorEndDate_ValueChanged;
            // 
            // lblStartDateEndDateGeneratorEndDate
            // 
            lblStartDateEndDateGeneratorEndDate.Location = new Point(10, 64);
            lblStartDateEndDateGeneratorEndDate.Name = "lblStartDateEndDateGeneratorEndDate";
            lblStartDateEndDateGeneratorEndDate.Size = new Size(121, 23);
            lblStartDateEndDateGeneratorEndDate.TabIndex = 6;
            lblStartDateEndDateGeneratorEndDate.Text = "&End Date :";
            lblStartDateEndDateGeneratorEndDate.TextAlign = ContentAlignment.MiddleRight;
            // 
            // dtpStartDateEndDateGeneratorStartDate
            // 
            dtpStartDateEndDateGeneratorStartDate.Location = new Point(150, 21);
            dtpStartDateEndDateGeneratorStartDate.Name = "dtpStartDateEndDateGeneratorStartDate";
            dtpStartDateEndDateGeneratorStartDate.Size = new Size(156, 23);
            dtpStartDateEndDateGeneratorStartDate.TabIndex = 5;
            dtpStartDateEndDateGeneratorStartDate.ValueChanged += dtpStartDateEndDateGeneratorStartDate_ValueChanged;
            // 
            // lblStartDateEndDateGeneratorStartDate
            // 
            lblStartDateEndDateGeneratorStartDate.Location = new Point(10, 21);
            lblStartDateEndDateGeneratorStartDate.Name = "lblStartDateEndDateGeneratorStartDate";
            lblStartDateEndDateGeneratorStartDate.Size = new Size(121, 23);
            lblStartDateEndDateGeneratorStartDate.TabIndex = 4;
            lblStartDateEndDateGeneratorStartDate.Text = "&Start Date :";
            lblStartDateEndDateGeneratorStartDate.TextAlign = ContentAlignment.MiddleRight;
            // 
            // tabEditorStartDateRepeatCountGenerator
            // 
            tabEditorStartDateRepeatCountGenerator.Controls.Add(nudStartDateRepeatCountGeneratorSequenceIncrement);
            tabEditorStartDateRepeatCountGenerator.Controls.Add(lblStartDateRepeatCountGeneratorSequenceIncrement);
            tabEditorStartDateRepeatCountGenerator.Controls.Add(nudStartDateRepeatCountGeneratorSequenceStart);
            tabEditorStartDateRepeatCountGenerator.Controls.Add(lblStartDateRepeatCountGeneratorSequenceStart);
            tabEditorStartDateRepeatCountGenerator.Controls.Add(nudStartDateRepeatCountGeneratorRepeatCount);
            tabEditorStartDateRepeatCountGenerator.Controls.Add(cboStartDateRepeatCountGeneratorInterval);
            tabEditorStartDateRepeatCountGenerator.Controls.Add(nudStartDateRepeatCountGeneratorInterval);
            tabEditorStartDateRepeatCountGenerator.Controls.Add(lblStartDateRepeatCountGeneratorInterval);
            tabEditorStartDateRepeatCountGenerator.Controls.Add(lblStartDateRepeatCountGeneratorRepeatCount);
            tabEditorStartDateRepeatCountGenerator.Controls.Add(dtpStartDateRepeatCountGeneratorStartDate);
            tabEditorStartDateRepeatCountGenerator.Controls.Add(lblStartDateRepeatCountGeneratorStartDate);
            tabEditorStartDateRepeatCountGenerator.Location = new Point(4, 24);
            tabEditorStartDateRepeatCountGenerator.Name = "tabEditorStartDateRepeatCountGenerator";
            tabEditorStartDateRepeatCountGenerator.Padding = new Padding(3);
            tabEditorStartDateRepeatCountGenerator.Size = new Size(373, 223);
            tabEditorStartDateRepeatCountGenerator.TabIndex = 2;
            tabEditorStartDateRepeatCountGenerator.Text = "Start Date / Repeat Count";
            tabEditorStartDateRepeatCountGenerator.UseVisualStyleBackColor = true;
            // 
            // nudStartDateRepeatCountGeneratorSequenceIncrement
            // 
            nudStartDateRepeatCountGeneratorSequenceIncrement.Location = new Point(150, 193);
            nudStartDateRepeatCountGeneratorSequenceIncrement.Name = "nudStartDateRepeatCountGeneratorSequenceIncrement";
            nudStartDateRepeatCountGeneratorSequenceIncrement.Size = new Size(61, 23);
            nudStartDateRepeatCountGeneratorSequenceIncrement.TabIndex = 19;
            nudStartDateRepeatCountGeneratorSequenceIncrement.TextAlign = HorizontalAlignment.Right;
            nudStartDateRepeatCountGeneratorSequenceIncrement.ValueChanged += nudStartDateRepeatCountGeneratorSequenceIncrement_ValueChanged;
            // 
            // lblStartDateRepeatCountGeneratorSequenceIncrement
            // 
            lblStartDateRepeatCountGeneratorSequenceIncrement.Location = new Point(10, 193);
            lblStartDateRepeatCountGeneratorSequenceIncrement.Name = "lblStartDateRepeatCountGeneratorSequenceIncrement";
            lblStartDateRepeatCountGeneratorSequenceIncrement.Size = new Size(121, 23);
            lblStartDateRepeatCountGeneratorSequenceIncrement.TabIndex = 18;
            lblStartDateRepeatCountGeneratorSequenceIncrement.Text = "Sequence &Increment :";
            lblStartDateRepeatCountGeneratorSequenceIncrement.TextAlign = ContentAlignment.MiddleRight;
            // 
            // nudStartDateRepeatCountGeneratorSequenceStart
            // 
            nudStartDateRepeatCountGeneratorSequenceStart.Location = new Point(150, 150);
            nudStartDateRepeatCountGeneratorSequenceStart.Name = "nudStartDateRepeatCountGeneratorSequenceStart";
            nudStartDateRepeatCountGeneratorSequenceStart.Size = new Size(61, 23);
            nudStartDateRepeatCountGeneratorSequenceStart.TabIndex = 17;
            nudStartDateRepeatCountGeneratorSequenceStart.TextAlign = HorizontalAlignment.Right;
            nudStartDateRepeatCountGeneratorSequenceStart.ValueChanged += nudStartDateRepeatCountGeneratorSequenceStart_ValueChanged;
            // 
            // lblStartDateRepeatCountGeneratorSequenceStart
            // 
            lblStartDateRepeatCountGeneratorSequenceStart.Location = new Point(10, 150);
            lblStartDateRepeatCountGeneratorSequenceStart.Name = "lblStartDateRepeatCountGeneratorSequenceStart";
            lblStartDateRepeatCountGeneratorSequenceStart.Size = new Size(121, 23);
            lblStartDateRepeatCountGeneratorSequenceStart.TabIndex = 16;
            lblStartDateRepeatCountGeneratorSequenceStart.Text = "Sequence St&art :";
            lblStartDateRepeatCountGeneratorSequenceStart.TextAlign = ContentAlignment.MiddleRight;
            // 
            // nudStartDateRepeatCountGeneratorRepeatCount
            // 
            nudStartDateRepeatCountGeneratorRepeatCount.Location = new Point(150, 64);
            nudStartDateRepeatCountGeneratorRepeatCount.Name = "nudStartDateRepeatCountGeneratorRepeatCount";
            nudStartDateRepeatCountGeneratorRepeatCount.Size = new Size(61, 23);
            nudStartDateRepeatCountGeneratorRepeatCount.TabIndex = 16;
            nudStartDateRepeatCountGeneratorRepeatCount.TextAlign = HorizontalAlignment.Right;
            nudStartDateRepeatCountGeneratorRepeatCount.ValueChanged += nudStartDateRepeatCountGeneratorRepeatCount_ValueChanged;
            // 
            // cboStartDateRepeatCountGeneratorInterval
            // 
            cboStartDateRepeatCountGeneratorInterval.DropDownStyle = ComboBoxStyle.DropDownList;
            cboStartDateRepeatCountGeneratorInterval.FormattingEnabled = true;
            cboStartDateRepeatCountGeneratorInterval.Location = new Point(217, 106);
            cboStartDateRepeatCountGeneratorInterval.Name = "cboStartDateRepeatCountGeneratorInterval";
            cboStartDateRepeatCountGeneratorInterval.Size = new Size(89, 23);
            cboStartDateRepeatCountGeneratorInterval.TabIndex = 15;
            cboStartDateRepeatCountGeneratorInterval.SelectedIndexChanged += cboStartDateRepeatCountGeneratorInterval_SelectedIndexChanged;
            // 
            // nudStartDateRepeatCountGeneratorInterval
            // 
            nudStartDateRepeatCountGeneratorInterval.Location = new Point(150, 107);
            nudStartDateRepeatCountGeneratorInterval.Name = "nudStartDateRepeatCountGeneratorInterval";
            nudStartDateRepeatCountGeneratorInterval.Size = new Size(61, 23);
            nudStartDateRepeatCountGeneratorInterval.TabIndex = 14;
            nudStartDateRepeatCountGeneratorInterval.TextAlign = HorizontalAlignment.Right;
            nudStartDateRepeatCountGeneratorInterval.ValueChanged += nudStartDateRepeatCountGeneratorInterval_ValueChanged;
            // 
            // lblStartDateRepeatCountGeneratorInterval
            // 
            lblStartDateRepeatCountGeneratorInterval.Location = new Point(10, 107);
            lblStartDateRepeatCountGeneratorInterval.Name = "lblStartDateRepeatCountGeneratorInterval";
            lblStartDateRepeatCountGeneratorInterval.Size = new Size(121, 23);
            lblStartDateRepeatCountGeneratorInterval.TabIndex = 13;
            lblStartDateRepeatCountGeneratorInterval.Text = "&Interval :";
            lblStartDateRepeatCountGeneratorInterval.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lblStartDateRepeatCountGeneratorRepeatCount
            // 
            lblStartDateRepeatCountGeneratorRepeatCount.Location = new Point(10, 64);
            lblStartDateRepeatCountGeneratorRepeatCount.Name = "lblStartDateRepeatCountGeneratorRepeatCount";
            lblStartDateRepeatCountGeneratorRepeatCount.Size = new Size(121, 23);
            lblStartDateRepeatCountGeneratorRepeatCount.TabIndex = 11;
            lblStartDateRepeatCountGeneratorRepeatCount.Text = "&Repeat Count :";
            lblStartDateRepeatCountGeneratorRepeatCount.TextAlign = ContentAlignment.MiddleRight;
            // 
            // dtpStartDateRepeatCountGeneratorStartDate
            // 
            dtpStartDateRepeatCountGeneratorStartDate.Location = new Point(150, 21);
            dtpStartDateRepeatCountGeneratorStartDate.Name = "dtpStartDateRepeatCountGeneratorStartDate";
            dtpStartDateRepeatCountGeneratorStartDate.Size = new Size(156, 23);
            dtpStartDateRepeatCountGeneratorStartDate.TabIndex = 7;
            dtpStartDateRepeatCountGeneratorStartDate.ValueChanged += dtpStartDateRepeatCountGeneratorStartDate_ValueChanged;
            // 
            // lblStartDateRepeatCountGeneratorStartDate
            // 
            lblStartDateRepeatCountGeneratorStartDate.Location = new Point(10, 21);
            lblStartDateRepeatCountGeneratorStartDate.Name = "lblStartDateRepeatCountGeneratorStartDate";
            lblStartDateRepeatCountGeneratorStartDate.Size = new Size(121, 23);
            lblStartDateRepeatCountGeneratorStartDate.TabIndex = 6;
            lblStartDateRepeatCountGeneratorStartDate.Text = "&Start Date :";
            lblStartDateRepeatCountGeneratorStartDate.TextAlign = ContentAlignment.MiddleRight;
            // 
            // panGeneratedDates
            // 
            panGeneratedDates.Controls.Add(lvwGeneratedDates);
            panGeneratedDates.Controls.Add(lblGeneratedDatesDisplay);
            panGeneratedDates.Dock = DockStyle.Right;
            panGeneratedDates.Location = new Point(381, 0);
            panGeneratedDates.Name = "panGeneratedDates";
            panGeneratedDates.Size = new Size(240, 270);
            panGeneratedDates.TabIndex = 2;
            // 
            // lvwGeneratedDates
            // 
            lvwGeneratedDates.Columns.AddRange(new ColumnHeader[] { columnHeader1, columnHeader2 });
            lvwGeneratedDates.ContextMenuStrip = ctxmnuDatesList;
            lvwGeneratedDates.Dock = DockStyle.Top;
            lvwGeneratedDates.FullRowSelect = true;
            lvwGeneratedDates.Location = new Point(0, 0);
            lvwGeneratedDates.Name = "lvwGeneratedDates";
            lvwGeneratedDates.Size = new Size(240, 227);
            lvwGeneratedDates.TabIndex = 0;
            lvwGeneratedDates.UseCompatibleStateImageBehavior = false;
            lvwGeneratedDates.View = View.Details;
            // 
            // columnHeader1
            // 
            columnHeader1.Text = "Date";
            columnHeader1.Width = 75;
            // 
            // columnHeader2
            // 
            columnHeader2.Text = "Description";
            columnHeader2.Width = 135;
            // 
            // ctxmnuDatesList
            // 
            ctxmnuDatesList.Items.AddRange(new ToolStripItem[] { ctxmnuDatesListCopy, toolStripSeparator1, ctxmnuDatesListExport });
            ctxmnuDatesList.Name = "ctxmnuDatesList";
            ctxmnuDatesList.Size = new Size(118, 54);
            // 
            // ctxmnuDatesListCopy
            // 
            ctxmnuDatesListCopy.Name = "ctxmnuDatesListCopy";
            ctxmnuDatesListCopy.Size = new Size(117, 22);
            ctxmnuDatesListCopy.Text = "&Copy";
            ctxmnuDatesListCopy.Click += ctxmnuDatesListCopy_Click;
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new Size(114, 6);
            // 
            // ctxmnuDatesListExport
            // 
            ctxmnuDatesListExport.Name = "ctxmnuDatesListExport";
            ctxmnuDatesListExport.Size = new Size(117, 22);
            ctxmnuDatesListExport.Text = "&Export...";
            // 
            // lblGeneratedDatesDisplay
            // 
            lblGeneratedDatesDisplay.BorderStyle = BorderStyle.FixedSingle;
            lblGeneratedDatesDisplay.Dock = DockStyle.Bottom;
            lblGeneratedDatesDisplay.Location = new Point(0, 247);
            lblGeneratedDatesDisplay.Name = "lblGeneratedDatesDisplay";
            lblGeneratedDatesDisplay.Size = new Size(240, 23);
            lblGeneratedDatesDisplay.TabIndex = 1;
            lblGeneratedDatesDisplay.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // NotableDatesGeneratorEditorForm
            // 
            AcceptButton = btnOK;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = btnCancel;
            ClientSize = new Size(621, 302);
            Controls.Add(tbcEditors);
            Controls.Add(panGeneratedDates);
            Controls.Add(panButtonBar);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "NotableDatesGeneratorEditorForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Date Generator Editor";
            Load += DateGeneratorEditorForm_Load;
            panButtonBar.ResumeLayout(false);
            tbcEditors.ResumeLayout(false);
            tabEditorFixedDateGenerator.ResumeLayout(false);
            tabEditorStartDateEndDateGenerator.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)nudStartDateEndDateGeneratorSequenceIncrementValue).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudStartDateEndDateGeneratorSequenceStartValue).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudStartDateEndDateGeneratorIntervalValue).EndInit();
            tabEditorStartDateRepeatCountGenerator.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)nudStartDateRepeatCountGeneratorSequenceIncrement).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudStartDateRepeatCountGeneratorSequenceStart).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudStartDateRepeatCountGeneratorRepeatCount).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudStartDateRepeatCountGeneratorInterval).EndInit();
            panGeneratedDates.ResumeLayout(false);
            ctxmnuDatesList.ResumeLayout(false);
            ResumeLayout(false);
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
        private Label lblGeneratedDatesDisplay;
        private NumericUpDown nudStartDateEndDateGeneratorSequenceStartValue;
        private Label lblStartDateEndDateGeneratorSequenceStart;
        private Label lblStartDateEndDateGeneratorSequenceIncrement;
        private NumericUpDown nudStartDateEndDateGeneratorSequenceIncrementValue;
        private NumericUpDown nudStartDateRepeatCountGeneratorSequenceIncrement;
        private Label lblStartDateRepeatCountGeneratorSequenceIncrement;
        private NumericUpDown nudStartDateRepeatCountGeneratorSequenceStart;
        private Label lblStartDateRepeatCountGeneratorSequenceStart;
    }
}
