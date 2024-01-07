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
            components = new System.ComponentModel.Container();
            var resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            msMain = new MenuStrip();
            tsmnuFile = new ToolStripMenuItem();
            tsmnuFileOpen = new ToolStripMenuItem();
            tsmnuFileSave = new ToolStripMenuItem();
            tsmnuFileSaveAs = new ToolStripMenuItem();
            toolStripSeparator9 = new ToolStripSeparator();
            tsmnuFileProgramOptions = new ToolStripMenuItem();
            toolStripSeparator8 = new ToolStripSeparator();
            tsmnuFileExit = new ToolStripMenuItem();
            tsmnuEdit = new ToolStripMenuItem();
            tsmnuEditCalendar = new ToolStripMenuItem();
            tsmnuView = new ToolStripMenuItem();
            tsmnuViewToday = new ToolStripMenuItem();
            toolStripSeparator12 = new ToolStripSeparator();
            tsmnuViewJumpToDate = new ToolStripMenuItem();
            toolStripSeparator11 = new ToolStripSeparator();
            tsmnuViewJumpToPreviousMarkedDate = new ToolStripMenuItem();
            tsmnuViewJumpToNextMarkedDate = new ToolStripMenuItem();
            toolStripSeparator14 = new ToolStripSeparator();
            tsmnuViewSelectToPreviousMarkedDate = new ToolStripMenuItem();
            tsmnuViewSelectToNextMarkedDate = new ToolStripMenuItem();
            toolStripSeparator7 = new ToolStripSeparator();
            tsmnuViewResetFirstVisibleMonth = new ToolStripMenuItem();
            toolStripSeparator15 = new ToolStripSeparator();
            tsmnuViewResize = new ToolStripMenuItem();
            tsmnuHelp = new ToolStripMenuItem();
            tsmnuHelpUsageGuide = new ToolStripMenuItem();
            toolStripSeparator5 = new ToolStripSeparator();
            tsmnuHelpAbout = new ToolStripMenuItem();
            ssMain = new StatusStrip();
            tslblInfo = new ToolStripStatusLabel();
            tslblFileName = new ToolStripStatusLabel();
            tslblSelectedDatesDescriptions = new ToolStripStatusLabel();
            tslblSelectedDaysCount = new ToolStripStatusLabel();
            tslblSelectedDaysRange = new ToolStripStatusLabel();
            tslblCalendarSetName = new ToolStripStatusLabel();
            tsMain = new ToolStrip();
            tsbtnFileExit = new ToolStripButton();
            toolStripSeparator10 = new ToolStripSeparator();
            tsbtnFileOpen = new ToolStripButton();
            tsbtnFileSave = new ToolStripButton();
            tssep1 = new ToolStripSeparator();
            tsbtnEditCalendar = new ToolStripButton();
            toolStripSeparator4 = new ToolStripSeparator();
            tsbtnViewToday = new ToolStripButton();
            tsbtnViewJumpToDate = new ToolStripButton();
            toolStripSeparator13 = new ToolStripSeparator();
            tsbtnViewJumpToPreviousMarkedDate = new ToolStripButton();
            tsbtnViewJumpToNextMarkedDate = new ToolStripButton();
            toolStripSeparator6 = new ToolStripSeparator();
            tsbtnViewResetFirstVisibleMonth = new ToolStripButton();
            tsbtnViewResize = new ToolStripButton();
            toolStripSeparator1 = new ToolStripSeparator();
            tsbtnFileProgramOptions = new ToolStripButton();
            toolStripSeparator2 = new ToolStripSeparator();
            tsbtnHelpAbout = new ToolStripButton();
            mcalCalendar = new MonthCalendar();
            dlgOpenFile = new OpenFileDialog();
            dlgSaveFile = new SaveFileDialog();
            tmrResetStatusBar = new System.Windows.Forms.Timer(components);
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
            tsmnuFile.DropDownItems.AddRange(new ToolStripItem[] { tsmnuFileOpen, tsmnuFileSave, tsmnuFileSaveAs, toolStripSeparator9, tsmnuFileProgramOptions, toolStripSeparator8, tsmnuFileExit });
            tsmnuFile.Name = "tsmnuFile";
            tsmnuFile.Size = new Size(37, 20);
            tsmnuFile.Text = "&File";
            //
            // tsmnuFileOpen
            //
            tsmnuFileOpen.Image = Properties.Resources.open_file_40455_24;
            tsmnuFileOpen.Name = "tsmnuFileOpen";
            tsmnuFileOpen.ShortcutKeys = Keys.Control | Keys.O;
            tsmnuFileOpen.Size = new Size(226, 22);
            tsmnuFileOpen.Text = "&Open...";
            tsmnuFileOpen.ToolTipText = "Open a Calendar";
            tsmnuFileOpen.Click += tsmnuFileOpen_Click;
            //
            // tsmnuFileSave
            //
            tsmnuFileSave.Image = Properties.Resources.Save_37110_24;
            tsmnuFileSave.Name = "tsmnuFileSave";
            tsmnuFileSave.ShortcutKeys = Keys.Control | Keys.S;
            tsmnuFileSave.Size = new Size(226, 22);
            tsmnuFileSave.Text = "&Save";
            tsmnuFileSave.ToolTipText = "Save the current Calendar";
            tsmnuFileSave.Click += tsmnuFileSave_Click;
            //
            // tsmnuFileSaveAs
            //
            tsmnuFileSaveAs.Name = "tsmnuFileSaveAs";
            tsmnuFileSaveAs.ShortcutKeys = Keys.Control | Keys.Shift | Keys.S;
            tsmnuFileSaveAs.Size = new Size(226, 22);
            tsmnuFileSaveAs.Text = "Save &As...";
            tsmnuFileSaveAs.ToolTipText = "Save the current Calendar, under a new File name";
            tsmnuFileSaveAs.Click += tsmnuFileSaveAs_Click;
            //
            // toolStripSeparator9
            //
            toolStripSeparator9.Name = "toolStripSeparator9";
            toolStripSeparator9.Size = new Size(223, 6);
            //
            // tsmnuFileProgramOptions
            //
            tsmnuFileProgramOptions.Image = Properties.Resources.settings3;
            tsmnuFileProgramOptions.Name = "tsmnuFileProgramOptions";
            tsmnuFileProgramOptions.ShortcutKeys = Keys.Control | Keys.F12;
            tsmnuFileProgramOptions.Size = new Size(226, 22);
            tsmnuFileProgramOptions.Text = "Program &Options...";
            tsmnuFileProgramOptions.ToolTipText = "Program Options and Settings";
            tsmnuFileProgramOptions.Click += tsmnuFileProgramOptions_Click;
            //
            // toolStripSeparator8
            //
            toolStripSeparator8.Name = "toolStripSeparator8";
            toolStripSeparator8.Size = new Size(223, 6);
            //
            // tsmnuFileExit
            //
            tsmnuFileExit.Image = Properties.Resources.exit4;
            tsmnuFileExit.Name = "tsmnuFileExit";
            tsmnuFileExit.Size = new Size(226, 22);
            tsmnuFileExit.Text = "E&xit";
            tsmnuFileExit.ToolTipText = "Exit Application";
            tsmnuFileExit.Click += tsmnuFileExit_Click;
            //
            // tsmnuEdit
            //
            tsmnuEdit.DropDownItems.AddRange(new ToolStripItem[] { tsmnuEditCalendar });
            tsmnuEdit.Name = "tsmnuEdit";
            tsmnuEdit.Size = new Size(39, 20);
            tsmnuEdit.Text = "&Edit";
            //
            // tsmnuEditCalendar
            //
            tsmnuEditCalendar.Image = Properties.Resources.edit_calendar1;
            tsmnuEditCalendar.Name = "tsmnuEditCalendar";
            tsmnuEditCalendar.ShortcutKeys = Keys.Control | Keys.E;
            tsmnuEditCalendar.Size = new Size(180, 22);
            tsmnuEditCalendar.Text = "Cal&endar...";
            tsmnuEditCalendar.ToolTipText = "View and Change the settings for this Calendar";
            tsmnuEditCalendar.Click += tsmnuEditCalendar_Click;
            //
            // tsmnuView
            //
            tsmnuView.DropDownItems.AddRange(new ToolStripItem[] { tsmnuViewToday, toolStripSeparator12, tsmnuViewJumpToDate, toolStripSeparator11, tsmnuViewJumpToPreviousMarkedDate, tsmnuViewJumpToNextMarkedDate, toolStripSeparator14, tsmnuViewSelectToPreviousMarkedDate, tsmnuViewSelectToNextMarkedDate, toolStripSeparator7, tsmnuViewResetFirstVisibleMonth, toolStripSeparator15, tsmnuViewResize });
            tsmnuView.Name = "tsmnuView";
            tsmnuView.Size = new Size(44, 20);
            tsmnuView.Text = "&View";
            //
            // tsmnuViewToday
            //
            tsmnuViewToday.Image = Properties.Resources.jump_today1;
            tsmnuViewToday.Name = "tsmnuViewToday";
            tsmnuViewToday.Size = new Size(268, 22);
            tsmnuViewToday.Text = "&Today";
            tsmnuViewToday.ToolTipText = "Jump to Today";
            tsmnuViewToday.Click += tsmnuViewToday_Click;
            //
            // toolStripSeparator12
            //
            toolStripSeparator12.Name = "toolStripSeparator12";
            toolStripSeparator12.Size = new Size(265, 6);
            //
            // tsmnuViewJumpToDate
            //
            tsmnuViewJumpToDate.Image = Properties.Resources.jump_date1;
            tsmnuViewJumpToDate.Name = "tsmnuViewJumpToDate";
            tsmnuViewJumpToDate.ShortcutKeys = Keys.Control | Keys.J;
            tsmnuViewJumpToDate.Size = new Size(268, 22);
            tsmnuViewJumpToDate.Text = "&Jump to Date...";
            tsmnuViewJumpToDate.ToolTipText = "Jump to Specified Date";
            tsmnuViewJumpToDate.Click += tsmnuViewJumpToDate_Click;
            //
            // toolStripSeparator11
            //
            toolStripSeparator11.Name = "toolStripSeparator11";
            toolStripSeparator11.Size = new Size(265, 6);
            //
            // tsmnuViewJumpToPreviousMarkedDate
            //
            tsmnuViewJumpToPreviousMarkedDate.Image = Properties.Resources.previous_marked_date_1;
            tsmnuViewJumpToPreviousMarkedDate.Name = "tsmnuViewJumpToPreviousMarkedDate";
            tsmnuViewJumpToPreviousMarkedDate.Size = new Size(268, 22);
            tsmnuViewJumpToPreviousMarkedDate.Text = "Jump to &Previous Marked Date";
            tsmnuViewJumpToPreviousMarkedDate.ToolTipText = "Jump to Previous Marked Date";
            tsmnuViewJumpToPreviousMarkedDate.Click += tsmnuViewJumpToPreviousMarkedDate_Click;
            //
            // tsmnuViewJumpToNextMarkedDate
            //
            tsmnuViewJumpToNextMarkedDate.Image = Properties.Resources.next_marked_date_1;
            tsmnuViewJumpToNextMarkedDate.Name = "tsmnuViewJumpToNextMarkedDate";
            tsmnuViewJumpToNextMarkedDate.Size = new Size(268, 22);
            tsmnuViewJumpToNextMarkedDate.Text = "Jump to &Next Marked Date";
            tsmnuViewJumpToNextMarkedDate.ToolTipText = "Jump to Next Marked Date";
            tsmnuViewJumpToNextMarkedDate.Click += tsmnuViewJumpToNextMarkedDate_Click;
            //
            // toolStripSeparator14
            //
            toolStripSeparator14.Name = "toolStripSeparator14";
            toolStripSeparator14.Size = new Size(265, 6);
            //
            // tsmnuViewSelectToPreviousMarkedDate
            //
            tsmnuViewSelectToPreviousMarkedDate.Name = "tsmnuViewSelectToPreviousMarkedDate";
            tsmnuViewSelectToPreviousMarkedDate.Size = new Size(268, 22);
            tsmnuViewSelectToPreviousMarkedDate.Text = "Select to Pre&vious Marked Date";
            tsmnuViewSelectToPreviousMarkedDate.ToolTipText = "Extend selection back to previous marked date";
            tsmnuViewSelectToPreviousMarkedDate.Click += tsmnuViewSelectToPreviousMarkedDate_Click;
            //
            // tsmnuViewSelectToNextMarkedDate
            //
            tsmnuViewSelectToNextMarkedDate.Name = "tsmnuViewSelectToNextMarkedDate";
            tsmnuViewSelectToNextMarkedDate.Size = new Size(268, 22);
            tsmnuViewSelectToNextMarkedDate.Text = "Select to Ne&xt Marked Date";
            tsmnuViewSelectToNextMarkedDate.ToolTipText = "Extend selection to next marked date";
            tsmnuViewSelectToNextMarkedDate.Click += tsmnuViewSelectToNextMarkedDate_Click;
            //
            // toolStripSeparator7
            //
            toolStripSeparator7.Name = "toolStripSeparator7";
            toolStripSeparator7.Size = new Size(265, 6);
            //
            // tsmnuViewResetFirstVisibleMonth
            //
            tsmnuViewResetFirstVisibleMonth.Image = Properties.Resources.go_first_view_24;
            tsmnuViewResetFirstVisibleMonth.Name = "tsmnuViewResetFirstVisibleMonth";
            tsmnuViewResetFirstVisibleMonth.ShortcutKeyDisplayString = "";
            tsmnuViewResetFirstVisibleMonth.ShortcutKeys = Keys.Control | Keys.Space;
            tsmnuViewResetFirstVisibleMonth.Size = new Size(268, 22);
            tsmnuViewResetFirstVisibleMonth.Text = "Reset &First Visible Month";
            tsmnuViewResetFirstVisibleMonth.ToolTipText = "Reset Calendar to show the specifed First Visible Month";
            tsmnuViewResetFirstVisibleMonth.Click += tsmnuViewResetFirstVisibleMonth_Click;
            //
            // toolStripSeparator15
            //
            toolStripSeparator15.Name = "toolStripSeparator15";
            toolStripSeparator15.Size = new Size(265, 6);
            //
            // tsmnuViewResize
            //
            tsmnuViewResize.Image = Properties.Resources.resize_form3;
            tsmnuViewResize.Name = "tsmnuViewResize";
            tsmnuViewResize.ShortcutKeys = Keys.Control | Keys.R;
            tsmnuViewResize.Size = new Size(268, 22);
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
            tsmnuHelpUsageGuide.Size = new Size(162, 22);
            tsmnuHelpUsageGuide.Text = "Usage Guide...";
            tsmnuHelpUsageGuide.ToolTipText = "View the online Guide";
            tsmnuHelpUsageGuide.Click += tsmnuHelpUsageGuide_Click;
            //
            // toolStripSeparator5
            //
            toolStripSeparator5.Name = "toolStripSeparator5";
            toolStripSeparator5.Size = new Size(159, 6);
            //
            // tsmnuHelpAbout
            //
            tsmnuHelpAbout.Image = Properties.Resources.about1;
            tsmnuHelpAbout.Name = "tsmnuHelpAbout";
            tsmnuHelpAbout.ShortcutKeys = Keys.Control | Keys.F1;
            tsmnuHelpAbout.Size = new Size(162, 22);
            tsmnuHelpAbout.Text = "&About...";
            tsmnuHelpAbout.ToolTipText = "Show Application Details";
            tsmnuHelpAbout.Click += tsmnuHelpAbout_Click;
            //
            // ssMain
            //
            ssMain.Items.AddRange(new ToolStripItem[] { tslblInfo, tslblFileName, tslblSelectedDatesDescriptions, tslblSelectedDaysCount, tslblSelectedDaysRange, tslblCalendarSetName });
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
            tslblInfo.Size = new Size(350, 17);
            tslblInfo.Spring = true;
            tslblInfo.TextAlign = ContentAlignment.MiddleLeft;
            //
            // tslblFileName
            //
            tslblFileName.Name = "tslblFileName";
            tslblFileName.Size = new Size(60, 17);
            tslblFileName.Text = "File Name";
            tslblFileName.ToolTipText = "Calendar File Name";
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
            tsMain.Items.AddRange(new ToolStripItem[] { tsbtnFileExit, toolStripSeparator10, tsbtnFileOpen, tsbtnFileSave, tssep1, tsbtnEditCalendar, toolStripSeparator4, tsbtnViewToday, tsbtnViewJumpToDate, toolStripSeparator13, tsbtnViewJumpToPreviousMarkedDate, tsbtnViewJumpToNextMarkedDate, toolStripSeparator6, tsbtnViewResetFirstVisibleMonth, tsbtnViewResize, toolStripSeparator1, tsbtnFileProgramOptions, toolStripSeparator2, tsbtnHelpAbout });
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
            tsbtnFileExit.Click += tsmnuFileExit_Click;
            //
            // toolStripSeparator10
            //
            toolStripSeparator10.Name = "toolStripSeparator10";
            toolStripSeparator10.Size = new Size(6, 25);
            //
            // tsbtnFileOpen
            //
            tsbtnFileOpen.DisplayStyle = ToolStripItemDisplayStyle.Image;
            tsbtnFileOpen.Image = Properties.Resources.open_file_40455_24;
            tsbtnFileOpen.ImageTransparentColor = Color.Magenta;
            tsbtnFileOpen.Name = "tsbtnFileOpen";
            tsbtnFileOpen.Size = new Size(23, 22);
            tsbtnFileOpen.Text = "&Open...";
            tsbtnFileOpen.Click += tsmnuFileOpen_Click;
            //
            // tsbtnFileSave
            //
            tsbtnFileSave.DisplayStyle = ToolStripItemDisplayStyle.Image;
            tsbtnFileSave.Image = Properties.Resources.Save_37110_24;
            tsbtnFileSave.ImageTransparentColor = Color.Magenta;
            tsbtnFileSave.Name = "tsbtnFileSave";
            tsbtnFileSave.Size = new Size(23, 22);
            tsbtnFileSave.Text = "toolStripButton2";
            tsbtnFileSave.Click += tsmnuFileSave_Click;
            //
            // tssep1
            //
            tssep1.Name = "tssep1";
            tssep1.Size = new Size(6, 25);
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
            // toolStripSeparator13
            //
            toolStripSeparator13.Name = "toolStripSeparator13";
            toolStripSeparator13.Size = new Size(6, 25);
            //
            // tsbtnViewJumpToPreviousMarkedDate
            //
            tsbtnViewJumpToPreviousMarkedDate.DisplayStyle = ToolStripItemDisplayStyle.Image;
            tsbtnViewJumpToPreviousMarkedDate.Image = Properties.Resources.previous_marked_date_1;
            tsbtnViewJumpToPreviousMarkedDate.ImageTransparentColor = Color.Magenta;
            tsbtnViewJumpToPreviousMarkedDate.Name = "tsbtnViewJumpToPreviousMarkedDate";
            tsbtnViewJumpToPreviousMarkedDate.Size = new Size(23, 22);
            tsbtnViewJumpToPreviousMarkedDate.Text = "toolStripButton1";
            tsbtnViewJumpToPreviousMarkedDate.ToolTipText = "Jump to Previous Marked Date";
            tsbtnViewJumpToPreviousMarkedDate.Click += tsmnuViewJumpToPreviousMarkedDate_Click;
            //
            // tsbtnViewJumpToNextMarkedDate
            //
            tsbtnViewJumpToNextMarkedDate.DisplayStyle = ToolStripItemDisplayStyle.Image;
            tsbtnViewJumpToNextMarkedDate.Image = Properties.Resources.next_marked_date_1;
            tsbtnViewJumpToNextMarkedDate.ImageTransparentColor = Color.Magenta;
            tsbtnViewJumpToNextMarkedDate.Name = "tsbtnViewJumpToNextMarkedDate";
            tsbtnViewJumpToNextMarkedDate.Size = new Size(23, 22);
            tsbtnViewJumpToNextMarkedDate.Text = "toolStripButton2";
            tsbtnViewJumpToNextMarkedDate.ToolTipText = "Jump to Next Marked Date";
            tsbtnViewJumpToNextMarkedDate.Click += tsmnuViewJumpToNextMarkedDate_Click;
            //
            // toolStripSeparator6
            //
            toolStripSeparator6.Name = "toolStripSeparator6";
            toolStripSeparator6.Size = new Size(6, 25);
            //
            // tsbtnViewResetFirstVisibleMonth
            //
            tsbtnViewResetFirstVisibleMonth.DisplayStyle = ToolStripItemDisplayStyle.Image;
            tsbtnViewResetFirstVisibleMonth.Image = Properties.Resources.go_first_view_24;
            tsbtnViewResetFirstVisibleMonth.ImageTransparentColor = Color.Magenta;
            tsbtnViewResetFirstVisibleMonth.Name = "tsbtnViewResetFirstVisibleMonth";
            tsbtnViewResetFirstVisibleMonth.Size = new Size(23, 22);
            tsbtnViewResetFirstVisibleMonth.Text = "toolStripButton1";
            tsbtnViewResetFirstVisibleMonth.Click += tsmnuViewResetFirstVisibleMonth_Click;
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
            // tsbtnFileProgramOptions
            //
            tsbtnFileProgramOptions.DisplayStyle = ToolStripItemDisplayStyle.Image;
            tsbtnFileProgramOptions.Image = Properties.Resources.settings3;
            tsbtnFileProgramOptions.ImageTransparentColor = Color.Magenta;
            tsbtnFileProgramOptions.Name = "tsbtnFileProgramOptions";
            tsbtnFileProgramOptions.Size = new Size(23, 22);
            tsbtnFileProgramOptions.Click += tsmnuFileProgramOptions_Click;
            //
            // toolStripSeparator2
            //
            toolStripSeparator2.Name = "toolStripSeparator2";
            toolStripSeparator2.Size = new Size(6, 25);
            //
            // tsbtnHelpAbout
            //
            tsbtnHelpAbout.DisplayStyle = ToolStripItemDisplayStyle.Image;
            tsbtnHelpAbout.Image = (Image)resources.GetObject("tsbtnHelpAbout.Image");
            tsbtnHelpAbout.ImageTransparentColor = Color.Magenta;
            tsbtnHelpAbout.Name = "tsbtnHelpAbout";
            tsbtnHelpAbout.Size = new Size(23, 22);
            tsbtnHelpAbout.Text = "&About...";
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
            // tmrResetStatusBar
            //
            tmrResetStatusBar.Tick += tmrResetStatusBar_Tick;
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
        private ToolStripButton tsbtnFileProgramOptions;
        private ToolStripSeparator toolStripSeparator2;
        private ToolStripButton tsbtnEditCalendar;
        private ToolStripSeparator toolStripSeparator4;
        private ToolStripMenuItem tsmnuHelpUsageGuide;
        private ToolStripSeparator toolStripSeparator5;
        private ToolStripMenuItem tsmnuViewJumpToPreviousMarkedDate;
        private ToolStripMenuItem tsmnuViewJumpToNextMarkedDate;
        private ToolStripButton tsbtnViewJumpToPreviousMarkedDate;
        private ToolStripButton tsbtnViewJumpToNextMarkedDate;
        private ToolStripSeparator toolStripSeparator6;
        private ToolStripSeparator toolStripSeparator7;
        private ToolStripMenuItem tsmnuFileProgramOptions;
        private ToolStripSeparator toolStripSeparator8;
        private ToolStripMenuItem tsmnuFileOpen;
        private ToolStripMenuItem tsmnuFileSave;
        private ToolStripMenuItem tsmnuFileSaveAs;
        private ToolStripSeparator toolStripSeparator9;
        private ToolStripSeparator toolStripSeparator10;
        private ToolStripButton tsbtnFileOpen;
        private ToolStripButton tsbtnFileSave;
        private OpenFileDialog dlgOpenFile;
        private SaveFileDialog dlgSaveFile;
        private ToolStripStatusLabel tslblFileName;
        private System.Windows.Forms.Timer tmrResetStatusBar;
        private ToolStripSeparator toolStripSeparator12;
        private ToolStripSeparator toolStripSeparator11;
        private ToolStripSeparator toolStripSeparator14;
        private ToolStripMenuItem tsmnuViewSelectToPreviousMarkedDate;
        private ToolStripMenuItem tsmnuViewSelectToNextMarkedDate;
        private ToolStripSeparator toolStripSeparator13;
        private ToolStripMenuItem tsmnuViewResetFirstVisibleMonth;
        private ToolStripSeparator toolStripSeparator15;
        private ToolStripButton tsbtnViewResetFirstVisibleMonth;
    }
}
