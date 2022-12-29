using GCScript_Automate_API.Data;
using GCScript_Automate_API.Models;
using GCScript_Automate_API.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GCScript_Automate_API.Controllers
{
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly AppDataContext _context;

        public CategoryController(AppDataContext context)
        {
            _context = context;
        }

        [HttpGet("api/v1/[controller]")]
        public async Task<ActionResult<CategoryModel>> Get()
        {
            try
            {
                if (_context.Categories is null) return NotFound();

                var results = await _context.Categories.AsNoTracking().ToListAsync();

                return Ok(results);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpGet("api/v1/[controller]/{id:guid}")]
        public async Task<ActionResult<CategoryModel>> GetById(Guid id)
        {
            try
            {
                if (_context.Categories is null) return NotFound();

                var result = await _context.Categories.FirstOrDefaultAsync(x => x.Id == id);

                if (result is null) return NotFound();

                return Ok(result);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPost("api/v1/[controller]")]
        public async Task<ActionResult<CategoryModel>> Post(CategoryPostViewModel model)
        {
            if (_context.Categories is null) return NotFound();

            try
            {
                var result = new CategoryModel()
                {
                    Code = model.Code,
                    Name = model.Name
                };

                await _context.Categories.AddAsync(result);
                await _context.SaveChangesAsync();

                return CreatedAtAction("GetById", new { id = result.Id }, result);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPost("api/v1/[controller]s")]
        public async Task<ActionResult<IEnumerable<CategoryModel>>> PostList(IEnumerable<CategoryPostViewModel> models)
        {
            if (_context.Categories is null) return NotFound();

            try
            {
                var results = models.Select(model => new CategoryModel
                {
                    Code = model.Code,
                    Name = model.Name
                });

                await _context.Categories.AddRangeAsync(results);
                await _context.SaveChangesAsync();

                return Ok(results);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }


        [HttpPut("api/v1/[controller]/{id:guid}")]
        public async Task<ActionResult<CategoryModel>> Put(Guid id, CategoryPutViewModel model)
        {
            try
            {
                if (id != model.Id) return BadRequest();

                if (_context.Categories is null) return NotFound();

                var result = await _context.Categories.FirstOrDefaultAsync(x => x.Id == id);

                if (result is null) return NotFound();

                result.Code = model.Code;
                result.Name = model.Name;

                _context.Categories.Update(result);
                await _context.SaveChangesAsync();

                return Ok(result);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpDelete("api/v1/[controller]/{id:guid}")]
        public async Task<ActionResult<CategoryModel>> Delete(Guid id)
        {
            try
            {
                var result = await _context.Categories.FirstOrDefaultAsync(x => x.Id == id);

                if (result is null) return NotFound();

                _context.Categories.Remove(result);
                await _context.SaveChangesAsync();

                return NoContent();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

    }
}
