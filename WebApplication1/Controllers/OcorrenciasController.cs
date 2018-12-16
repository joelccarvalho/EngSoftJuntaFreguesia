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
    public class OcorrenciasController : Controller
    {
        private ProjectDBEntities db = new ProjectDBEntities();

        // GET: Ocorrencias
        public ActionResult Index()
        {
            var status = CheckIsValid();

            if (status == 1)
            {
                var ocorrencias = db.Ocorrencias.Include(o => o.TipoOcorrencias).Include(o => o.Utilizadores);
                return View(ocorrencias.ToList());
            }
            return View("~/Views/Home/Index.cshtml");
        }

        // GET: Ocorrencias/Details/5
        public ActionResult Details(int? id)
        {
            var status = CheckIsValid();

            if (status == 1)
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
            return View("~/Views/Home/Index.cshtml");
        }

        // GET: Ocorrencias/Create
        public ActionResult Create()
        {
            var status = CheckIsValid();

            if (status == 1)
            {
                // Utilizador logado
                var CurrentUserId = User.Identity.GetUserId();
                // Tipo de utilizador
                var userCurrent = from u in db.Utilizadores
                                  where u.UserID == CurrentUserId
                                  select u;

                // Utilizador encontrado
                if (userCurrent.Count() == 1)
                {
                    foreach (var user in userCurrent)
                    {
                        // Esclarecimentos e problemas gerais restritos aos fregueses
                        var roles = from r in db.TipoOcorrencias
                                    where r.PermissoesUtilizador == null || r.PermissoesUtilizador == user.Tipo
                                    select r;

                        if (roles.Count() > 0)
                        {
                            ViewBag.IdOcorrencias = new SelectList(roles, "ID", "Designacao");
                        }
                        else
                        {
                            ViewBag.IdOcorrencias = new SelectList(db.TipoOcorrencias, "ID", "Designacao");
                        }
                    }
                }
                else
                {
                    ViewBag.IdOcorrencias = new SelectList(db.TipoOcorrencias, "ID", "Designacao");
                }

                ViewBag.IdUtilizador = new SelectList(db.Utilizadores, "ID", "Nome");
                return View();
            }
            return View("~/Views/Home/Index.cshtml");
        }

        // POST: Ocorrencias/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,IdUtilizador,IdOcorrencias,Descricao,Anexos")] Ocorrencias ocorrencias)
        {
            var status = CheckIsValid();

            if (status == 1)
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
            return View("~/Views/Home/Index.cshtml");
        }

        // GET: Ocorrencias/Edit/5
        public ActionResult Edit(int? id)
        {
            var status = CheckIsValid();

            if (status == 1)
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
            return View("~/Views/Home/Index.cshtml");
        }

        // POST: Ocorrencias/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,IdUtilizador,IdOcorrencias,Descricao,Anexos")] Ocorrencias ocorrencias)
        {
            var status = CheckIsValid();

            if (status == 1)
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
            return View("~/Views/Home/Index.cshtml");
        }

        // GET: Ocorrencias/Delete/5
        public ActionResult Delete(int? id)
        {
            var status = CheckIsValid();

            if (status == 1)
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
            return View("~/Views/Home/Index.cshtml");
        }

        // POST: Ocorrencias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var status = CheckIsValid();

            if (status == 1)
            {
                Ocorrencias ocorrencias = db.Ocorrencias.Find(id);
                db.Ocorrencias.Remove(ocorrencias);
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
                    // Se o email não foi verificado
                    if (user.Estado == 0)
                    {
                        return 0;
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
