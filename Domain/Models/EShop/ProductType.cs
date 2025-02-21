using Core.Models.EShop;

namespace EShopApi.Models.EShop;

public class ProductType(
    string name, 
    int filterTypeId,
    int id = default
)
{
    public int Id { get; private set; } = id;
    public string Name { get; private set; } = name;
    public int FilterTypeId { get; private set; } = filterTypeId;

    public virtual FilterType? FilterType { get; set; }
    public ICollection<ProductElement> ProductElements { get; private set; } = [];
    public ICollection<ProductValue> ProductValues { get; private set; } = [];
    public ICollection<SubcategoryRefProductType> SubcategoryRefProductTypes { get; private set; } = [];
}
