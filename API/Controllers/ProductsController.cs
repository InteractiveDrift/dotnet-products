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
        public async Task<ActionResult<Product>> GetProduct(long id)
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

            return product;
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
            // Retrieve the existing entities
            // long existingProductGroupId = _context.Producers
            //     .Where(pg => pg.Name == productDto.ProducerName)
            //     .Select(pg => pg.Id)
            //     .FirstOrDefault();

            // long existingSupplierId = _context.Suppliers
            //     .Where(s => s.Name == productDto.SupplierName)
            //     .Select(s => s.Id)
            //     .FirstOrDefault();

            // long existingProducerId = _context.ProductGroups
            //     .Where(p => p.Name == productDto.ProductGroupName)
            //     .Select(p => p.Id)
            //     .FirstOrDefault();
            Producer? existingProducer = productDto.ProducerName != null ? _context.Producers.FirstOrDefault(p => p.Name == productDto.ProducerName) : null;
            Supplier? existingSupplier = productDto.SupplierName != null ? _context.Suppliers.FirstOrDefault(s => s.Name == productDto.SupplierName) : null;
            ProductGroup? existingProductGroup = productDto.ProductGroupName != null ? _context.ProductGroups.FirstOrDefault(s => s.Name == productDto.ProductGroupName) : null;

            // Check if any of the entities don't exist
            if (existingProducer == null || existingSupplier == null || existingProductGroup == null)
            {
                // Return an appropriate response indicating that the required entities do not exist
                return NotFound("One or more required entities do not exist.");
            }

            Product product = new Product
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

            // product.SupplierId = existingSupplierId;
            // product.ProductGroupId = existingProductGroupId;
            // product.ProducerId = existingProducerId;

            // Producer existingProducer = product.Producer != null ? _context.Producers.FirstOrDefault(p => p.Name == product.Producer.Name) : null;
            // Supplier existingSupplier = _context.Suppliers.FirstOrDefault(s => s.Name == product.Supplier.Name);
            // ProductGroup existingProductGroup = _context.ProductGroups.FirstOrDefault(pg => pg.Name == product.ProductGroup.Name);

            // Check if any of the entities don't exist
            // if (existingProductGroupId == null || existingSupplierId == null || existingProducerId == null)
            // {
            //     return NotFound("One or more required entities do not exist.");
            // }

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
