using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MedicSystem.Models;
using MedicSystem.ViewModels;

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
            ClinicasCreateViewModel model = new ClinicasCreateViewModel();
            return View(model);
        }

        // POST: Clinicas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Enderecos endereco, Clinicas clinica)
        {
            Enderecos novo_endereco = endereco;
            if (ModelState.IsValid)
            {
                db.Enderecos.Add(novo_endereco);
                db.SaveChanges();

                clinica.Endereco = novo_endereco;

                db.Clinicas.Add(clinica);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ClinicasCreateViewModel view_model = new ClinicasCreateViewModel(clinica, endereco);

            return View(view_model);
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
