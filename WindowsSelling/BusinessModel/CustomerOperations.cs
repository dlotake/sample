using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsSelling.Models;

namespace WindowsSelling.BusinessModel
{
    class CustomerOperations
    {
        public static bool SaveCustomer(Customer customer)
        {
            try
            {
                using (SellingContext obj = new SellingContext())
                {                    
                    List<Customer> Customers = obj.Customers.Where(n => n.CustomerId == customer.CustomerId && n.IsDeleted == false).ToList();
                    var samecustomers = obj.Customers.Where(n => n.MobileNumber.ToLower().Trim().Equals(customer.MobileNumber.ToLower().Trim()) && n.IsDeleted == false).ToList();
                    if (Customers.Count > 0)
                    {                       
                        int count = samecustomers.Count(n => n.CustomerId != customer.CustomerId);
                        if (count > 0)
                        {
                            MessageBox.Show("Customer is already present,Please enter different Mobile", "Error");
                            return false;
                        }
                        Customers[0].Address = customer.Address;
                        Customers[0].CustomerId = customer.CustomerId;
                        Customers[0].MobileNumber = customer.MobileNumber;
                        Customers[0].Name = customer.Name;
                        Customers[0].GSTNumber = customer.GSTNumber;
                    }
                    if (Customers.Count == 0)
                    {
                        if(samecustomers.Count>0)
                        {
                            MessageBox.Show("Customer is already present,Please enter different Mobile", "Error");
                            return false;
                        }
                        obj.Customers.Add(customer);
                        int RowChangedCount = obj.SaveChanges();
                        return RowChangedCount > 0 ? true : false;
                    }
                    else
                    {
                        obj.Entry(Customers[0]).State = System.Data.Entity.EntityState.Modified;
                        int RowChangedCount = obj.SaveChanges();
                        return RowChangedCount > 0 ? true : false;
                    }
                }
            }
            catch (Exception ex)
            {
                BusinessModel.Log.Logger(ex);
                return false;
            }
        }

        public static List<Customer> LoadCustomers()
        {
            try
            {
                using (SellingContext obj = new SellingContext())
                {
                    obj.Configuration.ProxyCreationEnabled = false;
                    return obj.Customers.Where(n=>n.IsDeleted == false).ToList();
                }
            }
            catch (Exception ex)
            {
                BusinessModel.Log.Logger(ex);
            }
            return null;
        }

        public static List<Customer> LoadDeletedCustomers()
        {
            try
            {
                using (SellingContext obj = new SellingContext())
                {
                    return obj.Customers.Where(n => n.IsDeleted == true).ToList();
                }
            }
            catch (Exception ex)
            {
                BusinessModel.Log.Logger(ex);
            }
            return null;
        }

        public static bool DeleteCustomer(int customerId)
        {
            try
            {
                using (SellingContext obj = new SellingContext())
                {
                    Customer customer = obj.Customers.Single(n => n.CustomerId == customerId);
                    customer.IsDeleted = true;
                    obj.Entry(customer).State = System.Data.Entity.EntityState.Modified;
                    int RowChangedCount = obj.SaveChanges();
                    return RowChangedCount > 0 ? true : false;
                }
            }
            catch (Exception ex)
            {
                BusinessModel.Log.Logger(ex);
            }
            return false;
        }

        public static bool RestoreDeletedCustomer(int customerid)
        {
            try
            {
                using (SellingContext obj = new SellingContext())
                {
                    Customer customer = obj.Customers.Single(n => n.CustomerId == customerid);
                    customer.IsDeleted = false;
                    obj.Entry(customer).State = System.Data.Entity.EntityState.Modified;
                    int RowChangedCount = obj.SaveChanges();
                    return RowChangedCount > 0 ? true : false;
                }
            }
            catch (Exception ex)
            {
                BusinessModel.Log.Logger(ex);
            }
            return false;
        }


    }
}
