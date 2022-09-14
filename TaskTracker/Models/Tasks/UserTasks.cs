using System.Xml.Linq;

namespace TaskTracker.Models.Tasks
{
    public class UserTasks
    {
        public IEnumerable<UserTask>? Tasks { get; set; }

        public override string ToString() => $"{Tasks?.Count() ?? 0} tasks";
    }
}
