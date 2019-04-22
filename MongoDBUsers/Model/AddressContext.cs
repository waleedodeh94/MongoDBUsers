using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace MongoDBUsers.Model
{
    public class AddressContext : IAddressContext
    {
        private readonly IMongoDatabase _db;

        public AddressContext(IOptions<Settings> options, IMongoClient client)
        {

            _db = client.GetDatabase(options.Value.Database);
        }

        public IMongoCollection<Address> Address => _db.GetCollection<Address>("Address");

    }
    
}