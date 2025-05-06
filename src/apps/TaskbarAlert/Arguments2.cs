using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using System.Text.RegularExpressions;

namespace TaskbarAlert
{
    public class Arguments2
    {
        private string _Type;
        private string _Title;
        private string _Text;
        int _TimeToStay = 0;

        public string Type
        {
            get { return _Type; }
            set { _Type = value; }
        }
        public string Title
        {
            get { return _Title; }
            set { _Title = value; }
        }
        public string Text
        {
            get { return _Text; }
            set { _Text = value; }
        }
        public int TimeToStay
        {
            get { return _TimeToStay; }
            set { _TimeToStay = value; }
        }

        private Arguments2()
        {
        }

        static public string ClassName
        {
            get
            {
                string[] bits = typeof(Arguments).Name.Split('.');

                return bits[bits.Length - 1];
            }
        }

        static public Arguments ParseArgs()
        {
            return ParseArgs(Environment.GetCommandLineArgs());
        }
        static public Arguments ParseArgs(string[] args)
        {
            try
            {
                using (StringWriter writer = new StringWriter())
                {
                    using (XmlTextWriter xmlWriter = new XmlTextWriter(writer))
                    {
                        xmlWriter.WriteStartElement(ClassName);

                        foreach (string arg in args)
                        {
                            Match match = Regex.Match(arg, @"/(?<name>.+):(?<val>.+)");

                            if (match.Success)
                            {
                                string name = match.Groups["name"].Value;
                                string val = match.Groups["val"].Value;

                                xmlWriter.WriteElementString(name, val);
                            }
                            else
                            {
                                xmlWriter.WriteString(arg);
                            }
                        }

                        xmlWriter.WriteEndElement();

                        // DeSerialize XML into instance
                        using (StringReader reader = new StringReader(writer.ToString()))
                        {
                            XmlSerializer ser = new XmlSerializer(typeof(Arguments));
                            return (Arguments)ser.Deserialize(reader);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message, "EXCEPTION");
                return new Arguments();
            }
        }
    }
}
