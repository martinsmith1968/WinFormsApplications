namespace QuickCalendar.UserControls
{
    partial class CalendarSetViewer
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.mcalCalendar = new System.Windows.Forms.MonthCalendar();
            this.SuspendLayout();
            // 
            // mcalCalendar
            // 
            this.mcalCalendar.Dock = System.Windows.Forms.DockStyle.Top;
            this.mcalCalendar.Location = new System.Drawing.Point(0, 0);
            this.mcalCalendar.Name = "mcalCalendar";
            this.mcalCalendar.TabIndex = 0;
            // 
            // CalendarSetViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.mcalCalendar);
            this.Name = "CalendarSetViewer";
            this.Size = new System.Drawing.Size(230, 205);
            this.Load += new System.EventHandler(this.CalendarSetViewer_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private MonthCalendar mcalCalendar;
    }
}
