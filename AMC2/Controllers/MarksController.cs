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
            //var enrolls = db.enrolls.Include(e => e.session_Details).Include(e => e.skillset).Include(e => e.userreg);
            //return View(enrolls.ToList());
            //return RedirectToAction("Index", "Enrolls");
            return View();
            
        }
        public ActionResult Attendence()
        {
            var enrolls = db.enrolls.Include(e => e.session_Details).Include(e => e.skillset).Include(e => e.userreg);
            return View(enrolls.ToList());
            
            //return View();
        }

    }
}