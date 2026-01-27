using C_EgitimKampi301.EntityLayer.concrete;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_EgitimKampi301.DataAccessLayer.context
{
    public class KampContext: DbContext
    {
        public DbSet <Category> Categories { get; set; } //Category c# tarafında Categories de Sql e yansıyacak tablo ismi- sınıf ve tablo karışmasın diye böyle kullanılır - yalın hali class çoğıul hali tablo
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Admin> Admins { get; set; }









































    }
}
