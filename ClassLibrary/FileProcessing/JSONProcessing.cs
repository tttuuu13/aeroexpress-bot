using System.Text;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace ClassLibrary;
public class JSONProcessing
{
    public Train[] Read(MemoryStream memoryStream)
    {
        try
        {
            memoryStream.Position = 0;
            using var reader = new StreamReader(memoryStream);
            var json = reader.ReadToEnd();
            var trains = JsonSerializer.Deserialize<Train[]>(json, new JsonSerializerOptions
            {
                Converters = { new TimeOnlyConverter() }
            });
            return trains;
        }
        catch (Exception e)
        {
            Console.WriteLine($"Error while reading JSON: {e.Message}");
            throw new Exception("Некорректный формат данных в файле.");
        }
    }
    
    public Stream Write(Train[] trains)
    {
        var json = JsonSerializer.Serialize(trains, new JsonSerializerOptions
        {
            WriteIndented = true,
            Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
            Converters = { new TimeOnlyConverter() }
        });
        var memoryStream = new MemoryStream();
        using (var writer = new StreamWriter(memoryStream, Encoding.UTF8, leaveOpen: true))
        {
            writer.Write(json);
            writer.Flush();
            memoryStream.Position = 0;
        }
        return memoryStream;
    }
    
    private class TimeOnlyConverter : JsonConverter<TimeOnly>
    {
        public override TimeOnly Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            return TimeOnly.Parse(reader.GetString());
        }

        public override void Write(Utf8JsonWriter writer, TimeOnly value, JsonSerializerOptions options)
        {
            writer.WriteStringValue($"{value.Hour:D2}:{value.Minute:D2}");
        }
    }
}