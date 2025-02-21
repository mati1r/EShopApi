using EShopApi.Models.EShop;

namespace Core.Models.EShop;

public class SubcategoryRefProductType(int subcategoryId, int productTypeId)
{
    public int SubcategoryId { get; private set; } = subcategoryId;
    public int ProductTypeId { get; private set; } = productTypeId;

    public virtual Subcategory? Subcategory { get; set; }
    public virtual ProductType? ProductType { get; set; }
}
