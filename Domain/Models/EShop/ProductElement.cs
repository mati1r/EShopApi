namespace Core.Models.EShop;

public class ProductElement(
    int productTypeId,
    int productValueId,
    int productId,
    int id = default
)
{
    public int Id { get; private set; } = id;
    public int ProductTypeId { get; private set; } = productTypeId;
    public int ProductValueId { get; private set; } = productValueId;
    public int ProductId { get; private set; } = productId;

    public virtual ProductType? ProductType { get; set; }
    public virtual ProductValue? ProductValue { get; set; }
    public virtual Product? Product { get; set; }
}
