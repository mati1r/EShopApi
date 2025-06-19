namespace Core.Models.EShop;

public class ProductPhotos(
    int productId,
    string photo,
    int id = default
)
{
    public int Id { get; private set; } = id;
    public int ProductId { get; private set; } = productId;
    public string Photo { get; private set; } = photo;

    public virtual Product Product { get; set; }
}
