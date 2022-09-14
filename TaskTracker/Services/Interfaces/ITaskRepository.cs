using TaskTracker.Models.Tasks;

namespace TaskTracker.Services.Interfaces
{
    /// <summary>
    /// Context for handling and storing tasks
    /// </summary>
    public interface ITaskRepository
    {
        /// <summary>
        /// Gets tasks list by pagination range
        /// </summary>
        /// <param name="pageNumber">number of the page. Min: 1</param>
        /// <param name="pageSize">Size of the page. Min: 1</param>
        /// <returns>Enumerable of tasks in a range</returns>
        Task<UserTasks> GetPage(int pageNumber, int pageSize);

        /// <summary>
        /// Gets a task by its id
        /// </summary>
        Task<UserTask> GetById(string taskId);

        /// <summary>
        /// Creates the task by its name
        /// </summary>
        /// <returns>Created task</returns>
        Task<UserTask> Create(string taskName);

        /// <summary>
        /// Updates a task
        /// </summary>
        Task Update(UserTask task);

        /// <summary>
        /// Updates a task by its id.
        /// </summary>
        /// <param name="updateTaskModel">Id of the task and its new name (1-255 chars)</param>
        public async Task Update(UpdateTaskModel updateTaskModel)
        {
            UserTask task = await GetById(updateTaskModel.Id!);
            task.Name = updateTaskModel.Name;
            await Update(task);
        }

        /// <summary>
        /// Updates a task and adds complete time for it.
        /// </summary>
        public async Task SetAsCompleted(string taskId)
        {
            UserTask task = await GetById(taskId);
            task.CompletedTime = DateTime.UtcNow;
            await Update(task);
        }
    }
}
