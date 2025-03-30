namespace Core.IServices.Admin;

public interface ISubcategoryRefProductTypeService
{
    public Task Add(int subcategoryId, int productTypeId);
    public Task Delete(int subcategoryId, int productTypeId);
}
