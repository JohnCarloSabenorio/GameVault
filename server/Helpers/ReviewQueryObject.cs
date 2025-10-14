

namespace server.Helpers;


public class ReviewQueryObject
{
    public bool? IsRecommended { get; set; } = null;

    public int PageNumber { get; set; } = 1;

    public int PageSize { get; set; } = 20;
}

