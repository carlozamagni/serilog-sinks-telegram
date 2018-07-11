# Serilog.Sinks.Telegram

Writes Serilog events to a given Telegram chat being it a private chat or a group.

# Install
```
Install-Package Serilog.Sinks.Telegram
```
Note that a Telegram bot api key is required in order to configure the sink, if you don't know how the bot creation process works please [refer to the official documentation](https://core.telegram.org/bots#3-how-do-i-create-a-bot).

# Configuration
To configure the sink simply add "TeleSink" using the "WriteTo" method on the Serilog logger configuration.

```c#
new LoggerConfiguration()
	.MinimumLevel.Information()
	.WriteTo.TeleSink(
		telegramApiKey:"my-bot-api-key",
    	telegramChatId:"the target chat id").CreateLogger();
```