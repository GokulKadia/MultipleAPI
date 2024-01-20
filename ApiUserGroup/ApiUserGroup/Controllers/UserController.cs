using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ApiUserGroup.Data;
using ApiUserGroup.Model;
using Microsoft.EntityFrameworkCore;

namespace ApiUserGroup.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly ApiDBContext _context;
        public UserController(ApiDBContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<User>>> GetUsers()
        {
            return Ok(await _context.users.ToListAsync());
        }

        [HttpGet("{userid}")]
        public ActionResult<User> GetUsers(int userid)
        {
            var user = _context.users.Find(userid);
            if (user == null) { return NotFound(); }
            return user;
        }

        [HttpPost]
        public async Task<ActionResult<User>> Create(User Users)
        {
            _context.Add(Users);
            await _context.SaveChangesAsync();
            return Ok(Users);
        }

        [HttpPut("{userid}")]
        public async Task<ActionResult> Update(int id, User Users)
        {
            if (id != Users.userid) return BadRequest();
            _context.Entry(Users).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return Ok("User Updated Successfully.");
        }

        [HttpDelete("{userid}")]
        public async Task<ActionResult> Delete(int userid)
        {
            var cust = await _context.users.FindAsync(userid);

            if (cust == null) return NotFound("Incorrect User ID");
            _context.users.Remove(cust);
            await _context.SaveChangesAsync();
            return Ok("User Deleted Successfully");
        }

    }
}
