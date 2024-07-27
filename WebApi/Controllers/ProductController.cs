using Application.DTOs;
using Application.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        readonly IProductService _productService;
        public ProductsController(IProductService productService)
        {
            this._productService = productService;
        }

        [HttpGet()]
        public async Task<ActionResult<IEnumerable<ProductDTO>>> Get()
        {
            var ProductDTO = await _productService.GetAllAsync();
            if (ProductDTO == null)
                return NotFound("Products not found");

            return Ok(ProductDTO);
        }

        [HttpGet("{id:int}", Name = "GetProduct")]
        public async Task<ActionResult<ProductDTO>> Get(int id)
        {
            var ProductDTO = await _productService.GetAsync(id);
            if (ProductDTO == null)
                return NotFound("Product not found");

            return Ok(ProductDTO);
        }

        [HttpPost()]
        public async Task<ActionResult> Create([FromBody] ProductDTO dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid data.");
            }

            await _productService.AddAsync(dto);
            return new CreatedAtRouteResult("GetProduct", new { id = dto.Id }, dto);
        }

        [HttpPut()]
        public async Task<ActionResult<ProductDTO>> Put(int id, [FromBody] ProductDTO dto)
        {
            if (id != dto.Id || !ModelState.IsValid)
                return BadRequest();

            await _productService.UpdateAsync(dto);
            return Ok(dto);
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<ProductDTO>> Delete(int id)
        {
            var ProductDTO = await _productService.GetAsync(id);
            if (ProductDTO == null)
                return NotFound();

            await _productService.DeleteAsync(id);

            return Ok(ProductDTO);
        }
    }
}
