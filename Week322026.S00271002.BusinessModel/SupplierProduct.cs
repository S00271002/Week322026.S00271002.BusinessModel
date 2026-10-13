using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week32026.BusinessModel
{
    public class SupplierProduct
    {
    

        public int SupplierID { get; set; }
        public int ProductID { get; set; }
        public DateTime DateFirstSupplied { get; set; }
        public virtual Supplier? FK_Supplier { get; set; }

        public virtual Product? FK_Product { get; set; }
    }
}
