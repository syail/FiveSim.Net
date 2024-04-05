using Newtonsoft.Json;

namespace FiveSimApi.Dto;

public class GetProfileResult
{
    [JsonProperty("id")]
    public int Id { get; set; }
    
    [JsonProperty("email")]
    public required string Email { get; set; }
    
    [JsonProperty("vendor")]
    public required string Vendor { get; set; }
    
    [JsonProperty("balance")]
    public double Balance { get; set; }
    
    [JsonProperty("rating")]
    public double Rating { get; set; }
    
    [JsonProperty("frozen_balance")]
    public double FrozenBalance { get; set; }
}
