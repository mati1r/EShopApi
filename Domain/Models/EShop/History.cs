namespace EShopApi.Models.EShop;

public class History(
    int paymentTypeId,
    double sumPrice,
    int id = default
)
{
    public int Id { get; private set; } = id;
    public int PaymentTypeId { get; private set; } = paymentTypeId;
    public double SumPrice { get; private set; } = sumPrice;

    public virtual PaymentType? PaymentType { get; set; }

    public ICollection<ProductRefHistory> ProductRefHistories { get; private set; } = [];
}
