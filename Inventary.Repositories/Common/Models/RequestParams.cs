using Inventary.Domain.Enums;

namespace Inventary.Repositories.Common.Models;

public class RequestParams
{
    private const int maxPageSize = 20;
    public int PageIndex { get; set; } = 1;
    private int _pageSize = 5;

    public int PageSize
    {
        get
        {
            return _pageSize;
        }
        set
        {
            _pageSize = (value > maxPageSize) ? maxPageSize : value;
        }
    }

    public string? SortOrderBy { get; set; }
    public string? SearchString { get; set; }
    public string? FilterBySetup { get; set; }
    public string? FilterByRoom { get; set; }
    public StatusEnum.StatusType? FilterByStatus { get; set; }
    public DateTime? FilterByDateStart { get; set; }
    public DateTime? FilterByDateEnd { get; set; }
    public double? FilterByPriceStart { get; set; }
    public double? FilterByPriceEnd { get; set; }
}