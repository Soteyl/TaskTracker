using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace TaskTracker.Models.Tasks
{
    public class SetTaskCompletedModel
    {
        [Required]
        public string? Id { get; set; }

        public override string ToString() => $"[{Id}]";
    }
}
