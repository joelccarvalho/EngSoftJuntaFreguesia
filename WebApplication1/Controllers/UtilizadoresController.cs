using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ModelProject;
using Microsoft.AspNet.Identity;

namespace WebApplication1.Controllers
{
    [Authorize]
    public class UtilizadoresController : Controller
    {
        private ProjectDBEntities db = new ProjectDBEntities();

        // GET: Utilizadores
        public ActionResult Index(string searchString)
        {
            var status = CheckIsValid();

            if (status == 1)
            {
                if (!string.IsNullOrEmpty(searchString))
                {
                    var utilizadores = db.Utilizadores.Where(s => s.Nome.Contains(searchString));
                    return View(utilizadores.ToList());
                }
                else
                {
                    var utilizadores = db.Utilizadores.Include(u => u.CodigoPostal).Include(u => u.TipoUtilizador);
                    return View(utilizadores.ToList());
                }

            }
            return View("~/Views/Home/Index.cshtml");
        }

        // GET: Utilizadores/Details/5
        public ActionResult Details(int? id)
        {
            var status = CheckIsValid();

            if (status == 1)
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
            return View("~/Views/Home/Index.cshtml");
        }

        // GET: Utilizadores/Create
        public ActionResult Create()
        {
            var status = CheckIsValid();

            if (status == 2)
            {
                ViewBag.IdCodigoPostal = new SelectList(db.CodigoPostal, "ID", "Codigo");
                ViewBag.Tipo = new SelectList(db.TipoUtilizador, "ID", "Tipo");
                return View();
            }
            return View("~/Views/Home/Index.cshtml");
        }

        // POST: Utilizadores/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Nome,NumCC,NumEleitor,Morada,IdCodigoPostal,Email,NomeUtilizador,Password,Estado,Tipo,UserID")] Utilizadores utilizadores)
        {
            var status = CheckIsValid();

            if (status == 2)
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
            return View("~/Views/Home/Index.cshtml");
        }

        // GET: Utilizadores/Edit/5
        public ActionResult Edit(int? id)
        {
            var status = CheckIsValid();
            var itsMe  = CheckId(id);

            if (status == 1 || itsMe)
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
            return View("~/Views/Home/Index.cshtml");
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
            var status = CheckIsValid();

            if (status == 1)
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
            return View("~/Views/Home/Index.cshtml");
        }

        // POST: Utilizadores/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var status = CheckIsValid();

            if (status == 1)
            {
                Utilizadores utilizadores = db.Utilizadores.Find(id);
                db.Utilizadores.Remove(utilizadores);
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
                }

            }
            else // Falta 2º registo
            {
                return 2;
            }
            return 1;
        }

        public bool CheckId(int? id)
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
                    // Se o id é do utilizador logado
                    if (id == user.ID)
                    {
                        return true;
                    }
                }

            }
            return false;
        } 
    }
}
