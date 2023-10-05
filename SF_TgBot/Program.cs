using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Text;
using Telegram.Bot;
using Microsoft.Extensions.Hosting;
using SF_TgBot.Controllers;
using TBot.Services;

namespace SF_TgBot
{
    internal class Program
    {
        public static async Task Main(string[] args)
        {
            Console.OutputEncoding = Encoding.Unicode;
            var host = new HostBuilder()
                .ConfigureServices((hostContext, services) => ConfigureServices(services)).UseConsoleLifetime().Build();
            Console.WriteLine("Service started");
            await host.RunAsync();
            Console.WriteLine("Service stoped");
        }
        static void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<ITelegramBotClient>(provider => new TelegramBotClient("6464267165:AAE3IDweykF754MpdWJvoXn-J28_RAmaT5M"));
            services.AddTransient<DefaultMessageController>();
            services.AddTransient<TextMessageController>();
            services.AddTransient<InlineKeyboardController>();
            services.AddHostedService<Bot>();
            services.AddSingleton<IStorage, MemoryStorage>();
        }
    }
}