using Core.Exceptions;
using Core.IServices.Admin;
using Core.Models.EShop;
using Core.Specifications.Admin.FilterType;
using Core.SpecificationTypes.Common;

namespace Core.Services.Admin;

public class FilterTypeService(
    IRepository<FilterType> filterTypeRepository
) : IFilterTypeService
{
    private readonly IRepository<FilterType> _filterTypeRepository = filterTypeRepository;

    public async Task Add(string name)
    {
        var filterType = new FilterType(name);
        await _filterTypeRepository.AddAsync(filterType);
    }

    public async Task Delete(int id)
    {
        var filterType = await _filterTypeRepository.GetByIdAsync(id) ?? throw new BadRequestException($"Could not found filter type with id {id}");
        await _filterTypeRepository.DeleteAsync(filterType);
    }

    public async Task<List<SelectListSpecificationType>> GetList()
    {
        var filterTypeListSpec = new FilterTypeGetListSpecification();
        return await _filterTypeRepository.ListAsync(filterTypeListSpec);
    }

    public async Task Update(int id, string name)
    {
        var filterType = await _filterTypeRepository.GetByIdAsync(id) ?? throw new BadRequestException($"Could not found filter type with id {id}");
        filterType.Update(name);
        await _filterTypeRepository.SaveChangesAsync();
    }
}
