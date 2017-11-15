using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsSelling.Models;

namespace WindowsSelling.BusinessModel
{
    class ProductOperations
    {
        public static bool SaveProduct(Product product)
        {
            try
            {
                using (SellingContext obj = new SellingContext())
                {
                    var sameproducts = obj.Products.Where(n => n.Name.ToLower().Trim().Equals(product.Name.ToLower().Trim()) && n.IsDeleted == false).ToList();
                    List<Product> products = obj.Products.Where(n => n.ProductId == product.ProductId && n.IsDeleted == false).ToList();
                    if (products.Count > 0)
                    {
                        int count = sameproducts.Count(n => n.ProductId != product.ProductId);
                        if (count > 0)
                        {
                            MessageBox.Show("Product name is already present,Please enter different name", "Error");
                            return false;
                        }
                        products[0].CGST = product.CGST;
                        products[0].IGST = product.IGST;
                        products[0].material = product.material;
                        products[0].Name = product.Name;
                        products[0].Rate = product.Rate;
                        products[0].SGST = product.SGST;
                    }
                    if (products.Count == 0)
                    {
                        if (sameproducts.Count > 0)
                        {
                            MessageBox.Show("Product name is already present,Please enter different name", "Error");
                            return false;
                        }
                        obj.Products.Add(product);
                        int RowChangedCount = obj.SaveChanges();
                        return RowChangedCount > 0 ? true : false;
                    }
                    else
                    {
                        obj.Entry(products[0]).State = System.Data.Entity.EntityState.Modified;
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
        public static List<Product> LoadProducts()
        {
            try
            {
                using (SellingContext obj = new SellingContext())
                {
                    //obj.Configuration. .ProxyCreationEnabled = false;
                    return obj.Products.Where(n => n.IsDeleted == false).ToList();
                }
            }
            catch (Exception ex)
            {
                BusinessModel.Log.Logger(ex);
            }
            return null;
        }
        public static List<Product> LoadDeletedProducts()
        {
            try
            {
                using (SellingContext obj = new SellingContext())
                {
                    return obj.Products.Where(n => n.IsDeleted == true).ToList();
                }
            }
            catch (Exception ex)
            {
                BusinessModel.Log.Logger(ex);
            }
            return null;
        }
        public static bool DeleteProduct(int productId)
        {
            try
            {
                using (SellingContext obj = new SellingContext())
                {
                    Product product = obj.Products.Single(n => n.ProductId == productId);
                    product.IsDeleted = true;
                    obj.Entry(product).State = System.Data.Entity.EntityState.Modified;
                    int RowChangedCount = obj.SaveChanges();
                    return RowChangedCount > 0 ? true : false;
                }
            }
            catch (Exception ex)
            {

            }
            return false;
        }
        public static bool RestoreDeletedProduct(int productid)
        {
            try
            {
                using (SellingContext obj = new SellingContext())
                {
                    Product product = obj.Products.Single(n => n.ProductId == productid);
                    product.IsDeleted = false;
                    obj.Entry(product).State = System.Data.Entity.EntityState.Modified;
                    int RowChangedCount = obj.SaveChanges();
                    return RowChangedCount > 0 ? true : false;
                }
            }
            catch (Exception ex)
            {

            }
            return false;
        }
        public static Product GetProductDetails(string ProductName)
        {
            try
            {
                using (SellingContext obj = new SellingContext())
                {
                    var Products = obj.Products.Where(n => n.Name.Equals(ProductName)).ToList();
                    if (Products.Count > 0)
                        return Products[0];
                    else
                        return null;
                }
            }
            catch (Exception ex)
            {
                BusinessModel.Log.Logger(ex);
                return null;
            }
        }
        public static Product GetProductDetails(int ProductId)
        {
            try
            {
                using (SellingContext obj = new SellingContext())
                {
                    return obj.Products.Single(n => n.ProductId == ProductId);
                }
            }
            catch (Exception ex)
            {
                BusinessModel.Log.Logger(ex);
                return null;
            }
        }
        public static List<string> GetMaterials()
        {
            try
            {
                using (SellingContext obj = new SellingContext())
                {
                    return obj.Products.Select(n => n.material).Distinct().ToList();
                }
            }
            catch (Exception ex)
            {
                BusinessModel.Log.Logger(ex);
                return null;
            }

        }
    }
}
