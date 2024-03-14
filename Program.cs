namespace HW7;

public class Program
{
  static async Task Main()
  {
    string token = System.Environment.GetEnvironmentVariable("TOKEN");
    Bot bot = new Bot(token);
    try
    {
      await bot.Run();
    }
    catch (Exception e)
    {
      Console.WriteLine(e.Message);
    }
  }
}
