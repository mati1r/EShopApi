namespace Core.Models.EShop;

public class ProductDescriptions(int productId, string description, bool deleted = false, int id = default)
{
    public int Id { get; private set; } = id;
    public int ProductId { get; private set; } = productId;
    public string Description { get; private set; } = description;
    public bool Deleted { get; private set; } = deleted;
    public virtual Product Product { get; set; }

    public void Update(string? description)
    {
        if (description != null) Description = description;
    }

    public void Restore()
    {
        Deleted = false;
    }

    public void Remove()
    {
        Deleted = true;
    }
}
