namespace Core.Models.EShop;

public class History(
    int paymentTypeId,
    double sumPrice,
    int addressId,
    int? userId = null,
    int id = default
)
{
    public int Id { get; private set; } = id;
    public int PaymentTypeId { get; private set; } = paymentTypeId;
    public double SumPrice { get; private set; } = sumPrice;
    public int AddressId { get; private set; } = addressId;
    public int? UserId { get; private set; } = userId;
    public DateTime CreatedAt { get; private set; } = DateTime.UtcNow;

    public virtual PaymentType PaymentType { get; set; }
    public virtual Address Address { get; set; }
    public virtual User? User { get; set; }

    public ICollection<ProductRefHistory> ProductRefHistories { get; private set; } = [];
}
