using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace TaskbarAlert
{
    public class Alert
    {
        PopupType _Type;
        //TaskbarNotifier _Notifier = new TaskbarNotifier();
        TaskbarNotifier _Notifier = new TaskbarNotifier();
        int _TimeToShow = 250;
        int _TimeToStay = 1500;
        int _TimeToHide = 500;

        public delegate void AlertClosed(object sender, EventArgs args);

        public event AlertClosed OnAlertClosed;

        #region Properties

        public PopupType Type
        {
            get { return _Type; }
            set { _Type = value; }
        }
        public string Title
        {
            get { return _Notifier.TitleText; }
            set { _Notifier.TitleText = value; }
        }
        public string Text
        {
            get { return _Notifier.Text; }
            set { _Notifier.Text = value; }
        }
        public int TimeToShow
        {
            get { return _TimeToShow; }
            set { _TimeToShow = value; }
        }
        public int TimeToStay
        {
            get { return _TimeToStay; }
            set { _TimeToStay = value; }
        }
        public int TimeToHide
        {
            get { return _TimeToHide; }
            set { _TimeToHide = value; }
        }
        public TaskbarNotifier Notifier
        {
            get { return _Notifier; }
        }

        #endregion

        #region Constructor(s)

        public Alert()
        {
        }

        #endregion

        public void Display()
        {
            _Notifier.CloseClick += new EventHandler(_Notifier_CloseClick);
            _Notifier.ContentClick += new EventHandler(_Notifier_ContentClick);
            //_Notifier.TimeOut += new EventHandler(_Notifier_TimeOut);
            _Notifier.OnClosed += new EventHandler(_Notifier_TimeOut);

            _Notifier.FormClosed += new System.Windows.Forms.FormClosedEventHandler(_Notifier_FormClosed);

            _Notifier.Show(_Notifier.TitleText, _Notifier.Text, _TimeToShow, _TimeToStay, _TimeToHide);
        }

        #region Notifier Events

        void _Notifier_FormClosed(object sender, System.Windows.Forms.FormClosedEventArgs e)
        {
            if (OnAlertClosed != null)
                OnAlertClosed(this, EventArgs.Empty);
        }

        void _Notifier_TimeOut(object sender, EventArgs e)
        {
            _Notifier.Close();
        }

        void _Notifier_ContentClick(object sender, EventArgs e)
        {
            PerformAction();

            _Notifier.Hide();
            _Notifier.Close();
        }

        void _Notifier_CloseClick(object sender, EventArgs e)
        {
            _Notifier.Hide();
            _Notifier.Close();
        }

        #endregion

        void PerformAction()
        {
            switch (_Type)
            {
                case PopupType.Email:
                {
                    Process[] apps = Process.GetProcessesByName("Outlook");
                    foreach (Process p in apps)
                    {
                        Util.AppActivate(p);
                    }
                    break;
                }
            }
        }

        #region Static Factory

        /// <summary>
        /// Creates from file.
        /// </summary>
        /// <param name="fileName">Name of the file.</param>
        /// <returns></returns>
        static public Alert CreateFromFile(string fileName)
        {
            FileInfo fi = new FileInfo(fileName);

            if (!fi.Exists)
                throw new Exception(string.Format("File does not exist; {0}", fileName));

            return CreateFromParams(File.ReadAllLines(fi.FullName));
        }

        /// <summary>
        /// Creates from params.
        /// </summary>
        /// <param name="lines">The lines.</param>
        /// <returns></returns>
        static public Alert CreateFromParams(string[] lines)
        {
            Alert alert = new Alert();

            Arguments fakeArgs = new Arguments();

            foreach (string line in lines)
            {
                if (string.IsNullOrEmpty(line))
                    continue;

                string[] bits = line.Split(":".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);

                string paramName  = bits.Length > 0 ? bits[0] : string.Empty;
                string paramValue = bits.Length > 1 ? string.Join(":", bits, 1, bits.Length - 1) : string.Empty;

                if (string.Compare(paramName, "Type", true) == 0)
                {
                    PopupType type = (PopupType)(Enum.Parse(typeof(PopupType), paramValue));

                    fakeArgs.Type = type;
                    alert = Create(type, fakeArgs);
                }
                else if (string.Compare(paramName, "Title", true) == 0)
                {
                    fakeArgs.Title = paramValue;
                    alert.Title    = fakeArgs.Title;
                }
                else if (string.Compare(paramName, "Text", true) == 0)
                {
                    fakeArgs.Text = paramValue;
                    alert.Text    = fakeArgs.Text;
                }
                else if (string.Compare(paramName, "BackgroundImage", true) == 0)
                {
                    alert.Notifier.SetBackgroundBitmap(Image.FromFile(paramValue) as Bitmap, Color.Transparent);
                }
            }

            return alert;
        }

        /// <summary>
        /// Creates the specified type.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <param name="args">The args.</param>
        /// <returns></returns>
        static public Alert Create(PopupType type, Arguments args)
        {
            try
            {
                // Which type of Alert to Create ?
                switch (type)
                {
                    case PopupType.Email:
                        return CreateEmail(args);

                    case PopupType.Time:
                        return CreateTime(args);

                    case PopupType.Text:
                        return CreateText(args);

                    case PopupType.WarningText:
                        return CreateWarningText(args);

                    case PopupType.BlueSky:
                        return CreateBlueSky(args);

                    default:
                        return null;
                }
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// Creates the blue sky.
        /// </summary>
        /// <param name="args">The args.</param>
        /// <returns></returns>
        static protected Alert CreateBlueSky(Arguments args)
        {
            Alert alert = new Alert();

            alert.Type       = args.Type;
            alert.Title      = args.Title;
            alert.Text       = args.Text;
            alert.TimeToStay = Math.Abs(args.TimeToStay) == 0 ? 2000 : args.TimeToStay;

            alert.Notifier.NormalTitleColor   = SystemColors.HotTrack;
            alert.Notifier.NormalTitleFont    = new Font(alert.Notifier.NormalTitleFont.FontFamily, 9, FontStyle.Bold);
            alert.Notifier.NormalContentColor = SystemColors.WindowText;
            alert.Notifier.HoverContentColor  = SystemColors.HotTrack;
            alert.Notifier.HoverTitleColor    = SystemColors.ActiveCaption;
            alert.Notifier.HoverTitleFont     = alert.Notifier.NormalTitleFont;
            alert.Notifier.SetBackgroundBitmap(Properties.Resources.gradient_BlueSky_Small, Color.FromArgb(255, 0, 255));
            alert.Notifier.SetCloseBitmap(Properties.Resources.Cancel3, Color.FromArgb(255, 0, 255), new Point(176, 8));
            if (!string.IsNullOrEmpty(alert.Title))
            {
                alert.Notifier.TitleRectangle = new Rectangle(0, 0, 240, 15);
            }
            alert.Notifier.ContentRectangle   = new Rectangle(0, 5, 180, 50);
            alert.Notifier.TitleClickable     = false;
            alert.Notifier.ContentClickable   = true;

            return alert;
        }

        /// <summary>
        /// Creates the warning text.
        /// </summary>
        /// <param name="args">The args.</param>
        /// <returns></returns>
        static protected Alert CreateWarningText(Arguments args)
        {
            Alert alert = new Alert();

            alert.Type = args.Type;
            alert.Title = args.Title;
            alert.Text = args.Text;
            alert.TimeToStay = Math.Abs(args.TimeToStay) == 0 ? 2000 : args.TimeToStay;

            alert.Notifier.NormalTitleColor = Color.FromKnownColor(KnownColor.Wheat);
            //alert.Notifier.NormalTitleFont = new Font(alert.Notifier.NormalTitleFont.FontFamily, 9, FontStyle.Bold);
            alert.Notifier.NormalContentColor = SystemColors.WindowText;
            alert.Notifier.NormalContentFont = new Font(alert.Notifier.NormalContentFont.FontFamily, 10, FontStyle.Bold);
            alert.Notifier.HoverContentColor = SystemColors.HotTrack;
            alert.Notifier.HoverTitleColor = SystemColors.ActiveCaption;
            alert.Notifier.HoverTitleFont = alert.Notifier.NormalTitleFont;
            alert.Notifier.SetBackgroundBitmap(Properties.Resources.gradient_Red_Small, Color.FromArgb(255, 0, 255));
            alert.Notifier.SetCloseBitmap(Properties.Resources.Cancel3, Color.FromArgb(255, 0, 255), new Point(176, 8));
            if (!string.IsNullOrEmpty(alert.Title))
                alert.Notifier.TitleRectangle = new Rectangle(0, 0, 240, 15);
            alert.Notifier.ContentRectangle = new Rectangle(0, 5, 180, 50);

            alert.Notifier.TitleClickable = false;
            alert.Notifier.ContentClickable = true;

            return alert;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        static protected Alert CreateText(Arguments args)
        {
            Alert alert = new Alert();

            alert.Type = args.Type;
            alert.Title = args.Title;
            alert.Text = args.Text;
            alert.TimeToStay = Math.Abs(args.TimeToStay) == 0 ? 2000 : args.TimeToStay;

            alert.Notifier.NormalTitleColor = SystemColors.HotTrack;
            alert.Notifier.NormalTitleFont = new Font(alert.Notifier.NormalTitleFont.FontFamily, 9, FontStyle.Bold);
            alert.Notifier.NormalContentColor = SystemColors.WindowText;
            alert.Notifier.HoverContentColor = SystemColors.HotTrack;
            alert.Notifier.HoverTitleColor = SystemColors.ActiveCaption;
            alert.Notifier.HoverTitleFont = alert.Notifier.NormalTitleFont;
            alert.Notifier.SetBackgroundBitmap(Properties.Resources.gradient_Grey_Small, Color.FromArgb(255, 0, 255));
            alert.Notifier.SetCloseBitmap(Properties.Resources.Cancel3, Color.FromArgb(255, 0, 255), new Point(176, 8));
            if (!string.IsNullOrEmpty(alert.Title))
                alert.Notifier.TitleRectangle = new Rectangle(0, 0, 240, 15);
            alert.Notifier.ContentRectangle = new Rectangle(0, 5, 180, 50);

            alert.Notifier.TitleClickable = false;
            alert.Notifier.ContentClickable = true;

            return alert;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        static protected Alert CreateEmail(Arguments args)
        {
            Alert alert = new Alert();

            alert.Type = args.Type;
            alert.Title = string.IsNullOrEmpty(args.Title) ? "New Email arrived" : args.Title;
            alert.Text = string.IsNullOrEmpty(args.Text) ? "New Email has arrived in your inbox." : args.Text;
            alert.TimeToStay = Math.Abs(args.TimeToStay) == 0 ? 3000 : args.TimeToStay;

            alert.Notifier.NormalTitleColor = SystemColors.HotTrack;
            alert.Notifier.NormalTitleFont = new Font(alert.Notifier.NormalTitleFont, FontStyle.Bold);
            alert.Notifier.NormalContentColor = SystemColors.WindowText;
            alert.Notifier.HoverContentColor = SystemColors.HotTrack;
            alert.Notifier.HoverTitleColor = SystemColors.ActiveCaption;
            alert.Notifier.HoverTitleFont = alert.Notifier.NormalTitleFont;
            alert.Notifier.SetBackgroundBitmap(Properties.Resources.gradient_Blue, Color.FromArgb(255, 0, 255));
            alert.Notifier.SetCloseBitmap(Properties.Resources.Cancel3, Color.FromArgb(255, 0, 255), new Point(280, 15));
            alert.Notifier.TitleRectangle = new Rectangle(20, 15, 240, 30);
            alert.Notifier.ContentRectangle = new Rectangle(20, 60, 260, 30);

            alert.Notifier.TitleClickable = false;
            alert.Notifier.ContentClickable = true;

            return alert;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        static protected Alert CreateTime(Arguments args)
        {
            Alert alert = new Alert();

            alert.Type = args.Type;
            alert.Title = "";
            alert.Text = string.Format(string.IsNullOrEmpty(args.Text) ? "The time is now: {0:h:mm tt}" : args.Text, DateTime.Now);
            alert.TimeToStay = Math.Abs(args.TimeToStay) == 0 ? 2000 : args.TimeToStay;

            alert.Notifier.NormalTitleColor = SystemColors.HotTrack;
            alert.Notifier.NormalTitleFont = new Font(alert.Notifier.NormalTitleFont.FontFamily, 9, FontStyle.Bold);
            alert.Notifier.NormalContentColor = SystemColors.WindowText;
            alert.Notifier.HoverContentColor = SystemColors.HotTrack;
            alert.Notifier.HoverTitleColor = SystemColors.ActiveCaption;
            alert.Notifier.HoverTitleFont = alert.Notifier.NormalTitleFont;
            alert.Notifier.SetBackgroundBitmap(Properties.Resources.gradient_Green_Small, Color.FromArgb(255, 0, 255));
            alert.Notifier.SetCloseBitmap(Properties.Resources.Cancel3, Color.FromArgb(255, 0, 255), new Point(176, 8));
            //alert.Notifier.TitleRectangle = new Rectangle(20, 15, 240, 30);
            alert.Notifier.ContentRectangle = new Rectangle(10, 10, 170, 40);

            alert.Notifier.TitleClickable = false;
            alert.Notifier.ContentClickable = true;

            return alert;
        }

        #endregion
    }
}
