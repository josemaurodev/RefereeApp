using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RefereeAPI.Data;
using RefereeAPI.Entities;

namespace RefereeAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")] // GET /api/users
    public class UsersController : ControllerBase
    {
        //to be able to move in our database, we should use dependency injection, and thats what we're doing here
        private readonly DataContext _context;

        public UsersController(DataContext context)
        {
            _context = context;
        }


        [HttpGet]

        //WE USE TASK BECAUSE OF THE ANOLOGY OF THE RESTAURANT, WHERE THE WAITER CAN GRAB MORE THAN ONE REQUEST AT A TIME, AND IT WILL BE NOTIFIED WHEN THE REQUEST IS DONE
        public async Task<ActionResult<IEnumerable<AppUser>>> GetUsers()
        {
            //list all users user by saving all the users find with the ToList method and saving them into the users var 
            var users = await _context.Users.ToListAsync();

            return users;
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<AppUser>> GetUser(int id)
        {
            //find the user with the specified id and saves into the user var
            var user = await _context.Users.FindAsync(id);

            return user;
        }


    }
}