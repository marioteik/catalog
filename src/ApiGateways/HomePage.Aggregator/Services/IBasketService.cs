using HomePage.Aggregator.Models;

namespace HomePage.Aggregator.Services;

public interface IBasketService
{
    Task<BasketModel> GetBasket(string buyerId);
}