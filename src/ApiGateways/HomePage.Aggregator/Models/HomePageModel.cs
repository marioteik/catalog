namespace HomePage.Aggregator.Models;

public class HomePageModel
{
    public string UserName { get; set; }
    public BasketModel Basket { get; set; }
    public List<CatalogModel> Catalog { get; set; }
}