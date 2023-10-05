using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TBot.Models;
using Telegram.Bot;

namespace TBot.Services
{
    public interface IStorage
    {
        //public Session GetSession(ITelegramBotClient telegramBotClient);
        public Session GetSession(long chatID);
    }
}
