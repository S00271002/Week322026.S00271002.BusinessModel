using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Week32026.BusinessModel
{
    public class Product
    {
        public int ProductID { get; set; }
        public int CategoryID { get; set; }
        public string? Description { get; set; }
        public float UnitPrice { get; set; }
        public DateTime dateFirstIssued { get; set; }
        public int QuantityInStock { get; set; }
        public virtual Category? associatedCategory { get; set; }

        public ICollection<Supplier>? Suppliers { get; set; }
    }
}