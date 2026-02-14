namespace Core.Models.EShop;

public class ProductPhotos(
    int productId,
    string fileName,
    string generatedName,
    int id = default
)
{
    public int Id { get; private set; } = id;
    public int ProductId { get; private set; } = productId;
    public string FileName { get; private set; } = fileName;
    public string GeneratedName { get; private set; } = generatedName;

    public virtual Product Product { get; set; }
}
