using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsSelling.Models
{
    class Sale
    {
        public int SaleId { get; set; }
        public long Invoicenumber { get; set; }
        public DateTime Date { get; set; }
        [ForeignKey("Customer_Id")]        
        public virtual Customer customer { get; set; }
        public int Customer_Id { get; set; }
        public double Total { get; set; }
        public double FinalTotal { get; set; }
        public double CGST { get; set; }
        public double IGST { get; set; }
        public double SGST { get; set; }
        public double TotalTax { get; set; }

        public List<SaleDetail> saledetails { get; set; }

        public double PaidAmount { get; set; }
        public double RemainingAmount { get; set; }

        public string PaymentMode { get; set; }
        public string PaymentModeDetails { get; set; }

        public bool IsDeleted { get; set; }
    }
}
