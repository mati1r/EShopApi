namespace EShopApi.Models.EShop;

public class PaymentType(
    string name, 
    int id = default
)
{
    public int Id { get; private set; } = id;
    public string Name { get; private set; } = name;

    public ICollection<History> Histories { get; private set; } = [];
}
