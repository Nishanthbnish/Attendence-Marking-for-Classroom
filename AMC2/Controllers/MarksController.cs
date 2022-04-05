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
    public class MarksController : Controller
    {
        private AMCEntities1 db = new AMCEntities1();
        // GET: Marks
        public ActionResult EnrollList()
        {
            var enrolls = db.enrolls.Include(e => e.session_Details).Include(e => e.skillset).Include(e => e.userreg);
            return View(enrolls.ToList());

        }
        public ActionResult Attendence()
        {
            var enrolls = db.enrolls.Include(e => e.session_Details).Include(e => e.skillset).Include(e => e.userreg);
            return View(enrolls.ToList());
            
            //return View();
        }
        public ActionResult FeedbackList()
        {
            var feedbacks = db.Feedbacks.Include(f => f.session_Details).Include(f => f.userreg);
            return View(feedbacks.ToList());
        }

        public ActionResult SessionList()
        {
            var session_Details = db.session_Details.Include(s => s.skillset);
            return View(session_Details.ToList());
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
    }
}