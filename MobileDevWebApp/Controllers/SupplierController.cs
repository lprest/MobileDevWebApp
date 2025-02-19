using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MobileDevWebApp.Data;
using MobileDevWebApp.Models;

namespace MobileDevWebApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SupplierController : ControllerBase
    {
        [HttpGet("[action]")]
        public IActionResult getItems()
        {
            try
            {
                using (AppDbContext db = new AppDbContext())
                {
                    List<Models.SupplierM> Supplier = db.Supplier.ToList();

                    return new ObjectResult(Supplier);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Caught an exception: ", e.Message, "Stack Trace: ", e.StackTrace);
                return BadRequest(e);
            }
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> postItem([FromBody] SupplierM value)
        {
            try
            {
                using (AppDbContext db = new AppDbContext())
                {
                    SupplierM model = new SupplierM();

                    model.SupplierName = value.SupplierName;

                    db.Supplier.Add(model);
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
        public async Task<IActionResult> updateItem([FromBody] SupplierM value, Int64 id)
        {
            try
            {
                Console.WriteLine("updating the user with the id: ", id);
                using (AppDbContext db = new AppDbContext())
                {
                    SupplierM model = await db.Supplier.FirstOrDefaultAsync(x => x.SupplierID == id);
                    if (model == null)
                    {
                        Console.WriteLine("Id ", id, " Not found");
                        return NotFound(id);
                    }

                    model.SupplierName = value.SupplierName;

                    db.Supplier.Update(model);
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
                    SupplierM Supplier = await db.Supplier.FirstOrDefaultAsync(n => n.SupplierID == id);
                    if (Supplier != null)
                    {
                        Console.WriteLine("deleting item: " + Supplier);
                        db.Supplier.Remove(Supplier);
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
