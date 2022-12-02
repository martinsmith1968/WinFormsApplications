using QuickCalendar.Domain.Models;

namespace QuickCalendar.Domain.Generators;

public interface INotableDatesGenerator
{
    string GeneratorTypeName { get; }

    IList<NotableDate> Generate();

    string GetDefinitionValue();

    string GetDefinitionText();

    void PopulateFromDefinitionValue(string text);
}
