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
    public class SkillsetsController : Controller
    {
        private AMCEntities1 db = new AMCEntities1();

        // GET: Skillsets
        public ActionResult Index()
        {
            return View(db.skillsets.ToList());
        }

        // GET: Skillsets/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            skillset skillset = db.skillsets.Find(id);
            if (skillset == null)
            {
                return HttpNotFound();
            }
            return View(skillset);
        }

        // GET: Skillsets/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Skillsets/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Skill_Id,Skill_Type,Skill_Des")] skillset skillset)
        {
            if (ModelState.IsValid)
            {
                db.skillsets.Add(skillset);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(skillset);
        }

        // GET: Skillsets/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            skillset skillset = db.skillsets.Find(id);
            if (skillset == null)
            {
                return HttpNotFound();
            }
            return View(skillset);
        }

        // POST: Skillsets/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Skill_Id,Skill_Type,Skill_Des")] skillset skillset)
        {
            if (ModelState.IsValid)
            {
                db.Entry(skillset).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(skillset);
        }

        // GET: Skillsets/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            skillset skillset = db.skillsets.Find(id);
            if (skillset == null)
            {
                return HttpNotFound();
            }
            return View(skillset);
        }

        // POST: Skillsets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            skillset skillset = db.skillsets.Find(id);
            db.skillsets.Remove(skillset);
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
