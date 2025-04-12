using Core.SpecificationTypes.Admin.ProductElement;

namespace Core.SpecificationTypes.Admin.Product;

public class ProductGetListSpecificationType
{
    public int Id { get; set; }
    public int SubcategoryId { get; set; }
    public string? Description1 { get; set; }
    public string? Description2 { get; set; }
    public string? Description3 { get; set; }
    public double Price { get; private set; }
    public string? DescriptionPhoto1 { get; private set; }
    public string? DescriptionPhoto2 { get; private set; }
    public int Quantity { get; private set; }
    public bool Hidden { get; private set; }
    public List<ProductElementGetListSpecificationType> ProductElements { get; set; } = [];
}
