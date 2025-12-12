namespace Catalog.Application.Responses;

public class PaginationReponse<T> where T : class
{
    private int pageIndex;
    private int pageSize;
    private long totalCount;

    const int defaultPageSize = 10;
    const int defaultPageIndex = 1;   
    const long defaultTotalCount = 0;
    public PaginationReponse()
    {}
    public PaginationReponse(int pageIndex,
                             int pageSize,
                             long totalCount,
                             List<T> data)
    {
        this.PageIndex = pageIndex;
        this.PageSize = pageSize;
        this.TotalCount = totalCount;
        this.Items = data;
    }

    public int PageIndex 
    { 
        get => pageIndex; 
        set => pageIndex = (value > 0) ? value : defaultPageIndex ; 
    }
    public int PageSize
    {
        get => pageSize;
        set => pageSize = (value > 0) ? value : defaultPageSize;
    }
    public long TotalCount 
    { 
        get=> totalCount;
        set=> totalCount = (value >= 0) ? value : defaultTotalCount;
    }

    public List<T> Items { get; set; }
}
