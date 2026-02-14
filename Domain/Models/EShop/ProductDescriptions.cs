namespace Core.Models.EShop;

public class ProductDescriptions(int productId, string description, int id = default)
{
    public int Id { get; private set; } = id;
    public int ProductId { get; private set; } = productId;
    public string Description { get; private set; } = description;
    public virtual Product Product { get; set; }

    public void Update(string? description)
    {
        if (description != null) Description = description;
    }
}
