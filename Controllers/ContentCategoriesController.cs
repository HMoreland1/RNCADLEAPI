using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using RNCADLEAPI.Data;
using Microsoft.EntityFrameworkCore;
using System.Data.Entity;
using EntityState = Microsoft.EntityFrameworkCore.EntityState;

namespace RNCADLEAPI.Controllers
{
    [Route("contentcategories")]
    public class ContentCategoriesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ContentCategoriesController(AppDbContext context)
        {
            _context = context;
        }
        // GET api/rncadleapi/contentcategories/all
        [HttpGet]
        [Route("all")]
        public ActionResult<IEnumerable<ContentCategory>> GetAllContentCategories()
        {
            var categories = _context.ContentCategories.ToList();

            if (categories == null || categories.Count == 0)
            {
                return NotFound();
            }
            return categories;
        }

        // GET api/rncadleapi/contentcategories/{id}
        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<ContentCategory>> GetContentCategoryById(int id)
        {
            var category = await _context.ContentCategories.FindAsync(id);

            if (category == null)
            {
                return NotFound();
            }

            return category;
        }

        // POST api/rncadleapi/contentcategories/add
        [HttpPost]
        [Route("add")]
        public async Task<ActionResult<ContentCategory>> PostCategory(ContentCategory Category)
        {
            _context.ContentCategories.Add(Category);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetContentCategoryById", new { id = Category.CategoryId}, Category);
        }

        // PUT api/rncadleapi/contentcategories/update/{id}
        [HttpPut("update")]
        public async Task<IActionResult> PutCategory(int id, [FromBody] ContentCategory Category )
        {
            if (Category == null || id != Category.CategoryId)
            {
                return BadRequest();
            }

            _context.Entry(Category).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CategoryExists(Category.CategoryId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // DELETE api/rncadleapi/contentcategories/delete/{id}
        [HttpDelete]
        [Route("delete/{id}")]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            var category = await _context.ContentCategories.FindAsync(id);
            if (category == null)
            {
                return NotFound();
            }

            _context.ContentCategories.Remove(category);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UserExists(int id)
        {
            return _context.Users.Any(e => e.UserId == id);
        }

        private bool CategoryExists(int id)
        {
            return _context.ContentCategories.Any(e => e.CategoryId == id);
        }
    }

    public interface IActionResult<T>
    {
    }
    
}