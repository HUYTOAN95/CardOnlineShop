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
    public class BillDetailsController : Controller
    {
        private CardShopDBContext db = new CardShopDBContext();

        // GET: Admin/BillDetails
        public ActionResult Index()
        {
            var billDetails = db.BillDetails.Include(b => b.Bill).Include(b => b.Product);
            return View(billDetails.ToList());
        }

        // GET: Admin/BillDetails/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BillDetail billDetail = db.BillDetails.Find(id);
            if (billDetail == null)
            {
                return HttpNotFound();
            }
            return View(billDetail);
        }

        // GET: Admin/BillDetails/Create
        public ActionResult Create()
        {
            ViewBag.BillID = new SelectList(db.Bills, "BillID", "EmployeeID");
            ViewBag.ProductID = new SelectList(db.Products, "ProductID", "ProductName");
            return View();
        }

        // POST: Admin/BillDetails/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "BillDetailID,BillID,ProductID,Quanlity")] BillDetail billDetail)
        {
            if (ModelState.IsValid)
            {
                db.BillDetails.Add(billDetail);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.BillID = new SelectList(db.Bills, "BillID", "EmployeeID", billDetail.BillID);
            ViewBag.ProductID = new SelectList(db.Products, "ProductID", "ProductName", billDetail.ProductID);
            return View(billDetail);
        }

        // GET: Admin/BillDetails/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BillDetail billDetail = db.BillDetails.Find(id);
            if (billDetail == null)
            {
                return HttpNotFound();
            }
            ViewBag.BillID = new SelectList(db.Bills, "BillID", "EmployeeID", billDetail.BillID);
            ViewBag.ProductID = new SelectList(db.Products, "ProductID", "ProductName", billDetail.ProductID);
            return View(billDetail);
        }

        // POST: Admin/BillDetails/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "BillDetailID,BillID,ProductID,Quanlity")] BillDetail billDetail)
        {
            if (ModelState.IsValid)
            {
                db.Entry(billDetail).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.BillID = new SelectList(db.Bills, "BillID", "EmployeeID", billDetail.BillID);
            ViewBag.ProductID = new SelectList(db.Products, "ProductID", "ProductName", billDetail.ProductID);
            return View(billDetail);
        }

        // GET: Admin/BillDetails/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BillDetail billDetail = db.BillDetails.Find(id);
            if (billDetail == null)
            {
                return HttpNotFound();
            }
            return View(billDetail);
        }

        // POST: Admin/BillDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BillDetail billDetail = db.BillDetails.Find(id);
            db.BillDetails.Remove(billDetail);
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
