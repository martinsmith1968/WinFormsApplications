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
            components = new System.ComponentModel.Container();
            var resources = new System.ComponentModel.ComponentResourceManager(typeof(DateSelectionForm));
            pnlButtonBar = new Panel();
            btnCancel = new Button();
            btnOK = new Button();
            tbcDateSelection = new TabControl();
            tabSpecifiedDate = new TabPage();
            dtpSpecifiedDate = new DateTimePicker();
            lblSpecifiedDate = new Label();
            tabDateRange = new TabPage();
            dtpRangeEndDate = new DateTimePicker();
            label2 = new Label();
            dtpRangeStartDate = new DateTimePicker();
            label1 = new Label();
            timerErrorMessageReset = new System.Windows.Forms.Timer(components);
            panMessages = new Panel();
            lblErrorMessage = new Label();
            pnlButtonBar.SuspendLayout();
            tbcDateSelection.SuspendLayout();
            tabSpecifiedDate.SuspendLayout();
            tabDateRange.SuspendLayout();
            panMessages.SuspendLayout();
            SuspendLayout();
            // 
            // pnlButtonBar
            // 
            pnlButtonBar.Controls.Add(btnCancel);
            pnlButtonBar.Controls.Add(btnOK);
            pnlButtonBar.Dock = DockStyle.Bottom;
            pnlButtonBar.Location = new Point(0, 146);
            pnlButtonBar.Name = "pnlButtonBar";
            pnlButtonBar.Size = new Size(349, 29);
            pnlButtonBar.TabIndex = 0;
            // 
            // btnCancel
            // 
            btnCancel.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnCancel.DialogResult = DialogResult.Cancel;
            btnCancel.Location = new Point(270, 4);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(75, 23);
            btnCancel.TabIndex = 1;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnOK
            // 
            btnOK.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnOK.Location = new Point(189, 4);
            btnOK.Name = "btnOK";
            btnOK.Size = new Size(75, 23);
            btnOK.TabIndex = 0;
            btnOK.Text = "OK";
            btnOK.UseVisualStyleBackColor = true;
            btnOK.Click += btnOK_Click;
            // 
            // tbcDateSelection
            // 
            tbcDateSelection.Controls.Add(tabSpecifiedDate);
            tbcDateSelection.Controls.Add(tabDateRange);
            tbcDateSelection.Dock = DockStyle.Top;
            tbcDateSelection.Location = new Point(0, 0);
            tbcDateSelection.Name = "tbcDateSelection";
            tbcDateSelection.SelectedIndex = 0;
            tbcDateSelection.Size = new Size(349, 103);
            tbcDateSelection.TabIndex = 1;
            // 
            // tabSpecifiedDate
            // 
            tabSpecifiedDate.Controls.Add(dtpSpecifiedDate);
            tabSpecifiedDate.Controls.Add(lblSpecifiedDate);
            tabSpecifiedDate.Location = new Point(4, 24);
            tabSpecifiedDate.Name = "tabSpecifiedDate";
            tabSpecifiedDate.Padding = new Padding(3);
            tabSpecifiedDate.Size = new Size(341, 75);
            tabSpecifiedDate.TabIndex = 0;
            tabSpecifiedDate.Text = "Date";
            tabSpecifiedDate.UseVisualStyleBackColor = true;
            // 
            // dtpSpecifiedDate
            // 
            dtpSpecifiedDate.Location = new Point(86, 16);
            dtpSpecifiedDate.Name = "dtpSpecifiedDate";
            dtpSpecifiedDate.Size = new Size(200, 23);
            dtpSpecifiedDate.TabIndex = 1;
            // 
            // lblSpecifiedDate
            // 
            lblSpecifiedDate.Location = new Point(8, 16);
            lblSpecifiedDate.Name = "lblSpecifiedDate";
            lblSpecifiedDate.Size = new Size(44, 23);
            lblSpecifiedDate.TabIndex = 0;
            lblSpecifiedDate.Text = "&Date :";
            lblSpecifiedDate.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // tabDateRange
            // 
            tabDateRange.Controls.Add(dtpRangeEndDate);
            tabDateRange.Controls.Add(label2);
            tabDateRange.Controls.Add(dtpRangeStartDate);
            tabDateRange.Controls.Add(label1);
            tabDateRange.Location = new Point(4, 24);
            tabDateRange.Name = "tabDateRange";
            tabDateRange.Padding = new Padding(3);
            tabDateRange.Size = new Size(341, 75);
            tabDateRange.TabIndex = 1;
            tabDateRange.Text = "Range";
            tabDateRange.UseVisualStyleBackColor = true;
            // 
            // dtpRangeEndDate
            // 
            dtpRangeEndDate.Location = new Point(86, 49);
            dtpRangeEndDate.Name = "dtpRangeEndDate";
            dtpRangeEndDate.Size = new Size(200, 23);
            dtpRangeEndDate.TabIndex = 5;
            // 
            // label2
            // 
            label2.Location = new Point(8, 49);
            label2.Name = "label2";
            label2.Size = new Size(72, 23);
            label2.TabIndex = 4;
            label2.Text = "&End Date :";
            label2.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // dtpRangeStartDate
            // 
            dtpRangeStartDate.Location = new Point(86, 16);
            dtpRangeStartDate.Name = "dtpRangeStartDate";
            dtpRangeStartDate.Size = new Size(200, 23);
            dtpRangeStartDate.TabIndex = 3;
            // 
            // label1
            // 
            label1.Location = new Point(8, 16);
            label1.Name = "label1";
            label1.Size = new Size(72, 23);
            label1.TabIndex = 2;
            label1.Text = "&Start Date :";
            label1.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // timerErrorMessageReset
            // 
            timerErrorMessageReset.Tick += timerErrorMessageReset_Tick;
            // 
            // panMessages
            // 
            panMessages.BackColor = Color.Transparent;
            panMessages.Controls.Add(lblErrorMessage);
            panMessages.Dock = DockStyle.Bottom;
            panMessages.Location = new Point(0, 121);
            panMessages.Name = "panMessages";
            panMessages.Size = new Size(349, 25);
            panMessages.TabIndex = 2;
            // 
            // lblErrorMessage
            // 
            lblErrorMessage.BackColor = Color.Transparent;
            lblErrorMessage.Dock = DockStyle.Fill;
            lblErrorMessage.ForeColor = Color.Red;
            lblErrorMessage.Location = new Point(0, 0);
            lblErrorMessage.Name = "lblErrorMessage";
            lblErrorMessage.Size = new Size(349, 25);
            lblErrorMessage.TabIndex = 3;
            lblErrorMessage.Text = "Error Message";
            lblErrorMessage.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // DateSelectionForm
            // 
            AcceptButton = btnOK;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = btnCancel;
            ClientSize = new Size(349, 175);
            Controls.Add(panMessages);
            Controls.Add(tbcDateSelection);
            Controls.Add(pnlButtonBar);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "DateSelectionForm";
            ShowIcon = false;
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterParent;
            Text = "Date Selection";
            Load += DateSelection_Load;
            pnlButtonBar.ResumeLayout(false);
            tbcDateSelection.ResumeLayout(false);
            tabSpecifiedDate.ResumeLayout(false);
            tabDateRange.ResumeLayout(false);
            panMessages.ResumeLayout(false);
            ResumeLayout(false);
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