using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TBot.Services;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;

namespace SF_TgBot.Controllers
{
    public class TextMessageController
    {
        private readonly ITelegramBotClient _telegramClient;
        private IStorage _storage;

        public TextMessageController(ITelegramBotClient telegramBotClient, IStorage storage)
        {
            _telegramClient = telegramBotClient;
            _storage = storage;
        }
        public async Task Handle(Message message, CancellationToken ct)
        {
            Console.WriteLine($"Controller {GetType().Name} recieved a message");
            switch (message.Text)
            {
                case "/start":
                    var buttons = new List<InlineKeyboardButton[]>();
                    buttons.Add(new[]
                    {
                        InlineKeyboardButton.WithCallbackData($" Letters" , $"lt"),
                        InlineKeyboardButton.WithCallbackData($" Numbers" , $"nm")
                });
                    await _telegramClient.SendTextMessageAsync(
                        message.Chat.Id,
                        $"<b> Select the option </b> {Environment.NewLine}",
                        cancellationToken: ct,
                        parseMode: ParseMode.Html,
                        replyMarkup: new InlineKeyboardMarkup(buttons));
                    break;
            }
            if (_storage.GetSession(message.Chat.Id).MessageType == "lt")
            {
                await _telegramClient.SendTextMessageAsync(message.Chat.Id, $"String Lenght is " + StringHandler.GetStringLenght(message.Text), cancellationToken: ct);
            }
            else if (_storage.GetSession(message.Chat.Id).MessageType == "nm")
            {
                await _telegramClient.SendTextMessageAsync(message.Chat.Id, $"Sum is " + StringHandler.GetSum(message.Text), cancellationToken: ct); 
            }



        }
    }
}
