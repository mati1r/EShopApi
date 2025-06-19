namespace Core.SpecificationTypes.Anonymus.Product;

public class ProductGetListSpecificationType
{
    public int Id { get; set; }
    public string Name { get; set; }
    public double Price { get; set; }
    public int Quantity { get; set; }
    public string? Description1 { get; set; }
    public byte[]? DescriptionPhoto { get; set; } = [];
    public List<ProductElementListSpecificationType> ProductElements { get; set; } = [];
}
