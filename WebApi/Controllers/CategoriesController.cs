using Application.DTOs;
using Application.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class CategoriesController : ControllerBase
    {
        readonly ICategoryService _categoryService;
        public CategoriesController(ICategoryService categoryService)
        {
            this._categoryService = categoryService;
        }

        [HttpGet()]
        public async Task<ActionResult<IEnumerable<CategoryDTO>>> Get()
        {
            var categoryDto = await _categoryService.GetAllAsync();
            if (categoryDto == null)
                return NotFound("Categories not found");

            return Ok(categoryDto);
        }

        [HttpGet("{id:int}", Name = "GetCategory")]
        public async Task<ActionResult<CategoryDTO>> Get(int id)
        {
            var categoryDto = await _categoryService.GetAsync(id);
            if (categoryDto == null)
                return NotFound("Category not found");

            return Ok(categoryDto);
        }

        [HttpPost()]
        public async Task<ActionResult> Create([FromBody] CategoryDTO dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid data.");
            }

            await _categoryService.AddAsync(dto);
            return new CreatedAtRouteResult("GetCategory", new { id = dto.Id }, dto);
        }

        [HttpPut()]
        public async Task<ActionResult<CategoryDTO>> Put(int id, [FromBody] CategoryDTO dto)
        {
            if (id != dto.Id || !ModelState.IsValid)
                return BadRequest();

            await _categoryService.UpdateAsync(dto);
            return Ok(dto);
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<CategoryDTO>> Delete(int id)
        {
            var categoryDto = await _categoryService.GetAsync(id);
            if (categoryDto == null)
                return NotFound();

            await _categoryService.DeleteAsync(id);

            return Ok(categoryDto);
        }
    }
}
