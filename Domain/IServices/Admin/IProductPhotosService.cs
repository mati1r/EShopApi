using Core.DTO.Core;
using Core.SpecificationTypes.Admin.ProductPhotos;
using Core.SpecificationTypes.Core;

namespace Core.IServices.Admin;

public interface IProductPhotosService
{
    public Task<SpecificationListAggregation<ProductPhotosGetListSpecificationType>> GetList(int productId, AppPaginationList pagination, AppOrderBy orderBy, bool deleted);
    public Task<ProductPhotosGetListSpecificationType> Get(int id);
    public Task Add(int productId, FileModel file);
    public Task Update(int id, FileModel file);
    public Task Delete(int id);
    public Task Restore(int id);
}
