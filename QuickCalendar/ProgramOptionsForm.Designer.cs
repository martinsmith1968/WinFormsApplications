namespace QuickCalendar
{
    partial class ProgramOptionsForm
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
            var resources = new System.ComponentModel.ComponentResourceManager(typeof(ProgramOptionsForm));
            panButtonBar = new Panel();
            lblErrorText = new Label();
            btnCancel = new Button();
            btnOK = new Button();
            tabGeneral = new TabPage();
            cboShowCalendarNameInStatusBar = new ComboBox();
            lblShowCalendarNameInStatusBar = new Label();
            cboShowCalendarNameInWindowTitle = new ComboBox();
            lblShowCalendarNameInWindowTitle = new Label();
            chkCloseOnEscape = new CheckBox();
            tbcOptions = new TabControl();
            tabExperimental = new TabPage();
            chkStartWithWindows = new CheckBox();
            tabDebugging = new TabPage();
            lvwRawProperties = new ListView();
            colRawPropertiesName = new ColumnHeader();
            colRawPropertiesValue = new ColumnHeader();
            panButtonBar.SuspendLayout();
            tabGeneral.SuspendLayout();
            tbcOptions.SuspendLayout();
            tabExperimental.SuspendLayout();
            tabDebugging.SuspendLayout();
            SuspendLayout();
            // 
            // panButtonBar
            // 
            panButtonBar.Controls.Add(lblErrorText);
            panButtonBar.Controls.Add(btnCancel);
            panButtonBar.Controls.Add(btnOK);
            panButtonBar.Dock = DockStyle.Bottom;
            panButtonBar.Location = new Point(0, 210);
            panButtonBar.Name = "panButtonBar";
            panButtonBar.Size = new Size(504, 38);
            panButtonBar.TabIndex = 1;
            // 
            // lblErrorText
            // 
            lblErrorText.BorderStyle = BorderStyle.FixedSingle;
            lblErrorText.ForeColor = Color.Red;
            lblErrorText.Location = new Point(12, 8);
            lblErrorText.Name = "lblErrorText";
            lblErrorText.Size = new Size(322, 21);
            lblErrorText.TabIndex = 2;
            lblErrorText.Text = "label1";
            lblErrorText.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // btnCancel
            // 
            btnCancel.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnCancel.Location = new Point(421, 8);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(75, 23);
            btnCancel.TabIndex = 1;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnOK
            // 
            btnOK.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnOK.Location = new Point(340, 8);
            btnOK.Name = "btnOK";
            btnOK.Size = new Size(75, 23);
            btnOK.TabIndex = 0;
            btnOK.Text = "OK";
            btnOK.UseVisualStyleBackColor = true;
            btnOK.Click += btnOK_Click;
            // 
            // tabGeneral
            // 
            tabGeneral.Controls.Add(cboShowCalendarNameInStatusBar);
            tabGeneral.Controls.Add(lblShowCalendarNameInStatusBar);
            tabGeneral.Controls.Add(cboShowCalendarNameInWindowTitle);
            tabGeneral.Controls.Add(lblShowCalendarNameInWindowTitle);
            tabGeneral.Controls.Add(chkCloseOnEscape);
            tabGeneral.Location = new Point(4, 24);
            tabGeneral.Name = "tabGeneral";
            tabGeneral.Padding = new Padding(3);
            tabGeneral.Size = new Size(496, 150);
            tabGeneral.TabIndex = 0;
            tabGeneral.Text = "General";
            tabGeneral.UseVisualStyleBackColor = true;
            // 
            // cboShowCalendarNameInStatusBar
            // 
            cboShowCalendarNameInStatusBar.DropDownStyle = ComboBoxStyle.DropDownList;
            cboShowCalendarNameInStatusBar.FormattingEnabled = true;
            cboShowCalendarNameInStatusBar.Location = new Point(245, 74);
            cboShowCalendarNameInStatusBar.Name = "cboShowCalendarNameInStatusBar";
            cboShowCalendarNameInStatusBar.Size = new Size(188, 23);
            cboShowCalendarNameInStatusBar.TabIndex = 6;
            // 
            // lblShowCalendarNameInStatusBar
            // 
            lblShowCalendarNameInStatusBar.Location = new Point(8, 72);
            lblShowCalendarNameInStatusBar.Name = "lblShowCalendarNameInStatusBar";
            lblShowCalendarNameInStatusBar.Size = new Size(231, 24);
            lblShowCalendarNameInStatusBar.TabIndex = 5;
            lblShowCalendarNameInStatusBar.Text = "Show Calendar Name in Status Bar :";
            lblShowCalendarNameInStatusBar.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // cboShowCalendarNameInWindowTitle
            // 
            cboShowCalendarNameInWindowTitle.DropDownStyle = ComboBoxStyle.DropDownList;
            cboShowCalendarNameInWindowTitle.FormattingEnabled = true;
            cboShowCalendarNameInWindowTitle.Location = new Point(245, 45);
            cboShowCalendarNameInWindowTitle.Name = "cboShowCalendarNameInWindowTitle";
            cboShowCalendarNameInWindowTitle.Size = new Size(188, 23);
            cboShowCalendarNameInWindowTitle.TabIndex = 4;
            // 
            // lblShowCalendarNameInWindowTitle
            // 
            lblShowCalendarNameInWindowTitle.Location = new Point(8, 43);
            lblShowCalendarNameInWindowTitle.Name = "lblShowCalendarNameInWindowTitle";
            lblShowCalendarNameInWindowTitle.Size = new Size(231, 24);
            lblShowCalendarNameInWindowTitle.TabIndex = 3;
            lblShowCalendarNameInWindowTitle.Text = "Show Calendar Name in Window Title :";
            lblShowCalendarNameInWindowTitle.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // chkCloseOnEscape
            // 
            chkCloseOnEscape.CheckAlign = ContentAlignment.MiddleRight;
            chkCloseOnEscape.Location = new Point(8, 15);
            chkCloseOnEscape.Name = "chkCloseOnEscape";
            chkCloseOnEscape.Size = new Size(252, 24);
            chkCloseOnEscape.TabIndex = 0;
            chkCloseOnEscape.Text = "Close on &Escape :";
            chkCloseOnEscape.UseVisualStyleBackColor = true;
            // 
            // tbcOptions
            // 
            tbcOptions.Controls.Add(tabGeneral);
            tbcOptions.Controls.Add(tabExperimental);
            tbcOptions.Controls.Add(tabDebugging);
            tbcOptions.Dock = DockStyle.Top;
            tbcOptions.Location = new Point(0, 0);
            tbcOptions.Name = "tbcOptions";
            tbcOptions.SelectedIndex = 0;
            tbcOptions.Size = new Size(504, 178);
            tbcOptions.TabIndex = 0;
            // 
            // tabExperimental
            // 
            tabExperimental.Controls.Add(chkStartWithWindows);
            tabExperimental.Location = new Point(4, 24);
            tabExperimental.Name = "tabExperimental";
            tabExperimental.Padding = new Padding(3);
            tabExperimental.Size = new Size(496, 150);
            tabExperimental.TabIndex = 1;
            tabExperimental.Text = "Experimental";
            tabExperimental.UseVisualStyleBackColor = true;
            // 
            // chkStartWithWindows
            // 
            chkStartWithWindows.CheckAlign = ContentAlignment.MiddleRight;
            chkStartWithWindows.Location = new Point(8, 15);
            chkStartWithWindows.Name = "chkStartWithWindows";
            chkStartWithWindows.Size = new Size(231, 24);
            chkStartWithWindows.TabIndex = 2;
            chkStartWithWindows.Text = "Start with &Windows :";
            chkStartWithWindows.UseVisualStyleBackColor = true;
            // 
            // tabDebugging
            // 
            tabDebugging.Controls.Add(lvwRawProperties);
            tabDebugging.Location = new Point(4, 24);
            tabDebugging.Name = "tabDebugging";
            tabDebugging.Padding = new Padding(3);
            tabDebugging.Size = new Size(496, 150);
            tabDebugging.TabIndex = 2;
            tabDebugging.Text = "Debugging";
            tabDebugging.UseVisualStyleBackColor = true;
            // 
            // lvwRawProperties
            // 
            lvwRawProperties.Columns.AddRange(new ColumnHeader[] { colRawPropertiesName, colRawPropertiesValue });
            lvwRawProperties.Dock = DockStyle.Top;
            lvwRawProperties.Location = new Point(3, 3);
            lvwRawProperties.Name = "lvwRawProperties";
            lvwRawProperties.Size = new Size(490, 97);
            lvwRawProperties.TabIndex = 0;
            lvwRawProperties.UseCompatibleStateImageBehavior = false;
            lvwRawProperties.View = View.Details;
            // 
            // colRawPropertiesName
            // 
            colRawPropertiesName.Text = "Name";
            colRawPropertiesName.Width = 180;
            // 
            // colRawPropertiesValue
            // 
            colRawPropertiesValue.Text = "Value";
            colRawPropertiesValue.Width = 240;
            // 
            // ProgramOptionsForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = btnCancel;
            ClientSize = new Size(504, 248);
            Controls.Add(panButtonBar);
            Controls.Add(tbcOptions);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "ProgramOptionsForm";
            ShowInTaskbar = false;
            SizeGripStyle = SizeGripStyle.Hide;
            StartPosition = FormStartPosition.CenterParent;
            Text = "Program Options";
            Load += ProgramOptionsForm_Load;
            panButtonBar.ResumeLayout(false);
            tabGeneral.ResumeLayout(false);
            tbcOptions.ResumeLayout(false);
            tabExperimental.ResumeLayout(false);
            tabDebugging.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel panButtonBar;
        private Button btnCancel;
        private Button btnOK;
        private TabPage tabGeneral;
        private TabControl tbcOptions;
        private CheckBox chkCloseOnEscape;
        private Label lblErrorText;
        private TabPage tabExperimental;
        private CheckBox chkStartWithWindows;
        private ComboBox cboShowCalendarNameInWindowTitle;
        private Label lblShowCalendarNameInWindowTitle;
        private ComboBox cboShowCalendarNameInStatusBar;
        private Label lblShowCalendarNameInStatusBar;
        private TabPage tabDebugging;
        private ListView lvwRawProperties;
        private ColumnHeader colRawPropertiesName;
        private ColumnHeader colRawPropertiesValue;
    }
}