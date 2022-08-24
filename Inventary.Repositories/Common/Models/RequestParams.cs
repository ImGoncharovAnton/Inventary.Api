namespace Inventary.Repositories.Common.Models;

public class RequestParams
{
    private const int maxPageSize = 20;
    public int PageNumber { get; set; } = 1;
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

    public string SearchString { get; set; } = String.Empty;
}