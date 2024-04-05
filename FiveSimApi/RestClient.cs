using System.Text;
using Newtonsoft.Json;

namespace FiveSimApi;

public class RestClient
{
    private readonly HttpClient _client;
    private readonly string _baseUrl;
    
    public RestClient(HttpClient client, string baseUrl)
    {
        _client = client;
        _baseUrl = baseUrl;
    }
    
    public async Task<T> GetJson<T>(string path) where T : class
    {
        HttpRequestMessage req = new(HttpMethod.Get, new Uri($"{_baseUrl}{path}"));
        
        var result = await Request<T>(req);

        return result;
    }
    
    public async Task<T> PostJson<T>(string path, object data) where T : class
    {
        HttpRequestMessage req = new(HttpMethod.Post, new Uri($"{_baseUrl}{path}"))
        {
            Content = new StringContent(JsonConvert.SerializeObject(data), Encoding.UTF8, "application/json")
        };
        var result = await Request<T>(req);

        return result;
    } 
    

    public async Task<T> Request<T>(HttpRequestMessage req) where T : class
    {
        var result = await _client.SendAsync(req);
        
        if (!result.IsSuccessStatusCode)
        {
            throw new HttpRequestException($"Failed to send request with status {result.StatusCode}");
        }
        string content = await result.Content.ReadAsStringAsync();

        T data = JsonConvert.DeserializeObject<T>(content) ?? throw new InvalidCastException($"Cannot cast response to type {typeof(T)}");
        
        return data;
    }
}