using System.Reflection;
using Bogus;
using DNX.Extensions.Assemblies;
using Shouldly;
using Xunit;

namespace DNX.Common.Tests.Application
{
    public class ApplicationDetailsTests
    {
        private static readonly Faker Faker = new();

        [Fact]
        public void ApplicationId_returns_something_by_default_When_no_assembly_specified()
        {
            // Act
            var result = DNX.Common.Application.ApplicationDetails.GenerateApplicationId();

            // Assert
            result.ShouldNotBeNullOrEmpty();
        }

        [Fact]
        public void ApplicationId_returns_something_by_default_When_assembly_specified()
        {
            var assembly = Assembly.GetExecutingAssembly();

            // Act
            var result = DNX.Common.Application.ApplicationDetails.GenerateApplicationId(assembly.GetAssemblyDetails());

            // Assert
            result.ShouldNotBeNullOrEmpty();
        }

        [Fact]
        public void ApplicationId_returns_consistent_results_When_no_assembly_specified()
        {
            var iterations = Faker.Random.Int(5, 10);

            // Act
            var result = Enumerable.Range(1, iterations)
                .Select(_ => DNX.Common.Application.ApplicationDetails.GenerateApplicationId())
                .ToArray();

            // Assert
            result.Length.ShouldBe(iterations);
            result.Distinct().Count().ShouldBe(1);
        }

        [Fact]
        public void ApplicationId_returns_consistent_results_When_assembly_specified()
        {
            var iterations = Faker.Random.Int(5, 10);
            var assembly = Assembly.GetExecutingAssembly();

            // Act
            var result = Enumerable.Range(1, iterations)
                .Select(_ => DNX.Common.Application.ApplicationDetails.GenerateApplicationId(assembly.GetAssemblyDetails()))
                .ToArray();

            // Assert
            result.Length.ShouldBe(iterations);
            result.Distinct().Count().ShouldBe(1);
        }
    }
}
