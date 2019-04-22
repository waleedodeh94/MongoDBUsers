using MongoDB.Driver;

namespace MongoDBUsers.Model
{
    // Users Abstraction
    public interface IUsersContext
    {
        IMongoCollection<Users> Users { get; }
    }
}