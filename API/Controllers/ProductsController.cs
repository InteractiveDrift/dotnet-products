using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using API.Data;
using API.Models;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly ProductsContext _context;

        public ProductsController(ProductsContext context)
        {
            _context = context;
        }

        // GET: api/Products
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetProducts()
        {
            if (_context.Products == null)
            {
                return NotFound();
            }
            return await _context.Products.ToListAsync();
        }

        // GET: api/Products/5
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(ProductDto), StatusCodes.Status200OK)]
        public Task<ActionResult<Product>> GetProduct(long id)
        {
            Product? product = _context.Products
                .Include(p => p.Producer)
                .Include(p => p.Supplier)
                .Include(p => p.ProductGroup)
                .FirstOrDefault(p => p.Id == id);

            if (product == null)
            {
                return Task.FromResult<ActionResult<Product>>(Problem("Product or related field is null"));
            }

            // Map the Product entity to a ProductDto
            ProductDto productDto = new()
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                Price = product.Price,
                Deposit = product.Deposit,
                VolymInml = product.VolymInml,
                PricePerLiter = product.PricePerLiter,
                SalesStart = product.SalesStart,
                Discontinued = product.Discontinued != null && product.Discontinued != 0,
                ProductGroupName = product.ProductGroup.Name,
                Type = product.Type,
                Style = product.Style,
                Packaging = product.Packaging,
                SealType = product.SealType,
                Origin = product.Origin,
                OriginCountryName = product.OriginCountryName,
                ProducerName = product.Producer.Name,
                SupplierName = product.Supplier.Name,
                Vintage = product.Vintage,
                AlcoholContent = product.AlcoholContent,
                AssortmentCode = product.AssortmentCode,
                AssortmentText = product.AssortmentText,
                Organic = product.Organic != null && product.Organic != 0,
                Ethical = product.Ethical != null && product.Ethical != 0,
                Kosher = product.Kosher != null && product.Kosher != 0,
                RawMaterialsDescription = product.RawMaterialsDescription
            };
            if (_context.Products == null)
            {
                return Task.FromResult<ActionResult<Product>>(NotFound());
            }

            return Task.FromResult<ActionResult<Product>>(product);
        }

        // PUT: api/Products/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProduct(long id, Product product)
        {
            if (id != product.Id)
            {
                return BadRequest();
            }

            _context.Entry(product).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductExists(id))
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

        // POST: api/Products
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [ProducesResponseType(typeof(ProductDto), StatusCodes.Status200OK)]
        public async Task<ActionResult<Product>> PostProduct(ProductDto productDto)
        {
            if (_context.Products == null)
            {
                return Problem("Entity set 'ProductsContext.Products'  is null.");
            }

            Producer? existingProducer = productDto.ProducerName != null ? _context.Producers.FirstOrDefault(p => p.Name == productDto.ProducerName) : null;
            Supplier? existingSupplier = productDto.SupplierName != null ? _context.Suppliers.FirstOrDefault(s => s.Name == productDto.SupplierName) : null;
            ProductGroup? existingProductGroup = productDto.ProductGroupName != null ? _context.ProductGroups.FirstOrDefault(pg => pg.Name == productDto.ProductGroupName) : null;

            // Check if any of the entities don't exist
            if (existingProducer == null || existingSupplier == null || existingProductGroup == null)
            {
                // Return an appropriate response indicating that the required entities do not exist
                return NotFound("One or more required entities do not exist.");
            }

            Product product = new()
            {
                Name = productDto.Name,
                Description = productDto.Description,
                Price = productDto.Price,
                Deposit = productDto.Deposit,
                VolymInml = productDto.VolymInml,
                PricePerLiter = productDto.PricePerLiter,
                SalesStart = productDto.SalesStart,
                Discontinued = productDto.Discontinued ? 1L : null,
                Type = productDto.Type,
                Style = productDto.Style,
                Packaging = productDto.Packaging,
                SealType = productDto.SealType,
                Origin = productDto.Origin,
                OriginCountryName = productDto.OriginCountryName,
                Vintage = productDto.Vintage,
                AlcoholContent = productDto.AlcoholContent,
                AssortmentCode = productDto.AssortmentCode,
                AssortmentText = productDto.AssortmentText,
                Organic = productDto.Organic ? 1L : null,
                Ethical = productDto.Ethical ? 1L : null,
                Kosher = productDto.Kosher ? 1L : null,
                RawMaterialsDescription = productDto.RawMaterialsDescription,

                // Set the existing entities
                Producer = existingProducer,
                Supplier = existingSupplier,
                ProductGroup = existingProductGroup
            };

            _context.Products.Add(product);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProduct", new { id = product.Id }, product);
        }

        // DELETE: api/Products/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(long id)
        {
            if (_context.Products == null)
            {
                return NotFound();
            }
            var product = await _context.Products.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }

            _context.Products.Remove(product);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ProductExists(long id)
        {
            return (_context.Products?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
