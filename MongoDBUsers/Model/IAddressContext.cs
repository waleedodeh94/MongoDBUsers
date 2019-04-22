using MongoDB.Driver;

namespace MongoDBUsers.Model
{
    public interface IAddressContext
    {
        IMongoCollection<Address> Address { get; }
    }
}