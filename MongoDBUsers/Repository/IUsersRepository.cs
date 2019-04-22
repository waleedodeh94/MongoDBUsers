using System.Collections.Generic;
using System.Threading.Tasks;
using MongoDBUsers.Model;


namespace MongoDBUsers.Repository
{
    //contains an interface that defines the user services
    public interface IUsersRepository
    {
        Task<IEnumerable<Users>> GetAllUsers();
        Task<Users> GetUserbyName(string name, string username, string password);
        Task<Users> GetUserbyuserName(string username, string Username, string password);
        Task<Users> GetUserbyZipCode(string zipcode, string Username, string password);
        Task<Users> GetUserbyCompanyName(string name, string Username, string password);
        Task<Users> GetUserById(int id, string username, string password);
        Task Create(Users user, string username, string password);
        Task<bool> Update(Users user, string username, string password);
        Task<bool> Delete(int id, string username, string password);
    }
}