using GCScript_Automate_API.Data;
using GCScript_Automate_API.Models;
using GCScript_Automate_API.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GCScript_Automate_API.Controllers
{
    [ApiController]
    public class SubtypeController : ControllerBase
    {
        private readonly AppDataContext _context;

        public SubtypeController(AppDataContext context)
        {
            _context = context;
        }

        [HttpGet("api/v1/[controller]")]
        public async Task<ActionResult<SubtypeModel>> Get()
        {
            try
            {
                if (_context.Subtypes is null) return NotFound();

                var results = await _context.Subtypes.AsNoTracking().ToListAsync();

                return Ok(results);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpGet("api/v1/[controller]/{id:guid}")]
        public async Task<ActionResult<SubtypeModel>> GetById(Guid id)
        {
            try
            {
                if (_context.Subtypes is null) return NotFound();

                var result = await _context.Subtypes.FirstOrDefaultAsync(x => x.Id == id);

                if (result is null) return NotFound();

                return Ok(result);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpGet("api/v1/[controller]/{code:alpha:maxlength(100)}")]
        public async Task<ActionResult<SubtypeModel>> GetByCode(string code)
        {
            try
            {
                if (_context.Subtypes is null) return NotFound();

                var result = await _context.Subtypes.FirstOrDefaultAsync(x => x.Code == code);

                if (result is null) return NotFound();

                return Ok(result);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpGet("api/v1/Category/{categoryCode:alpha:maxlength(100)}/Type/{typeCode:alpha:maxlength(100)}/Subtype/{subtypeCode:alpha:maxlength(100)}")]
        public async Task<ActionResult<SubtypeModel>> GetTypeAndSubtypeByCode(string categoryCode, string typeCode, string subtypeCode)
        {
            try
            {
                if (_context.Subtypes is null) return NotFound();


                var result = await _context.Subtypes.Include(s => s.Type)
                                                     .ThenInclude(t => t.Category)
                                                     .FirstOrDefaultAsync(x => x.Code == subtypeCode && x.Type.Code == typeCode && x.Type.Category.Code == categoryCode);

                if (result is null) return NotFound();

                CategoryTypeSubtypeViewModel cts = new()
                {
                    CategoryName = result.Type.Category.Name,
                    TypeName = result.Type.Name,
                    SubtypeName = result.Name
                };

                return Ok(cts);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPost("api/v1/[controller]")]
        public async Task<ActionResult<SubtypeModel>> Post(SubtypePostViewModel model)
        {
            if (_context.Subtypes is null) return NotFound();

            try
            {
                var type = await _context.Types.FirstOrDefaultAsync(x => x.Code == model.TypeCode);

                if (type is null) { return NotFound(); }

                var result = new SubtypeModel()
                {
                    Type = type,
                    Code = model.Code,
                    Name = model.Name,
                };

                await _context.Subtypes.AddAsync(result);
                await _context.SaveChangesAsync();

                return CreatedAtAction("GetById", new { id = result.Id }, result);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPost("api/v1/[controller]s/")]
        public async Task<ActionResult<List<SubtypeModel>>> PostBulk(List<SubtypePostViewModel> models)
        {
            if (_context.Types is null) return NotFound();

            try
            {
                var result = new List<SubtypeModel>();

                foreach (var model in models)
                {
                    var type = await _context.Types.FirstOrDefaultAsync(x => x.Code == model.TypeCode);
                    if (type is null) continue;

                    result.Add(new SubtypeModel()
                    {
                        Type = type,
                        Code = model.Code,
                        Name = model.Name,
                    });
                }

                await _context.Subtypes.AddRangeAsync(result);
                await _context.SaveChangesAsync();

                return Ok($"{result.Count} registros foram inseridos na base de dados!");
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }


        [HttpPut("api/v1/[controller]/{id:guid}")]
        public async Task<ActionResult<SubtypeModel>> Put(Guid id, SubtypePutViewModel model)
        {
            try
            {
                if (id != model.Id) return BadRequest();

                if (_context.Subtypes is null) return NotFound();

                var result = await _context.Subtypes.FirstOrDefaultAsync(x => x.Id == id);

                if (result is null) return NotFound();

                result.Name = model.Name;
                result.Code = model.Code;

                _context.Subtypes.Update(result);
                await _context.SaveChangesAsync();

                return Ok(result);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpDelete("api/v1/[controller]/{id:guid}")]
        public async Task<ActionResult<SubtypeModel>> Delete(Guid id)
        {
            try
            {
                var result = await _context.Subtypes.FirstOrDefaultAsync(x => x.Id == id);

                if (result is null) return NotFound();

                _context.Subtypes.Remove(result);
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
