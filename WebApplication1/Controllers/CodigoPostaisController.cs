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
    public class CodigoPostaisController : Controller
    {
        private ProjectDBEntities db = new ProjectDBEntities();

        // GET: CodigoPostais
        public ActionResult Index()
        {
            return View(db.CodigoPostal.ToList());
        }

        // GET: CodigoPostais/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CodigoPostal codigoPostal = db.CodigoPostal.Find(id);
            if (codigoPostal == null)
            {
                return HttpNotFound();
            }
            return View(codigoPostal);
        }

        // GET: CodigoPostais/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CodigoPostais/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Codigo,Localidade")] CodigoPostal codigoPostal)
        {
            if (ModelState.IsValid)
            {
                db.CodigoPostal.Add(codigoPostal);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(codigoPostal);
        }

        // GET: CodigoPostais/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CodigoPostal codigoPostal = db.CodigoPostal.Find(id);
            if (codigoPostal == null)
            {
                return HttpNotFound();
            }
            return View(codigoPostal);
        }

        // POST: CodigoPostais/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Codigo,Localidade")] CodigoPostal codigoPostal)
        {
            if (ModelState.IsValid)
            {
                db.Entry(codigoPostal).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(codigoPostal);
        }

        // GET: CodigoPostais/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CodigoPostal codigoPostal = db.CodigoPostal.Find(id);
            if (codigoPostal == null)
            {
                return HttpNotFound();
            }
            return View(codigoPostal);
        }

        // POST: CodigoPostais/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CodigoPostal codigoPostal = db.CodigoPostal.Find(id);
            db.CodigoPostal.Remove(codigoPostal);
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
