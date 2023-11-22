using Telegram.Bot;

namespace TelegramTestBot
{
    public class Program
    {
        private static TelegramBotClient botClient = new TelegramBotClient("6329059912:AAHOLuXfVWBpc9WHHdjzXRhmsXDP-2Varhw");

        static void Main(string[] args)
        {
            var botInfo = botClient.GetMeAsync().Result;

            Console.WriteLine($"Id: {botInfo.Id}");
            Console.WriteLine($"Name: {botInfo.FirstName}");
        }
    }
}