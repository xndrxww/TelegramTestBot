﻿using Telegram.Bot;
using Telegram.Bot.Polling;

namespace TelegramTestBot
{
    public class Program
    {
        private static readonly ITelegramBotClient _botClient = new TelegramBotClient("6329059912:AAHOLuXfVWBpc9WHHdjzXRhmsXDP-2Varhw");

        static void Main(string[] args)
        {
            StartInfo();

            var handler = new UpdateHandler();
            var cancellationToken = new CancellationToken();
            var receiverOptions = new ReceiverOptions
            {
                AllowedUpdates = { } //принимает все изменения
            };

            _botClient.StartReceiving(handler, receiverOptions, cancellationToken);
            Console.ReadLine();
        }

        private static void StartInfo()
        {
            var botInfo = _botClient.GetMeAsync().Result;
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine($"Запуск бота: {botInfo.FirstName}");
            Console.WriteLine($"Информация: {botInfo}");
            Console.WriteLine();
            Console.ResetColor();
        }
    }
}