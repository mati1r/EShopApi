namespace Core.Models.EShop;

public class ProductValue(
    int productTypeId,
    string name,
    int? value,
    int id = default
)
{
    public int Id { get; private set; } = id;
    public int ProductTypeId { get; private set; } = productTypeId;
    public string Name { get; private set; } = name;
    public int? Value { get; private set; } = value;

    public virtual ProductType ProductType { get; set; }

    public ICollection<ProductElement> ProductElements { get; private set; } = [];

    public void Update(string name, int? value, int productTypeId)
    {
        Name = name;
        Value = value;
        ProductTypeId = productTypeId;
    }
}
