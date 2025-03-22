using System.ComponentModel.DataAnnotations;

namespace Core.Models.EShop;

public class Category(
    string name, 
    int id = default
)
{
    public int Id { get; private set; } = id;

    [MaxLength(100)]
    public string Name { get; private set; } = name;
    public ICollection<Subcategory> Subcategories { get; private set; } = [];

    public void Update(string name)
    {
        Name = name;
    }

}
