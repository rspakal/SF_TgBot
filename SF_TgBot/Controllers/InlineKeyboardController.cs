using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TBot.Services;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace SF_TgBot.Controllers
{
    internal class InlineKeyboardController
    {
        private readonly ITelegramBotClient _telegramClient;
        private IStorage _storage;

        public InlineKeyboardController(ITelegramBotClient telegramBotClient, IStorage storage) 
        {
            _telegramClient = telegramBotClient;
            _storage = storage;
        }
        public async Task Handle(CallbackQuery? callbackQuery, CancellationToken ct)
        {
            if (callbackQuery?.Data == null)
                return;
            Console.WriteLine($"Controller {GetType().Name} detect a button pressed");
            _storage.GetSession(callbackQuery.From.Id).MessageType = callbackQuery.Data;

            await _telegramClient.SendTextMessageAsync(callbackQuery.From.Id, $"We will proceed ur message" , cancellationToken: ct);
        }
    }
}
