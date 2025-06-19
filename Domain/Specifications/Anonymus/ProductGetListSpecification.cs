using System.Linq.Expressions;
using Ardalis.Specification;
using Core.DTO.Core;
using Core.Enums;
using Core.Models.EShop;
using Core.SpecificationTypes.Core;

namespace Core.Specifications.Anonymus;

public class ProductGetListSpecification : Specification<Product, ProductGetListSpecificationType>
{
    public ProductGetListSpecification(int subcategoryId, List<AppFilters>? filters, AppOrderBy orderBy)
    {
        Expression<Func<Product, object?>> orderByExpression = orderBy.OrderBy switch
        {
            OrderByEnum.Name => p => p.Name,
            OrderByEnum.Price => p => p.Price,
            OrderByEnum.Quantity => p => p.Quantity,
            _ => p => p.Id
        };

        var query = Query
            .Select(p => new ProductGetListSpecificationType
            {
                Id = p.Id,
                Name = p.Name,
                Price = p.Price,
                Quantity = p.Quantity,
                Description1 = p.Description1,
                DescriptionPhoto = null,
                ProductElements = p.ProductElements
                    .Select(pe => new ProductElementListSpecificationType
                    {
                        Id = pe.Id,
                        ProductValueId = pe.ProductValueId,
                        ProductValueName = pe.ProductValue.Name,
                        ProductTypeId = pe.ProductTypeId,
                        ProductTypeName = pe.ProductType.Name,
                        ProductTypeFilterId = pe.ProductType.FilterTypeId,
                        ProductTypeFilterName = pe.ProductType.Name
                    })
                    .ToList()
            }).Where(p => p.SubcategoryId == subcategoryId && !p.Hidden);

        if (filters != null)
        {
            foreach (var filter in filters)
            {
                if (filter.FilterTypeId == FilterTypeEnum.MultiSelect && filter.FilterValueIds != null)
                {
                    query.Where(p =>
                        p.ProductElements.Any(pe =>
                            pe.ProductType.FilterTypeId == (int)filter.FilterTypeId &&
                            filter.FilterValueIds.Contains(pe.ProductValueId)
                        )
                    );
                }

                if (filter.FilterTypeId == FilterTypeEnum.SingleSelect && filter.FilterValueIds != null && filter.FilterValueIds.Count == 1)
                {
                    var filterValueId = filter.FilterValueIds.First();
                    query.Where(p =>
                        p.ProductElements.Any(pe =>
                            pe.ProductType.FilterTypeId == (int)filter.FilterTypeId &&
                            filterValueId == pe.ProductValueId
                        )
                    );
                }

                if (filter.FilterTypeId == FilterTypeEnum.Range && filter.FilterRangeMin != null && filter.FilterRangeMax != null)
                {
                    query.Where(p =>
                        p.ProductElements.Any(pe =>
                            pe.ProductType.FilterTypeId == (int)filter.FilterTypeId &&
                            pe.ProductValue.Value >= filter.FilterRangeMin &&
                            pe.ProductValue.Value <= filter.FilterRangeMax
                        )
                    );
                }
            }
        }

        if (orderBy.OrderDirection == OrderDirectionEnum.Asc) query.OrderBy(orderByExpression);
        if (orderBy.OrderDirection == OrderDirectionEnum.Desc) query.OrderByDescending(orderByExpression);

        query.AsTracking();
    }
}
