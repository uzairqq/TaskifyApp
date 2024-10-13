namespace TaskifyApp.Models
{
    public class PaginationFilter
    {
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 10;
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public bool? IsCompleted { get; set; } // Add a nullable boolean for filtering by completion status
        public DateTime? DueDate { get; set; } // Add a nullable datetime for filtering by due date
    }
}
