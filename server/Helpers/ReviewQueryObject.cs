

namespace server.Helpers;


public class ReviewQueryObject
{

    public string? SortBy { get; set; } = null;
    public bool IsDescending { get; set; } = false;

    public bool? IsRecommended { get; set; } = null;

    public int PageNumber { get; set; } = 1;

    public int PageSize { get; set; } = 20;
}

