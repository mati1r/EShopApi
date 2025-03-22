using Core.IServices.Admin;
using Core.Models.EShop;
using Core.SpecificationTypes.Admin.ProductType;

namespace Core.Services.Admin;

public class ProductTypeService(
    IRepository<ProductType> productTypeRepository,
    IRepository<FilterType> filterTypeRepository
) : IProductTypeService
{
    private readonly IRepository<ProductType> _productTypeRepository = productTypeRepository;
    private readonly IRepository<FilterType> _filterTypeRepository = filterTypeRepository;

    public Task Add(string name, int filterTypeId)
    {
        throw new NotImplementedException();
    }

    public Task Delete(int id)
    {
        throw new NotImplementedException();
    }

    public Task<List<ProductTypeGetListSpecificationType>> GetList()
    {
        throw new NotImplementedException();
    }

    public Task Update(int id, string name, int filterTypeId)
    {
        throw new NotImplementedException();
    }
}
