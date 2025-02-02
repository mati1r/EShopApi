namespace Core.SpecificationTypes.Core;

public class SpecificationListAggregation<T>
{
    public List<T> list { get; set; } = new List<T>();
    public int total { get; set; }
    public int page { get; set; }
}
