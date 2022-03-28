using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AMC2.Models;

namespace AMC2.Controllers
{
    public class AdminController : Controller
    {
        private AMCEntities1 db = new AMCEntities1();

        // GET: Admin
        public ActionResult Index()
        {
            return View(db.adminregs.ToList());
        }

        // GET: Admin/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            adminreg adminreg = db.adminregs.Find(id);
            if (adminreg == null)
            {
                return HttpNotFound();
            }
            return View(adminreg);
        }

        // GET: Admin/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "FirstName,LastName,Age,Gender,Contact_Number,Admin_Id,Password")] adminreg adminreg)
        {
            if (ModelState.IsValid)
            {
                db.adminregs.Add(adminreg);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(adminreg);
        }

        // GET: Admin/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            adminreg adminreg = db.adminregs.Find(id);
            if (adminreg == null)
            {
                return HttpNotFound();
            }
            return View(adminreg);
        }

        // POST: Admin/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "FirstName,LastName,Age,Gender,Contact_Number,Admin_Id,Password")] adminreg adminreg)
        {
            if (ModelState.IsValid)
            {
                db.Entry(adminreg).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(adminreg);
        }

        // GET: Admin/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            adminreg adminreg = db.adminregs.Find(id);
            if (adminreg == null)
            {
                return HttpNotFound();
            }
            return View(adminreg);
        }

        // POST: Admin/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            adminreg adminreg = db.adminregs.Find(id);
            db.adminregs.Remove(adminreg);
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
