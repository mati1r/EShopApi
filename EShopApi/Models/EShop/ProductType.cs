namespace EShopApi.Models.EShop;

public class ProductType(
    string name, 
    int id = default
)
{
    public int Id { get; private set; } = id;
    public string Name { get; private set; } = name;

    public ICollection<ProductElement> ProductElements { get; private set; } = [];
    public ICollection<ProductValue> ProductValues { get; private set; } = [];
}
