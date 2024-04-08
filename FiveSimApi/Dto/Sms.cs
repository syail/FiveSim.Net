using Newtonsoft.Json;

namespace FiveSimApi.Dto
{
    public class Sms
    {
        [JsonProperty("created_at")]
        public required string CreatedAt { get; set; }

        [JsonProperty("date")]
        public required string Date { get; set; }

        [JsonProperty("sender")]
        public required string Sender { get; set; }

        [JsonProperty("text")]
        public required string Text { get; set; }

        [JsonProperty("code")]
        public required string Code { get; set; }
    }
}
