using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MobileDevWebApp.Data;
using MobileDevWebApp.Models;

namespace MobileDevWebApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TeaController : ControllerBase
    {
        [HttpGet("[action]")]
        public IActionResult getItems()
        {
            try
            {
                using (AppDbContext db = new AppDbContext())
                {
                    List<Models.TeaM> Tea = db.Tea.ToList();

                    return new ObjectResult(Tea);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Caught an exception: ", e.Message, "Stack Trace: ", e.StackTrace);
                return BadRequest(e);
            }
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> postItem([FromBody] TeaM value)
        {
            try
            {
                using (AppDbContext db = new AppDbContext())
                {
                    TeaM model = new TeaM();

                    model.TeaName = value.TeaName;
                    model.TeaType = value.TeaType;

                    db.Tea.Add(model);
                    await db.SaveChangesAsync();

                    return new ObjectResult(model);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Caught an exception: ", e.Message, "Stack Trace: ", e.StackTrace);
                return BadRequest(e);
            }
        }
        [HttpPut("[action]/{id}")]
        public async Task<IActionResult> updateItem([FromBody] TeaM value, Int64 id)
        {
            try
            {
                Console.WriteLine("updating the user with the id: ", id);
                using (AppDbContext db = new AppDbContext())
                {
                    TeaM model = await db.Tea.FirstOrDefaultAsync(x => x.TeaID == id);
                    if (model == null)
                    {
                        Console.WriteLine("Id ", id, " Not found");
                        return NotFound(id);
                    }

                    model.TeaName = value.TeaName;
                    model.TeaType = value.TeaType;

                    db.Tea.Update(model);
                    await db.SaveChangesAsync();

                    return new ObjectResult(model);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Caught exception: ", e.Message, "Stack trace: ", e.StackTrace);
                return BadRequest(e);
            }
        }
        [HttpDelete("[action]/{id}")]
        public async Task<IActionResult> deleteItem(Int64 id)
        {
            try
            {
                using (AppDbContext db = new AppDbContext())
                {
                    TeaM Tea = await db.Tea.FirstOrDefaultAsync(n => n.TeaID == id);
                    if (Tea != null)
                    {
                        Console.WriteLine("deleting item: " + Tea);
                        db.Tea.Remove(Tea);
                        await db.SaveChangesAsync();
                    }
                    Console.WriteLine("The item doesn't exist or was already deleted");
                    return new OkResult();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Caught exception: ", e.Message, "Stack Trace: ", e.StackTrace);
                return BadRequest(e);
            }
        }
    }
}
