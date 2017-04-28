using System.Linq;
using System.Collections.Generic;
using System.Web.Mvc;
using Equipamentos.Models;
using Equipamentos.Contexts;
using System.Net;
using System.Data.Entity;

namespace Equipamentos.Controllers
{
    public class CategoriasController : Controller
    {
        private EFContext context = new EFContext();

        #region Index
        // GET: Categorias
        public ActionResult Index()
        {
            return View(context.Categorias.OrderBy(c => c.Nome));
        }
        #endregion

        #region GET Create
        // GET: Categorias
        public ActionResult Create()
        {
            return View();
        }
        #endregion

        #region POST Create
        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Categoria categoria)
        {
            context.Categorias.Add(categoria);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        #endregion

        #region GET Edit
        //Atualizar GET
        public ActionResult Edit (long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Categoria categoria = context.Categorias.Find(id);
            if (categoria == null)
            {
                return HttpNotFound();
            }

            return View(categoria);
        }
        #endregion

        #region POST Edit
        //Atualizar POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit (Categoria categoria)
        {
            if (ModelState.IsValid)
            {
                context.Entry(categoria).State = EntityState.Modified;
                context.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(categoria);
        }
        #endregion

        #region Details
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Categoria categoria = context.Categorias.Find(id);
            if(categoria == null)
            {
                return HttpNotFound();
            }
            return View(categoria);
        }
        #endregion

        #region GET Delete
        public ActionResult Delete (long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Categoria categoria = context.Categorias.Find(id);
            if (categoria == null)
            {
                return HttpNotFound();
            }
            return View(categoria);
        }
        #endregion

        #region POST Delete
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete (long id)
        {
            Categoria categoria = context.Categorias.Find(id);
            context.Categorias.Remove(categoria);
            context.SaveChanges();
            TempData["Message"] = "Categoria " + categoria.Nome.ToUpper() + " removida com sucesso.";
            return RedirectToAction("Index");
        }
        #endregion

    }
}