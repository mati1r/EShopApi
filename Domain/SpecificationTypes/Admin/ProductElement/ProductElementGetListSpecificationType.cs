namespace Core.SpecificationTypes.Admin.ProductElement;

public class ProductElementGetListSpecificationType
{
    public int Id { get; set; }
    public int ProductId { get; set; }
    public int ProductValueId { get; set; }
    public string ProductValueName { get; set; }
    public int ProductTypeId { get; set; }
    public string ProductTypeName { get; set; }
    public int ProductTypeFilterId { get; set; }
}
