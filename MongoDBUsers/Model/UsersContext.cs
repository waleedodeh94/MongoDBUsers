using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace MongoDBUsers.Model
{
    public class UsersContext : IUsersContext
    {
        private readonly IMongoDatabase _db;

        public UsersContext(IOptions<Settings> options, IMongoClient client)
        {

            _db = client.GetDatabase(options.Value.Database);
        }

        public IMongoCollection<Users> Users => _db.GetCollection<Users>("Users");
    }
    
}

