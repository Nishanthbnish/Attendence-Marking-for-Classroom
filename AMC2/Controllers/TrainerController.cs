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
    public class TrainerController : Controller
    {
        private AMCEntities1 db = new AMCEntities1();

        // GET: Trainer
        public ActionResult Index()
        {
            var trainerregs = db.trainerregs.Include(t => t.session_Details).Include(t => t.skillset);
            return View(trainerregs.ToList());
        }

        // GET: Trainer/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            trainerreg trainerreg = db.trainerregs.Find(id);
            if (trainerreg == null)
            {
                return HttpNotFound();
            }
            return View(trainerreg);
        }

        // GET: Trainer/Create
        public ActionResult Create()
        {
            ViewBag.Session_Id = new SelectList(db.session_Details, "Session_Id", "Session_Des");
            ViewBag.Skill_Id = new SelectList(db.skillsets, "Skill_Id", "Skill_Type");
            return View();
        }

        // POST: Trainer/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Trainer_Id,Trainer_Name,Contact_Number,Email,Skill_Id,Session_Id")] trainerreg trainerreg)
        {
            if (ModelState.IsValid)
            {
                db.trainerregs.Add(trainerreg);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Session_Id = new SelectList(db.session_Details, "Session_Id", "Session_Des", trainerreg.Session_Id);
            ViewBag.Skill_Id = new SelectList(db.skillsets, "Skill_Id", "Skill_Type", trainerreg.Skill_Id);
            return View(trainerreg);
        }

        // GET: Trainer/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            trainerreg trainerreg = db.trainerregs.Find(id);
            if (trainerreg == null)
            {
                return HttpNotFound();
            }
            ViewBag.Session_Id = new SelectList(db.session_Details, "Session_Id", "Session_Des", trainerreg.Session_Id);
            ViewBag.Skill_Id = new SelectList(db.skillsets, "Skill_Id", "Skill_Type", trainerreg.Skill_Id);
            return View(trainerreg);
        }

        // POST: Trainer/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Trainer_Id,Trainer_Name,Contact_Number,Email,Skill_Id,Session_Id")] trainerreg trainerreg)
        {
            if (ModelState.IsValid)
            {
                db.Entry(trainerreg).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Session_Id = new SelectList(db.session_Details, "Session_Id", "Session_Des", trainerreg.Session_Id);
            ViewBag.Skill_Id = new SelectList(db.skillsets, "Skill_Id", "Skill_Type", trainerreg.Skill_Id);
            return View(trainerreg);
        }

        // GET: Trainer/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            trainerreg trainerreg = db.trainerregs.Find(id);
            if (trainerreg == null)
            {
                return HttpNotFound();
            }
            return View(trainerreg);
        }

        // POST: Trainer/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            trainerreg trainerreg = db.trainerregs.Find(id);
            db.trainerregs.Remove(trainerreg);
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
