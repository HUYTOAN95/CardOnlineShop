using CardOnlineShop.Areas.Admin.Models.BusinessModel;
using CardOnlineShop.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CardOnlineShop.Areas.Admin.Controllers
{
    public class HomeController : Controller
    {
        // GET: Admin/Home
        CardShopDBContext db = new CardShopDBContext();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(string username, string password)
        {
            string passwordmd5 = EncryptMD5.Encrypt(password);
            var user = db.Administrators.SingleOrDefault(x => x.UserName == username && x.PassWord == passwordmd5 && x.Allowed==1);
            if(user!=null)
            {
                Session["userid"] = user.UserID;
                Session["username"] = user.UserName;
                Session["fullname"] = user.FullName;
                Session["avatar"] = user.Avatar;
                return RedirectToAction("Index");
            }
            ViewBag.Error = "Đăng nhập sai cmmr!";
            return View();
        }
        public ActionResult MainMenu()
        {
            var model = db.SubMenus.ToList();
            return PartialView(model);
        }
    }
}