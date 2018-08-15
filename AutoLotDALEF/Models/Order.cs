using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AutoLotDALEF.Models
{
    public partial class Order
    {
        [Key, Required, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int OrderId { get; set; }

        [Required]
        public int CustId { get; set; }

        [Required]
        public int CarId { get; set; }

        [Timestamp]
        public byte[] Timestamp { get; set; }

        [ForeignKey("CustId")]
        public virtual Customer Customer { get; set; }

        [ForeignKey("CarId")]
        public virtual Inventory Car { get; set; }

    }
}
