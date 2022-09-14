using System.ComponentModel.DataAnnotations;

namespace TaskTracker.Models.Tasks
{
    public class UpdateTaskModel
    {
        [Required]
        public string? Id { get; set; }

        [Required]
        [StringLength(255, MinimumLength = 1)]
        public string? Name { get; set; }

        public override string ToString() => $"[{Id}] {Name}";
    }
}
