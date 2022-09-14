using System.ComponentModel.DataAnnotations;

namespace TaskTracker.Models.Tasks
{
    public class SetTaskCompletedModel
    {
        [Required]
        public string? Id { get; set; }
    }
}
