using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace TaskTracker.Models.Tasks
{
    public class GetTaskModel
    {
        [Required]
        public string? Id { get; set; }

        public override string ToString() => $"[{Id}]";
    }
}
