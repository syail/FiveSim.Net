using Newtonsoft.Json;

namespace FiveSimApi.Dto
{
    public class SmsInboxResult
    {
        [JsonProperty("Data")]
        public List<Sms>? Data { get; set; }

        [JsonProperty("Total")]
        public int Total { get; set; }
    }
}
