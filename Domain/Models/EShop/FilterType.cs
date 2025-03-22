namespace Core.Models.EShop;

public class FilterType(string name, int id = default)
{
    public int Id { get; private set; } = id;
    public string Name { get; private set; } = name;

    public ICollection<ProductType> ProductTypes { get; private set; } = [];

    public void Update(string name)
    {
        Name = name;
    }
}
