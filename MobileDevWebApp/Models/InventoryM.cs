using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MobileDevWebApp.Models
{
    public class InventoryM
    {
        [Key]
        [Column("InventoryID")]
        public int InventoryID { get; set; }

        [ForeignKey("Tea")]
        [Column("TeaID")]
        public int TeaID { get; set; }

        [ForeignKey("Supplier")]
        [Column("SupplierID")]
        public int SupplierID { get; set; }

        [Column("Quantity")]
        public int? Quantity { get; set; }
    }
}
