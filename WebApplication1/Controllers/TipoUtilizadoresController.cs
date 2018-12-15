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
    public class TipoUtilizadoresController : Controller
    {
        private ProjectDBEntities db = new ProjectDBEntities();

        // GET: TipoUtilizadores
        public ActionResult Index()
        {
            return View(db.TipoUtilizador.ToList());
        }

        // GET: TipoUtilizadores/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoUtilizador tipoUtilizador = db.TipoUtilizador.Find(id);
            if (tipoUtilizador == null)
            {
                return HttpNotFound();
            }
            return View(tipoUtilizador);
        }

        // GET: TipoUtilizadores/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TipoUtilizadores/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Tipo")] TipoUtilizador tipoUtilizador)
        {
            if (ModelState.IsValid)
            {
                db.TipoUtilizador.Add(tipoUtilizador);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tipoUtilizador);
        }

        // GET: TipoUtilizadores/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoUtilizador tipoUtilizador = db.TipoUtilizador.Find(id);
            if (tipoUtilizador == null)
            {
                return HttpNotFound();
            }
            return View(tipoUtilizador);
        }

        // POST: TipoUtilizadores/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Tipo")] TipoUtilizador tipoUtilizador)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tipoUtilizador).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tipoUtilizador);
        }

        // GET: TipoUtilizadores/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoUtilizador tipoUtilizador = db.TipoUtilizador.Find(id);
            if (tipoUtilizador == null)
            {
                return HttpNotFound();
            }
            return View(tipoUtilizador);
        }

        // POST: TipoUtilizadores/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TipoUtilizador tipoUtilizador = db.TipoUtilizador.Find(id);
            db.TipoUtilizador.Remove(tipoUtilizador);
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
