using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsSelling.Models;

namespace WindowsSelling.BusinessModel
{
    class SaleOperations
    {
        public static bool SaveSaleRecord(Sale sale, out int BillNo)
        {
            try
            {
                using (SellingContext obj = new SellingContext())
                {

                    var samesale = obj.Sales.Where(n => n.Invoicenumber == sale.Invoicenumber && n.IsDeleted == false).ToList();
                    Customer cust = obj.Customers.Single(n => n.CustomerId == sale.customer.CustomerId);
                    List<Sale> salelst = obj.Sales.Include("saledetails").Where(n => n.SaleId == sale.SaleId).ToList();
                    sale.customer = cust;
                    if (salelst.Count > 0)
                    {
                        int count = samesale.Count(n => n.SaleId != sale.SaleId);
                        if (count > 0)
                        {
                            MessageBox.Show("Invoice no is already present");
                            BillNo = -1;
                            return false;
                        }
                        salelst[0].CGST = sale.CGST;
                        salelst[0].customer = sale.customer;
                        salelst[0].Date = sale.Date;
                        salelst[0].FinalTotal = sale.FinalTotal;
                        salelst[0].IGST = sale.IGST;
                        salelst[0].IsDeleted = sale.IsDeleted;
                        salelst[0].PaidAmount = sale.PaidAmount;
                        salelst[0].PaymentMode = sale.PaymentMode;
                        salelst[0].PaymentModeDetails = sale.PaymentModeDetails;
                        salelst[0].RemainingAmount = sale.RemainingAmount;

                        foreach (SaleDetail saled in sale.saledetails)
                        {
                            if (saled.SaleDetailId > 0)
                            {                              
                                obj.Entry(saled).State = System.Data.Entity.EntityState.Modified;
                                int yy = obj.SaveChanges();
                            }
                        }
                        salelst[0].SGST = sale.SGST;
                        salelst[0].Total = sale.Total;
                        salelst[0].TotalTax = sale.TotalTax;
                        obj.Entry(salelst[0]).State = System.Data.Entity.EntityState.Modified;
                        int RowChangedCount = obj.SaveChanges();
                       

                        List<int> saleid = salelst[0].saledetails.Select(n => n.SaleDetailId).ToList();
                        foreach (int id in saleid)
                        {
                            var temp = obj.SaleDetails.Single(n => n.SaleDetailId == id);
                            obj.Entry(temp).State = System.Data.Entity.EntityState.Deleted;
                        }

                        int ii = obj.SaveChanges();
                        foreach (SaleDetail saled in sale.saledetails)
                        {
                            obj.SaleDetails.Add(saled);
                        }
                        int o = obj.SaveChanges();
                        BillNo = sale.SaleId;
                        return RowChangedCount > 0 ? true : false;
                    }
                    else
                    {        
                        if(obj.Sales.Count(n=>n.Invoicenumber == sale.Invoicenumber) != 0)
                        {
                            MessageBox.Show("Invoice number is already present");
                            BillNo = -1;
                            return false;
                        }
                        sale = obj.Sales.Add(sale);                        
                        int RowChangedCount = obj.SaveChanges();
                        BillNo = sale.SaleId;
                        return RowChangedCount > 0 ? true : false;
                    }

                }
            }
            catch (Exception ex)
            {
                BusinessModel.Log.Logger(ex);
                BillNo = 0;
                return false;
            }
        }

        public static bool UpdateSaleRecord(Sale sale)
        {
            try
            {
                using (SellingContext obj = new SellingContext())
                {
                    var samesale = obj.Sales.Where(n => n.Invoicenumber == sale.Invoicenumber && n.IsDeleted == false).ToList();

                    int count = samesale.Count(n => n.SaleId != sale.SaleId);
                    if (count > 0)
                    {
                        //MessageBox.Show("Invoice no is already present");                       
                        return false;
                    }
                }
                List<SaleDetail> saledetails = sale.saledetails.ToList();
                using (SellingContext obj = new SellingContext())
                {
                    List<SaleDetail> temp = obj.SaleDetails.Include("SaleId").Where(n => n.SaleId.SaleId == sale.SaleId).ToList();
                    foreach (var saledetail in temp)
                    {
                        if (saledetail.SaleDetailId > 0)
                        {
                            var hhhh = obj.Entry(saledetail).State = System.Data.Entity.EntityState.Deleted;
                            int yy = obj.SaveChanges();
                        }
                    }
                }
                using (SellingContext obj = new SellingContext())
                {
                    
                    sale.saledetails = null;                    
                    sale.Customer_Id = sale.customer.CustomerId;
                    var ttt = obj.Entry(sale).State = System.Data.Entity.EntityState.Modified;                                     
                    int yy = obj.SaveChanges();
                    var ttdt = obj.SaleDetails.AddRange(saledetails);
                    yy = obj.SaveChanges();
                }
                return true;
            }
            catch (Exception ex)
            {
                BusinessModel.Log.Logger(ex);
                return false;
            }

        }

        public static Sale GetSaleRecord(int SaleId)
        {
            try
            {
                using (SellingContext obj = new SellingContext())
                {
                    return obj.Sales.Include("customer").Include("saledetails").Single(n => n.SaleId == SaleId);
                }
            }
            catch (Exception ex)
            {
                BusinessModel.Log.Logger(ex);
            }
            return null;
        }

        public static List<Sale> LoadSaleRecords()
        {
            try
            {
                using (SellingContext obj = new SellingContext())
                {
                    return obj.Sales.Include("Customer").Where(n => n.IsDeleted == false).OrderByDescending(n => n.Date).Take(100).ToList();
                }
            }
            catch (Exception ex)
            {
                BusinessModel.Log.Logger(ex);
                return null;
            }
        }

        public static List<Sale> LoadDeletedSaleRecords()
        {
            try
            {
                using (SellingContext obj = new SellingContext())
                {
                    return obj.Sales.Include("Customer").Where(n => n.IsDeleted == true).OrderByDescending(n => n.Date).ToList();
                }
            }
            catch (Exception ex)
            {
                BusinessModel.Log.Logger(ex);
                return null;
            }
        }

        public static bool SaleDelete(int SaleId)
        {
            try
            {
                using (SellingContext obj = new SellingContext())
                {
                    Sale sale = obj.Sales.Single(n => n.SaleId == SaleId);
                    sale.IsDeleted = true;
                    obj.Entry(sale).State = System.Data.Entity.EntityState.Modified;
                    int RowChangedCount = obj.SaveChanges();
                    if (RowChangedCount > 0)
                        return true;
                    else
                        return false;
                }
            }
            catch (Exception ex)
            {
                BusinessModel.Log.Logger(ex);
                return false;
            }
        }

        public static bool SaleUndoDelete(int SaleId)
        {
            try
            {
                using (SellingContext obj = new SellingContext())
                {
                    Sale sale = obj.Sales.Single(n => n.SaleId == SaleId);
                    sale.IsDeleted = false;
                    obj.Entry(sale).State = System.Data.Entity.EntityState.Modified;
                    int RowChangedCount = obj.SaveChanges();
                    if (RowChangedCount > 0)
                        return true;
                    else
                        return false;
                }
            }
            catch (Exception ex)
            {
                BusinessModel.Log.Logger(ex);
                return false;
            }
        }

        public static List<Sale> LoadSaleRecords(string customername, bool _customername, DateTime start, bool _start, DateTime end, bool _end)
        {
            try
            {
                using (SellingContext obj = new SellingContext())
                {
                    if (_customername && !_start && !_end)
                        return obj.Sales.Include("Customer").Where(n => n.IsDeleted == false).OrderByDescending(n => n.Date).ToList().Where(n => n.customer.Name.Equals(customername)).ToList();
                    else if (!_customername && _start && _end)
                        return obj.Sales.Include("Customer").Where(n => n.IsDeleted == false).OrderByDescending(n => n.Date).ToList().Where(n => n.Date.Date >= start.Date && n.Date.Date <= end.Date).ToList();
                    else if (_customername && _start && _end)
                        return obj.Sales.Include("Customer").Where(n => n.IsDeleted == false).OrderByDescending(n => n.Date).ToList().Where(n => (n.Date.Date >= start.Date && n.Date.Date <= end.Date) && n.customer.Name.Equals(customername)).ToList();
                    else
                        return obj.Sales.Include("Customer").Where(n => n.IsDeleted == false).OrderByDescending(n => n.Date).ToList();


                }
            }
            catch (Exception ex)
            {
                BusinessModel.Log.Logger(ex);
                return null;
            }
        }

        public static List<Sale> LoadPendingSaleRecords()
        {
            try
            {
                using (SellingContext obj = new SellingContext())
                {
                    return obj.Sales.Include("Customer").Where(n => n.IsDeleted == false && n.RemainingAmount > 0).OrderByDescending(n => n.Date).ToList();
                }
            }
            catch (Exception ex)
            {
                BusinessModel.Log.Logger(ex);
                return null;
            }
        }

        public static List<Sale> LoadDeletedSaleRecords(string customername, bool _customername, DateTime start, bool _start, DateTime end, bool _end)
        {
            try
            {
                using (SellingContext obj = new SellingContext())
                {
                    if (_customername && !_start && !_end)
                        return obj.Sales.Include("Customer").Where(n => n.IsDeleted == true).OrderByDescending(n => n.Date).ToList().Where(n => n.customer.Name.Equals(customername)).ToList();
                    else if (!_customername && _start && _end)
                        return obj.Sales.Include("Customer").Where(n => n.IsDeleted == true).OrderByDescending(n => n.Date).ToList().Where(n => n.Date.Date >= start.Date && n.Date.Date <= end.Date).ToList();
                    else if (_customername && _start && _end)
                        return obj.Sales.Include("Customer").Where(n => n.IsDeleted == true).OrderByDescending(n => n.Date).ToList().Where(n => (n.Date.Date >= start.Date && n.Date.Date <= end.Date) && n.customer.Name.Equals(customername)).ToList();
                    else
                        return obj.Sales.Include("Customer").Where(n => n.IsDeleted == true).OrderByDescending(n => n.Date).ToList();


                }
            }
            catch (Exception ex)
            {
                BusinessModel.Log.Logger(ex);
                return null;
            }
        }

        public static List<SaleDetail> MaterialWise(string Materialname, DateTime date1, DateTime date2)
        {
            try
            {
                using (SellingContext obj = new SellingContext())
                {

                    var sales = obj.SaleDetails.Include("SaleId").Include("SaleId.customer").Where(nn => (nn.Date.Day >= date1.Day && nn.Date.Month >= date1.Month && nn.Date.Year >= date1.Year) && (nn.Date.Day <= date2.Day && nn.Date.Month <= date2.Month && nn.Date.Year <= date2.Year)).ToList();
                    if (sales.Count > 0)
                    {
                        var Saledetails = sales.Where(nn => BusinessModel.ProductOperations.GetProductDetails(nn.ProductId).material == Materialname).ToList();
                        return Saledetails;
                    }
                    return new List<SaleDetail>();
                }
            }
            catch (Exception ex)
            {
                BusinessModel.Log.Logger(ex);
                return new List<SaleDetail>();
            }
        }

        public static List<SaleDetail> AllMaterialWise(DateTime date1, DateTime date2)
        {
            try
            {
                using (SellingContext obj = new SellingContext())
                {

                    var sales = obj.SaleDetails.Include("SaleId").Include("SaleId.customer").Where(nn => (nn.Date.Day >= date1.Day && nn.Date.Month >= date1.Month && nn.Date.Year >= date1.Year) && (nn.Date.Day <= date2.Day && nn.Date.Month <= date2.Month && nn.Date.Year <= date2.Year)).ToList();
                    return sales;
                }
            }
            catch (Exception ex)
            {
                BusinessModel.Log.Logger(ex);
                return new List<SaleDetail>();
            }
        }



    }
}
