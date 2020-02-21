using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Stravinsky.Models;

namespace Stravinsky.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class APICommentsController : ControllerBase
    {
        private readonly AppIdentityDbContext _context;

        public APICommentsController(AppIdentityDbContext context)
        {
            _context = context;
        }

        // GET: api/APIComments
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Comment>>> GetComments()
        {
            return await _context.Comments.ToListAsync();
        }

        // GET: api/APIComments/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Comment>> GetComment(int id)
        {
            var comment = await _context.Comments.FindAsync(id);

            if (comment == null)
            {
                return NotFound();
            }

            return comment;
        }

        // PUT: api/APIComments/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutComment(int id, Comment comment)
        {
            if (id != comment.CommentID)
            {
                return BadRequest();
            }

            _context.Entry(comment).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CommentExists(id))
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

        // POST: api/APIComments
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Comment>> PostComment(Comment comment)
        {
            _context.Comments.Add(comment);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetComment", new { id = comment.CommentID }, comment);
        }

        // PATCH: api/APIComments
        [HttpPatch("{id}")]
        public async Task<ActionResult<Comment>> PatchComment(int id, string operation, string parameterName, string parameterValue)
        {
            var comment = await _context.Comments.FindAsync(id);
            if (operation == "replace")
            {
                switch (parameterName)
                {
                    case "name":
                        comment.Name = parameterValue;
                        break;
                    case "storyPost":
                        comment.CommentText = parameterValue;
                        break;
                    default: break;
                }
            }
            _context.Comments.Update(comment);
            await _context.SaveChangesAsync();
            return Ok(comment);

        }

        // DELETE: api/APIComments/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Comment>> DeleteComment(int id)
        {
            var comment = await _context.Comments.FindAsync(id);
            if (comment == null)
            {
                return NotFound();
            }

            _context.Comments.Remove(comment);
            await _context.SaveChangesAsync();

            return comment;
        }

        private bool CommentExists(int id)
        {
            return _context.Comments.Any(e => e.CommentID == id);
        }
    }
}
