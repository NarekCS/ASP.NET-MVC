﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AutoLotDALEF.Models
{    
    public partial class Customer
    {
        [Key]
        public int CustId { get; set; }

        [StringLength(50)]
        public string FirstName { get; set; }

        [StringLength(50)]
        public string LastName { get; set; }

        [Timestamp]
        public byte[] Timestamp { get; set; }

        [NotMapped]
        public string FullName => FirstName + " " + LastName;

        public virtual ICollection<Order> Orders { get; set; } = new HashSet<Order>();

        public override string ToString()
        {
            return $"{this.FirstName} {this.LastName}.";
        }
    }
}