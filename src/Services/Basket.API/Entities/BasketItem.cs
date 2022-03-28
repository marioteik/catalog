namespace Basket.API.Entities;

public class ShoppingCardItem
{
    public string ProductId { get; set; }
    public string ProductName { get; set; }
    public decimal UnitPrice { get; set; }
    public int Quantity { get; set; }
    public string PictureUrl { get; set; }
}