using System.ComponentModel.DataAnnotations;

namespace TaskifyApi.Dto
{
    public class UpdateTaskDto
    {
        [Required]
        public int Id { get; set; }

        [Required(ErrorMessage = "Title is required")]
        public string Title { get; set; } = string.Empty;

        public bool IsCompleted { get; set; }
    }
}
