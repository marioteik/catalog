using System.Net;
using Basket.API.Entities;
using Basket.API.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Basket.API.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class BasketController : ControllerBase
{
    private readonly IBasketRepository _repository;

    public BasketController(IBasketRepository repository)
    {
        _repository = repository ?? throw new ArgumentNullException(nameof(repository));
    }

    [HttpGet]
    [Route("{buyerId}", Name = "GetBasket")]
    [ProducesResponseType(typeof(ShoppingCart), (int) HttpStatusCode.OK)]
    public async Task<ActionResult<ShoppingCart>> GetBasket(string buyerId)
    {
        var basket = await _repository.GetBasket(buyerId);
        return Ok(basket ?? new ShoppingCart(buyerId, ""));
    }

    [HttpPost]
    [ProducesResponseType(typeof(ShoppingCart), (int) HttpStatusCode.OK)]
    public async Task<ActionResult<ShoppingCart>> UpdateBasket([FromBody] ShoppingCart basket)
    {
        return Ok(await _repository.UpdateBasket(basket));
    }

    [HttpDelete]
    [Route("{buyerId}", Name = "DeleteBasket")]
    [ProducesResponseType(typeof(void), (int) HttpStatusCode.OK)]
    public async Task<ActionResult> DeleteBasket(string buyerId)
    {
        await _repository.DeleteBasket(buyerId);
        return Ok();
    }
}