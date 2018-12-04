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
    public class InformacoesUteisController : Controller
    {
        private ProjectDBEntities db = new ProjectDBEntities();

        // GET: InformacoesUteis
        public ActionResult Index()
        {
            var informacoesUteis = db.InformacoesUteis.Include(i => i.CodigoPostal).Include(i => i.Utilizadores);
            return View(informacoesUteis.ToList());
        }

        // GET: InformacoesUteis/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            InformacoesUteis informacoesUteis = db.InformacoesUteis.Find(id);
            if (informacoesUteis == null)
            {
                return HttpNotFound();
            }
            return View(informacoesUteis);
        }

        // GET: InformacoesUteis/Create
        public ActionResult Create()
        {
            ViewBag.IdCodigoPostal = new SelectList(db.CodigoPostal, "ID", "Codigo");
            ViewBag.Destinatario = new SelectList(db.Utilizadores, "ID", "Nome");
            return View();
        }

        // POST: InformacoesUteis/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Assunto,Descricao,Destinatario,IdCodigoPostal")] InformacoesUteis informacoesUteis)
        {
            if (ModelState.IsValid)
            {
                db.InformacoesUteis.Add(informacoesUteis);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdCodigoPostal = new SelectList(db.CodigoPostal, "ID", "Codigo", informacoesUteis.IdCodigoPostal);
            ViewBag.Destinatario = new SelectList(db.Utilizadores, "ID", "Nome", informacoesUteis.Destinatario);
            return View(informacoesUteis);
        }

        // GET: InformacoesUteis/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            InformacoesUteis informacoesUteis = db.InformacoesUteis.Find(id);
            if (informacoesUteis == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdCodigoPostal = new SelectList(db.CodigoPostal, "ID", "Codigo", informacoesUteis.IdCodigoPostal);
            ViewBag.Destinatario = new SelectList(db.Utilizadores, "ID", "Nome", informacoesUteis.Destinatario);
            return View(informacoesUteis);
        }

        // POST: InformacoesUteis/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Assunto,Descricao,Destinatario,IdCodigoPostal")] InformacoesUteis informacoesUteis)
        {
            if (ModelState.IsValid)
            {
                db.Entry(informacoesUteis).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdCodigoPostal = new SelectList(db.CodigoPostal, "ID", "Codigo", informacoesUteis.IdCodigoPostal);
            ViewBag.Destinatario = new SelectList(db.Utilizadores, "ID", "Nome", informacoesUteis.Destinatario);
            return View(informacoesUteis);
        }

        // GET: InformacoesUteis/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            InformacoesUteis informacoesUteis = db.InformacoesUteis.Find(id);
            if (informacoesUteis == null)
            {
                return HttpNotFound();
            }
            return View(informacoesUteis);
        }

        // POST: InformacoesUteis/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            InformacoesUteis informacoesUteis = db.InformacoesUteis.Find(id);
            db.InformacoesUteis.Remove(informacoesUteis);
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
