using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using CardOnlineShop.Areas.Admin.Models.DataModel;

namespace CardOnlineShop.Areas.Admin.Models.BusinessModel
{
    public class CardShopDatabaseInitializer : DropCreateDatabaseIfModelChanges<CardShopDBContext>
    {
        protected override void Seed(CardShopDBContext context)

        {
            var admin = new Administrator()
            {
                UserName = "admin",
                PassWord = "21232f297a57a5a743894a0e4a801fc3",
                FullName = "Nguyễn Huy Toàn",
                Avatar = "/Areas/Admin/Content/images/mypicture.jpg",
                Email = "nguyenhuytoanbsh@gmail.com",
                CreateDate = DateTime.Now.Date,
                IsAdmin = 1,
                Allowed = 1

            };
            context.Administrators.Add(admin);
            var user = new Administrator()
            {
                UserName = "user",
                PassWord = "ee11cbb19052e40b07aac0ca060c23ee",
                FullName = "Nguyễn Huy Toàn",
                Avatar = "/Areas/Admin/Content/images/avatar-01.jpg",
                Email = "nguyenhuytoanbsh@gmail.com",
                CreateDate = DateTime.Now.Date,
                IsAdmin = 0,
                Allowed = 1

            };
            context.Administrators.Add(user);
         
            var menu = new SubMenu()
            {
                SubMenuName = "Product",
                Link = "/Admin/Products/Index",
                Icon = "fa fa-bars"
            };
            context.SubMenus.Add(menu);
            context.SaveChanges();
        }
        


    }
}