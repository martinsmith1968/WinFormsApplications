namespace Toaster
{
    partial class ToastMessageForm
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
            timRevealer = new System.Windows.Forms.Timer(components);
            timCloser = new System.Windows.Forms.Timer(components);
            SuspendLayout();
            //
            // timRevealer
            //
            timRevealer.Tick += timRevealer_Tick;
            //
            // timCloser
            //
            timCloser.Interval = 5000;
            timCloser.Tick += timCloser_Tick;
            //
            // ToastMessageForm
            //
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(365, 132);
            FormBorderStyle = FormBorderStyle.None;
            Name = "ToastMessageForm";
            StartPosition = FormStartPosition.Manual;
            Load += ToastMessageForm_Load;
            Shown += ToastMessageForm_Shown;
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Timer timRevealer;
        private System.Windows.Forms.Timer timCloser;
    }
}
