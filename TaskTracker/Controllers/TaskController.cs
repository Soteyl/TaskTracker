using Microsoft.AspNetCore.Mvc;
using TaskTracker.Models.Tasks;
using TaskTracker.Services.Interfaces;

namespace TaskTracker.Controllers
{
    /// <summary>
    /// Controller for tasks
    /// </summary>
    /// <remarks>
    /// <c>URL: /tasks</c>
    /// </remarks> 
    [Route("[controller]")]
    public class TasksController
    {
        private readonly ITaskRepository _taskContext;

        public TasksController(ITaskRepository context)
        {
            _taskContext = context;
        }

        /// <summary>
        /// Gets specific task.
        /// </summary>
        /// <remarks>
        /// <c>GET: /tasks/{model.id}</c>
        /// </remarks>
        /// <param name="model">Model contains id of the task to get.</param>
        /// <returns>Found task</returns>
        [HttpGet("{model.Id}")]
        public async Task<ActionResult<UserTask>> GetTask(GetTaskModel model)
        {
            return await _taskContext.GetById(model.Id!);
        }

        /// <summary>
        /// Gets tasks list
        /// </summary>
        /// <remarks>
        /// <c>GET: /tasks</c>
        /// </remarks>
        /// <param name="model">Pagination range</param>
        /// <returns>Enumerable of tasks</returns>
        [HttpGet("")]
        public async Task<ActionResult<UserTasks>> GetTasksPage([FromQuery] GetTasksPageModel model)
        {
            return await _taskContext.GetPage(model.PageNumber, model.PageSize);
        }

        /// <summary>
        /// Creates task by its name
        /// </summary>
        /// <remarks>
        /// <c>POST: /tasks</c>
        /// </remarks>
        /// <param name="model">Name of the task</param>
        /// <returns>Created task</returns>
        [HttpPost("")]
        public async Task<ActionResult<UserTask>> CreateTask([FromBody] CreateTaskModel model)
        {
            return await _taskContext.Create(model.Name!);
        }

        /// <summary>
        /// Updates name of the task by its id
        /// </summary>
        /// <remarks>
        /// <c>PUT: /tasks</c>
        /// </remarks>
        /// <param name="model">id and new name</param>
        [HttpPut("")]
        public async Task UpdateTask([FromBody] UpdateTaskModel model)
        {
            await _taskContext.Update(model);
        }
        
        /// <summary>
        /// Sets task as completed task
        /// </summary>
        /// <remarks>
        /// POST: /tasks/{model.id}/complete
        /// </remarks>
        /// <param name="model">Id of the task</param>
        [HttpPost("{model.Id}/complete")]
        public async Task SetTaskAsCompleted(SetTaskCompletedModel model)
        {
            await _taskContext.SetAsCompleted(model.Id!);
        }
    }
}
