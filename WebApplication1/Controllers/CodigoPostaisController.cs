using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
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
            var status = CheckIsValid();

            if (status == 1)
            {
                return View(db.CodigoPostal.ToList());
            }
            return View("~/Views/Home/Index.cshtml");
        }

        // GET: CodigoPostais/Details/5
        public ActionResult Details(int? id)
        {
            var status = CheckIsValid();

            if (status == 1)
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
            return View("~/Views/Home/Index.cshtml");
        }

        // GET: CodigoPostais/Create
        public ActionResult Create()
        {
            var status = CheckIsValid();

            if (status == 2 || status == 1)
            {
                return View();
            }
            return View("~/Views/Home/Index.cshtml");
        }

        // POST: CodigoPostais/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Codigo,Localidade")] CodigoPostal codigoPostal)
        {
            var status = CheckIsValid();

            if (status == 2 || status == 1)
            {
                if (ModelState.IsValid)
                {
                    db.CodigoPostal.Add(codigoPostal);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }

                return View(codigoPostal);
            }
            return View("~/Views/Home/Index.cshtml");
        }

        // GET: CodigoPostais/Edit/5
        public ActionResult Edit(int? id)
        {
            var status = CheckIsValid();

            if (status == 1)
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
            return View("~/Views/Home/Index.cshtml");
        }

        // POST: CodigoPostais/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Codigo,Localidade")] CodigoPostal codigoPostal)
        {
            var status = CheckIsValid();

            if (status == 1)
            {
                if (ModelState.IsValid)
                {
                    db.Entry(codigoPostal).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                return View(codigoPostal);
            }
            return View("~/Views/Home/Index.cshtml");
        }

        // GET: CodigoPostais/Delete/5
        public ActionResult Delete(int? id)
        {
            var status = CheckIsValid();

            if (status == 1)
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
            return View("~/Views/Home/Index.cshtml");
        }

        // POST: CodigoPostais/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var status = CheckIsValid();

            if (status == 1)
            {
                CodigoPostal codigoPostal = db.CodigoPostal.Find(id);
                db.CodigoPostal.Remove(codigoPostal);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View("~/Views/Home/Index.cshtml");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        /* Verificar tipo e estado do utilizador
        * 0 - Sem permissões
        * 1 - Permitido
        * 2 - Permitido registar-se
        */
        public int CheckIsValid()
        {
            var CurrentUserId = User.Identity.GetUserId();

            var userCurrent = from u in db.Utilizadores
                              where u.UserID == CurrentUserId
                              select u;

            // Utilizador encontrado
            if (userCurrent.Count() != 0)
            {
                foreach (var user in userCurrent)
                {
                    // Se o email não foi verificado ou for diferente de administrador
                    if (user.Estado == 0 || user.TipoUtilizador.Tipo != "Administrador")
                    {
                        return 0;
                    }
                    else if(user.Estado == 1 || user.TipoUtilizador.Tipo == "Administrador")
                    {
                        return 1;
                    }
                }

            }
            else // Falta 2º registo
            {
                return 2;
            }
            return 1;
        }
    }
}
