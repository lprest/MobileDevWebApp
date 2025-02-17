using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MobileDevWebApp.Models
{
    public class SupplierM
    {
        [Key]
        [Column("SupplierID")]
        public int SupplierID { get; set; }
        [Column("SupplierName")]
        public string SupplierName { get; set; }
    }
}
