using System.Net.Http.Headers;
using FiveSimApi.Dto;

namespace FiveSimApi;

public class FiveSimApi : RestClient
{
    public FiveSimApi(string token) : base(GenerateClient(token), Config.API_HOST)
    {
    }

    /// <summary>
    /// For only use guest apis
    /// </summary>
    public FiveSimApi() : base(GenerateClient(), Config.API_HOST)
    {
    }

    public async Task<GetProfileResult> GetProfile()
    {
        GetProfileResult result = await GetJson<GetProfileResult>("/v1/user/profile");

        return result;
    }
    
    private static HttpClient GenerateClient(string? token = null)
    {
        return new()
        {
            DefaultRequestHeaders =
            {
                Authorization = new AuthenticationHeaderValue("Bearer", token)
            }
        };
    }
}