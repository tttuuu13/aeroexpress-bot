namespace ClassLibrary.Logging;

public static class LogsFileHandler
{
  public static Stream GetFile(string filePath)
  {
    return new FileStream(filePath, FileMode.Open, FileAccess.Read);
  }

  public static void ClearLogs(string filePath)
  {
    File.WriteAllText(filePath, string.Empty);
  }
}