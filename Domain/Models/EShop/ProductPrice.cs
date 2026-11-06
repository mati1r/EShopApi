namespace Core.Models.EShop;

public class ProductPrice(int productId, double value, DateOnly dateFrom, DateOnly? dateTo, bool deleted = false, int id = default)
{
    public int Id { get; private set; } = id;
    public int ProductId { get; private set; } = productId;
    public double Value { get; private set; } = value;
    public DateOnly DateFrom { get; private set; } = dateFrom;
    //Current price is the one with dateTo set as null, or the one that is closest to current date if there are any set to the future
    public DateOnly? DateTo { get; private set; } = dateTo;
    public bool Deleted { get; private set; } = deleted;
    //Currently wihout currency could be added in the future

    public virtual Product Product { get; set; }

    public void Update(double value)
    {
        Value = value;
    }

    public void ChangeDate(DateOnly dateFrom, DateOnly? dateTo)
    {
        DateFrom = dateFrom;
        DateTo = dateTo;
    }
}
