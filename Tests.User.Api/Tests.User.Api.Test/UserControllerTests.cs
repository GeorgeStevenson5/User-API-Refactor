using Microsoft.AspNetCore.Mvc;
using Tests.User.Api.Controllers;

namespace Tests.User.Api.Test
{
    public class UserControllerTests
    {
        [Fact]
        public async Task Should_Return_User_When_Valid_Id_Passed()
        {
            DatabaseContext database = new DatabaseContext();
            Models.User user = new Models.User
            {
                FirstName = "Test",
                LastName = "User",
                Age = 20
            };
            database.Users.Add(user);
            database.SaveChanges();

            UserController controller = new UserController();
            IActionResult result = controller.Get(user.Id);
            OkObjectResult ok = result as OkObjectResult;           
  
            Assert.NotNull(ok);
            Assert.Equal(200, ok.StatusCode);            
        }

        [Fact]
        public async Task Should_Return_Valid_When_User_Created()
        {
            UserController controller = new UserController();
            IActionResult result = controller.Create(new Models.UserAddModel
            {
                FirstName = "Test",
                LastName = "User",
                Age = 20
            });
            Assert.NotNull(result);

            OkObjectResult ok = result as OkObjectResult;

            Assert.NotNull(result);
            Assert.Equal(200, ok.StatusCode);
        }

        [Fact]
        public async Task Should_Return_Valid_When_User_Updated()
        {
            DatabaseContext database = new DatabaseContext();
            Models.User user = new Models.User
            {
                FirstName = "Test",
                LastName = "User",
                Age = 20
            };
            database.Users.Add(user);
            database.SaveChanges();

            UserController controller = new UserController();
            IActionResult result = controller.Update(new Models.User
            {
                Id = user.Id,
                FirstName = "Updated",
                LastName = "User",
                Age = 20
            });

            OkObjectResult ok = result as OkObjectResult;

            Assert.NotNull(ok);
            Assert.Equal(200, ok.StatusCode);
        }

        [Fact]
        public async Task Should_Return_Valid_When_User_Removed()
        {
            DatabaseContext database = new DatabaseContext();
            Models.User user = new Models.User
            {
                FirstName = "Test",
                LastName = "User",
                Age = 20
            };
            database.Users.Add(user);
            database.SaveChanges();

            UserController controller = new UserController();
            IActionResult result = controller.Delete(user.Id);

            OkResult ok = result as OkResult;

            Assert.NotNull(ok);
            Assert.Equal(200, ok.StatusCode);
        }
    }
}