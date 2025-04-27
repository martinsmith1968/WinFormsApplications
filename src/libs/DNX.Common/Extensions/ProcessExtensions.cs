using System.Diagnostics;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using DNX.Extensions.Strings;

namespace DNX.Common.Extensions;

[Flags]
public enum DescriptionStyle
{
    None = 0,
    Short = 1,
    Long = 2,
    Full = 255,
}

public static class ProcessExtensions
{
    public static string GetShortDescription(this ProcessStartInfo startInfo) =>
        startInfo.GetDescription(DescriptionStyle.Short);

    public static string GetLongDescription(this ProcessStartInfo startInfo) =>
        startInfo.GetDescription(DescriptionStyle.Long);

    public static string GetFullDescription(this ProcessStartInfo startInfo) =>
        startInfo.GetDescription(DescriptionStyle.Full);

    private static string GetPropertyDescription<T>(Expression<Func<T>> propertyExpression)
    {
        var name = string.Empty;

        if (propertyExpression is LambdaExpression lambdaExpression)
        {
            if (lambdaExpression.Body is MemberExpression memberExpression)
            {
                name = memberExpression.Member.Name;
            }
        }

        name = name.CoalesceNullOrEmptyWith(typeof(T).Name);

        return $"{name}: {propertyExpression.Compile().Invoke()}";
    }

    public static string GetDescription(this ProcessStartInfo startInfo, DescriptionStyle descriptionStyle = DescriptionStyle.Full)
    {
        var sb = new StringBuilder();

        if (descriptionStyle.HasFlag(DescriptionStyle.Short))
        {
            if (startInfo.UseShellExecute)
            {
                sb.AppendFormat("shell: {0}", startInfo.Verb.CoalesceNullOrEmptyWith("default"));
            }

            sb.AppendSpace();
            sb.Append(startInfo.FileName);

            if (startInfo.ArgumentList.Any())
            {
                sb.AppendSpace();
                sb.Append(startInfo.ArgumentList.JoinAndSurround(" ", null, null));
            }
            else if (!startInfo.Arguments.IsNullOrWhiteSpace())
            {
                sb.AppendSpace();
                sb.Append(startInfo.Arguments);
            }
        }

        if (descriptionStyle.HasFlag(DescriptionStyle.Long))
        {
            if (!startInfo.WorkingDirectory.IsNullOrWhiteSpace())
            {
                sb.AppendSpace();
                sb.AppendFormat("Dir: {0}", startInfo.WorkingDirectory);
            }
        }

        if (descriptionStyle.HasFlag(DescriptionStyle.Full))
        {
            if (startInfo.WindowStyle != ProcessWindowStyle.Normal)
            {
                sb.AppendSpace();
                sb.Append(GetPropertyDescription(() => startInfo.WindowStyle));
            }

            if (!startInfo.UserName.IsNullOrWhiteSpace())
            {
                sb.AppendSpace();
                sb.Append(GetPropertyDescription(() => startInfo.UserName));
            }

            if (!startInfo.Domain.IsNullOrWhiteSpace())
            {
                sb.AppendSpace();
                sb.Append(GetPropertyDescription(() => startInfo.Domain));
            }

            // TODO: Implement all other relevant properties



            var executeFlags =  startInfo.GetType().GetProperties(BindingFlags.Instance | BindingFlags.Public)
                .Where(pi => pi.PropertyType == typeof(bool))
                .Where(pi => (bool)pi.GetValue(startInfo))
                .Select(pi => pi.Name)
                .ToArray();
            if (executeFlags.Any())
            {
                sb.Append(executeFlags.JoinAndSurround());
            }
        }

        return sb.ToString();
    }
}
