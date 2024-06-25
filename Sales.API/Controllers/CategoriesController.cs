using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sales.API.Data;
using Sales.Shared.Entities;

namespace Sales.API.Controllers
{
    [ApiController]
    [Route("/api/categories")]
    public class CategoriesController : ControllerBase
    {
        private readonly DataContext _context;

        public CategoriesController(DataContext context)
        {
            this._context = context;
        }

        //Método post
        [HttpPost]
        public async Task<ActionResult> PostAsync(Category category)
        {
            try
            {
                _context.Categories.Add(category);
                await _context.SaveChangesAsync();
                return Ok(category);
            }
            catch (DbUpdateException dbUpdateException)
            {
                if (dbUpdateException.InnerException!.Message.Contains("duplicate"))
                {
                    return BadRequest("Ya existe una categoría con el mismo nombre");
                }
                return BadRequest("Ya existe una categoría con el mismo nombre");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        //Método get
        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            return Ok(await _context.Categories.ToListAsync());
        }
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetAsync(int id)
        {
            var category = await _context.Categories.FirstOrDefaultAsync(x => x.Id == id);

            if (category == null)
            {
                return NotFound();
            }
            return Ok(category);
        }

        //Método put
        [HttpPut]
        public async Task<ActionResult> PutAsync(Category category)
        {
            try
            {
                _context.Update(category);
                await _context.SaveChangesAsync();
                return Ok(category);
            }
            catch (DbUpdateException dbUpdateException)
            {
                if (dbUpdateException.InnerException!.Message.Contains("duplicate"))
                {
                    return BadRequest("Ya existe una categoría con el mismo nombre");
                }
                return BadRequest("Ya existe una categoría con el mismo nombre");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        //Método delete 
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var category = await _context.Categories.FirstOrDefaultAsync(x => x.Id == id);
            if (category == null)
            {
                return NotFound();
            }
            _context.Remove(category);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
