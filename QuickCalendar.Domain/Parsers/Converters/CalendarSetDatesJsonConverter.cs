using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using QuickCalendar.Domain.Generators;
using QuickCalendar.Domain.Models;

namespace QuickCalendar.Domain.Parsers.Converters;

public class CalendarSetDatesJsonConverter : JsonConverter<CalendarSetDates>
{
    private static readonly NotableDateGeneratorFactory Factory = new();

    public override bool CanRead => true;
    public override bool CanWrite => false;

    public override void WriteJson(JsonWriter writer, CalendarSetDates? value, JsonSerializer serializer)
    {
    }

    public override CalendarSetDates? ReadJson(JsonReader reader, Type objectType, CalendarSetDates? existingValue, bool hasExistingValue, JsonSerializer serializer)
    {
        var jObject = JObject.Load(reader);

        var calendarSetDates = new CalendarSetDates();

        PopulateFrom(serializer, reader, calendarSetDates.AnnualDatesGenerators, jObject[nameof(CalendarSetDates.AnnualDatesGenerators)]);
        PopulateFrom(serializer, reader, calendarSetDates.MonthlyDatesGenerators, jObject[nameof(CalendarSetDates.MonthlyDatesGenerators)]);
        PopulateFrom(serializer, reader, calendarSetDates.DatesGenerators, jObject[nameof(CalendarSetDates.DatesGenerators)]);

        return calendarSetDates;
    }

    private static void PopulateFrom(JsonSerializer serializer, JsonReader reader, ICollection<INotableDatesGenerator> datesGeneratorsList, JToken? generatorObjects)
    {
        if (generatorObjects == null)
            return;

        foreach (var generatorObject in generatorObjects)
        {
            var generatorTypeName = generatorObject[nameof(BaseNotableDatesGenerator.GeneratorTypeName)]?.ToString()
                                    ?? string.Empty;

            var instance = Factory.Create(generatorTypeName, null);
            if (instance != null)
            {
                serializer.Populate(CreateReaderForObject(reader, generatorObject), instance);
                datesGeneratorsList.Add(instance);
            }
        }
    }

    // <summary>Creates a new reader for the specified jObject by copying the settings
    /// from an existing reader.</summary>
    /// <param name="reader">The reader whose settings should be copied.</param>
    /// <param name="jToken">The jToken to create a new reader for.</param>
    /// <returns>The new disposable reader.</returns>
    /// <remarks>
    /// From : https://stackoverflow.com/questions/8030538/how-to-implement-custom-jsonconverter-in-json-net/8031283#8031283
    /// </remarks>
    public static JsonReader CreateReaderForObject(JsonReader reader, JToken jToken)
    {
        var jTokenReader = jToken.CreateReader();
        jTokenReader.Culture = reader.Culture;
        jTokenReader.DateFormatString = reader.DateFormatString;
        jTokenReader.DateParseHandling = reader.DateParseHandling;
        jTokenReader.DateTimeZoneHandling = reader.DateTimeZoneHandling;
        jTokenReader.FloatParseHandling = reader.FloatParseHandling;
        jTokenReader.MaxDepth = reader.MaxDepth;
        jTokenReader.SupportMultipleContent = reader.SupportMultipleContent;
        return jTokenReader;
    }
}
