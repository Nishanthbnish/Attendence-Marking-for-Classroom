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
    public class SessionController : Controller
    {
        private AMCEntities1 db = new AMCEntities1();

        // GET: Session
        public ActionResult Index()
        {
            var session_Details = db.session_Details.Include(s => s.skillset);
            return View(session_Details.ToList());
        }

        // GET: Session/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            session_Details session_Details = db.session_Details.Find(id);
            if (session_Details == null)
            {
                return HttpNotFound();
            }
            return View(session_Details);
        }

        // GET: Session/Create
        public ActionResult Create()
        {
            ViewBag.Skill_Id = new SelectList(db.skillsets, "Skill_Id", "Skill_Type");
            return View();
        }

        // POST: Session/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Session_Id,Session_Des,Skill_Id,Session_Date,Session_Time,Available_Slots")] session_Details session_Details)
        {
            if (ModelState.IsValid)
            {
                db.session_Details.Add(session_Details);
                db.SaveChanges();
                TempData["AlertMessage"] = "Session Created Successfully !";
                return RedirectToAction("Index");
            }

            ViewBag.Skill_Id = new SelectList(db.skillsets, "Skill_Id", "Skill_Type", session_Details.Skill_Id);
            return View(session_Details);
        }

        // GET: Session/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            session_Details session_Details = db.session_Details.Find(id);
            if (session_Details == null)
            {
                return HttpNotFound();
            }
            ViewBag.Skill_Id = new SelectList(db.skillsets, "Skill_Id", "Skill_Type", session_Details.Skill_Id);
            return View(session_Details);
        }

        // POST: Session/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Session_Id,Session_Des,Skill_Id,Session_Date,Session_Time,Available_Slots")] session_Details session_Details)
        {
            if (ModelState.IsValid)
            {
                db.Entry(session_Details).State = EntityState.Modified;
                db.SaveChanges();
                TempData["AlertMessage"] = "Session Updated Successfully !";
                return RedirectToAction("Index");
            }
            ViewBag.Skill_Id = new SelectList(db.skillsets, "Skill_Id", "Skill_Type", session_Details.Skill_Id);
            return View(session_Details);
        }

        // GET: Session/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            session_Details session_Details = db.session_Details.Find(id);
            if (session_Details == null)
            {
                return HttpNotFound();
            }
            return View(session_Details);
        }

        // POST: Session/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            session_Details session_Details = db.session_Details.Find(id);
            db.session_Details.Remove(session_Details);
            db.SaveChanges();
            TempData["AlertMessage"] = "Session Deleted Successfully !";
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
