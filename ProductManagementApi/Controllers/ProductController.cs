using DataAccessLayer.Irepo;
using DataAccessLayer.Models;
using Microsoft.AspNetCore.Mvc;

namespace ProductManagementApi.Controllers
{
    [ApiController]
    public class ProductController:ControllerBase
    {
        private readonly Iproduct _repo;
        public ProductController(Iproduct repo)
        {
            _repo = repo;
        }
        [HttpGet]
        [Route("api/products")]
        public async Task<IActionResult> GetAllProducts()
        {
            List<Product> products = await _repo.GetAllProducts();
            return Ok(products);
        }

        [HttpGet]
        [Route("api/products/{id}")]
        public async Task<IActionResult> GetProduct([FromRoute]int id)
        {
            try
            {
                Product product = await _repo.GetProduct(id);
                return Ok(product);
            }
            catch(Exception ex)
            {
                return NotFound(new {message=ex.Message});
            }
        }
        [HttpPost]
        [Route("api/products")]
        public async Task<IActionResult> CreateProduct([FromBody]Product product)
        {
            try
            {
                await _repo.AddProduct(product);
                return Ok(new
                {
                    message = "Poduct added successfully"
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }
        [HttpPut]
        [Route("api/products/{id?}")]
        public async Task<IActionResult> EditProduct([FromBody]Product product)
        {
            try
            {
                await _repo.EditProduct(product);
                return Ok(new
                {
                    message = "Poduct updated successfully"
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }
        [HttpDelete]
        [Route("api/products/{id}")]
        public async Task<IActionResult> DeleteProduct([FromRoute]int id)
        {
            try
            {
                await _repo.DeleteProduct(id);
                return Ok(new
                {
                    message = "Poduct deleted successfully"
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }
    }
}

