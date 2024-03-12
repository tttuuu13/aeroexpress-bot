using Telegram.Bot.Types.ReplyMarkups;
namespace ClassLibrary.Telegram;

public static class Menu
{
  public static readonly InlineKeyboardMarkup MainMenu = new InlineKeyboardMarkup(new[]
  {
    new []
    {
      InlineKeyboardButton.WithCallbackData("\ud83d\udd0dФильтр", "select"),
      InlineKeyboardButton.WithCallbackData("\ud83d\udcf6Сортировка", "sort")
    },
    new []
    {
      InlineKeyboardButton.WithCallbackData("\ud83d\udcbeСкачать файл", "save")
    },
    new [] {InlineKeyboardButton.WithCallbackData("\ud83d\udd00Выбрать другой файл", "chooseAnotherFile")}
  });
  
  public static readonly InlineKeyboardMarkup FilterMenu = new InlineKeyboardMarkup(new[]
  {
    new [] {InlineKeyboardButton.WithCallbackData("По станции отправления", "stationStart")},
    new [] {InlineKeyboardButton.WithCallbackData("По станции прибытия", "stationEnd")},
    new [] {InlineKeyboardButton.WithCallbackData("По станции отправления и прибытия", "stationStartandEnd")},
    new [] {InlineKeyboardButton.WithCallbackData("\ud83d\udd19", "backToMainMenu")}
  });

  public static readonly InlineKeyboardMarkup SortMenu = new InlineKeyboardMarkup(new[]
  {
    new [] {InlineKeyboardButton.WithCallbackData("По времени отправления", "timeStart")},
    new [] {InlineKeyboardButton.WithCallbackData("По времени прибытия", "timeEnd")},
    new [] {InlineKeyboardButton.WithCallbackData("\ud83d\udd19", "backToMainMenu")}
  });
  
  public static readonly InlineKeyboardMarkup ChoseFormat = new InlineKeyboardMarkup(new[]
  {
    new [] {InlineKeyboardButton.WithCallbackData("CSV", "csv")},
    new [] {InlineKeyboardButton.WithCallbackData("JSON", "json")}
  });
}
