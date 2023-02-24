using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Pharmacy.API.Data;
using Pharmacy.API.Interfaces;
using Pharmacy.API.Models;

namespace Pharmacy.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productservice)
        {
            _productService = productservice;
        }

        [HttpGet]
        public async Task<ActionResult<List<Product>>> GetAllProducts()
        {
            return await _productService.GetAllProducts();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProductById(long id)
        {
            var product = await _productService.GetProductById(id);
            if(product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }

        [HttpPost]
        public async Task<ActionResult> CreateProduct(Product product)
        {
            await _productService.CreateProduct(product);
            return CreatedAtAction(nameof(GetProductById), new { id = product.Id }, product);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateProduct(long id, Product product)
        {
            if(id != product.Id)
            {
                return BadRequest();
            }
            await _productService.UpdateProduct(id, product);
            return NoContent();

        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteProduct(long id)
        {
            await _productService.DeleteProduct(id);
            return NoContent();
        }
    }
}
