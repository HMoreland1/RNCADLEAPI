using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using RNCADLEAPI.Data;

namespace RNCADLEAPI.Controllers
{
    [Route("userprogress")]
    public class UserProgressController : ControllerBase
    {
        // GET api/rncadleapi/userprogress/all
        [HttpGet]
        [Route("all")]
        public IEnumerable<UserProgress> GetAllUserProgress()
        {
            return null;
            // Implement logic to retrieve all user progress from the database
        }

        // GET api/rncadleapi/userprogress/{id}
        [HttpGet]
        [Route("{id}")]
        public UserProgress GetUserProgressById(int id)
        {
            return null;
            // Implement logic to retrieve specific user progress by id from the database
        }

        // POST api/rncadleapi/userprogress/add
        [HttpPost]
        [Route("add")]
        public void AddUserProgress([FromBody] UserProgress userProgress)
        {
            // Implement logic to add new user progress to the database
        }

        // PUT api/rncadleapi/userprogress/update/{id}
        [HttpPut]
        [Route("update/{id}")]
        public void UpdateUserProgress(int id, [FromBody] UserProgress userProgress)
        {
            // Implement logic to update existing user progress in the database
        }

        // DELETE api/rncadleapi/userprogress/delete/{id}
        [HttpDelete]
        [Route("delete/{id}")]
        public void DeleteUserProgress(int id)
        {
            // Implement logic to delete user progress from the database
        }
    }
}