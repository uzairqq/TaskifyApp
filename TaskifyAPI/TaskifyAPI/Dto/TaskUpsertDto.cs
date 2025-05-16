using System.ComponentModel.DataAnnotations;

namespace TaskifyAPI.Dto
{
    public class TaskUpsertDto
    {
        [Required(ErrorMessage = "Title is required")]
        [MaxLength(100, ErrorMessage = "Title cannot exceed 100 characters")]
        public string Title { get; set; }
        [MaxLength(500, ErrorMessage = "Description cannot exceed 500 characters")]
        public string? Description { get; set; }
        public bool IsCompleted { get; set; }
    }
}
