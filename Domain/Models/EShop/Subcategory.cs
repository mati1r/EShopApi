namespace EShopApi.Models.EShop;

public class Subcategory(
    int categoryId, 
    string name, 
    int id = default
)
{
    public int Id { get; private set; } = id;
    public int CategoryId { get; private set; } = categoryId;
    public string Name { get; private set; } = name;

    public virtual Category? Category { get; set; }

    public ICollection<Product> Products { get; private set; } = [];
}
