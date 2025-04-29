using System.Diagnostics;
using System.Reflection;
using DNX.Extensions.Assemblies;
using DNX.Extensions.Execution;
using DNX.Extensions.Strings;

// ReSharper disable LocalizableElement

#pragma warning disable IDE1006

namespace QuickCalendar;

partial class AboutBoxForm : Form
{
    public AboutBoxForm()
    {
        InitializeComponent();
    }

    private void AboutBoxForm_Load(object sender, EventArgs e)
    {
        var assemblyDetails = new AssemblyDetails(Assembly.GetEntryAssembly());

        var fileName = assemblyDetails.FileName.CoalesceNullOrWhitespaceWith(
            Process.GetCurrentProcess().MainModule?.FileName,
            Path.Combine(Environment.ProcessPath ?? string.Empty, Process.GetCurrentProcess().ProcessName)
        );

        Icon                    = RunSafely.Execute(() => Icon.ExtractAssociatedIcon(fileName));
        Text                    = $"About {assemblyDetails.Title}";
        labelProductName.Text   = $"{assemblyDetails.Product} v{assemblyDetails.Version.Simplify(2)}";
        labelCopyright.Text     = assemblyDetails.Copyright;
        linkWebsite.Text        = ProjectInfo.WebsiteUrl;
        linkWebsite.LinkArea    = new LinkArea(0, linkWebsite.Text.Length);
        textBoxDescription.Text = assemblyDetails.Description;
    }

    private void linkWebsite_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
    {
        var linkTarget = (sender as LinkLabel)?.Text;
        if (string.IsNullOrEmpty(linkTarget))
        {
            return;
        }

        var ps = new ProcessStartInfo(linkTarget)
        {
            UseShellExecute = true,
            Verb = "open"
        };
        Process.Start(ps);
        if (e.Link != null)
        {
            e.Link.Visited = true;
        }
    }
}
