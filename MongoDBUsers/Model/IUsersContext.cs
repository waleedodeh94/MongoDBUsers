using MongoDB.Driver;

namespace MongoDBUsers.Model
{
    public interface IUsersContext
    {
        IMongoCollection<Users> Users { get; }
    }
}