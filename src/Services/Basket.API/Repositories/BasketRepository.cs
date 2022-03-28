using Basket.API.Entities;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;

namespace Basket.API.Repositories;

public class BasketRepository : IBasketRepository
{
    private readonly IDistributedCache _cache;

    public BasketRepository(IDistributedCache cache)
    {
        _cache = cache ?? throw new ArgumentNullException(nameof(cache));
    }

    public async Task<ShoppingCart?> GetBasket(string buyerId)
    {
        var basket = await _cache.GetStringAsync(buyerId);

        return string.IsNullOrEmpty(basket) ? null : JsonConvert.DeserializeObject<ShoppingCart>(basket);
    }

    public async Task<ShoppingCart?> UpdateBasket(ShoppingCart basket)
    {
        await _cache.SetStringAsync(basket.BuyerId, JsonConvert.SerializeObject(basket));

        return await GetBasket(basket.BuyerId);
    }

    public async Task DeleteBasket(string buyerId)
    {
        await _cache.RemoveAsync(buyerId);
    }
}