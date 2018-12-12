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
    public class UtilizadoresController : Controller
    {
        private ProjectDBEntities db = new ProjectDBEntities();

        // GET: Utilizadores
        public ActionResult Index()
        {
            var utilizadores = db.Utilizadores.Include(u => u.CodigoPostal).Include(u => u.TipoUtilizador);
            return View(utilizadores.ToList());
        }

        // GET: Utilizadores/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Utilizadores utilizadores = db.Utilizadores.Find(id);
            if (utilizadores == null)
            {
                return HttpNotFound();
            }
            return View(utilizadores);
        }

        // GET: Utilizadores/Create
        public ActionResult Create()
        {
            ViewBag.IdCodigoPostal = new SelectList(db.CodigoPostal, "ID", "Codigo");
            ViewBag.Tipo = new SelectList(db.TipoUtilizador, "ID", "Tipo");
            return View();
        }

        // POST: Utilizadores/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Nome,NumCC,NumEleitor,Morada,IdCodigoPostal,Email,NomeUtilizador,Password,Estado,Tipo,UserID")] Utilizadores utilizadores)
        {
            if (ModelState.IsValid)
            {
                db.Utilizadores.Add(utilizadores);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdCodigoPostal = new SelectList(db.CodigoPostal, "ID", "Codigo", utilizadores.IdCodigoPostal);
            ViewBag.Tipo = new SelectList(db.TipoUtilizador, "ID", "Tipo", utilizadores.Tipo);
            return View("/");
        }

        // GET: Utilizadores/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Utilizadores utilizadores = db.Utilizadores.Find(id);
            if (utilizadores == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdCodigoPostal = new SelectList(db.CodigoPostal, "ID", "Codigo", utilizadores.IdCodigoPostal);
            ViewBag.Tipo = new SelectList(db.TipoUtilizador, "ID", "Tipo", utilizadores.Tipo);
            return View(utilizadores);
        }

        // POST: Utilizadores/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Nome,NumCC,NumEleitor,Morada,IdCodigoPostal,Email,NomeUtilizador,Password,Estado,Tipo,UserID")] Utilizadores utilizadores)
        {
            if (ModelState.IsValid)
            {
                db.Entry(utilizadores).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdCodigoPostal = new SelectList(db.CodigoPostal, "ID", "Codigo", utilizadores.IdCodigoPostal);
            ViewBag.Tipo = new SelectList(db.TipoUtilizador, "ID", "Tipo", utilizadores.Tipo);
            return View(utilizadores);
        }

        // GET: Utilizadores/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Utilizadores utilizadores = db.Utilizadores.Find(id);
            if (utilizadores == null)
            {
                return HttpNotFound();
            }
            return View(utilizadores);
        }

        // POST: Utilizadores/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Utilizadores utilizadores = db.Utilizadores.Find(id);
            db.Utilizadores.Remove(utilizadores);
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
