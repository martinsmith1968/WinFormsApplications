namespace QuickCalendar
{
    partial class CalendarSizeForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CalendarSizeForm));
            this.pnlButtonBar = new System.Windows.Forms.Panel();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.pnlSettings = new System.Windows.Forms.Panel();
            this.pnlPreview = new System.Windows.Forms.Panel();
            this.picSampleCalendarMonth = new System.Windows.Forms.PictureBox();
            this.cboCalendarSize = new System.Windows.Forms.ComboBox();
            this.lblCalendarSize = new System.Windows.Forms.Label();
            this.pnlButtonBar.SuspendLayout();
            this.pnlSettings.SuspendLayout();
            this.pnlPreview.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picSampleCalendarMonth)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlButtonBar
            // 
            this.pnlButtonBar.Controls.Add(this.btnCancel);
            this.pnlButtonBar.Controls.Add(this.btnOK);
            this.pnlButtonBar.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlButtonBar.Location = new System.Drawing.Point(0, 282);
            this.pnlButtonBar.Name = "pnlButtonBar";
            this.pnlButtonBar.Size = new System.Drawing.Size(297, 30);
            this.pnlButtonBar.TabIndex = 0;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(219, 3);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.Location = new System.Drawing.Point(138, 3);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 0;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // pnlSettings
            // 
            this.pnlSettings.Controls.Add(this.pnlPreview);
            this.pnlSettings.Controls.Add(this.cboCalendarSize);
            this.pnlSettings.Controls.Add(this.lblCalendarSize);
            this.pnlSettings.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlSettings.Location = new System.Drawing.Point(0, 0);
            this.pnlSettings.Name = "pnlSettings";
            this.pnlSettings.Size = new System.Drawing.Size(264, 282);
            this.pnlSettings.TabIndex = 2;
            // 
            // pnlPreview
            // 
            this.pnlPreview.Controls.Add(this.picSampleCalendarMonth);
            this.pnlPreview.Location = new System.Drawing.Point(12, 35);
            this.pnlPreview.Name = "pnlPreview";
            this.pnlPreview.Padding = new System.Windows.Forms.Padding(0, 4, 0, 0);
            this.pnlPreview.Size = new System.Drawing.Size(240, 240);
            this.pnlPreview.TabIndex = 3;
            // 
            // picSampleCalendarMonth
            // 
            this.picSampleCalendarMonth.Image = global::QuickCalendar.Properties.Resources.calendar_month1;
            this.picSampleCalendarMonth.Location = new System.Drawing.Point(3, 197);
            this.picSampleCalendarMonth.Name = "picSampleCalendarMonth";
            this.picSampleCalendarMonth.Padding = new System.Windows.Forms.Padding(4);
            this.picSampleCalendarMonth.Size = new System.Drawing.Size(40, 40);
            this.picSampleCalendarMonth.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.picSampleCalendarMonth.TabIndex = 4;
            this.picSampleCalendarMonth.TabStop = false;
            this.picSampleCalendarMonth.Visible = false;
            // 
            // cboCalendarSize
            // 
            this.cboCalendarSize.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCalendarSize.FormattingEnabled = true;
            this.cboCalendarSize.Location = new System.Drawing.Point(103, 6);
            this.cboCalendarSize.Name = "cboCalendarSize";
            this.cboCalendarSize.Size = new System.Drawing.Size(149, 23);
            this.cboCalendarSize.TabIndex = 1;
            this.cboCalendarSize.SelectedIndexChanged += new System.EventHandler(this.cboCalendarSize_SelectedIndexChanged);
            this.cboCalendarSize.SelectedValueChanged += new System.EventHandler(this.cboCalendarSize_SelectedValueChanged);
            // 
            // lblCalendarSize
            // 
            this.lblCalendarSize.AutoSize = true;
            this.lblCalendarSize.Location = new System.Drawing.Point(12, 9);
            this.lblCalendarSize.Name = "lblCalendarSize";
            this.lblCalendarSize.Size = new System.Drawing.Size(83, 15);
            this.lblCalendarSize.TabIndex = 0;
            this.lblCalendarSize.Text = "Calendar &Size :";
            // 
            // CalendarSizeForm
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(297, 312);
            this.Controls.Add(this.pnlSettings);
            this.Controls.Add(this.pnlButtonBar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CalendarSizeForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Calendar Size";
            this.Load += new System.EventHandler(this.CalendarSizeForm_Load);
            this.pnlButtonBar.ResumeLayout(false);
            this.pnlSettings.ResumeLayout(false);
            this.pnlSettings.PerformLayout();
            this.pnlPreview.ResumeLayout(false);
            this.pnlPreview.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picSampleCalendarMonth)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Panel pnlButtonBar;
        private Button btnCancel;
        private Button btnOK;
        private Panel pnlSettings;
        private ComboBox cboCalendarSize;
        private Label lblCalendarSize;
        private Panel pnlPreview;
        private PictureBox picSampleCalendarMonth;
    }
}