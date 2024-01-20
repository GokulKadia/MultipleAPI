using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ApiUserGroup.Data;
using ApiUserGroup.Model;
using Microsoft.EntityFrameworkCore;

namespace ApiUserGroup.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GroupController : ControllerBase
    {
        private readonly ApiDBContext _context;
        public GroupController(ApiDBContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Group>>> GetGroup()
        {
            return Ok(await _context.groups.ToListAsync());
        }

        [HttpGet("{groupid}")]
        public ActionResult<Group> GetGroup(int groupid)
        {
            var group = _context.groups.Find(groupid);
            if (group == null) { return NotFound(); }
            return group;
        }

        [HttpPost]
        public async Task<ActionResult<Group>> Create(Group group)
        {
            _context.Add(group);
            await _context.SaveChangesAsync();
            return Ok(group);
        }

        [HttpPut("{groupid}")]
        public async Task<ActionResult> Update(int id, Group group)
        {
            if (id != group.groupid) return BadRequest();
            _context.Entry(group).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return Ok("Group Updated Successfully");
        }

        [HttpDelete("{groupid}")]
        public async Task<ActionResult> Delete(int groupid)
        {
            var group = await _context.groups.FindAsync(groupid);

            if (group == null) return NotFound("Incorrect group ID");
            _context.groups.Remove(group);
            await _context.SaveChangesAsync();
            return Ok("Group Deleted Successfully");
        }

    }
}
