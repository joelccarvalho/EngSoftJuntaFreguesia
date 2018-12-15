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
    [Authorize]
    public class TipoOcorrenciasController : Controller
    {
        private ProjectDBEntities db = new ProjectDBEntities();

        // GET: TipoOcorrencias
        public ActionResult Index()
        {
            var tipoOcorrencias = db.TipoOcorrencias.Include(t => t.TipoUtilizador);
            return View(tipoOcorrencias.ToList());
        }

        // GET: TipoOcorrencias/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoOcorrencias tipoOcorrencias = db.TipoOcorrencias.Find(id);
            if (tipoOcorrencias == null)
            {
                return HttpNotFound();
            }
            return View(tipoOcorrencias);
        }

        // GET: TipoOcorrencias/Create
        public ActionResult Create()
        {
            ViewBag.PermissoesUtilizador = new SelectList(db.TipoUtilizador, "ID", "Tipo");
            return View();
        }

        // POST: TipoOcorrencias/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Designacao,PermissoesUtilizador")] TipoOcorrencias tipoOcorrencias)
        {
            if (ModelState.IsValid)
            {
                db.TipoOcorrencias.Add(tipoOcorrencias);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.PermissoesUtilizador = new SelectList(db.TipoUtilizador, "ID", "Tipo", tipoOcorrencias.PermissoesUtilizador);
            return View(tipoOcorrencias);
        }

        // GET: TipoOcorrencias/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoOcorrencias tipoOcorrencias = db.TipoOcorrencias.Find(id);
            if (tipoOcorrencias == null)
            {
                return HttpNotFound();
            }
            ViewBag.PermissoesUtilizador = new SelectList(db.TipoUtilizador, "ID", "Tipo", tipoOcorrencias.PermissoesUtilizador);
            return View(tipoOcorrencias);
        }

        // POST: TipoOcorrencias/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Designacao,PermissoesUtilizador")] TipoOcorrencias tipoOcorrencias)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tipoOcorrencias).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.PermissoesUtilizador = new SelectList(db.TipoUtilizador, "ID", "Tipo", tipoOcorrencias.PermissoesUtilizador);
            return View(tipoOcorrencias);
        }

        // GET: TipoOcorrencias/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoOcorrencias tipoOcorrencias = db.TipoOcorrencias.Find(id);
            if (tipoOcorrencias == null)
            {
                return HttpNotFound();
            }
            return View(tipoOcorrencias);
        }

        // POST: TipoOcorrencias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TipoOcorrencias tipoOcorrencias = db.TipoOcorrencias.Find(id);
            db.TipoOcorrencias.Remove(tipoOcorrencias);
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
