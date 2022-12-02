using System.Diagnostics;
using System.Reflection;
using DNX.Helpers.Assemblies;
using QuickCalendar.Properties;

// ReSharper disable LocalizableElement

#pragma warning disable IDE1006

namespace QuickCalendar;

partial class AboutBoxForm : Form
{
    private const string WebsiteUrl = "https://github.com/martinsmith1968/WinFormsApplications";

    public AboutBoxForm()
    {
        InitializeComponent();
    }

    private void AboutBoxForm_Load(object sender, EventArgs e)
    {
        var assemblyDetails = new AssemblyDetails(Assembly.GetEntryAssembly());

        Icon = Icon.ExtractAssociatedIcon(assemblyDetails.FileName);
        Text = $"About {assemblyDetails.Title}";
        labelProductName.Text = $"{assemblyDetails.Product} v{assemblyDetails.Version.Simplify(2)}";
        labelCopyright.Text = assemblyDetails.Copyright;
        linkWebsite.Text = WebsiteUrl;
        linkWebsite.LinkArea = new LinkArea(0, linkWebsite.Text.Length);
        textBoxDescription.Text = assemblyDetails.Description;
    }

    private void linkWebsite_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
    {
        var ps = new ProcessStartInfo(((LinkLabel)sender).Text)
        {
            UseShellExecute = true,
            Verb = "open"
        };
        Process.Start(ps);
        e.Link.Visited = true;
    }
}
