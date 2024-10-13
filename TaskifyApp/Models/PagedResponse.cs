namespace TaskifyApp.Models
{
    public class PagedResponse<T>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public int TotalCount { get; set; }
        public int TotalPages { get; set; }
        public Uri FirstPage { get; set; }
        public Uri LastPage { get; set; }
        public Uri NextPage { get; set; }
        public Uri PreviousPage { get; set; }
        public List<T> Data { get; set; }

        public PagedResponse(List<T> data, int pageNumber, int pageSize, int totalCount, int totalPages)
        {
            Data = data;
            PageNumber = pageNumber;
            PageSize = pageSize;
            TotalCount = totalCount;
            TotalPages = totalPages;
        }
    }
}
