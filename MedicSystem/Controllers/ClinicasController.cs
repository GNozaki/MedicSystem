using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MedicSystem.Models;

namespace MedicSystem.Controllers
{
    public class ClinicasController : Controller
    {
        private MedicalContext db = new MedicalContext();

        // GET: Clinicas
        public ActionResult Index()
        {
            return View(db.Clinicas.ToList());
        }

        // GET: Clinicas/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Clinicas clinicas = db.Clinicas.Find(id);
            if (clinicas == null)
            {
                return HttpNotFound();
            }
            return View(clinicas);
        }

        // GET: Clinicas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Clinicas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ClinicaId,Nome,Cidade,Estado")] Clinicas clinicas)
        {
            if (ModelState.IsValid)
            {
                db.Clinicas.Add(clinicas);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(clinicas);
        }

        // GET: Clinicas/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Clinicas clinicas = db.Clinicas.Find(id);
            if (clinicas == null)
            {
                return HttpNotFound();
            }
            return View(clinicas);
        }

        // POST: Clinicas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ClinicaId,Nome,Cidade,Estado")] Clinicas clinicas)
        {
            if (ModelState.IsValid)
            {
                db.Entry(clinicas).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(clinicas);
        }

        // GET: Clinicas/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Clinicas clinicas = db.Clinicas.Find(id);
            if (clinicas == null)
            {
                return HttpNotFound();
            }
            return View(clinicas);
        }

        // POST: Clinicas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            Clinicas clinicas = db.Clinicas.Find(id);
            db.Clinicas.Remove(clinicas);
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
