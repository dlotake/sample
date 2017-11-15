using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BillingApplication.Models
{
    class SaleDetail
    {
        public int SaleDetailId { get; set; }      
        public double Rate { get; set; }
        public double Quantity { get; set; }
        public double TotalAmount { get; set; }
        public double IGST { get; set; }
        public double IGSTAmount { get; set; }
        public double CGST { get; set; }
        public double CGSTAmount { get; set; }
        public double SGST { get; set; }
        public double SGSTAmount { get; set; }
        public double FinalAmount { get; set; }
        public DateTime Date { get; set; }
        public double Discount { get; set; }
        public double DiscountAmount { get; set; }
        public int ProductId { get; set; }          
        public Sale SaleId { get; set; }      

    }
}
