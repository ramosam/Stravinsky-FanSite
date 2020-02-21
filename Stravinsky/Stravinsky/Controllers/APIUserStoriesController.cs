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
    public class APIUserStoriesController : ControllerBase
    {
        private readonly AppIdentityDbContext _context;

        public APIUserStoriesController(AppIdentityDbContext context)
        {
            _context = context;
        }

        // GET: api/APIUserStories
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserStory>>> GetUserStories()
        {
            return await _context.UserStories.ToListAsync();
        }

        // GET: api/APIUserStories/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UserStory>> GetUserStory(int id)
        {
            var userStory = await _context.UserStories.FindAsync(id);

            if (userStory == null)
            {
                return NotFound();
            }

            return userStory;
        }

        // PUT: api/APIUserStories/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUserStory(int id, UserStory userStory)
        {
            if (id != userStory.UserStoryID)
            {
                return BadRequest();
            }

            _context.Entry(userStory).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserStoryExists(id))
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

        // POST: api/APIUserStories
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<UserStory>> PostUserStory(UserStory userStory)
        {
            _context.UserStories.Add(userStory);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUserStory", new { id = userStory.UserStoryID }, userStory);
        }

        // PATCH: api/APIUserStories
        [HttpPatch("{id}")]
        public async Task<ActionResult<UserStory>>PatchUserStory(int id, string operation, string parameterName, string parameterValue)
        {
            var uStory = await _context.UserStories.FindAsync(id);
            if (operation == "replace")
            {
                switch (parameterName)
                {
                    case "name":
                        uStory.Name = parameterValue;
                        break;
                    case "storyPost":
                        uStory.StoryPost = parameterValue;
                        break;
                    default: break;
                }
            }
            _context.UserStories.Update(uStory);
            await _context.SaveChangesAsync();
            return Ok(uStory);

        }


        // DELETE: api/APIUserStories/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<UserStory>> DeleteUserStory(int id)
        {
            var userStory = await _context.UserStories.FindAsync(id);
            if (userStory == null)
            {
                return NotFound();
            }

            _context.UserStories.Remove(userStory);
            await _context.SaveChangesAsync();

            return userStory;
        }

        private bool UserStoryExists(int id)
        {
            return _context.UserStories.Any(e => e.UserStoryID == id);
        }
    }
}
