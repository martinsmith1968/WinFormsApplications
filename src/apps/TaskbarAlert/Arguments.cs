using System;
using System.Collections.Generic;
using System.Text;
using TaskbarAlert.Legacy.CommandLine;

namespace TaskbarAlert
{
    /// <summary>
    ///
    /// </summary>
    public enum PopupType
    {
        None,

        Text,

        Time,

        Email,

        WarningText,

        BlueSky
    }

    /// <summary>
    ///
    /// </summary>
    public class Arguments
    {
        #region Custom

        [Argument(ArgumentType.AtMostOnce, GroupName = "Custom", ShortName = "cfg", HelpText = "A configuration file of settings")]
        public string ConfigFile;

        #endregion

        #region Main

        [Argument(ArgumentType.AtMostOnce, DefaultValue = PopupType.None, GroupName = "Main", ShortName = "t", HelpText = "The type of Alert to display")]
        public PopupType Type;

        #endregion

        #region Optional

        [Argument(ArgumentType.AtMostOnce, GroupName = "Optional", HelpText = "The Title to display at the top of the Alert")]
        public string Title;

        [Argument(ArgumentType.AtMostOnce, GroupName = "Optional", HelpText = "The text to display inside the Alert")]
        public string Text;

        [Argument(ArgumentType.AtMostOnce, GroupName = "Optional", DefaultValue = 3000, HelpText = "The number of milliseconds to keep the Alert on screen")]
        public int TimeToStay;

        #endregion

        #region Standalone

        [Argument(ArgumentType.BypassMandatory, DefaultValue = false, ShortName = "?", GroupName = "Standalone", HelpText = "Show the Help page")]
        public bool Help;

        #endregion

        #region Derived Properties

        /// <summary>
        /// Gets a value indicating whether this instance has type.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance has type; otherwise, <c>false</c>.
        /// </value>
        public bool HasType
        {
            get { return this.Type != PopupType.None; }
        }

        /// <summary>
        /// Gets a value indicating whether this instance has text.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance has text; otherwise, <c>false</c>.
        /// </value>
        public bool HasText
        {
            get { return !string.IsNullOrEmpty(this.Text); }
        }

        /// <summary>
        /// Gets a value indicating whether this instance has title.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance has title; otherwise, <c>false</c>.
        /// </value>
        public bool HasTitle
        {
            get { return !string.IsNullOrEmpty(this.Title); }
        }

        /// <summary>
        /// Gets a value indicating whether this instance has config file.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance has config file; otherwise, <c>false</c>.
        /// </value>
        public bool HasConfigFile
        {
            get { return !string.IsNullOrEmpty(this.ConfigFile); }
        }

        #endregion
    }
}
