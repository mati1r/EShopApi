namespace Core.Models.EShop;

public class ProductValue(
    int productTypeId,
    string name,
    int id = default
)
{
    public int Id { get; private set; } = id;
    public int ProductTypeId { get; private set; } = productTypeId;
    public string Name { get; private set; } = name;

    public virtual ProductType? ProductType { get; set; }

    public ICollection<ProductElement> ProductElements { get; private set; } = [];

    public void Update(string name, int productTypeId)
    {
        Name = name;
        ProductTypeId = productTypeId;
    }
}
