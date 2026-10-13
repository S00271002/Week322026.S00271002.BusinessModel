using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week32026.BusinessModel
{
    public class Supplier
    {
        public int SupplierID { get; set; }
        public string? SupplierName { get; set; }
        public string? SupplierAddressLine1 { get; set; }
        public string? SupplierAddressLine2 { get; set; }

        public ICollection<Product>? Products { get; set; }
    }
}
