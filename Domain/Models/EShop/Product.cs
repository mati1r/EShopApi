using Core.Exceptions;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Core.Models.EShop;

public class Product(
    int subcategoryId,
    string name,
    int quantity,
    bool deleted = false,
    int id = default
)
{
    public int Id { get; private set; } = id;
    public int SubcategoryId { get; private set; } = subcategoryId;
    public string Name { get; private set; } = name;
    public int Quantity { get; private set; } = quantity;
    public bool Deleted { get; private set; } = deleted;

    public virtual Subcategory Subcategory { get; set; }

    public ICollection<ProductElement> ProductElements { get; set; } = [];
    public ICollection<ProductPhotos> ProductPhotos { get; set; } = [];
    public ICollection<ProductRefHistory> ProductRefHistory { get; set;} = [];
    public ICollection<ProductDescriptions> ProductDescriptions { get; set; } = [];
    public ICollection<Photos> Photos { get; set;} = [];
    public ICollection<ProductPrice> ProductPrices { get; set; } = [];

    public void Update(
        int? subcategoryId,
        string? name,
        int? quantity
    )
    {
        if(subcategoryId != null) SubcategoryId = (int)subcategoryId;
        if(name != null) Name = name;
        if(quantity != null) Quantity = (int)quantity;
    }

    public void AddPrice(double value, DateOnly dateFrom, DateOnly? dateTo)
    {
        ProductPrices.Add(new ProductPrice(this.Id, value, dateFrom, dateTo));
    }

    public void UpdatePrice(ProductPrice price, double value)
    {
        var currentDate = DateOnly.FromDateTime(DateTime.UtcNow);
        if (price.DateFrom < currentDate)
        {
            price.Update(value);
        }
        else if((price.DateTo ?? DateOnly.MaxValue) >= currentDate)
        {
            var currentDateTo = price.DateTo;
            price.ChangeDate(price.DateFrom, currentDate);
            ProductPrices.Add(new ProductPrice(this.Id, value, price.DateFrom, currentDateTo));
        }else if (price.DateTo < currentDate)
        {
            throw new BadRequestException("Cannot change closed price value, please add new value in appropriate range");
        }
    }

    public void Remove()
    {
        Deleted = true;
    }

    public void Restore()
    {
        Deleted = false;
    }
}

