using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CardOnlineShop.Areas.Admin.Models.BusinessModel;
using CardOnlineShop.Areas.Admin.Models.DataModel;

namespace CardOnlineShop.Areas.Admin.Controllers
{
    public class GrantPermissionsController : Controller
    {
        private CardShopDBContext db = new CardShopDBContext();

        // GET: Admin/GrantPermissions
        public ActionResult Index()
        {
            var grantPermissions = db.GrantPermissions.Include(g => g.Administrator);
            return View(grantPermissions.ToList());
        }

        // GET: Admin/GrantPermissions/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GrantPermissions grantPermissions = db.GrantPermissions.Find(id);
            if (grantPermissions == null)
            {
                return HttpNotFound();
            }
            return View(grantPermissions);
        }

        // GET: Admin/GrantPermissions/Create
        public ActionResult Create()
        {
            ViewBag.UserID = new SelectList(db.Administrators, "UserID", "UserName");
            return View();
        }

        // POST: Admin/GrantPermissions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PermissionID,PemissionName,Descrpition,UserID")] GrantPermissions grantPermissions)
        {
            if (ModelState.IsValid)
            {
                db.GrantPermissions.Add(grantPermissions);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.UserID = new SelectList(db.Administrators, "UserID", "UserName", grantPermissions.UserID);
            return View(grantPermissions);
        }

        // GET: Admin/GrantPermissions/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GrantPermissions grantPermissions = db.GrantPermissions.Find(id);
            if (grantPermissions == null)
            {
                return HttpNotFound();
            }
            ViewBag.UserID = new SelectList(db.Administrators, "UserID", "UserName", grantPermissions.UserID);
            return View(grantPermissions);
        }

        // POST: Admin/GrantPermissions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PermissionID,PemissionName,Descrpition,UserID")] GrantPermissions grantPermissions)
        {
            if (ModelState.IsValid)
            {
                db.Entry(grantPermissions).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.UserID = new SelectList(db.Administrators, "UserID", "UserName", grantPermissions.UserID);
            return View(grantPermissions);
        }

        // GET: Admin/GrantPermissions/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GrantPermissions grantPermissions = db.GrantPermissions.Find(id);
            if (grantPermissions == null)
            {
                return HttpNotFound();
            }
            return View(grantPermissions);
        }

        // POST: Admin/GrantPermissions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            GrantPermissions grantPermissions = db.GrantPermissions.Find(id);
            db.GrantPermissions.Remove(grantPermissions);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
