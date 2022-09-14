using TaskTracker.Models.Tasks;

namespace TaskTracker.Services.Interfaces
{
    /// <summary>
    /// Context for handling and storing tasks
    /// </summary>
    public interface ITaskContext
    {
        /// <summary>
        /// Gets tasks list by pagination range
        /// </summary>
        /// <param name="pageNumber">number of the page in pagination</param>
        /// <param name="pageSize">size of the page</param>
        /// <returns>Enumerable of tasks in a range</returns>
        Task<UserTasks> GetTasksPage(int pageNumber, int pageSize);

        /// <summary>
        /// Gets a task by its id
        /// </summary>
        /// <param name="id">id of the task</param>
        /// <returns>task</returns>
        Task<UserTask> GetTaskById(string id);

        /// <summary>
        /// Creates the task by its name
        /// </summary>
        /// <param name="name">Name of the task</param>
        /// <returns>Created task</returns>
        Task<UserTask> CreateTask(string name);

        /// <summary>
        /// Updates a task
        /// </summary>
        /// <param name="task">task to update</param>
        Task UpdateTask(UserTask task);

        /// <summary>
        /// Updates a task by its id.
        /// </summary>
        /// <param name="updateTaskModel">Id of the task and its new name</param>
        /// <returns></returns>
        public async Task UpdateTask(UpdateTaskModel updateTaskModel)
        {
            UserTask task = await GetTaskById(updateTaskModel.Id!);
            task.Name = updateTaskModel.Name;
            await UpdateTask(task);
        }

        /// <summary>
        /// Updates a task and adds complete time for it.
        /// </summary>
        /// <param name="id">task id</param>
        public async Task SetTaskAsCompleted(string id)
        {
            UserTask task = await GetTaskById(id);
            task.CompletedTime = DateTime.UtcNow;
            await UpdateTask(task);
        }
    }
}
