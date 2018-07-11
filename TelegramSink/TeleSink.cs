using System;
using System.Collections.Generic;
using System.Text;
using Serilog.Core;
using Serilog.Events;
using TelegramSink.TelegramBotClient;

namespace TelegramSink
{
    public class TeleSink : ILogEventSink
    {
        private readonly IFormatProvider _formatProvider;
        private readonly Bot _telegramBot;

        public TeleSink(IFormatProvider formatProvider, string telegramApiKey, string chatId)
        {
            _formatProvider = formatProvider;
            _telegramBot = new Bot(botConfiguration: new BotConfiguration
            {
                ApiKey = telegramApiKey,
                ChatId = chatId
            });
        }

        public void Emit(LogEvent logEvent)
        {
            var loggedMessage = logEvent.RenderMessage(_formatProvider);
            
            _telegramBot.SendMessage(loggedMessage);
        }
    }
}
