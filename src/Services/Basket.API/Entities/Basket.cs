namespace Basket.API.Entities;

public class ShoppingCart
{
    public ShoppingCart()
    {
    }

    public ShoppingCart(string buyerId, string establishmentId)
    {
        BuyerId = buyerId;
        EstablishmentId = establishmentId;
    }

    public string BuyerId { get; set; }
    public List<ShoppingCardItem> Items { get; set; } = new();
    public string EstablishmentId { get; set; }

    public decimal TotalPrice
    {
        get
        {
            decimal total = 0;
            foreach (var item in Items) total += item.UnitPrice * item.Quantity;
            return total;
        }
    }
}