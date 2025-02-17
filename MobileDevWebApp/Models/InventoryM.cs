using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MobileDevWebApp.Models
{
    public class InventoryM
    {
        [Key]
        [Column("InventoryID")]
        public int InventoryID { get; set; }

        [ForeignKey("Tea")] //Table name not column name
        [Column("TeaID")]
        public int TeaID { get; set; }
        public TeaM Tea { get; set; }

        [ForeignKey("Supplier")]
        [Column("SupplierID")]
        public int SupplierID { get; set; }
        public SupplierM Supplier { get; set; }

        [Column("Quantity")]
        public string Quantity { get; set; }
    }
}
