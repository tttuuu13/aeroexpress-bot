using System.Text;

namespace ClassLibrary;

public class CSVProcessing
{
    public Stream Write(Train[] trains)
    {
        MemoryStream memoryStream = new MemoryStream();
        using (var writer = new StreamWriter(memoryStream, Encoding.UTF8, leaveOpen: true))
        {
            writer.WriteLine("\"ID\";\"StationStart\";\"Line\";\"TimeStart\";\"StationEnd\";\"TimeEnd\";\"global_id\";");
            writer.WriteLine("\"Локальный идентификатор\";\"Станция отправления\";\"Направление Аэроэкспресс\";\"Время отправления со станции\";\"Конечная станция направления Аэроэкспресс\";\"Время прибытия на конечную станцию направления Аэроэкспресс\";\"global_id\";");
            foreach (var train in trains)
            {
                writer.WriteLine(
                    $"\"{train.Id}\";\"{train.StationStart}\";\"{train.Line}\";\"{train.TimeStart.Hour:D2}:{train.TimeStart.Minute:D2}\";\"{train.StationEnd}\";\"{train.TimeEnd.Hour:D2}:{train.TimeEnd.Minute:D2}\";\"{train.GlobalId}\";");
            }
        }
        memoryStream.Position = 0;
        return memoryStream;
    }
    public Train[] Read(MemoryStream memoryStream)
    {
        try
        {
            memoryStream.Position = 0;
            using var reader = new StreamReader(memoryStream);
            var trains = new List<Train>();
            reader.ReadLine(); // skip header
            reader.ReadLine(); // skip header
            while (!reader.EndOfStream)
            {
                var line = reader.ReadLine()?.Replace("\"", "");
                if (line == null) continue;
                var values = line.Split(';');
                var train = new Train(
                    int.Parse(values[0]),
                    values[1],
                    values[2],
                    TimeOnly.Parse(values[3]),
                    values[4],
                    TimeOnly.Parse(values[5]),
                    long.Parse(values[6])
                );
                trains.Add(train);
            }
            return trains.ToArray();
        }
        catch (Exception e)
        {
            throw new Exception("Некорректный формат данных в файле.");
        }
    }
}