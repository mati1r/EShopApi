namespace Core.SpecificationTypes.Core;

public class ProductPriceListSpecificationType
{
    public int Id { get; set; }
    public double Value { get; set; }
    public DateOnly DateFrom { get; set; }
    public DateOnly? DateTo { get; set; }
}
