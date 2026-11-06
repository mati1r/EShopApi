namespace Core.SpecificationTypes.Core;

public class ProductGetListSpecificationType
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Quantity { get; set; }
    public List<string>? Descriptions { get; set; } = [];
    public List<string>? ProductPhotosName { get; set; } = [];
    public List<byte[]>? ProductPhotos { get; set; } = [];
    public List<ProductElementListSpecificationType> ProductElements { get; set; } = [];
    public List<ProductPriceListSpecificationType> ProductPrices { get; set; } = [];
}
