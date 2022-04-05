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
    public class EnrollsController : Controller
    {
        private AMCEntities1 db = new AMCEntities1();

        // GET: Enrolls
        public ActionResult Index()
        {
            var enrolls = db.enrolls.Include(e => e.session_Details).Include(e => e.skillset).Include(e => e.userreg);
            return View(enrolls.ToList());
        }

        // GET: Enrolls/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            enroll enroll = db.enrolls.Find(id);
            if (enroll == null)
            {
                return HttpNotFound();
            }
            return View(enroll);
        }

        // GET: Enrolls/Create
        public ActionResult Create()
        {
            ViewBag.Session_Id = new SelectList(db.session_Details, "Session_Id", "Session_Des");
            ViewBag.Skill_Id = new SelectList(db.skillsets, "Skill_Id", "Skill_Type");
            ViewBag.User_Id = new SelectList(db.userregs, "User_Id", "FirstName");
            return View();
        }

        // POST: Enrolls/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Sno,Skill_Id,Session_Id,User_Id")] enroll enroll)
        {
            if (ModelState.IsValid)
            {
                db.enrolls.Add(enroll);
                db.SaveChanges();
                TempData["AlertMessage"] = "Enrolled Successfully !";
                return RedirectToAction("Index");
            }

            ViewBag.Session_Id = new SelectList(db.session_Details, "Session_Id", "Session_Des", enroll.Session_Id);
            ViewBag.Skill_Id = new SelectList(db.skillsets, "Skill_Id", "Skill_Type", enroll.Skill_Id);
            ViewBag.User_Id = new SelectList(db.userregs, "User_Id", "FirstName", enroll.User_Id);
            return View(enroll);
        }

        // GET: Enrolls/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            enroll enroll = db.enrolls.Find(id);
            if (enroll == null)
            {
                return HttpNotFound();
            }
            ViewBag.Session_Id = new SelectList(db.session_Details, "Session_Id", "Session_Des", enroll.Session_Id);
            ViewBag.Skill_Id = new SelectList(db.skillsets, "Skill_Id", "Skill_Type", enroll.Skill_Id);
            ViewBag.User_Id = new SelectList(db.userregs, "User_Id", "FirstName", enroll.User_Id);
            return View(enroll);
        }

        // POST: Enrolls/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Sno,Skill_Id,Session_Id,User_Id")] enroll enroll)
        {
            if (ModelState.IsValid)
            {
                db.Entry(enroll).State = EntityState.Modified;
                db.SaveChanges();
                TempData["AlertMessage"] = "Updated Successfully !";
                return RedirectToAction("Index");
            }
            ViewBag.Session_Id = new SelectList(db.session_Details, "Session_Id", "Session_Des", enroll.Session_Id);
            ViewBag.Skill_Id = new SelectList(db.skillsets, "Skill_Id", "Skill_Type", enroll.Skill_Id);
            ViewBag.User_Id = new SelectList(db.userregs, "User_Id", "FirstName", enroll.User_Id);
            return View(enroll);
        }

        // GET: Enrolls/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            enroll enroll = db.enrolls.Find(id);
            if (enroll == null)
            {
                return HttpNotFound();
            }
            return View(enroll);
        }

        // POST: Enrolls/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            enroll enroll = db.enrolls.Find(id);
            db.enrolls.Remove(enroll);
            db.SaveChanges();
            TempData["AlertMessage"] = "Deleted Successfully !";
            return RedirectToAction("Index");
        }
        public ActionResult Save(session_Details stud)
        {
            try
            {
                stud.Session_Id = db.session_Details.Select(e => e.Session_Id).Max() + 1;
                db.session_Details.Add(stud);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
            }
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
