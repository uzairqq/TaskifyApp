namespace TaskifyAPI.Dto
{
    public class TaskReadDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public bool IsCompleted { get; set; }
    }
}
