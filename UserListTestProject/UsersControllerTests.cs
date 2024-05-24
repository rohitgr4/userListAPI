using Microsoft.AspNetCore.Routing;
using UserListAPI.Domain;
using UserListAPI;
using Microsoft.Extensions.Configuration;
using NUnit.Framework;
using UserListAPI.Data;
using Moq;
//using NUnit.Framework;

namespace UserListTestProject
{
    public class UsersControllerTests
    {

        private UsersController _controller;
        private Mock<UsersRepository> _userRepositoryMock;


        [SetUp]
        public void Setup(UsersRepository _userRepository)
        {
            // Mock IConfiguration
            var configurationMock = new Mock<IConfiguration>();
            configurationMock.Setup(c => c.GetConnectionString("DefaultConnection"));

            // Mock IUsersRepository
            _userRepositoryMock = new Mock<UsersRepository>();

           // _userRepository = new UsersController(configurationMock.Object);
           
        }

        [Test]
        public void GetUsers_ReturnsCorrectData()
        {
           
            var expectedUsers = new List<Users>
            {
                new Users { UserId = 1, UserName = "Albert Miguel", UserEmail = "albert.miguel@example.com" },
                new Users { UserId = 2, UserName = "Jona", UserEmail = "jane.smith@example.com" },
                new Users { UserId = 3, UserName = "Michael Johnson", UserEmail = "michael.johnson@example.com" },
                new Users { UserId = 4, UserName = "Emily Ross", UserEmail = "emily.ross@example.com" },    
                
            };

            
            var result = _controller.GetUsers();

            // Assert: Verify the result
            Xunit.Assert.NotNull(result.Value); // Ensure result is not null
            Xunit.Assert.Equal(expectedUsers.Count, result.Value.Count()); // Ensure correct number of users returned
            Xunit.Assert.True(expectedUsers.SequenceEqual(result.Value)); // Ensure expected users match returned users
        }
    }
}