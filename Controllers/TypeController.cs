using GCScript_Automate_API.Data;
using GCScript_Automate_API.Models;
using GCScript_Automate_API.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GCScript_Automate_API.Controllers
{
    [ApiController]
    public class TypeController : ControllerBase
    {
        private readonly AppDataContext _context;

        public TypeController(AppDataContext context)
        {
            _context = context;
        }

        [HttpGet("api/v1/[controller]")]
        public async Task<ActionResult<TypeModel>> Get()
        {
            try
            {
                if (_context.Types is null) return NotFound();

                var results = await _context.Types.AsNoTracking().ToListAsync();

                return Ok(results);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpGet("api/v1/[controller]/{id:guid}")]
        public async Task<ActionResult<TypeModel>> GetById(Guid id)
        {
            try
            {
                if (_context.Types is null) return NotFound();

                var result = await _context.Types.FirstOrDefaultAsync(x => x.Id == id);

                if (result is null) return NotFound();

                return Ok(result);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpGet("api/v1/[controller]/{code:alpha:maxlength(100)}")]
        public async Task<ActionResult<TypeModel>> GetByCode(string code)
        {
            try
            {
                if (_context.Types is null) return NotFound();

                var result = await _context.Types.FirstOrDefaultAsync(x => x.Code == code);

                if (result is null) return NotFound();

                return Ok(result);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPost("api/v1/[controller]")]
        public async Task<ActionResult<TypeModel>> Post(TypePostViewModel model)
        {
            if (_context.Types is null) return NotFound();

            try
            {
                var category = await _context.Categories.FirstOrDefaultAsync(x => x.Id == model.CategoryId);

                if (category is null) return NotFound();

                var result = new TypeModel()
                {
                    Category = category,
                    Code = model.Code,
                    Name = model.Name,
                };

                await _context.Types.AddAsync(result);
                await _context.SaveChangesAsync();

                return CreatedAtAction("GetById", new { id = result.Id }, result);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPost("api/v1/[controller]s/")]
        public async Task<ActionResult<List<TypeModel>>> PostBulk(List<TypePostViewModel> models)
        {
            if (_context.Types is null) return NotFound();

            try
            {
                var result = new List<TypeModel>();

                foreach (var model in models)
                {
                    var category = await _context.Categories.FirstOrDefaultAsync(x => x.Id == model.CategoryId);
                    if (category is null) continue;

                    result.Add(new TypeModel()
                    {
                        Category = category,
                        Code = model.Code,
                        Name = model.Name,
                    });
                }

                await _context.Types.AddRangeAsync(result);
                await _context.SaveChangesAsync();

                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPut("api/v1/[controller]/{id:guid}")]
        public async Task<ActionResult<TypeModel>> Put(Guid id, TypePutViewModel model)
        {
            try
            {
                if (id != model.Id) return BadRequest();

                if (_context.Types is null) return NotFound();

                var result = await _context.Types.FirstOrDefaultAsync(x => x.Id == id);

                if (result is null) return NotFound();

                result.Name = model.Name;
                result.Code = model.Code;

                _context.Types.Update(result);
                await _context.SaveChangesAsync();

                return Ok(result);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpDelete("api/v1/[controller]/{id:guid}")]
        public async Task<ActionResult<TypeModel>> Delete(Guid id)
        {
            try
            {
                var result = await _context.Types.FirstOrDefaultAsync(x => x.Id == id);

                if (result is null) return NotFound();

                _context.Types.Remove(result);
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
