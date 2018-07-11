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
        private readonly LogEventLevel _minimumLevel;
        private readonly Bot _telegramBot;

        public TeleSink(IFormatProvider formatProvider, string telegramApiKey, string chatId) : this(formatProvider, telegramApiKey, chatId, LogEventLevel.Verbose)
        {
        }

        public TeleSink(IFormatProvider formatProvider, string telegramApiKey, string chatId, LogEventLevel minimumLevel)
        {
            _formatProvider = formatProvider;
            _minimumLevel = minimumLevel;
            _telegramBot = new Bot(botConfiguration: new BotConfiguration
            {
                ApiKey = telegramApiKey,
                ChatId = chatId
            });
        }

		public void Emit(LogEvent logEvent)
		{
		    if (logEvent.Level < _minimumLevel) return;

            var loggedMessage = logEvent.RenderMessage(_formatProvider);
            
            _telegramBot.SendMessage(loggedMessage);
        }
    }
}
