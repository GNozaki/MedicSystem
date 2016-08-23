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
    public class PacientesController : Controller
    {
        private MedicalContext db = new MedicalContext();

        // GET: Pacientes
        public ActionResult Index()
        {
            var pacientes = db.Pacientes.Include(p => p.Dados).Include(p => p.Endereco);
            return View(pacientes.ToList());
        }

        // GET: Pacientes/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pacientes pacientes = db.Pacientes.Find(id);
            if (pacientes == null)
            {
                return HttpNotFound();
            }
            return View(pacientes);
        }

        // GET: Pacientes/Create
        public ActionResult Create()
        {
            ViewBag.data_string = "01/01/2000";
            PacientesCreateViewModel model = new PacientesCreateViewModel();
            return View(model);
        }

        // POST: Pacientes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(DadosPessoais dados, Enderecos endereco, string data_nasc)
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

                Pacientes paciente = new Pacientes();
                paciente.Dados = dados;
                paciente.Endereco = endereco;

                db.Pacientes.Add(paciente);
                 
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            PacientesCreateViewModel view_model = new PacientesCreateViewModel(dados, endereco);

            ViewBag.data_string = "";

            return View(view_model);
        }

        // GET: Pacientes/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pacientes pacientes = db.Pacientes.Find(id);
            if (pacientes == null)
            {
                return HttpNotFound();
            }
            ViewBag.DadosPessoaisId = new SelectList(db.DadosPessoais, "DadosId", "Cpf", pacientes.DadosPessoaisId);
            ViewBag.EnderecoId = new SelectList(db.Enderecos, "EnderecoId", "Pais", pacientes.EnderecoId);
            return View(pacientes);
        }

        // POST: Pacientes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PacienteId,EnderecoId,DadosPessoaisId")] Pacientes pacientes)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pacientes).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DadosPessoaisId = new SelectList(db.DadosPessoais, "DadosId", "Cpf", pacientes.DadosPessoaisId);
            ViewBag.EnderecoId = new SelectList(db.Enderecos, "EnderecoId", "Pais", pacientes.EnderecoId);
            return View(pacientes);
        }

        // GET: Pacientes/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pacientes pacientes = db.Pacientes.Find(id);
            if (pacientes == null)
            {
                return HttpNotFound();
            }
            return View(pacientes);
        }

        // POST: Pacientes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            Pacientes pacientes = db.Pacientes.Find(id);
            db.Pacientes.Remove(pacientes);
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
