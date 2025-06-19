namespace Core.SpecificationTypes.Core;

public class ProductElementListSpecificationType
{
    public int Id { get; set; }
    public int ProductValueId { get; set; }
    public string ProductValueName { get; set; }
    public int ProductTypeId { get; set; }
    public string ProductTypeName { get; set; }
    public int ProductTypeFilterId { get; set; }
    public string ProductTypeFilterName { get; set; }
}
