using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AutoLotDALEF.Models
{
    public partial class CreditRisk
    {
        [Key]
        public int CustId { get; set; }

        [StringLength(50)]
        [Index("IDX_CreditRisk_Name", IsUnique = true, Order = 2)]
        public string FirstName { get; set; }

        [Index("IDX_CreditRisk_Name", IsUnique = true, Order = 1)]
        [StringLength(50)]
        public string LastName { get; set; }

        [Timestamp]
        public byte[] Timestamp { get; set; }
    }
}
