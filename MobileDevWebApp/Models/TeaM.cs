using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MobileDevWebApp.Models
{
    [Table("Tea")]
    public class TeaM
    {
        [Key]
        [Column("TeaID")]
        public int TeaID { get; set; }
        [Column("TeaName")]
        public string TeaName { get; set; }
        [Column("TeaType")]
        public string TeaType { get; set; }
    }
}
