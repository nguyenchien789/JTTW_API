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
    public class EquipmentListsController : ControllerBase
    {
        private readonly Journey_To_The_WestContext _context = new Journey_To_The_WestContext();

        // GET: api/EquipmentLists
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EquipmentList>>> GetEquipmentList()
        {
            return await _context.EquipmentList.ToListAsync();
        }

        // GET: api/EquipmentLists/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EquipmentList>> GetEquipmentList(int id)
        {
            var equipmentList = await _context.EquipmentList.FindAsync(id);

            if (equipmentList == null)
            {
                return NotFound();
            }

            return equipmentList;
        }

        // PUT: api/EquipmentLists/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEquipmentList(int id, EquipmentList equipmentList)
        {
            if (id != equipmentList.EquipmentId)
            {
                return BadRequest();
            }

            _context.Entry(equipmentList).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EquipmentListExists(id))
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

        // POST: api/EquipmentLists
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<EquipmentList>> PostEquipmentList(EquipmentList equipmentList)
        {
            _context.EquipmentList.Add(equipmentList);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (EquipmentListExists(equipmentList.EquipmentId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetEquipmentList", new { id = equipmentList.EquipmentId }, equipmentList);
        }

        // DELETE: api/EquipmentLists/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<EquipmentList>> DeleteEquipmentList(int id)
        {
            var equipmentList = await _context.EquipmentList.FindAsync(id);
            if (equipmentList == null)
            {
                return NotFound();
            }

            _context.EquipmentList.Remove(equipmentList);
            await _context.SaveChangesAsync();

            return equipmentList;
        }

        private bool EquipmentListExists(int id)
        {
            return _context.EquipmentList.Any(e => e.EquipmentId == id);
        }
    }
}
