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
    public class DadosPessoaisController : Controller
    {
        private MedicalContext db = new MedicalContext();

        // GET: DadosPessoais/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DadosPessoais dadosPessoais = db.DadosPessoais.Find(id);
            if (dadosPessoais == null)
            {
                return HttpNotFound();
            }
            return View(dadosPessoais);
        }

        // POST: DadosPessoais/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "DadosId,Cpf,Nome,Nascimento")] DadosPessoais dadosPessoais)
        {
            if (ModelState.IsValid)
            {
                db.Entry(dadosPessoais).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index", "Pacientes");
            }
            return View(dadosPessoais);
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
