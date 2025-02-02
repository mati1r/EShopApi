namespace EShopApi.Models.EShop;

public class ProductRefHistory(
    int productId,
    int historyId,
    double oldPrice,
    int quantity,
    bool discount = false,
    int? discountPrecentage = null
)
{
    public int ProductId { get; private set; } = productId;
    public int HistoryId { get; private set; } = historyId;
    public double OldPrice { get; private set; } = oldPrice;
    public int Quantity { get; private set; } = quantity;
    public bool Discount { get; private set; } = discount;
    public int? DiscountPrecentage { get; private set; } = discountPrecentage;

    public virtual Product? Product { get; set; }
    public virtual History? History { get; set; }
}
