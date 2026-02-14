namespace Core.SpecificationTypes.Admin.ProductPhotos;

public class ProductPhotosGetListSpecificationType
{
    public int Id { get; set; }
    public int ProductId { get; set; }
    public string FileName { get; set; }
    public string Extension { get; set; }
    public byte[] Content { get; set; }
}
