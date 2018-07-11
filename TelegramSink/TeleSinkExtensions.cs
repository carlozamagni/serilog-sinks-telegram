using System;
using System.Collections.Generic;
using System.Text;
using Serilog;
using Serilog.Configuration;

namespace TelegramSink
{
    public static class TeleSinkExtensions
    {
        public static LoggerConfiguration TeleSink(this LoggerSinkConfiguration config, string telegramApiKey, string telegramChatId, IFormatProvider formatProvider = null)
        {
            return config.Sink(new TeleSink(formatProvider, telegramApiKey, telegramChatId));
        }
    }
}
