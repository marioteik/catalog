using HomePage.Aggregator.Models;
using HomePage.Aggregator.Services;
using Microsoft.AspNetCore.Mvc;

namespace HomePage.Aggregator.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class HomePageController : ControllerBase
{
    private readonly IBasketService _basketService;
    private readonly ICatalogService _catalogService;

    public HomePageController(ICatalogService catalogService, IBasketService basketService)
    {
        _catalogService = catalogService;
        _basketService = basketService;
    }

    [HttpGet]
    [Route("{userId}", Name = "GetHomePage")]
    public async Task<ActionResult<HomePageModel>> GetHomePage(string userId)
    {
        var basket = await _basketService.GetBasket(userId);

        foreach (var basketItem in basket.Items)
        {
            var catalogItem = await _catalogService.GetCatalog(basketItem.ProductId);
            basketItem.ProductId = catalogItem.Id;
            basketItem.ProductName = catalogItem.Name;
            basketItem.Category = catalogItem.Category;
            basketItem.Summary = catalogItem.Summary;
            basketItem.Description = catalogItem.Description;
            basketItem.ImageFile = catalogItem.ImageFile;
        }

        var catalog = await _catalogService.GetCatalog();

        return new HomePageModel
        {
            UserName = "needs authentication",
            Basket = basket,
            Catalog = catalog.ToList()
        };
    }
}