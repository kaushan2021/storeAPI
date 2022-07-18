using Microsoft.AspNetCore.Mvc;
using sopifyDemo.Models;
namespace sopifyDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    

    public class productController : ControllerBase
    {
        private readonly DataContext _context;
        public productController(DataContext context)
        {
                           _context = context;
           
        }
        
        
       
        [HttpGet]
        public async Task<ActionResult<List<Products>>> Get()
        {
            
            return Ok(await _context.items.ToArrayAsync());
        }

        [HttpPost]
        public async Task<ActionResult<List<Products>>> AddProduct()
        {
            Products newProduct = new Products();
            newProduct.Name = "Raleigh";
            newProduct.quantity = 2;
            newProduct.unitprice = 249.99;
           
            _context.items.Add(newProduct);
            await _context.SaveChangesAsync();

            return Ok(await _context.items.ToArrayAsync());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Products>>> DeleteProduct(int id)
        {
            var dbItem = await _context.items.FindAsync(id);
            if (dbItem == null)
                return BadRequest("Item Not Found");
            _context.items.Remove(dbItem);
            await _context.SaveChangesAsync();
            return Ok(await _context.items.ToArrayAsync());
        }

    }
}
