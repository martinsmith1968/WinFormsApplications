using System.Reflection;
using DNX.Extensions.Assemblies;
using DNX.Extensions.Conversion;

namespace DNX.Common.Application;

public static class ApplicationDetails
{
    public static string GenerateApplicationId()
    {
        return GenerateApplicationId(new AssemblyDetails(Assembly.GetEntryAssembly()));
    }

    public static string GenerateApplicationId(IAssemblyDetails assemblyDetails)
    {
        return $"{assemblyDetails.Company}.{assemblyDetails.Product}.{assemblyDetails.SimplifiedVersion}"
            .ToDeterministicGuid()
            .ToString()
            .ToUpper();
    }
}
