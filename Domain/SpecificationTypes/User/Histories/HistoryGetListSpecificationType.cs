namespace Core.SpecificationTypes.User.Histories;

public class HistoryGetListSpecificationType
{
    public int HistoryId { get; set; }
    public DateTime CreatedAt { get; set; }
    public double SumPrice { get; set; }
    public string PaymentTypeName { get; set; }
    public List<string> ProductNames { get; set; } = [];
}
