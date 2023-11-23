using System.Text.Json;
using Telegram.Bot;
using Telegram.Bot.Polling;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace TelegramTestBot
{
    public class UpdateHandler : IUpdateHandler
    {
        public async Task HandleUpdateAsync(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
        {
            if (update.Type == UpdateType.Message)
            {
                var message = update.Message;
                var userName = message.Chat.Username;

                if (message.Text.ToLower() == "/start")
                {
                    await botClient.SendTextMessageAsync(message.Chat, $"Сообщение отправлено. Username пользователя: {userName}");
                    Console.WriteLine($"Сообщение отправлено. Username пользователя: {userName}");
                }
            }
        }

        public async Task HandlePollingErrorAsync(ITelegramBotClient botClient, Exception exception, CancellationToken cancellationToken)
        {
            Console.WriteLine($"Произошла ошибка: {JsonSerializer.Serialize(exception)}");
        }
    }
}
