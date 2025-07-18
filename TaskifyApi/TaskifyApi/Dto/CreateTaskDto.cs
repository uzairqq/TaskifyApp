using System.ComponentModel.DataAnnotations;

namespace TaskifyApi.Dto
{
    public class CreateTaskDto
    {
        [Required(ErrorMessage = "Title is required")]
        [MinLength(3, ErrorMessage = "Title must be at least 3 characters")]
        public string Title { get; set; } = string.Empty;
    }
}
