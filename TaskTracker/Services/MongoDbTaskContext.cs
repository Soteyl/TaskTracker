using MongoDB.Bson;
using MongoDB.Driver;
using TaskTracker.Models.Tasks;
using TaskTracker.Services.Interfaces;

namespace TaskTracker.Services
{
    public class MongoDbTaskContext : ITaskContext
    {
        private const string ID_KEY = "_id";

        private readonly IMongoCollection<UserTask> _tasks;

        public MongoDbTaskContext()
        {
            string connectionString = "mongodb://localhost:27017/TaskTracker";
            var connection = new MongoUrlBuilder(connectionString);
            var client = new MongoClient(connectionString);
            IMongoDatabase database = client.GetDatabase(connection.DatabaseName);
            _tasks = database.GetCollection<UserTask>("tasks");
        }

        public async Task<UserTask> CreateTask(string name)
        {
            var task = new UserTask { Id = ObjectId.GenerateNewId().ToString(), 
                                      CreatedTime = DateTime.UtcNow, 
                                      Name = name };
            await _tasks.InsertOneAsync(task);

            return task;
        }

        public async Task<UserTask> GetTaskById(string id)
        {
            return await _tasks.Find(new BsonDocument(ID_KEY, new ObjectId(id))).FirstOrDefaultAsync();
        }

        public async Task<UserTasks> GetTasksPage(int pageNumber, int pageSize)
        {
            var cursor = _tasks.Find(Builders<UserTask>.Filter.Empty);
            cursor.SortBy(t => t.CreatedTime)
                  .Skip((pageNumber - 1) * pageSize)
                  .Limit(pageSize);

            return new UserTasks { Tasks = await cursor.ToListAsync() };
        }

        public async Task UpdateTask(UserTask task)
        {
            await _tasks.ReplaceOneAsync(new BsonDocument(ID_KEY, new ObjectId(task.Id)), task);
        }
    }
}
