using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace TaskTracker.Models.Tasks
{
    public class GetTasksPageModel
    {
        [Range(1, Int32.MaxValue)]
        public int PageNumber { get; set; } = 1;

        [Range(1, Int32.MaxValue)]
        public int PageSize { get; set; } = 10;

        public override string ToString() => $"[#{PageNumber}] Size: {PageSize}";
    }
}
