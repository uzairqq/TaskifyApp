using System.ComponentModel.DataAnnotations;

namespace Taskify_API.Models
{
    public class Task
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        [StringLength(250)]
        public string Description { get; set; }
        public DateTime CreatedDateAndTime { get; set; }
        public DateTime DueDateAndTime { get; set; }
        public string Priority { get; set; }
        public bool IsComplete { get; set; } = false;
    }
}
