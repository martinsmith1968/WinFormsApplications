namespace QuickCalendar
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            var resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            msMain = new MenuStrip();
            tsmnuFile = new ToolStripMenuItem();
            tsmnuFileExit = new ToolStripMenuItem();
            tsmnuEdit = new ToolStripMenuItem();
            tsmnuEditCalendar = new ToolStripMenuItem();
            toolStripSeparator3 = new ToolStripSeparator();
            tsmnuEditProgramOptions = new ToolStripMenuItem();
            tsmnuView = new ToolStripMenuItem();
            tsmnuViewToday = new ToolStripMenuItem();
            tsmnuViewJumpToDate = new ToolStripMenuItem();
            tsmnuViewResize = new ToolStripMenuItem();
            tsmnuHelp = new ToolStripMenuItem();
            tsmnuHelpUsageGuide = new ToolStripMenuItem();
            toolStripSeparator5 = new ToolStripSeparator();
            tsmnuHelpAbout = new ToolStripMenuItem();
            ssMain = new StatusStrip();
            tslblInfo = new ToolStripStatusLabel();
            tslblSelectedDatesDescriptions = new ToolStripStatusLabel();
            tslblSelectedDaysCount = new ToolStripStatusLabel();
            tslblSelectedDaysRange = new ToolStripStatusLabel();
            tslblCalendarSetName = new ToolStripStatusLabel();
            tsMain = new ToolStrip();
            tsbtnFileExit = new ToolStripButton();
            tssep1 = new ToolStripSeparator();
            tsbtnEditProgramOptions = new ToolStripButton();
            toolStripSeparator2 = new ToolStripSeparator();
            tsbtnEditCalendar = new ToolStripButton();
            toolStripSeparator4 = new ToolStripSeparator();
            tsbtnViewToday = new ToolStripButton();
            tsbtnViewJumpToDate = new ToolStripButton();
            tsbtnViewResize = new ToolStripButton();
            toolStripSeparator1 = new ToolStripSeparator();
            tsbtnHelpAbout = new ToolStripButton();
            mcalCalendar = new MonthCalendar();
            msMain.SuspendLayout();
            ssMain.SuspendLayout();
            tsMain.SuspendLayout();
            SuspendLayout();
            // 
            // msMain
            // 
            msMain.Items.AddRange(new ToolStripItem[] { tsmnuFile, tsmnuEdit, tsmnuView, tsmnuHelp });
            msMain.Location = new Point(0, 0);
            msMain.Name = "msMain";
            msMain.Size = new Size(753, 24);
            msMain.TabIndex = 0;
            msMain.Text = "menuStrip1";
            // 
            // tsmnuFile
            // 
            tsmnuFile.DropDownItems.AddRange(new ToolStripItem[] { tsmnuFileExit });
            tsmnuFile.Name = "tsmnuFile";
            tsmnuFile.Size = new Size(37, 20);
            tsmnuFile.Text = "&File";
            // 
            // tsmnuFileExit
            // 
            tsmnuFileExit.Image = Properties.Resources.exit4;
            tsmnuFileExit.Name = "tsmnuFileExit";
            tsmnuFileExit.Size = new Size(93, 22);
            tsmnuFileExit.Text = "E&xit";
            tsmnuFileExit.ToolTipText = "Exit Application";
            tsmnuFileExit.Click += tsmnuFileExit_Click;
            // 
            // tsmnuEdit
            // 
            tsmnuEdit.DropDownItems.AddRange(new ToolStripItem[] { tsmnuEditCalendar, toolStripSeparator3, tsmnuEditProgramOptions });
            tsmnuEdit.Name = "tsmnuEdit";
            tsmnuEdit.Size = new Size(39, 20);
            tsmnuEdit.Text = "&Edit";
            // 
            // tsmnuEditCalendar
            // 
            tsmnuEditCalendar.Image = Properties.Resources.edit_calendar1;
            tsmnuEditCalendar.Name = "tsmnuEditCalendar";
            tsmnuEditCalendar.ShortcutKeys = Keys.Control | Keys.E;
            tsmnuEditCalendar.Size = new Size(217, 22);
            tsmnuEditCalendar.Text = "Cal&endar...";
            tsmnuEditCalendar.ToolTipText = "View and Change the settings for this Calendar";
            tsmnuEditCalendar.Click += tsmnuEditCalendar_Click;
            // 
            // toolStripSeparator3
            // 
            toolStripSeparator3.Name = "toolStripSeparator3";
            toolStripSeparator3.Size = new Size(214, 6);
            // 
            // tsmnuEditProgramOptions
            // 
            tsmnuEditProgramOptions.Image = Properties.Resources.settings3;
            tsmnuEditProgramOptions.Name = "tsmnuEditProgramOptions";
            tsmnuEditProgramOptions.ShortcutKeys = Keys.Control | Keys.O;
            tsmnuEditProgramOptions.Size = new Size(217, 22);
            tsmnuEditProgramOptions.Text = "Program &Options...";
            tsmnuEditProgramOptions.Click += tsmnuEditProgramOptions_Click;
            // 
            // tsmnuView
            // 
            tsmnuView.DropDownItems.AddRange(new ToolStripItem[] { tsmnuViewToday, tsmnuViewJumpToDate, tsmnuViewResize });
            tsmnuView.Name = "tsmnuView";
            tsmnuView.Size = new Size(44, 20);
            tsmnuView.Text = "&View";
            // 
            // tsmnuViewToday
            // 
            tsmnuViewToday.Image = Properties.Resources.jump_today1;
            tsmnuViewToday.Name = "tsmnuViewToday";
            tsmnuViewToday.ShortcutKeys = Keys.Control | Keys.T;
            tsmnuViewToday.Size = new Size(191, 22);
            tsmnuViewToday.Text = "&Today";
            tsmnuViewToday.ToolTipText = "Jump to Today";
            tsmnuViewToday.Click += tsmnuViewToday_Click;
            // 
            // tsmnuViewJumpToDate
            // 
            tsmnuViewJumpToDate.Image = Properties.Resources.jump_date1;
            tsmnuViewJumpToDate.Name = "tsmnuViewJumpToDate";
            tsmnuViewJumpToDate.ShortcutKeys = Keys.Control | Keys.J;
            tsmnuViewJumpToDate.Size = new Size(191, 22);
            tsmnuViewJumpToDate.Text = "&Jump to Date...";
            tsmnuViewJumpToDate.ToolTipText = "Jump to Specified Date";
            tsmnuViewJumpToDate.Click += tsmnuViewJumpToDate_Click;
            // 
            // tsmnuViewResize
            // 
            tsmnuViewResize.Image = Properties.Resources.resize_form3;
            tsmnuViewResize.Name = "tsmnuViewResize";
            tsmnuViewResize.ShortcutKeys = Keys.Control | Keys.R;
            tsmnuViewResize.Size = new Size(191, 22);
            tsmnuViewResize.Text = "&Resize...";
            tsmnuViewResize.ToolTipText = "Resize Form to specific Layout";
            tsmnuViewResize.Click += tsmnuViewResize_Click;
            // 
            // tsmnuHelp
            // 
            tsmnuHelp.DropDownItems.AddRange(new ToolStripItem[] { tsmnuHelpUsageGuide, toolStripSeparator5, tsmnuHelpAbout });
            tsmnuHelp.Name = "tsmnuHelp";
            tsmnuHelp.Size = new Size(44, 20);
            tsmnuHelp.Text = "&Help";
            // 
            // tsmnuHelpUsageGuide
            // 
            tsmnuHelpUsageGuide.Image = Properties.Resources.usage_guide1;
            tsmnuHelpUsageGuide.Name = "tsmnuHelpUsageGuide";
            tsmnuHelpUsageGuide.Size = new Size(149, 22);
            tsmnuHelpUsageGuide.Text = "Usage Guide...";
            tsmnuHelpUsageGuide.Click += tsmnuHelpUsageGuide_Click;
            // 
            // toolStripSeparator5
            // 
            toolStripSeparator5.Name = "toolStripSeparator5";
            toolStripSeparator5.Size = new Size(146, 6);
            // 
            // tsmnuHelpAbout
            // 
            tsmnuHelpAbout.Image = Properties.Resources.about1;
            tsmnuHelpAbout.Name = "tsmnuHelpAbout";
            tsmnuHelpAbout.Size = new Size(149, 22);
            tsmnuHelpAbout.Text = "&About...";
            tsmnuHelpAbout.ToolTipText = "Show Application Details";
            tsmnuHelpAbout.Click += tsmnuHelpAbout_Click;
            // 
            // ssMain
            // 
            ssMain.Items.AddRange(new ToolStripItem[] { tslblInfo, tslblSelectedDatesDescriptions, tslblSelectedDaysCount, tslblSelectedDaysRange, tslblCalendarSetName });
            ssMain.Location = new Point(0, 416);
            ssMain.Name = "ssMain";
            ssMain.ShowItemToolTips = true;
            ssMain.Size = new Size(753, 22);
            ssMain.TabIndex = 1;
            ssMain.Text = "statusStrip1";
            // 
            // tslblInfo
            // 
            tslblInfo.Name = "tslblInfo";
            tslblInfo.Size = new Size(410, 17);
            tslblInfo.Spring = true;
            tslblInfo.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // tslblSelectedDatesDescriptions
            // 
            tslblSelectedDatesDescriptions.ForeColor = SystemColors.Highlight;
            tslblSelectedDatesDescriptions.Name = "tslblSelectedDatesDescriptions";
            tslblSelectedDatesDescriptions.Size = new Size(94, 17);
            tslblSelectedDatesDescriptions.Text = "Date Description";
            // 
            // tslblSelectedDaysCount
            // 
            tslblSelectedDaysCount.Name = "tslblSelectedDaysCount";
            tslblSelectedDaysCount.Size = new Size(115, 17);
            tslblSelectedDaysCount.Text = "Selected Days Range";
            // 
            // tslblSelectedDaysRange
            // 
            tslblSelectedDaysRange.Name = "tslblSelectedDaysRange";
            tslblSelectedDaysRange.Size = new Size(74, 17);
            tslblSelectedDaysRange.Text = "Selected Day";
            tslblSelectedDaysRange.TextAlign = ContentAlignment.MiddleRight;
            // 
            // tslblCalendarSetName
            // 
            tslblCalendarSetName.Name = "tslblCalendarSetName";
            tslblCalendarSetName.Size = new Size(45, 17);
            tslblCalendarSetName.Text = "Default";
            // 
            // tsMain
            // 
            tsMain.Items.AddRange(new ToolStripItem[] { tsbtnFileExit, tssep1, tsbtnEditProgramOptions, toolStripSeparator2, tsbtnEditCalendar, toolStripSeparator4, tsbtnViewToday, tsbtnViewJumpToDate, tsbtnViewResize, toolStripSeparator1, tsbtnHelpAbout });
            tsMain.Location = new Point(0, 24);
            tsMain.Name = "tsMain";
            tsMain.Size = new Size(753, 25);
            tsMain.TabIndex = 1;
            tsMain.Text = "tsMain";
            // 
            // tsbtnFileExit
            // 
            tsbtnFileExit.DisplayStyle = ToolStripItemDisplayStyle.Image;
            tsbtnFileExit.Image = Properties.Resources.exit4;
            tsbtnFileExit.ImageTransparentColor = Color.Magenta;
            tsbtnFileExit.Name = "tsbtnFileExit";
            tsbtnFileExit.Size = new Size(23, 22);
            tsbtnFileExit.Text = "Exit";
            tsbtnFileExit.ToolTipText = "Exit Application";
            tsbtnFileExit.Click += tsmnuFileExit_Click;
            // 
            // tssep1
            // 
            tssep1.Name = "tssep1";
            tssep1.Size = new Size(6, 25);
            // 
            // tsbtnEditProgramOptions
            // 
            tsbtnEditProgramOptions.DisplayStyle = ToolStripItemDisplayStyle.Image;
            tsbtnEditProgramOptions.Image = Properties.Resources.settings3;
            tsbtnEditProgramOptions.ImageTransparentColor = Color.Magenta;
            tsbtnEditProgramOptions.Name = "tsbtnEditProgramOptions";
            tsbtnEditProgramOptions.Size = new Size(23, 22);
            tsbtnEditProgramOptions.Text = "Program Options and Settings";
            tsbtnEditProgramOptions.Click += tsmnuEditProgramOptions_Click;
            // 
            // toolStripSeparator2
            // 
            toolStripSeparator2.Name = "toolStripSeparator2";
            toolStripSeparator2.Size = new Size(6, 25);
            // 
            // tsbtnEditCalendar
            // 
            tsbtnEditCalendar.DisplayStyle = ToolStripItemDisplayStyle.Image;
            tsbtnEditCalendar.Image = Properties.Resources.edit_calendar1;
            tsbtnEditCalendar.ImageTransparentColor = Color.Magenta;
            tsbtnEditCalendar.Name = "tsbtnEditCalendar";
            tsbtnEditCalendar.Size = new Size(23, 22);
            tsbtnEditCalendar.Text = "toolStripButton1";
            tsbtnEditCalendar.Click += tsmnuEditCalendar_Click;
            // 
            // toolStripSeparator4
            // 
            toolStripSeparator4.Name = "toolStripSeparator4";
            toolStripSeparator4.Size = new Size(6, 25);
            // 
            // tsbtnViewToday
            // 
            tsbtnViewToday.DisplayStyle = ToolStripItemDisplayStyle.Image;
            tsbtnViewToday.Image = Properties.Resources.jump_today1;
            tsbtnViewToday.ImageTransparentColor = Color.Magenta;
            tsbtnViewToday.Name = "tsbtnViewToday";
            tsbtnViewToday.Size = new Size(23, 22);
            tsbtnViewToday.Text = "&Today";
            tsbtnViewToday.ToolTipText = "Jump to Today";
            tsbtnViewToday.Click += tsmnuViewToday_Click;
            // 
            // tsbtnViewJumpToDate
            // 
            tsbtnViewJumpToDate.DisplayStyle = ToolStripItemDisplayStyle.Image;
            tsbtnViewJumpToDate.Image = Properties.Resources.jump_date1;
            tsbtnViewJumpToDate.ImageTransparentColor = Color.Magenta;
            tsbtnViewJumpToDate.Name = "tsbtnViewJumpToDate";
            tsbtnViewJumpToDate.Size = new Size(23, 22);
            tsbtnViewJumpToDate.Text = "&Jump to Date...";
            tsbtnViewJumpToDate.ToolTipText = "Jump to Specified Date";
            tsbtnViewJumpToDate.Click += tsmnuViewJumpToDate_Click;
            // 
            // tsbtnViewResize
            // 
            tsbtnViewResize.DisplayStyle = ToolStripItemDisplayStyle.Image;
            tsbtnViewResize.Image = Properties.Resources.resize_form3;
            tsbtnViewResize.ImageTransparentColor = Color.Magenta;
            tsbtnViewResize.Name = "tsbtnViewResize";
            tsbtnViewResize.Size = new Size(23, 22);
            tsbtnViewResize.Text = "&Resize...";
            tsbtnViewResize.ToolTipText = "Resize Form to specific Layout";
            tsbtnViewResize.Click += tsmnuViewResize_Click;
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new Size(6, 25);
            // 
            // tsbtnHelpAbout
            // 
            tsbtnHelpAbout.DisplayStyle = ToolStripItemDisplayStyle.Image;
            tsbtnHelpAbout.Image = (Image)resources.GetObject("tsbtnHelpAbout.Image");
            tsbtnHelpAbout.ImageTransparentColor = Color.Magenta;
            tsbtnHelpAbout.Name = "tsbtnHelpAbout";
            tsbtnHelpAbout.Size = new Size(23, 22);
            tsbtnHelpAbout.Text = "toolStripButton1";
            tsbtnHelpAbout.Click += tsmnuHelpAbout_Click;
            // 
            // mcalCalendar
            // 
            mcalCalendar.CalendarDimensions = new Size(3, 1);
            mcalCalendar.Dock = DockStyle.Top;
            mcalCalendar.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            mcalCalendar.Location = new Point(0, 49);
            mcalCalendar.Name = "mcalCalendar";
            mcalCalendar.ShowWeekNumbers = true;
            mcalCalendar.TabIndex = 0;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(753, 438);
            Controls.Add(mcalCalendar);
            Controls.Add(tsMain);
            Controls.Add(ssMain);
            Controls.Add(msMain);
            Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            Icon = (Icon)resources.GetObject("$this.Icon");
            KeyPreview = true;
            MainMenuStrip = msMain;
            Name = "MainForm";
            StartPosition = FormStartPosition.Manual;
            Text = "Main Form";
            Load += MainForm_Load;
            KeyPress += MainForm_KeyPress;
            msMain.ResumeLayout(false);
            msMain.PerformLayout();
            ssMain.ResumeLayout(false);
            ssMain.PerformLayout();
            tsMain.ResumeLayout(false);
            tsMain.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip msMain;
        private ToolStripMenuItem tsmnuFile;
        private ToolStripMenuItem tsmnuFileExit;
        private ToolStripMenuItem tsmnuHelp;
        private ToolStripMenuItem tsmnuHelpAbout;
        private StatusStrip ssMain;
        private ToolStrip tsMain;
        private ToolStripButton tsbtnFileExit;
        private MonthCalendar mcalCalendar;
        private ToolStripStatusLabel tslblInfo;
        private ToolStripStatusLabel tslblSelectedDaysRange;
        private ToolStripSeparator tssep1;
        private ToolStripButton tsbtnHelpAbout;
        private ToolStripStatusLabel tslblCalendarSetName;
        private ToolStripStatusLabel tslblSelectedDatesDescriptions;
        private ToolStripStatusLabel tslblSelectedDaysCount;
        private ToolStripMenuItem tsmnuView;
        private ToolStripMenuItem tsmnuViewToday;
        private ToolStripMenuItem tsmnuViewJumpToDate;
        private ToolStripMenuItem tsmnuViewResize;
        private ToolStripButton tsbtnViewToday;
        private ToolStripButton tsbtnViewJumpToDate;
        private ToolStripButton tsbtnViewResize;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripMenuItem tsmnuEdit;
        private ToolStripMenuItem tsmnuEditCalendar;
        private ToolStripSeparator toolStripSeparator3;
        private ToolStripMenuItem tsmnuEditProgramOptions;
        private ToolStripButton tsbtnEditProgramOptions;
        private ToolStripSeparator toolStripSeparator2;
        private ToolStripButton tsbtnEditCalendar;
        private ToolStripSeparator toolStripSeparator4;
        private ToolStripMenuItem tsmnuHelpUsageGuide;
        private ToolStripSeparator toolStripSeparator5;
    }
}