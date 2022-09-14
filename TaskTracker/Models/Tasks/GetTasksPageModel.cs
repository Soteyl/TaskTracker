using System.ComponentModel.DataAnnotations;

namespace TaskTracker.Models.Tasks
{
    public class GetTasksPageModel
    {
        [Range(1, Int32.MaxValue)]
        public int PageNumber { get; set; } = 1;

        [Range(1, Int32.MaxValue)]
        public int PageSize { get; set; } = 10;
    }
}
