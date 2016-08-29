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
    public class MedicosController : Controller
    {
        private MedicalContext db = new MedicalContext();

        // GET: Medicos
        public ActionResult Index()
        {
            var medicos = db.Medicos.Include(m => m.Dados).Include(m => m.Endereco);
            return View(medicos.ToList());
        }

        // GET: Medicos/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Medicos medicos = db.Medicos.Find(id);
            db.Entry(medicos).Reference(p => p.Dados).Load();
            db.Entry(medicos).Reference(p => p.Endereco).Load();
            if (medicos == null)
            {
                return HttpNotFound();
            }
            return View(medicos);
        }

        // GET: Medicos/Create
        public ActionResult Create()
        {
            ViewBag.data_string = "01/01/2000";
            MedicosCreateViewModel model = new MedicosCreateViewModel();
            return View(model);
        }

        // POST: Medicos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(DadosPessoais dados, Enderecos endereco, Medicos medicos, string data_nasc)
        {
            DateTime data_object;
            if (!DateTime.TryParse(data_nasc + " 00:00:00", out data_object))
            {
                data_object = DateTime.Today;
            }

            Enderecos novo_endereco = endereco;
            DadosPessoais novos_dados = dados;
            novos_dados.Nascimento = data_object;            

            if (ModelState.IsValid)
            {
                db.DadosPessoais.Add(novos_dados);
                db.Enderecos.Add(novo_endereco);

                db.SaveChanges();

                medicos.Dados = novos_dados;
                medicos.Endereco = novo_endereco;

                db.Medicos.Add(medicos);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            MedicosCreateViewModel view_model = new MedicosCreateViewModel(dados, endereco, medicos);

            ViewBag.data_string = "";

            return View(view_model);
        }

        // GET: Medicos/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Medicos medicos = db.Medicos.Find(id);
            if (medicos == null)
            {
                return HttpNotFound();
            }
            ViewBag.DadosPessoaisId = new SelectList(db.DadosPessoais, "DadosId", "Cpf", medicos.DadosPessoaisId);
            ViewBag.EnderecoId = new SelectList(db.Enderecos, "EnderecoId", "Pais", medicos.EnderecoId);
            return View(medicos);
        }

        // POST: Medicos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MedicoId,Crm,Especialidade,EnderecoId,DadosPessoaisId")] Medicos medicos)
        {
            if (ModelState.IsValid)
            {
                db.Entry(medicos).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DadosPessoaisId = new SelectList(db.DadosPessoais, "DadosId", "Cpf", medicos.DadosPessoaisId);
            ViewBag.EnderecoId = new SelectList(db.Enderecos, "EnderecoId", "Pais", medicos.EnderecoId);
            return View(medicos);
        }

        // GET: Medicos/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Medicos medicos = db.Medicos.Find(id);
            if (medicos == null)
            {
                return HttpNotFound();
            }
            return View(medicos);
        }

        // POST: Medicos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            Medicos medicos = db.Medicos.Find(id);
            db.Medicos.Remove(medicos);
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
