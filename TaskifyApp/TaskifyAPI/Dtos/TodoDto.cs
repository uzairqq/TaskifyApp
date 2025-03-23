using System.ComponentModel.DataAnnotations;

namespace TaskifyAPI.Dtos
{
    public class TodoDto
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Title is required.")]
        [MaxLength(100, ErrorMessage = "Title must be at most 100 characters.")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Description is required.")]
        [MaxLength(500, ErrorMessage = "Description must be at most 500 characters.")]
        public string Description { get; set; }
        [Required(ErrorMessage = "DueDate is required.")]
        [DataType(DataType.Date)]
        public DateTime DueDate { get; set; }
        public bool IsCompleted { get; set; }
        [Range(0, 5, ErrorMessage = "Status must be between 0 and 5.")]
        public int Status { get; set; }
        public bool IsUpdated { get; set; }
        public bool IsDeleted { get; set; }
        [Required(ErrorMessage = "UserId is required.")]
        [Range(1, int.MaxValue, ErrorMessage = "UserId must be greater than 0.")]
        public int UserId { get; set; }

    }
}
