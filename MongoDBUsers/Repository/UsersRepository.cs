using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDBUsers.Model;

namespace MongoDBUsers.Repository
{
    //this class s responsible for all database interaction and core business logic related to user
    public class UsersRepository : IUsersRepository
    {
        private readonly IUsersContext _context;

        public UsersRepository(IUsersContext context)
        {
            _context = context;
        }



        public async Task<IEnumerable<Users>> GetAllUsers()
        {
            return await _context
                            .Users
                            .Find(_ => true)
                            .ToListAsync();
        }

        public Task<Users> GetUserbyName(string name, string username, string password)
        {
            FilterDefinition<Users> filter = Builders<Users>.Filter.Eq(m => m.name, name);

            return _context
                    .Users
                    .Find(filter)
                    .FirstOrDefaultAsync();
        }

        public Task<Users> GetUserbyuserName(string username, string Username, string password)
        {
            FilterDefinition<Users> filter = Builders<Users>.Filter.Eq(m => m.username, username);

            return _context
                .Users
                .Find(filter)
                .FirstOrDefaultAsync();
        }

        public Task<Users> GetUserById(int id, string username, string password)
        {
            FilterDefinition<Users> filter = Builders<Users>.Filter.Eq(m => m.id, id);

            var user = _context
                .Users
                .Find(filter)
                .FirstOrDefaultAsync();
            return user;
        }


        public Task<Users> GetUserbyZipCode(string zipcode, string Username, string password)
        {
            FilterDefinition<Users> filter = Builders<Users>.Filter.Eq(m => m.address.zipcode, zipcode);

            return _context
                .Users
                .Find(filter)
                .FirstOrDefaultAsync();
        }


        public Task<Users> GetUserbyCompanyName(string name, string Username, string password)
        {
            FilterDefinition<Users> filter = Builders<Users>.Filter.Eq(m => m.company.name, name);

            return _context
                .Users
                .Find(filter)
                .FirstOrDefaultAsync();
        }
        public async Task Create(Users User, string username, string password)
        {

            await _context.Users.InsertOneAsync(User);
        }

        public async Task<bool> Update(Users user, string username, string password)
        {

            ReplaceOneResult updateResult =
                await _context
                        .Users
                        .ReplaceOneAsync(
                            filter: g => g._Id == user._Id,
                            replacement: user);

            return updateResult.IsAcknowledged
                    && updateResult.ModifiedCount > 0;
        }

        public async Task<bool> Delete(int id, string username, string password)
        {
            FilterDefinition<Users> filter = Builders<Users>.Filter.Eq(m => m.id, id);

            DeleteResult deleteResult = await _context
                                                .Users
                                                .DeleteOneAsync(filter);

            return deleteResult.IsAcknowledged
                && deleteResult.DeletedCount > 0;
        }
    }
}