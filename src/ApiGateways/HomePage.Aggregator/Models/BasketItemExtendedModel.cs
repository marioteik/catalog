namespace HomePage.Aggregator.Models;

public class BasketItemExtendedModel
{
    public string ProductId { get; set; }
    public string ProductName { get; set; }
    public decimal UnitPrice { get; set; }
    public int Quantity { get; set; }
    public string PictureUrl { get; set; }

    // FROM CATALOG
    public string Category { get; set; }
    public string Summary { get; set; }
    public string Description { get; set; }
    public string ImageFile { get; set; }
}