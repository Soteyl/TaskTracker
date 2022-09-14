using System.ComponentModel.DataAnnotations;

namespace TaskTracker.Models.Tasks
{
    public class CreateTaskModel
    {
        [Required]
        [StringLength(255, MinimumLength =1)]
        public string? Name { get; set; }
    }
}
