using MongoDB.Driver;

namespace MongoDBUsers.Model
{
    public interface ICompanyContext
    {
        IMongoCollection<Company> Company { get; }
    }
}