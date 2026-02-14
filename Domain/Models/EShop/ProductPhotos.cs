namespace Core.Models.EShop;

public class ProductPhotos(
    int productId,
    string fileName,
    string generatedName,
    bool deleted = false,
    int id = default
)
{
    public int Id { get; private set; } = id;
    public int ProductId { get; private set; } = productId;
    public string FileName { get; private set; } = fileName;
    public string GeneratedName { get; private set; } = generatedName;
    public bool Deleted { get; private set; } = deleted;

    public virtual Product Product { get; set; }

    public void Remove()
    {
        Deleted = true;
    }

    public void Restore()
    {
        Deleted = false;
    }
}
