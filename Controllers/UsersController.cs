using Microsoft.AspNetCore.Mvc;
using UserListAPI.Data;
using UserListAPI.Domain;

namespace UserListAPI
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {

        private readonly UsersRepository _userRepository;

        public UsersController(IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection");
            _userRepository = new UsersRepository(connectionString);
        }
        /*private static readonly List<Users> Users = new List<Users>
        {
            new Users { UserId = 1, UserName = "Albert Miguel", UserEmail = "albert.miguel@example.com" },
            new Users { UserId = 2, UserName = "Jona", UserEmail = "jane.smith@example.com" },
            new Users { UserId = 3, UserName = "Michael Johnson", UserEmail = "michael.johnson@example.com" },
            new Users { UserId = 4, UserName = "Emily Ross", UserEmail = "emily.ross@example.com" },            
        };*/

        [HttpGet]        
        public ActionResult<IEnumerable<Users>> GetUsers()
        {
            var users = _userRepository.GetUsers();
            return users;
        }
    }

}
