namespace TaskifyAPI.Models
{
    public class Todo
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime DueDate { get; set; }
        public bool IsCompleted { get; set; }
        public string Description { get; set; }
        public int Status { get; set; }
        public bool IsUpdated { get; set; }
        public bool IsDeleted { get; set; }
        public int UserId { get; set; }
    }
}
