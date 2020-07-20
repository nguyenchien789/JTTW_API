using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using JTTW_API.Models;

namespace JTTW_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActorListsController : ControllerBase
    {
        private readonly Journey_To_The_WestContext _context = new Journey_To_The_WestContext();

        // GET: api/ActorLists
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ActorList>>> GetActorList()
        {
            return await _context.ActorList.ToListAsync();
        }

        // GET: api/ActorLists/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ActorList>> GetActorList(int id)
        {
            var actorList = await _context.ActorList.FindAsync(id);

            if (actorList == null)
            {
                return NotFound();
            }

            return actorList;
        }

        // PUT: api/ActorLists/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutActorList(int id, ActorList actorList)
        {
            if (id != actorList.Id)
            {
                return BadRequest();
            }

            _context.Entry(actorList).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ActorListExists(id))
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

        // POST: api/ActorLists
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<ActorList>> PostActorList(ActorList actorList)
        {
            _context.ActorList.Add(actorList);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetActorList", new { id = actorList.Id }, actorList);
        }

        // DELETE: api/ActorLists/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ActorList>> DeleteActorList(int id)
        {
            var actorList = await _context.ActorList.FindAsync(id);
            if (actorList == null)
            {
                return NotFound();
            }

            _context.ActorList.Remove(actorList);
            await _context.SaveChangesAsync();

            return actorList;
        }

        private bool ActorListExists(int id)
        {
            return _context.ActorList.Any(e => e.Id == id);
        }
    }
}
