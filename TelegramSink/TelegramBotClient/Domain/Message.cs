using Newtonsoft.Json;

namespace TelegramSink.TelegramBotClient.Domain
{
	public class Message
	{
		[JsonProperty(PropertyName = "message_id")]
		public string MessageId { get; set; }
		[JsonProperty(PropertyName = "date")]
		public long Date { get; set; }
	}
}