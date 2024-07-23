using API_Crud_Log.Data;
using API_Crud_Log.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace InMemoryCrudExample.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductsController : ControllerBase
{
    private readonly AppDbContext _context;
    private readonly ILogger<ProductsController> _logger;

    public ProductsController(AppDbContext context, ILogger<ProductsController> logger)
    {
        _context = context;
        _logger = logger;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Product>>> GetProducts()
    {
        _logger.LogInformation("Getting all products.");
        var products = await _context.Products.ToListAsync();
        _logger.LogInformation("Returned {Count} products.", products.Count);
        return products;
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Product>> GetProduct(int id)
    {
        _logger.LogInformation("Getting product with id {Id}.", id);
        var product = await _context.Products.FindAsync(id);

        if (product == null)
        {
            _logger.LogWarning("Product with id {Id} not found.", id);
            return NotFound();
        }

        _logger.LogInformation("Returned product with id {Id}.", id);
        return product;
    }

    [HttpPost]
    public async Task<ActionResult<Product>> PostProduct(Product product)
    {
        _logger.LogInformation("Adding a new product.");
        _context.Products.Add(product);
        await _context.SaveChangesAsync();

        _logger.LogInformation("Added new product with id {Id}.", product.Id);
        return CreatedAtAction(nameof(GetProduct), new { id = product.Id }, product);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> PutProduct(int id, Product product)
    {
        if (id != product.Id)
        {
            _logger.LogWarning("Product id {Id} does not match route id {RouteId}.", product.Id, id);
            return BadRequest();
        }

        _context.Entry(product).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
            _logger.LogInformation("Product updated: {Id}", product.Id);
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!ProductExists(id))
            {
                _logger.LogWarning("Product with id {Id} not found during update.", id);
                return NotFound();
            }
            else
            {
                _logger.LogError("Concurrency exception occurred while updating product with id {Id}.", id);
                throw;
            }
        }

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteProduct(int id)
    {
        _logger.LogInformation("Deleting product with id {Id}.", id);
        var product = await _context.Products.FindAsync(id);
        if (product == null)
        {
            _logger.LogWarning("Product with id {Id} not found for deletion.", id);
            return NotFound();
        }

        _context.Products.Remove(product);
        await _context.SaveChangesAsync();
        _logger.LogInformation("Deleted product with id {Id}.", id);

        return NoContent();
    }

    private bool ProductExists(int id)
    {
        return _context.Products.Any(e => e.Id == id);
    }
}
