using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using RNCADLEAPI.Data;

namespace RNCADLEAPI.Controllers
{
    [Route("contentcategories")]
    public class ContentCategoriesController : ControllerBase
    {
        // GET api/rncadleapi/contentcategories/all
        [HttpGet]
        [Route("all")]
        public IEnumerable<ContentCategory> GetAllContentCategories()
        {
            return null;
            // Implement logic to retrieve all content categories from the database
        }

        // GET api/rncadleapi/contentcategories/{id}
        [HttpGet]
        [Route("{id}")]
        public ContentCategory GetContentCategoryById(int id)
        {
            return null;
            // Implement logic to retrieve specific content category by id from the database
        }

        // POST api/rncadleapi/contentcategories/add
        [HttpPost]
        [Route("add")]
        public void AddContentCategory([FromBody] ContentCategory contentCategory)
        {
            // Implement logic to add new content category to the database
        }

        // PUT api/rncadleapi/contentcategories/update/{id}
        [HttpPut]
        [Route("update/{id}")]
        public void UpdateContentCategory(int id, [FromBody] ContentCategory contentCategory)
        {
            // Implement logic to update existing content category in the database
        }

        // DELETE api/rncadleapi/contentcategories/delete/{id}
        [HttpDelete]
        [Route("delete/{id}")]
        public void DeleteContentCategory(int id)
        {
            // Implement logic to delete content category from the database
        }
    }
}