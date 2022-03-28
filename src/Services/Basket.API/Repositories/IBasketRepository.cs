using Basket.API.Entities;

namespace Basket.API.Repositories;

public interface IBasketRepository
{
    Task<ShoppingCart?> GetBasket(string buyerId);
    Task<ShoppingCart?> UpdateBasket(ShoppingCart basket);
    Task DeleteBasket(string buyerId);
}