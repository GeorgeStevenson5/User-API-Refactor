using Microsoft.AspNetCore.Mvc;

namespace Tests.User.Api.Controllers
{
    public class UserController : Controller
    {
        /// <summary>
        ///     Gets a user
        /// </summary>
        /// <param name="id">ID of the user</param>
        /// <returns></returns>
        [HttpGet]
        [Route("api/users")]
        public IActionResult Get(int id)
        {
            using (var database = new DatabaseContext()){
                try
                {
                    Models.User user = database.Users.Where(user => user.Id == id).First();
                    return Ok(user);
                }
                catch (Exception ex)
                {
                    return NotFound($"Employee with Id = {id} not found");
                }
            }
        }

        /// <summary>
        ///     Create a new user
        /// </summary>
        /// <param name="firstName">First name of the user</param>
        /// <param name="lastName">Last name of the user</param>
        /// <param name="age">Age of the user (must be a number)</param>
        /// <returns></returns>
        [HttpPost]
        [Route("api/users")]
        public IActionResult Create([FromBody]Models.UserAddModel userAddModel)
        {
            using (var database = new DatabaseContext())
            {
                if (ModelState.IsValid)
                {
                    Models.User user = new Models.User
                    {
                        FirstName = userAddModel.FirstName,
                        LastName = userAddModel.LastName,
                        Age = userAddModel.Age
                    };
                    database.Users.Add(user);
                    database.SaveChanges();
                    return Ok(user.Id);
                }
                else
                {
                    return BadRequest();
                }
            }
        }

        /// <summary>
        ///     Updates a user
        /// </summary>
        /// <param name="id">ID of the user</param>
        /// <param name="firstName">First name of the user</param>
        /// <param name="lastName">Last name of the user</param>
        /// <param name="age">Age of the user (must be a number)</param>
        /// <returns></returns>
        [HttpPut]
        [Route("api/users")]
        public IActionResult Update([FromBody]Models.User userUpdated)
        {
            using (var database = new DatabaseContext())
            {
                if (ModelState.IsValid)
                {
                    try
                    {
                        Models.User user = database.Users.Where(user => user.Id == userUpdated.Id).First();
                        user.Age = userUpdated.Age;
                        user.FirstName = userUpdated.FirstName;
                        user.LastName = userUpdated.LastName;
                        database.Users.Update(user);
                        database.SaveChanges();
                        return Ok(user);
                    }
                    catch (Exception ex)
                    {
                        return NotFound($"Employee with Id = {userUpdated.Id} not found");
                    }
                }
                else
                {
                    return BadRequest();
                }

            }
        }

        /// <summary>
        ///     Deletes a user
        /// </summary>
        /// <param name="id">ID of the user</param>
        /// <returns></returns>
        [HttpDelete]
        [Route("api/users")]
        public IActionResult Delete(int id)
        {
            using (var database = new DatabaseContext())
            {
                try
                {
                    Models.User user = database.Users.Where(user => user.Id == id).First();
                    database.Users.Remove(user);
                    database.SaveChanges();
                    return Ok();
                }
                catch (Exception ex)
                {
                    return NotFound($"Employee with Id = {id} not found");
                }
            }
        }
    }
}
