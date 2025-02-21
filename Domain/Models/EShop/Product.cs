using Core.Models.EShop;

namespace EShopApi.Models.EShop;

public class Product(
    int subcategoryId,
    double price, 
    int quantity,
    bool hidden = false,
    int id = default,
    string? description1 = null,
    string? description2 = null,
    string? description3 = null,
    string? descriptionPhoto1 = null,
    string? descriptionPhoto2 = null
)
{
    public int Id { get; private set; } = id;
    public int SubcategoryId { get; private set; } = subcategoryId;
    public string? Description1 { get; private set; } = description1;
    public string? Description2 { get; private set; } = description2;
    public string? Description3 { get; private set; } = description3;
    public double Price { get; private set; } = price;
    public string? DescriptionPhoto1 { get; private set; } = descriptionPhoto1;
    public string? DescriptionPhoto2 { get; private set; } = descriptionPhoto2;
    public int Quantity { get; private set; } = quantity;
    public bool Hidden { get; private set; } = hidden;

    public virtual Subcategory? Subcategory { get; set; }

    public ICollection<ProductElement> ProductElements { get; private set; } = [];
    public ICollection<ProductPhotos> ProductPhotos { get; private set; } = [];
    public ICollection<ProductRefHistory> ProductRefHistory { get; private set;} = [];
    public ICollection<Photos> Photos { get; private set;} = [];
}

