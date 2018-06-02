using CardOnlineShop.Areas.Admin.Models.DataModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace CardOnlineShop.Areas.Admin.Models.BusinessModel
{
    public class CardShopDBContext : DbContext
    {
        public CardShopDBContext() : base("name=CardShopDBContextConnectionString")
        {

        }
        public DbSet<Administrator> Administrators { get; set; }
        public DbSet<Bill> Bills { get; set; }
        public DbSet<BillDetail> BillDetails { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<GrantPermissions> GrantPermissions { get; set; }
        public DbSet<Product> Products { get; set; }
     
        public DbSet<SubMenu> SubMenus { get; set; }


    }
}