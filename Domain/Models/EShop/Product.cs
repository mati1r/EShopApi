namespace Core.Models.EShop;

public class Product(
    int subcategoryId,
    string name,
    double price, 
    int quantity,
    string? description1 = null,
    string? description2 = null,
    string? description3 = null,
    string? descriptionPhoto1 = null,
    string? descriptionPhoto2 = null,
    bool hidden = false,
    int id = default
)
{
    public int Id { get; private set; } = id;
    public int SubcategoryId { get; private set; } = subcategoryId;
    public string Name { get; private set; } = name;
    public string? Description1 { get; private set; } = description1;
    public string? Description2 { get; private set; } = description2;
    public string? Description3 { get; private set; } = description3;
    public double Price { get; private set; } = price;
    public string? DescriptionPhoto1 { get; private set; } = descriptionPhoto1;
    public string? DescriptionPhoto2 { get; private set; } = descriptionPhoto2;
    public int Quantity { get; private set; } = quantity;
    public bool Hidden { get; private set; } = hidden;

    public virtual Subcategory Subcategory { get; set; }

    public ICollection<ProductElement> ProductElements { get; private set; } = [];
    public ICollection<ProductPhotos> ProductPhotos { get; private set; } = [];
    public ICollection<ProductRefHistory> ProductRefHistory { get; private set;} = [];
    public ICollection<Photos> Photos { get; private set;} = [];

    public void Update(
        int? subcategoryId,
        string? name,
        double? price,
        int? quantity,
        string? description1,
        string? description2,
        string? description3,
        string? descriptionPhoto1,
        string? descriptionPhoto2
    )
    {
        if(subcategoryId != null) SubcategoryId = (int)subcategoryId;
        if(name != null) Name = name;
        if(description1 != null) Description1 = description1;
        if(description2 != null) Description2 = description2;
        if(description3 != null) Description3 = description3;
        if(price != null) Price = (double)price;
        if(descriptionPhoto1 != null) DescriptionPhoto1 = descriptionPhoto1;
        if(descriptionPhoto2 != null) DescriptionPhoto2 = descriptionPhoto2;
        if(quantity != null) Quantity = (int)quantity;
    }

    public void Delete()
    {
        Hidden = true;
    }

    public void Restore()
    {
        Hidden = false;
    }
}

