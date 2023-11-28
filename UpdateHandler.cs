using System.Text.Json;
using Telegram.Bot;
using Telegram.Bot.Polling;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;

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
                    await botClient.SendTextMessageAsync(message.Chat.Id, $"Пользователь {userName} запустил бота!");
                    Console.WriteLine($"Сообщение отправлено. Username пользователя: {userName}");
                }

                if (message.Text.ToLower() == "/github")
                {
                    var request = await botClient.SendTextMessageAsync(
                        chatId: message.Chat.Id,
                        text: "Тестовое сообщение со ссылкой",
                        parseMode: ParseMode.Html,
                        replyToMessageId: message.MessageId,
                        replyMarkup: new InlineKeyboardMarkup(
                            InlineKeyboardButton.WithUrl(
                                text: "Ссылка на Github",
                                url: "https://github.com/xndrxww")),
                        cancellationToken: cancellationToken);

                    Console.WriteLine($"Сообщение отправлено {request.From.FirstName} в чат {request.Chat.Id}");
                }
            }
        }

        public async Task HandlePollingErrorAsync(ITelegramBotClient botClient, Exception exception, CancellationToken cancellationToken)
        {
            Console.WriteLine($"Произошла ошибка: {JsonSerializer.Serialize(exception)}");
        }
    }
}
