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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.msMain = new System.Windows.Forms.MenuStrip();
            this.tsmnuFile = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmnuFileExit = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmnuEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmnuEditCalendar = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmnuEditProgramOptions = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmnuView = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmnuViewToday = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmnuViewJumpToDate = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmnuViewResize = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmnuHelp = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmnuHelpUsageGuide = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmnuHelpAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.ssMain = new System.Windows.Forms.StatusStrip();
            this.tslblInfo = new System.Windows.Forms.ToolStripStatusLabel();
            this.tslblSelectedDatesDescriptions = new System.Windows.Forms.ToolStripStatusLabel();
            this.tslblSelectedDaysCount = new System.Windows.Forms.ToolStripStatusLabel();
            this.tslblSelectedDaysRange = new System.Windows.Forms.ToolStripStatusLabel();
            this.tslblCalendarSetName = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsMain = new System.Windows.Forms.ToolStrip();
            this.tsbtnFileExit = new System.Windows.Forms.ToolStripButton();
            this.tssep1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbtnEditProgramOptions = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbtnEditCalendar = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbtnViewToday = new System.Windows.Forms.ToolStripButton();
            this.tsbtnViewJumpToDate = new System.Windows.Forms.ToolStripButton();
            this.tsbtnViewResize = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbtnHelpAbout = new System.Windows.Forms.ToolStripButton();
            this.mcalCalendar = new System.Windows.Forms.MonthCalendar();
            this.msMain.SuspendLayout();
            this.ssMain.SuspendLayout();
            this.tsMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // msMain
            // 
            this.msMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmnuFile,
            this.tsmnuEdit,
            this.tsmnuView,
            this.tsmnuHelp});
            this.msMain.Location = new System.Drawing.Point(0, 0);
            this.msMain.Name = "msMain";
            this.msMain.Size = new System.Drawing.Size(753, 24);
            this.msMain.TabIndex = 0;
            this.msMain.Text = "menuStrip1";
            // 
            // tsmnuFile
            // 
            this.tsmnuFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmnuFileExit});
            this.tsmnuFile.Name = "tsmnuFile";
            this.tsmnuFile.Size = new System.Drawing.Size(37, 20);
            this.tsmnuFile.Text = "&File";
            // 
            // tsmnuFileExit
            // 
            this.tsmnuFileExit.Image = global::QuickCalendar.Properties.Resources.exit4;
            this.tsmnuFileExit.Name = "tsmnuFileExit";
            this.tsmnuFileExit.Size = new System.Drawing.Size(93, 22);
            this.tsmnuFileExit.Text = "E&xit";
            this.tsmnuFileExit.ToolTipText = "Exit Application";
            this.tsmnuFileExit.Click += new System.EventHandler(this.tsmnuFileExit_Click);
            // 
            // tsmnuEdit
            // 
            this.tsmnuEdit.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmnuEditCalendar,
            this.toolStripSeparator3,
            this.tsmnuEditProgramOptions});
            this.tsmnuEdit.Name = "tsmnuEdit";
            this.tsmnuEdit.Size = new System.Drawing.Size(39, 20);
            this.tsmnuEdit.Text = "&Edit";
            // 
            // tsmnuEditCalendar
            // 
            this.tsmnuEditCalendar.Image = global::QuickCalendar.Properties.Resources.edit_calendar1;
            this.tsmnuEditCalendar.Name = "tsmnuEditCalendar";
            this.tsmnuEditCalendar.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.E)));
            this.tsmnuEditCalendar.Size = new System.Drawing.Size(217, 22);
            this.tsmnuEditCalendar.Text = "Cal&endar...";
            this.tsmnuEditCalendar.ToolTipText = "View and Change the settings for this Calendar";
            this.tsmnuEditCalendar.Click += new System.EventHandler(this.tsmnuEditCalendar_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(214, 6);
            // 
            // tsmnuEditProgramOptions
            // 
            this.tsmnuEditProgramOptions.Image = global::QuickCalendar.Properties.Resources.settings3;
            this.tsmnuEditProgramOptions.Name = "tsmnuEditProgramOptions";
            this.tsmnuEditProgramOptions.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.tsmnuEditProgramOptions.Size = new System.Drawing.Size(217, 22);
            this.tsmnuEditProgramOptions.Text = "Program &Options...";
            this.tsmnuEditProgramOptions.Click += new System.EventHandler(this.tsmnuEditProgramOptions_Click);
            // 
            // tsmnuView
            // 
            this.tsmnuView.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmnuViewToday,
            this.tsmnuViewJumpToDate,
            this.tsmnuViewResize});
            this.tsmnuView.Name = "tsmnuView";
            this.tsmnuView.Size = new System.Drawing.Size(44, 20);
            this.tsmnuView.Text = "&View";
            // 
            // tsmnuViewToday
            // 
            this.tsmnuViewToday.Image = global::QuickCalendar.Properties.Resources.jump_today1;
            this.tsmnuViewToday.Name = "tsmnuViewToday";
            this.tsmnuViewToday.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.T)));
            this.tsmnuViewToday.Size = new System.Drawing.Size(191, 22);
            this.tsmnuViewToday.Text = "&Today";
            this.tsmnuViewToday.ToolTipText = "Jump to Today";
            this.tsmnuViewToday.Click += new System.EventHandler(this.tsmnuViewToday_Click);
            // 
            // tsmnuViewJumpToDate
            // 
            this.tsmnuViewJumpToDate.Image = global::QuickCalendar.Properties.Resources.jump_date1;
            this.tsmnuViewJumpToDate.Name = "tsmnuViewJumpToDate";
            this.tsmnuViewJumpToDate.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.J)));
            this.tsmnuViewJumpToDate.Size = new System.Drawing.Size(191, 22);
            this.tsmnuViewJumpToDate.Text = "&Jump to Date...";
            this.tsmnuViewJumpToDate.ToolTipText = "Jump to Specified Date";
            this.tsmnuViewJumpToDate.Click += new System.EventHandler(this.tsmnuViewJumpToDate_Click);
            // 
            // tsmnuViewResize
            // 
            this.tsmnuViewResize.Image = global::QuickCalendar.Properties.Resources.resize_form3;
            this.tsmnuViewResize.Name = "tsmnuViewResize";
            this.tsmnuViewResize.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.R)));
            this.tsmnuViewResize.Size = new System.Drawing.Size(191, 22);
            this.tsmnuViewResize.Text = "&Resize...";
            this.tsmnuViewResize.ToolTipText = "Resize Form to specific Layout";
            this.tsmnuViewResize.Click += new System.EventHandler(this.tsmnuViewResize_Click);
            // 
            // tsmnuHelp
            // 
            this.tsmnuHelp.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmnuHelpUsageGuide,
            this.toolStripSeparator5,
            this.tsmnuHelpAbout});
            this.tsmnuHelp.Name = "tsmnuHelp";
            this.tsmnuHelp.Size = new System.Drawing.Size(44, 20);
            this.tsmnuHelp.Text = "&Help";
            // 
            // tsmnuHelpUsageGuide
            // 
            this.tsmnuHelpUsageGuide.Image = global::QuickCalendar.Properties.Resources.usage_guide1;
            this.tsmnuHelpUsageGuide.Name = "tsmnuHelpUsageGuide";
            this.tsmnuHelpUsageGuide.Size = new System.Drawing.Size(149, 22);
            this.tsmnuHelpUsageGuide.Text = "Usage Guide...";
            this.tsmnuHelpUsageGuide.Click += new System.EventHandler(this.tsmnuHelpUsageGuide_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(146, 6);
            // 
            // tsmnuHelpAbout
            // 
            this.tsmnuHelpAbout.Image = global::QuickCalendar.Properties.Resources.about1;
            this.tsmnuHelpAbout.Name = "tsmnuHelpAbout";
            this.tsmnuHelpAbout.Size = new System.Drawing.Size(149, 22);
            this.tsmnuHelpAbout.Text = "&About...";
            this.tsmnuHelpAbout.ToolTipText = "Show Application Details";
            this.tsmnuHelpAbout.Click += new System.EventHandler(this.tsmnuHelpAbout_Click);
            // 
            // ssMain
            // 
            this.ssMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tslblInfo,
            this.tslblSelectedDatesDescriptions,
            this.tslblSelectedDaysCount,
            this.tslblSelectedDaysRange,
            this.tslblCalendarSetName});
            this.ssMain.Location = new System.Drawing.Point(0, 416);
            this.ssMain.Name = "ssMain";
            this.ssMain.ShowItemToolTips = true;
            this.ssMain.Size = new System.Drawing.Size(753, 22);
            this.ssMain.TabIndex = 1;
            this.ssMain.Text = "statusStrip1";
            // 
            // tslblInfo
            // 
            this.tslblInfo.Name = "tslblInfo";
            this.tslblInfo.Size = new System.Drawing.Size(410, 17);
            this.tslblInfo.Spring = true;
            this.tslblInfo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tslblSelectedDatesDescriptions
            // 
            this.tslblSelectedDatesDescriptions.ForeColor = System.Drawing.SystemColors.Highlight;
            this.tslblSelectedDatesDescriptions.Name = "tslblSelectedDatesDescriptions";
            this.tslblSelectedDatesDescriptions.Size = new System.Drawing.Size(94, 17);
            this.tslblSelectedDatesDescriptions.Text = "Date Description";
            // 
            // tslblSelectedDaysCount
            // 
            this.tslblSelectedDaysCount.Name = "tslblSelectedDaysCount";
            this.tslblSelectedDaysCount.Size = new System.Drawing.Size(115, 17);
            this.tslblSelectedDaysCount.Text = "Selected Days Range";
            // 
            // tslblSelectedDaysRange
            // 
            this.tslblSelectedDaysRange.Name = "tslblSelectedDaysRange";
            this.tslblSelectedDaysRange.Size = new System.Drawing.Size(74, 17);
            this.tslblSelectedDaysRange.Text = "Selected Day";
            this.tslblSelectedDaysRange.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tslblCalendarSetName
            // 
            this.tslblCalendarSetName.Name = "tslblCalendarSetName";
            this.tslblCalendarSetName.Size = new System.Drawing.Size(45, 17);
            this.tslblCalendarSetName.Text = "Default";
            // 
            // tsMain
            // 
            this.tsMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbtnFileExit,
            this.tssep1,
            this.tsbtnEditProgramOptions,
            this.toolStripSeparator2,
            this.tsbtnEditCalendar,
            this.toolStripSeparator4,
            this.tsbtnViewToday,
            this.tsbtnViewJumpToDate,
            this.tsbtnViewResize,
            this.toolStripSeparator1,
            this.tsbtnHelpAbout});
            this.tsMain.Location = new System.Drawing.Point(0, 24);
            this.tsMain.Name = "tsMain";
            this.tsMain.Size = new System.Drawing.Size(753, 25);
            this.tsMain.TabIndex = 1;
            this.tsMain.Text = "tsMain";
            // 
            // tsbtnFileExit
            // 
            this.tsbtnFileExit.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbtnFileExit.Image = global::QuickCalendar.Properties.Resources.exit4;
            this.tsbtnFileExit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnFileExit.Name = "tsbtnFileExit";
            this.tsbtnFileExit.Size = new System.Drawing.Size(23, 22);
            this.tsbtnFileExit.Text = "Exit";
            this.tsbtnFileExit.ToolTipText = "Exit Application";
            this.tsbtnFileExit.Click += new System.EventHandler(this.tsmnuFileExit_Click);
            // 
            // tssep1
            // 
            this.tssep1.Name = "tssep1";
            this.tssep1.Size = new System.Drawing.Size(6, 25);
            // 
            // tsbtnEditProgramOptions
            // 
            this.tsbtnEditProgramOptions.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbtnEditProgramOptions.Image = global::QuickCalendar.Properties.Resources.settings3;
            this.tsbtnEditProgramOptions.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnEditProgramOptions.Name = "tsbtnEditProgramOptions";
            this.tsbtnEditProgramOptions.Size = new System.Drawing.Size(23, 22);
            this.tsbtnEditProgramOptions.Text = "Program Options and Settings";
            this.tsbtnEditProgramOptions.Click += new System.EventHandler(this.tsmnuEditProgramOptions_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // tsbtnEditCalendar
            // 
            this.tsbtnEditCalendar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbtnEditCalendar.Image = global::QuickCalendar.Properties.Resources.edit_calendar1;
            this.tsbtnEditCalendar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnEditCalendar.Name = "tsbtnEditCalendar";
            this.tsbtnEditCalendar.Size = new System.Drawing.Size(23, 22);
            this.tsbtnEditCalendar.Text = "toolStripButton1";
            this.tsbtnEditCalendar.Click += new System.EventHandler(this.tsmnuEditCalendar_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 25);
            // 
            // tsbtnViewToday
            // 
            this.tsbtnViewToday.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbtnViewToday.Image = global::QuickCalendar.Properties.Resources.jump_today1;
            this.tsbtnViewToday.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnViewToday.Name = "tsbtnViewToday";
            this.tsbtnViewToday.Size = new System.Drawing.Size(23, 22);
            this.tsbtnViewToday.Text = "&Today";
            this.tsbtnViewToday.ToolTipText = "Jump to Today";
            this.tsbtnViewToday.Click += new System.EventHandler(this.tsmnuViewToday_Click);
            // 
            // tsbtnViewJumpToDate
            // 
            this.tsbtnViewJumpToDate.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbtnViewJumpToDate.Image = global::QuickCalendar.Properties.Resources.jump_date1;
            this.tsbtnViewJumpToDate.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnViewJumpToDate.Name = "tsbtnViewJumpToDate";
            this.tsbtnViewJumpToDate.Size = new System.Drawing.Size(23, 22);
            this.tsbtnViewJumpToDate.Text = "&Jump to Date...";
            this.tsbtnViewJumpToDate.ToolTipText = "Jump to Specified Date";
            this.tsbtnViewJumpToDate.Click += new System.EventHandler(this.tsmnuViewJumpToDate_Click);
            // 
            // tsbtnViewResize
            // 
            this.tsbtnViewResize.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbtnViewResize.Image = global::QuickCalendar.Properties.Resources.resize_form3;
            this.tsbtnViewResize.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnViewResize.Name = "tsbtnViewResize";
            this.tsbtnViewResize.Size = new System.Drawing.Size(23, 22);
            this.tsbtnViewResize.Text = "&Resize...";
            this.tsbtnViewResize.ToolTipText = "Resize Form to specific Layout";
            this.tsbtnViewResize.Click += new System.EventHandler(this.tsmnuViewResize_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // tsbtnHelpAbout
            // 
            this.tsbtnHelpAbout.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbtnHelpAbout.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnHelpAbout.Image")));
            this.tsbtnHelpAbout.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnHelpAbout.Name = "tsbtnHelpAbout";
            this.tsbtnHelpAbout.Size = new System.Drawing.Size(23, 22);
            this.tsbtnHelpAbout.Text = "toolStripButton1";
            this.tsbtnHelpAbout.Click += new System.EventHandler(this.tsmnuHelpAbout_Click);
            // 
            // mcalCalendar
            // 
            this.mcalCalendar.CalendarDimensions = new System.Drawing.Size(3, 1);
            this.mcalCalendar.Dock = System.Windows.Forms.DockStyle.Top;
            this.mcalCalendar.Location = new System.Drawing.Point(0, 49);
            this.mcalCalendar.Name = "mcalCalendar";
            this.mcalCalendar.ShowWeekNumbers = true;
            this.mcalCalendar.TabIndex = 0;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(753, 438);
            this.Controls.Add(this.mcalCalendar);
            this.Controls.Add(this.tsMain);
            this.Controls.Add(this.ssMain);
            this.Controls.Add(this.msMain);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MainMenuStrip = this.msMain;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Main Form";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.MainForm_KeyPress);
            this.msMain.ResumeLayout(false);
            this.msMain.PerformLayout();
            this.ssMain.ResumeLayout(false);
            this.ssMain.PerformLayout();
            this.tsMain.ResumeLayout(false);
            this.tsMain.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

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