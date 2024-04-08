using System.Net.Http.Headers;
using FiveSimApi.Dto;
using Newtonsoft.Json.Linq;

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

    public async Task<GetPricesByProductIdResult> GetPricesByProductId(string productId)
    {
        var data = await GetJson<JObject>($"/v1/guest/prices?product={productId}");

        JObject productData = (JObject?)data[productId] ?? throw new Exception("Response Product not found");

        var countries = productData.Properties().Select(x => x.Name).ToList();

        var products = new List<GetPricesByProductIdResult.ProductItemInfo>();

        foreach (var country in countries)
        {
            var countryData = (JObject)productData[country]!;
            var operators = countryData.Properties().Select(x => x.Name).ToList();

            for (int i = 0; i < operators.Count; i++)
            {
                var operatorData = (JObject)countryData[operators[i]]!;

                int count = operatorData["count"]?.Value<int>() ?? 0;

                if (count == 0) continue;

                products.Add(new GetPricesByProductIdResult.ProductItemInfo
                {
                    Country = country,
                    OperatorId = operators[i],
                    Cost = operatorData["cost"]?.Value<double>() ?? -1,
                    Count = count,
                    Rate = operatorData["rate"]?.Value<double>() ?? -1
                });
            }
        }
        return new(productId, products);
    }

    public async Task<ActivateNumberResult> ActivateNumber(string country, string productId, string operatorId)
    {
        var data = await GetJson<ActivateNumberResult>($"/v1/user/buy/activation/{country}/{operatorId}/{productId}");

        return data;
    }

    public async Task<ActivateNumberResult> CheckOrder(long orderId)
    {
        var data = await GetJson<ActivateNumberResult>($"/v1/user/check/{orderId}");

        return data;
    }

    public async Task<ActivateNumberResult> FinishOrder(long orderId)
    {
        var data = await GetJson<ActivateNumberResult>($"/v1/user/finish/{orderId}");

        return data;
    }

    public async Task<ActivateNumberResult> CancelOrder(long orderId)
    {
        var data = await GetJson<ActivateNumberResult>($"/v1/user/cancel/{orderId}");

        return data;
    }

    public async Task<ActivateNumberResult> BanOrder(long orderId)
    {
        var data = await GetJson<ActivateNumberResult>($"/v1/user/ban/{orderId}");

        return data;
    }

    public async Task<SmsInboxResult> GetInbox(long orderId)
    {
        var data = await GetJson<SmsInboxResult>($"/v1/user/sms/inbox/{orderId}");

        return data;
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