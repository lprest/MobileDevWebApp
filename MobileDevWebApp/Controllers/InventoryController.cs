using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MobileDevWebApp.Models;

namespace MobileDevWebApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class InventoryController : ControllerBase
    {
        [HttpGet("[action]")]
        public IActionResult getItems()
        {
            try
            {
                using (MyContext db = new MyContext())
                {
                    List<Models.InventoryM> inventory = db.Inventory.ToList();

                    return new ObjectResult(inventory);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Caught exception:", e.Message, "Stack trace: ", e.StackTrace);
                return BadRequest(e);
            }
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> postItem([FromBody] InventoryM value)
        {
            try
            {
                using (MyContext db = new MyContext())
                {
                    InventoryM model = new InventoryM();
                    TeaM tea = await db.Tea.FirstOrDefaultAsync(x => x.TeaID == value.TeaID) ?? new();
                    SupplierM supplier = await db.Supplier.FirstOrDefaultAsync(x => x.SupplierID == value.SupplierID) ?? new();

                    if (tea == null || supplier == null)
                    {
                        Console.WriteLine("One or both of the TeaId or SupplierID does not exist");
                        return NotFound();
                    }
                    model.SupplierID = value.SupplierID;
                    model.TeaID = value.TeaID;
                    model.Quantity = value.Quantity;

                    db.Inventory.Add(model);
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

    }
}
