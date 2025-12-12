namespace Catalog.Application.Dtos;
public class PaginationSpecParams
{
    public int PageIndex { get; set; } = 1;
    public int PageSize { get; set; } = 10;
    public string Search { get; set; } = string.Empty;
    public string Sort { get; set; } = string.Empty;
    public string TypeId { get; set; } = string.Empty;
    public string BrandId { get; set; } = string.Empty;
    public SortOrder SortOrder{ get; set; } = SortOrder.Ascending;
}

public enum SortOrder
{
    Ascending = 0,
    Descending
} 
