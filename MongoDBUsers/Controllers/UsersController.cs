using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using MongoDBUsers.Model;
using MongoDBUsers.Repository;

namespace MongoDBUsers.Controllers
{
    [Produces("application/json")]
    [Route("api/Users")]
    public class UsersController : Controller
    {
        private readonly IUsersRepository _UserRepository;


        public UsersController(IUsersRepository userRepository)
        {
            _UserRepository = userRepository;
        }

        // GET: api/user
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return new ObjectResult(await _UserRepository.GetAllUsers());
        }

        // GET: api/user/name
        [HttpGet("GetByname")]
        public async Task<IActionResult> GetByname(string name, string username, string password)
        {
            var user = await _UserRepository.GetUserbyName(name, username, password);

            if (user == null)
                return new NotFoundResult();

            return new ObjectResult(user);
        }

        // GET: api/user/name
        [HttpGet("GetByUsername")]
        public async Task<IActionResult> GetByUsername(string username, string Username, string password)
        {
            var user = await _UserRepository.GetUserbyuserName(username, Username, password);

            if (user == null)
                return new NotFoundResult();

            return new ObjectResult(user);
        }
        // GET: api/user/id
        [HttpGet("GetById")]
        public async Task<IActionResult> GetById(int id, string username, string password)
        {
            var user = await _UserRepository.GetUserById(id, username, password);

            if (user == null)
                return new NotFoundResult();

            return new ObjectResult(user);
        }
        [HttpGet("GetZipCode")]
        public async Task<IActionResult> GetZipCode(string zipcode, string Username, string password)
        {
            var user = await _UserRepository.GetUserbyZipCode(zipcode, Username, password);

            if (user == null)
                return new NotFoundResult();

            return new ObjectResult(user);
        }
        [HttpGet("GetByCompanyName")]
        public async Task<IActionResult> GetByCompanyName(string name, string Username, string password)
        {
            var user = await _UserRepository.GetUserbyCompanyName(name, Username, password);

            if (user == null)
                return new NotFoundResult();

            return new ObjectResult(user);
        }
        // POST: api/user
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]Users user, string username, string password)
        {
            await _UserRepository.Create(user, username, password);
            return new OkObjectResult(user);
        }

        // PUT: api/user/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, string username, string password, [FromBody]Users user)
        {
            var UserFromDb = await _UserRepository.GetUserById(id, username, password);

            if (UserFromDb == null)
                return new NotFoundResult();

            user._Id = UserFromDb._Id;

            await _UserRepository.Update(user, username, password);

            return new OkObjectResult(user);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id, string username, string password)
        {
            var userFromDb = await _UserRepository.GetUserById(id, username, password);

            if (userFromDb == null)
                return new NotFoundResult();

            await _UserRepository.Delete(id, username, password);

            return new OkResult();
        }
    }
}
