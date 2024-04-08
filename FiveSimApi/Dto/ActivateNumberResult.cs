using Newtonsoft.Json;

namespace FiveSimApi.Dto
{
    public class ActivateNumberResult
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("phone")]
        public required string Phone { get; set; }

        [JsonProperty("operator")]
        public required string Operator { get; set; }

        [JsonProperty("product")]
        public required string Product { get; set; }

        [JsonProperty("price")]
        public double Price { get; set; }

        [JsonProperty("status")]
        public required string Status { get; set; }

        [JsonProperty("expires")]
        public required string Expires { get; set; }

        [JsonProperty("sms")]
        public List<Sms>? Sms { get; set; }

        [JsonProperty("created_at")]
        public required string CreatedAt { get; set; }

        [JsonProperty("country")]
        public required string Country { get; set; }
    }
}
