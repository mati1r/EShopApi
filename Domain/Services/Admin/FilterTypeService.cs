using Core.DTO.Core;
using Core.Exceptions;
using Core.IServices.Admin;
using Core.Models.EShop;
using Core.Specifications.Admin.FilterType;
using Core.SpecificationTypes.Core;

namespace Core.Services.Admin;

public class FilterTypeService(
    IRepository<FilterType> filterTypeRepository
) : IFilterTypeService
{
    private readonly IRepository<FilterType> _filterTypeRepository = filterTypeRepository;

    public async Task<SpecificationListAggregation<SelectListSpecificationType>> GetList(AppPaginationList pagination, AppOrderBy orderBy)
    {
        var filterTypeListSpec = new FilterTypeGetListSpecification(orderBy);
        return await _filterTypeRepository.AppListAsync(filterTypeListSpec, pagination.PerPage, pagination.Page);
    }

    public async Task Add(string name)
    {
        var filterType = new FilterType(name);
        await _filterTypeRepository.AddAsync(filterType);
    }

    public async Task Update(int id, string name)
    {
        var filterType = await _filterTypeRepository.GetByIdAsync(id) ?? throw new BadRequestException($"Could not found filter type with id {id}");
        filterType.Update(name);
        await _filterTypeRepository.SaveChangesAsync();
    }

    public async Task Delete(int id)
    {
        var filterType = await _filterTypeRepository.GetByIdAsync(id) ?? throw new BadRequestException($"Could not found filter type with id {id}");
        await _filterTypeRepository.DeleteAsync(filterType);
    }
}
