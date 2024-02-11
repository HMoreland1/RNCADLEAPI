using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using RNCADLEAPI.Data;
using Microsoft.EntityFrameworkCore;
using System.Data.Entity;
using EntityState = Microsoft.EntityFrameworkCore.EntityState;

namespace RNCADLEAPI.Controllers
{
    [Route("learningcontent")]
    public class LearningContentController : ControllerBase
    {
        private readonly AppDbContext _context;

        public LearningContentController(AppDbContext context)
        {
            _context = context;
        }

        // GET api/rncadleapi/learningcontent/all
        [HttpGet]
        [Route("all")]
        public ActionResult<IEnumerable<LearningContent>> GetAllLearningContent()
        {
            var learningContent = _context.LearningContents.ToList();

            if (learningContent == null || learningContent.Count == 0)
            {
                return NotFound();
            }
            return learningContent;
        }

        // GET api/rncadleapi/learningcontent/{id}
        [HttpGet]
        [Route("{id}")]
        public ActionResult<LearningContent> GetLearningContentById(int id)
        {
            var content = _context.LearningContents.Find(id);

            if (content == null)
            {
                return NotFound();
            }

            return content;
        }

        // POST api/rncadleapi/learningcontent/add
        [HttpPost]
        [Route("add")]
        public async Task<ActionResult<LearningContent>> AddLearningContent([FromBody] LearningContent learningContent)
        {
            _context.LearningContents.Add(learningContent);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetLearningContentById", new { id = learningContent.ContentId }, learningContent);
        }

        // PUT api/rncadleapi/learningcontent/update/{id}
        [HttpPut]
        [Route("update/{id}")]
        public async Task<IActionResult> UpdateLearningContent(int id, [FromBody] LearningContent learningContent)
        {
            if (learningContent == null || id != learningContent.ContentId)
            {
                return BadRequest();
            }

            _context.Entry(learningContent).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LearningContentExists(learningContent.ContentId))
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

        // DELETE api/rncadleapi/learningcontent/delete/{id}
        [HttpDelete]
        [Route("delete/{id}")]
        public async Task<IActionResult> DeleteLearningContent(int id)
        {
            var content = await _context.LearningContents.FindAsync(id);
            if (content == null)
            {
                return NotFound();
            }

            _context.LearningContents.Remove(content);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool LearningContentExists(int id)
        {
            return _context.LearningContents.Any(e => e.ContentId == id);
        }
    }
}