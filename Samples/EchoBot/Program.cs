﻿using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace EchoBot
{
    using static Messenger.Consts;
    using Messenger;
    
    class Program
    {
        static MessengerBot bot = new MessengerBot(80, AppSecret, PageToken, VerifyToken, LogLevel.Error);

        static void Main(string[] args)
        {
            Console.WriteLine("Starting the bot...");

            bot.OnMessage += Bot_OnMessage;

            bot.StartReceivingAsync();

            bot.WaitForShutdown();
        }

        private async static Task Bot_OnMessage(MessageEventArgs e)
        {
            Console.WriteLine($"\n{e.Sender}:{e.Message.Text}");

            await bot.SendMessageAsync(e.Sender, e.Message.Text);
        }
    }
}
