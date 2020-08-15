using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SepetIslemi.Models
{
    public class Product
    {
        public int ProductID { get; set; }
        public int? CategoryId { get; set; }
        public string ProductName { get; set; }
        public decimal UnitPrice { get; set; }

        public virtual Category Category { get; set; }
    }
}
