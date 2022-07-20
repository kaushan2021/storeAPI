using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using sopifyDemo.Models;

namespace sopifyDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class userController : ControllerBase
    {
        private readonly DataContext context;

        public userController(DataContext context)
        {
            this.context = context;
        }
        [HttpGet]
        public async Task<ActionResult<List<Users>>> Get()
        {
            return Ok(await context.shopifyUsers.ToArrayAsync());
        }

        [HttpPost]
        public async Task<ActionResult<List<Users>>> AddUser()
        {
            Users newUser = new Users();
            newUser.userName = "pasindu";
            newUser.email = "pasindu@gmail.com";
            newUser.password = "pasindu98";
            await context.AddAsync(newUser);
            await context.SaveChangesAsync();
            return Ok(await context.shopifyUsers.ToArrayAsync());
        }
    }
}
