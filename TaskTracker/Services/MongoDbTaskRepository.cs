using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;
using TaskTracker.Models.Tasks;
using TaskTracker.Services.Interfaces;

namespace TaskTracker.Services
{
    /// <summary>
    /// MongoDB implementation of <see cref="ITaskRepository"/>
    /// </summary>
    public class MongoDbTaskRepository : ITaskRepository
    {
        private const string ID_KEY = "_id";

        private readonly IMongoCollection<UserTask> _tasks;

        public MongoDbTaskRepository(IOptions<MongoDbConfig> mongoDbConfig)
        {
            MongoDbConfig config = mongoDbConfig.Value;
            var connection = new MongoUrlBuilder(config.ConnectionString);
            var client = new MongoClient(config.ConnectionString);
            IMongoDatabase database = client.GetDatabase(connection.DatabaseName);
            _tasks = database.GetCollection<UserTask>("tasks");
        }

        public async Task<UserTask> Create(string taskName)
        {
            var task = new UserTask { Id = ObjectId.GenerateNewId().ToString(), 
                                      CreatedTime = DateTime.UtcNow, 
                                      Name = taskName };
            await _tasks.InsertOneAsync(task);

            return task;
        }

        public Task<UserTask> GetById(string taskId) =>
             _tasks.Find(new BsonDocument(ID_KEY, new ObjectId(taskId))).FirstOrDefaultAsync();

        public async Task<UserTasks> GetPage(int pageNumber, int pageSize)
        {
            IFindFluent<UserTask, UserTask> cursor = _tasks.Find(Builders<UserTask>.Filter.Empty)
                                                           .SortBy(t => t.CreatedTime)
                                                           .Skip((pageNumber - 1) * pageSize)
                                                           .Limit(pageSize);

            return new UserTasks { Tasks = await cursor.ToListAsync() };
        }

        public Task Update(UserTask task) =>
            _tasks.ReplaceOneAsync(new BsonDocument(ID_KEY, new ObjectId(task.Id)), task);
    }
}
