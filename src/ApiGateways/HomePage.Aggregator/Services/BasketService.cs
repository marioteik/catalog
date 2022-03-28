using HomePage.Aggregator.Extensions;
using HomePage.Aggregator.Models;

namespace HomePage.Aggregator.Services;

public class BasketService : IBasketService
{
    private readonly HttpClient _client;

    public BasketService(HttpClient client)
    {
        _client = client ?? throw new ArgumentNullException(nameof(client));
    }

    public async Task<BasketModel> GetBasket(string buyerId)
    {
        var response = await _client.GetAsync($"/api/v1/Basket/{buyerId}");
        return await response.ReadContentAs<BasketModel>();
    }
}