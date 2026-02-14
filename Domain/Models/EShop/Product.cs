namespace Core.Models.EShop;

public class Product(
    int subcategoryId,
    string name,
    double price, 
    int quantity,
    bool hidden = false,
    int id = default
)
{
    public int Id { get; private set; } = id;
    public int SubcategoryId { get; private set; } = subcategoryId;
    public string Name { get; private set; } = name;
    public double Price { get; private set; } = price;
    public int Quantity { get; private set; } = quantity;
    public bool Hidden { get; private set; } = hidden;

    public virtual Subcategory Subcategory { get; set; }

    public ICollection<ProductElement> ProductElements { get; set; } = [];
    public ICollection<ProductPhotos> ProductPhotos { get; set; } = [];
    public ICollection<ProductRefHistory> ProductRefHistory { get; set;} = [];
    public ICollection<ProductDescriptions> ProductDescriptions { get; set; } = [];
    public ICollection<Photos> Photos { get; set;} = [];

    public void Update(
        int? subcategoryId,
        string? name,
        double? price,
        int? quantity
    )
    {
        if(subcategoryId != null) SubcategoryId = (int)subcategoryId;
        if(name != null) Name = name;
        if(price != null) Price = (double)price;
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

