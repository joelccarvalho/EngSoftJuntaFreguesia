using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ModelProject;

namespace WebApplication1.Controllers
{
    public class OcorrenciasController : Controller
    {
        private ProjectDBEntities db = new ProjectDBEntities();

        // GET: Ocorrencias
        public ActionResult Index()
        {
            var ocorrencias = db.Ocorrencias.Include(o => o.TipoOcorrencias).Include(o => o.Utilizadores);
            return View(ocorrencias.ToList());
        }

        // GET: Ocorrencias/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ocorrencias ocorrencias = db.Ocorrencias.Find(id);
            if (ocorrencias == null)
            {
                return HttpNotFound();
            }
            return View(ocorrencias);
        }

        // GET: Ocorrencias/Create
        public ActionResult Create()
        {
            ViewBag.IdOcorrencias = new SelectList(db.TipoOcorrencias, "ID", "Designacao");
            ViewBag.IdUtilizador = new SelectList(db.Utilizadores, "ID", "Nome");
            return View();
        }

        // POST: Ocorrencias/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,IdUtilizador,IdOcorrencias,Descricao,Anexos")] Ocorrencias ocorrencias)
        {
            if (ModelState.IsValid)
            {
                db.Ocorrencias.Add(ocorrencias);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdOcorrencias = new SelectList(db.TipoOcorrencias, "ID", "Designacao", ocorrencias.IdOcorrencias);
            ViewBag.IdUtilizador = new SelectList(db.Utilizadores, "ID", "Nome", ocorrencias.IdUtilizador);
            return View(ocorrencias);
        }

        // GET: Ocorrencias/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ocorrencias ocorrencias = db.Ocorrencias.Find(id);
            if (ocorrencias == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdOcorrencias = new SelectList(db.TipoOcorrencias, "ID", "Designacao", ocorrencias.IdOcorrencias);
            ViewBag.IdUtilizador = new SelectList(db.Utilizadores, "ID", "Nome", ocorrencias.IdUtilizador);
            return View(ocorrencias);
        }

        // POST: Ocorrencias/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,IdUtilizador,IdOcorrencias,Descricao,Anexos")] Ocorrencias ocorrencias)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ocorrencias).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdOcorrencias = new SelectList(db.TipoOcorrencias, "ID", "Designacao", ocorrencias.IdOcorrencias);
            ViewBag.IdUtilizador = new SelectList(db.Utilizadores, "ID", "Nome", ocorrencias.IdUtilizador);
            return View(ocorrencias);
        }

        // GET: Ocorrencias/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ocorrencias ocorrencias = db.Ocorrencias.Find(id);
            if (ocorrencias == null)
            {
                return HttpNotFound();
            }
            return View(ocorrencias);
        }

        // POST: Ocorrencias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Ocorrencias ocorrencias = db.Ocorrencias.Find(id);
            db.Ocorrencias.Remove(ocorrencias);
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
