namespace HW7;

public class Program
{
  static async Task Main()
  {
    //string token = System.Environment.GetEnvironmentVariable("TOKEN");
    string token = "7123360905:AAE-89fU1NoXeX9JVhIADHRsoBQpNn1h7wY";
    Bot bot = new Bot(token);
    while (true)
    {
      try
      {
        await bot.Run();
        Console.ReadLine();
      }
      catch (Exception e)
      {
        Console.WriteLine(e);
      }
    }
  }
}