namespace Ecommerce.Helpers
{
    public class ProductQueryObject
    {
        public  string? Name { get; set; }
        public decimal? Price { get; set; }
        public String? Category { get; set; } = null;
        public String? SortBy { get; set; } = null;
        public bool IsDesc { get; set; } = false;
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 6;
    }
}
