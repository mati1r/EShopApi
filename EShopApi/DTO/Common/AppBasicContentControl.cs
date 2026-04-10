using Core.DTO.Core;

namespace Application.DTO.Common;

public class AppBasicContentControl
{
    public AppPaginationList Pagination { get; set; }
    public AppOrderBy OrderBy { get; set; }
}
