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
    public class EnderecosController : Controller
    {
        private MedicalContext db = new MedicalContext();

        // GET: Enderecos/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Enderecos enderecos = db.Enderecos.Find(id);
            if (enderecos == null)
            {
                return HttpNotFound();
            }
            return View(enderecos);
        }

        // POST: Enderecos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EnderecoId,Pais,Estado,Cidade,Bairro,Logradouro,NumeroLocal,Cep")] Enderecos enderecos)
        {
            if (ModelState.IsValid)
            {
                db.Entry(enderecos).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index", "Pacientes");
            }
            return View(enderecos);
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
