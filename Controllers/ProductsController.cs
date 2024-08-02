using Microsoft.AspNetCore.Mvc;
using FleskBtocBackend.Data;
using FleskBtocBackend.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace FleskBtocBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ProductsController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetProducts()
        {
            return await _context.Products.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
            var product = await _context.Products.FindAsync(id);

            if (product == null)
            {
                return NotFound();
            }

            return product;
        }

        [HttpPost]
        public async Task<ActionResult<Product>> PostProduct(Product product)
        {
            _context.Products.Add(product);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetProduct), new { id = product.Id }, product);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutProduct(int id, Product product)
        {
            if (id != product.Id)
            {
                return BadRequest();
            }

            _context.Entry(product).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }

            _context.Products.Remove(product);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpGet("category/{categoryId}")]
        public async Task<ActionResult<IEnumerable<Product>>> GetProductsByCategory(int categoryId, int page = 1, int pageSize = 10)
        {
            var products = await _context.Products
                .Where(p => p.categoryId == categoryId)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            return Ok(products);
        }

        // New search endpoint
        [HttpGet("search")]
        public async Task<ActionResult<IEnumerable<Product>>> Search([FromQuery] string query)
        {
            if (string.IsNullOrWhiteSpace(query))
            {
                return BadRequest("Search query cannot be empty.");
            }

            // Convert the search query to lowercase
            var lowerQuery = query.ToLower();

            // Fetch and filter products in-memory
            var products = await _context.Products
                .Where(p => p.title.ToLower().Contains(lowerQuery))
                .ToListAsync();

            if (!products.Any())
            {
                return NotFound("No products found matching the search criteria.");
            }

            return Ok(products);
        }

        // New endpoint to get products with discounts
        [HttpGet("discounts")]
        public async Task<ActionResult<IEnumerable<Product>>> GetDiscountedProducts()
        {
            var discountedProducts = await _context.Products
                .Where(p => p.newCustomerDiscount > 0 || p.shippingDiscount > 0)
                .ToListAsync();

            if (!discountedProducts.Any())
            {
                return NotFound("No discounted products found.");
            }

            return Ok(discountedProducts);
        }
    }
}
