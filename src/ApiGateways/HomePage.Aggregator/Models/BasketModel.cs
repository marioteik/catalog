namespace HomePage.Aggregator.Models;

public class BasketModel
{
    public string BuyerId { get; set; }
    public List<BasketItemExtendedModel> Items { get; set; } = new();
    public decimal TotalPrice { get; set; }
}