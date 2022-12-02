namespace QuickCalendar
{
    partial class DateSelectionForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DateSelectionForm));
            this.pnlButtonBar = new System.Windows.Forms.Panel();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.tbcDateSelection = new System.Windows.Forms.TabControl();
            this.tabSpecifiedDate = new System.Windows.Forms.TabPage();
            this.dtpSpecifiedDate = new System.Windows.Forms.DateTimePicker();
            this.lblSpecifiedDate = new System.Windows.Forms.Label();
            this.tabDateRange = new System.Windows.Forms.TabPage();
            this.dtpRangeEndDate = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.dtpRangeStartDate = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.timerErrorMessageReset = new System.Windows.Forms.Timer(this.components);
            this.panMessages = new System.Windows.Forms.Panel();
            this.lblErrorMessage = new System.Windows.Forms.Label();
            this.pnlButtonBar.SuspendLayout();
            this.tbcDateSelection.SuspendLayout();
            this.tabSpecifiedDate.SuspendLayout();
            this.tabDateRange.SuspendLayout();
            this.panMessages.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlButtonBar
            // 
            this.pnlButtonBar.Controls.Add(this.btnCancel);
            this.pnlButtonBar.Controls.Add(this.btnOK);
            this.pnlButtonBar.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlButtonBar.Location = new System.Drawing.Point(0, 146);
            this.pnlButtonBar.Name = "pnlButtonBar";
            this.pnlButtonBar.Size = new System.Drawing.Size(349, 29);
            this.pnlButtonBar.TabIndex = 0;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(270, 4);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.Location = new System.Drawing.Point(189, 4);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 0;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // tbcDateSelection
            // 
            this.tbcDateSelection.Controls.Add(this.tabSpecifiedDate);
            this.tbcDateSelection.Controls.Add(this.tabDateRange);
            this.tbcDateSelection.Dock = System.Windows.Forms.DockStyle.Top;
            this.tbcDateSelection.Location = new System.Drawing.Point(0, 0);
            this.tbcDateSelection.Name = "tbcDateSelection";
            this.tbcDateSelection.SelectedIndex = 0;
            this.tbcDateSelection.Size = new System.Drawing.Size(349, 103);
            this.tbcDateSelection.TabIndex = 1;
            // 
            // tabSpecifiedDate
            // 
            this.tabSpecifiedDate.Controls.Add(this.dtpSpecifiedDate);
            this.tabSpecifiedDate.Controls.Add(this.lblSpecifiedDate);
            this.tabSpecifiedDate.Location = new System.Drawing.Point(4, 24);
            this.tabSpecifiedDate.Name = "tabSpecifiedDate";
            this.tabSpecifiedDate.Padding = new System.Windows.Forms.Padding(3);
            this.tabSpecifiedDate.Size = new System.Drawing.Size(341, 75);
            this.tabSpecifiedDate.TabIndex = 0;
            this.tabSpecifiedDate.Text = "Date";
            this.tabSpecifiedDate.UseVisualStyleBackColor = true;
            // 
            // dtpSpecifiedDate
            // 
            this.dtpSpecifiedDate.Location = new System.Drawing.Point(86, 16);
            this.dtpSpecifiedDate.Name = "dtpSpecifiedDate";
            this.dtpSpecifiedDate.Size = new System.Drawing.Size(200, 23);
            this.dtpSpecifiedDate.TabIndex = 1;
            // 
            // lblSpecifiedDate
            // 
            this.lblSpecifiedDate.Location = new System.Drawing.Point(8, 16);
            this.lblSpecifiedDate.Name = "lblSpecifiedDate";
            this.lblSpecifiedDate.Size = new System.Drawing.Size(44, 23);
            this.lblSpecifiedDate.TabIndex = 0;
            this.lblSpecifiedDate.Text = "&Date :";
            this.lblSpecifiedDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tabDateRange
            // 
            this.tabDateRange.Controls.Add(this.dtpRangeEndDate);
            this.tabDateRange.Controls.Add(this.label2);
            this.tabDateRange.Controls.Add(this.dtpRangeStartDate);
            this.tabDateRange.Controls.Add(this.label1);
            this.tabDateRange.Location = new System.Drawing.Point(4, 24);
            this.tabDateRange.Name = "tabDateRange";
            this.tabDateRange.Padding = new System.Windows.Forms.Padding(3);
            this.tabDateRange.Size = new System.Drawing.Size(341, 75);
            this.tabDateRange.TabIndex = 1;
            this.tabDateRange.Text = "Range";
            this.tabDateRange.UseVisualStyleBackColor = true;
            // 
            // dtpRangeEndDate
            // 
            this.dtpRangeEndDate.Location = new System.Drawing.Point(86, 49);
            this.dtpRangeEndDate.Name = "dtpRangeEndDate";
            this.dtpRangeEndDate.Size = new System.Drawing.Size(200, 23);
            this.dtpRangeEndDate.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(8, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 23);
            this.label2.TabIndex = 4;
            this.label2.Text = "&End Date :";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dtpRangeStartDate
            // 
            this.dtpRangeStartDate.Location = new System.Drawing.Point(86, 16);
            this.dtpRangeStartDate.Name = "dtpRangeStartDate";
            this.dtpRangeStartDate.Size = new System.Drawing.Size(200, 23);
            this.dtpRangeStartDate.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(8, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 23);
            this.label1.TabIndex = 2;
            this.label1.Text = "&Start Date :";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // timerErrorMessageReset
            // 
            this.timerErrorMessageReset.Tick += new System.EventHandler(this.timerErrorMessageReset_Tick);
            // 
            // panMessages
            // 
            this.panMessages.BackColor = System.Drawing.Color.Transparent;
            this.panMessages.Controls.Add(this.lblErrorMessage);
            this.panMessages.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panMessages.Location = new System.Drawing.Point(0, 121);
            this.panMessages.Name = "panMessages";
            this.panMessages.Size = new System.Drawing.Size(349, 25);
            this.panMessages.TabIndex = 2;
            // 
            // lblErrorMessage
            // 
            this.lblErrorMessage.BackColor = System.Drawing.Color.Transparent;
            this.lblErrorMessage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblErrorMessage.ForeColor = System.Drawing.Color.Red;
            this.lblErrorMessage.Location = new System.Drawing.Point(0, 0);
            this.lblErrorMessage.Name = "lblErrorMessage";
            this.lblErrorMessage.Size = new System.Drawing.Size(349, 25);
            this.lblErrorMessage.TabIndex = 3;
            this.lblErrorMessage.Text = "Error Message";
            this.lblErrorMessage.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // DateSelectionForm
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(349, 175);
            this.Controls.Add(this.panMessages);
            this.Controls.Add(this.tbcDateSelection);
            this.Controls.Add(this.pnlButtonBar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DateSelectionForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Date Selection";
            this.Load += new System.EventHandler(this.DateSelection_Load);
            this.pnlButtonBar.ResumeLayout(false);
            this.tbcDateSelection.ResumeLayout(false);
            this.tabSpecifiedDate.ResumeLayout(false);
            this.tabDateRange.ResumeLayout(false);
            this.panMessages.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Panel pnlButtonBar;
        private Button btnCancel;
        private Button btnOK;
        private TabControl tbcDateSelection;
        private TabPage tabSpecifiedDate;
        private TabPage tabDateRange;
        private DateTimePicker dtpSpecifiedDate;
        private Label lblSpecifiedDate;
        private DateTimePicker dtpRangeEndDate;
        private Label label2;
        private DateTimePicker dtpRangeStartDate;
        private Label label1;
        private System.Windows.Forms.Timer timerErrorMessageReset;
        private Panel panMessages;
        private Label lblErrorMessage;
    }
}