namespace HW7;

public class Program
{
  static async Task Main()
  {
    // Not storing sensetive data in the code, using Heroku config variables instead.
    string token = System.Environment.GetEnvironmentVariable("TOKEN");
    Bot bot = new Bot(token, "../../../logs.txt");
    await bot.Run();
  }
}
