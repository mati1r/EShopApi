namespace Core.Models.EShop;

public class Photos(int productId, string storageFolder, string storageFileName, string fileName, int id = default)
{
    public int Id { get; private set; } = id;
    public int ProductId { get; private set; } = productId;
    public string StorageFolder { get; private set; } = storageFolder;
    public string StorageFileName { get; private set; } = storageFileName;
    public string FileName { get; private set; } = fileName;

    public virtual Product? Product { get; set; }
}
