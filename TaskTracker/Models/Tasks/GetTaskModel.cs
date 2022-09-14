using System.ComponentModel.DataAnnotations;

namespace TaskTracker.Models.Tasks
{
    public class GetTaskModel
    {
        [Required]
        public string? Id { get; set; }
    }
}
