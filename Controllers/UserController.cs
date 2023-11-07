using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using RNCADLEAPI.Data;
using System.Data;

namespace RNCADLEAPI.Controllers
{
    [ApiController]
    [Route("user")]
    public class UserController : ControllerBase
    {
        // GET api/user
        [HttpGet]
        [Route("all")]
        public IEnumerable<User> Get()
        {
            return null;
            // Implement logic to retrieve all users from the database
        }

        // GET api/user/{id}
        [HttpGet]
        [Route("{id}")]
        public User Get(int id)
        {
            return null;
            // Implement logic to retrieve a specific user by id from the database
        }

        // POST api/user
        [HttpPost]
        [Route("add")]
        public void Post([FromBody] User user)
        {
            // Implement logic to add a new user to the database
        }

        // PUT api/user/{id}
        [HttpPut]
        [Route("update/{id}")]
        public void Put(int id, [FromBody] User user)
        {
            // Implement logic to update an existing user in the database
        }

        // DELETE api/user/{id}
        [HttpDelete]
        [Route("remove/{id}")]
        public void Delete(int id)
        {
            // Implement logic to delete a user from the database
        }
    }
}