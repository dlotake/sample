using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Sql;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsSelling.Models
{
    class SellingContext : DbContext
    {
        public SellingContext() : base()
        {
            string myServer = Environment.MachineName;

           // DataTable servers = SqlDataSourceEnumerator.Instance.GetDataSources();
            //Database.SetInitializer(new MigrateDatabaseToLatestVersion<SellingContext, Migrations.Configuration>());
            // Database.SetInitializer(new MigrateDatabaseToLatestVersion<SellingContext, SellingContext.Migrations.Configuration>("SchoolDBConnectionString"));
            //this.Configuration.LazyLoadingEnabled = true;
            Database.SetInitializer<SellingContext>(new CreateDatabaseIfNotExists<SellingContext>());
            
        }  

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Product> Products { get; set; }     
        public DbSet<Sale> Sales { get; set; }
        public DbSet<SaleDetail> SaleDetails { get; set; }
      
    }
}
