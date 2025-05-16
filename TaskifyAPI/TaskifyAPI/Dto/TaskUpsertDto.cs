namespace TaskifyAPI.Dto
{
    public class TaskUpsertDto
    {
        public string Title { get; set; }
        public string? Description { get; set; }
        public bool IsCompleted { get; set; }
    }
}
