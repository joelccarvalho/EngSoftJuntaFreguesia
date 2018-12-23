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
    public class InformacoesUteisController : Controller
    {
        private ProjectDBEntities db = new ProjectDBEntities();

        // GET: InformacoesUteis
        public ActionResult Index()
        {
            var status = CheckIsValid();

            if (status != 2)
            {
                var type = CheckUserType();

                // Admin ou membro da junta vê todas as informações
                if(type == "admin" || type == "mj")
                {
                    var informacoesUteis = db.InformacoesUteis.Include(i => i.CodigoPostal).Include(i => i.Utilizadores);
                    return View(informacoesUteis.ToList());
                }
                else // Senão só vê as informações enviadas para ele ou para a sua freguesia
                {
                    string CurrentId = User.Identity.GetUserId();

                    // Código Postal
                    var userCurrent = from u in db.Utilizadores
                                      where u.UserID == CurrentId
                                      select u;
 
                    foreach (var user in userCurrent)
                    {
                        var informacoesUteis = db.InformacoesUteis.Include(i => i.CodigoPostal).Include(i => i.Utilizadores).Where(s => s.Utilizadores.UserID == CurrentId || s.CodigoPostal.ID == user.IdCodigoPostal);
                        return View(informacoesUteis.ToList());
                    }
                }
            }
            return View("~/Views/Home/Index.cshtml");
        }

        // GET: InformacoesUteis/Details/5
        public ActionResult Details(int? id)
        {
            var status = CheckIsValid();

            if (status == 1)
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
            return View("~/Views/Home/Index.cshtml");
        }

        // GET: InformacoesUteis/Create
        public ActionResult Create()
        {
            var status = CheckIsValid();

            if (status == 1)
            {
                ViewBag.IdCodigoPostal = new SelectList(db.CodigoPostal, "ID", "Codigo");
                ViewBag.Destinatario = new SelectList(db.Utilizadores, "ID", "Nome");
                return View();
            }
            return View("~/Views/Home/Index.cshtml");
        }

        // POST: InformacoesUteis/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Assunto,Descricao,Destinatario,IdCodigoPostal")] InformacoesUteis informacoesUteis)
        {
            var status = CheckIsValid();

            if (status == 1)
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
            return View("~/Views/Home/Index.cshtml");
        }

        // GET: InformacoesUteis/Edit/5
        public ActionResult Edit(int? id)
        {
            var status = CheckIsValid();

            if (status == 1)
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
            return View("~/Views/Home/Index.cshtml");
        }

        // POST: InformacoesUteis/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Assunto,Descricao,Destinatario,IdCodigoPostal")] InformacoesUteis informacoesUteis)
        {
            var status = CheckIsValid();

            if (status == 1)
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
            return View("~/Views/Home/Index.cshtml");
        }

        // GET: InformacoesUteis/Delete/5
        public ActionResult Delete(int? id)
        {
            var status = CheckIsValid();

            if (status == 1)
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
            return View("~/Views/Home/Index.cshtml");
        }

        // POST: InformacoesUteis/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var status = CheckIsValid();

            if (status == 1)
            {
                InformacoesUteis informacoesUteis = db.InformacoesUteis.Find(id);
                db.InformacoesUteis.Remove(informacoesUteis);
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

        /*
         * Verificar tipo de utilizador logado
         */
        public string CheckUserType()
        {
            var type = "";

            var CurrentUserId = User.Identity.GetUserId();

            var userCurrent = from u in db.Utilizadores
                              where u.UserID == CurrentUserId
                              select u;

            // Utilizador encontrado
            if (userCurrent.Count() != 0)
            {
                foreach (var user in userCurrent)
                {
                    switch (user.TipoUtilizador.Tipo)
                    {
                        case "Administrador":
                            type = "admin";
                            break;

                        case "Freguês":
                            type = "fregues";
                            break;

                        case "Pessoa não residente":
                            type = "pnr";
                            break;

                        case "Membro da Junta":
                            type = "mj";
                            break;

                        default:
                            break;
                    }
                }
            }
            return type;
        }
    }
}
