using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Perftest.Models;

namespace Perftest.Controllers
{ 
    public class PersonController : Controller
    {
        private PerftestContext db = new PerftestContext();

        //
        // GET: /Person/

        public ViewResult Index()
        {
            return View(db.PersonModels.ToList());
        }

        //
        // GET: /Person/Details/5

        public ViewResult Details(int id)
        {
            PersonModels personmodels = db.PersonModels.Find(id);
            return View(personmodels);
        }

        //
        // GET: /Person/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /Person/Create

        [HttpPost]
        public ActionResult Create(PersonModels personmodels)
        {
            if (ModelState.IsValid)
            {
                db.PersonModels.Add(personmodels);
                db.SaveChanges();
                return RedirectToAction("Index");  
            }

            return View(personmodels);
        }
        
        //
        // GET: /Person/Edit/5
 
        public ActionResult Edit(int id)
        {
            PersonModels personmodels = db.PersonModels.Find(id);
            return View(personmodels);
        }

        //
        // POST: /Person/Edit/5

        [HttpPost]
        public ActionResult Edit(PersonModels personmodels)
        {
            if (ModelState.IsValid)
            {
                db.Entry(personmodels).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(personmodels);
        }

        //
        // GET: /Person/Delete/5
 
        public ActionResult Delete(int id)
        {
            PersonModels personmodels = db.PersonModels.Find(id);
            return View(personmodels);
        }

        //
        // POST: /Person/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {            
            PersonModels personmodels = db.PersonModels.Find(id);
            db.PersonModels.Remove(personmodels);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}