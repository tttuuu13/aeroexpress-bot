using System.Text.Json;
using System.Text.Json.Serialization;

namespace ClassLibrary;

public class Train
{
    [JsonPropertyName("ID")]
    public int Id { get; }
    public string StationStart { get; }
    public string Line { get; }
    public TimeOnly TimeStart { get; }
    public string StationEnd { get; }
    public TimeOnly TimeEnd { get; }
    [JsonPropertyName("global_id")]
    public long GlobalId { get; }
    
    public Train(int id, string stationStart, string line, TimeOnly timeStart, string stationEnd, TimeOnly timeEnd, long globalId)
    {
        Id = id;
        StationStart = stationStart;
        Line = line;
        TimeStart = timeStart;
        StationEnd = stationEnd;
        TimeEnd = timeEnd;
        GlobalId = globalId;
    }
}