using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace MongoDBUsers.Model
{
    public class CompanyContext : ICompanyContext
    {
        private readonly IMongoDatabase _db;

        public CompanyContext(IOptions<Settings> options, IMongoClient client)
        {

            _db = client.GetDatabase(options.Value.Database);
        }


        public IMongoCollection<Company> Company => _db.GetCollection<Company>("Company");

       
    }
}