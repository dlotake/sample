using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BillingApplication.Models
{
    class Product
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public double Rate { get; set; }
        public double CGST { get; set; }
        public double SGST { get; set; }
        public double IGST { get; set; }
        public string material { get;set; }
        public bool IsDeleted { get; set; }
    }
}
