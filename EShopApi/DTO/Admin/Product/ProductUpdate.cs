namespace Application.DTO.Admin.Product;

public class ProductUpdate
{
    public int Id { get; set; }
    public int? SubcategoryId { get; set; }
    public string? Name { get; set; }
    public string? Description1 { get; set; }
    public string? Description2 { get; set; }
    public string? Description3 { get; set; }
    public double? Price { get; set; }
    public string? DescriptionPhoto1 { get; set; }
    public string? DescriptionPhoto2 { get; set; }
    public int? Quantity { get; set; }
}
