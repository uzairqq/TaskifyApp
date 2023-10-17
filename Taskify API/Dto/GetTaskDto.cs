namespace Taskify_API.Dto
{
    public class GetTaskDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime CreatedDateAndTime { get; set; }
        public DateTime DueDateAndTime { get; set; }
        public string Priority { get; set; }
        public bool IsComplete { get; set; } = false;
    }
}
