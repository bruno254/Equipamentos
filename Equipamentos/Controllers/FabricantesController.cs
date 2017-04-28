using Equipamentos.Contexts;
using Equipamentos.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Equipamentos.Controllers
{
    public class FabricantesController : Controller
    {
        private EFContext context = new EFContext();

        #region Index 
        // GET: Fabricantes
        public ActionResult Index()
        {
            return View(context.Fabricantes.OrderBy(c => c.Nome));
        }
        #endregion

        #region GET Create
        // GET: Fabricantes
        public ActionResult Create()
        {
            return View();
        }
        #endregion

        #region POST Create
        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Fabricante fabricante)
        {
            context.Fabricantes.Add(fabricante);
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

            Fabricante fabricante = context.Fabricantes.Find(id);
            if(fabricante ==null)
            {
                return HttpNotFound();
            }
            return View(fabricante);
        }
        #endregion

        #region POST Edit
        //Atualizar POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit (Fabricante fabricante)
        {
            if (ModelState.IsValid)
            {
                context.Entry(fabricante).State = EntityState.Modified;
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(fabricante);

        }
        #endregion

        #region Details
        //Detalhes 
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Fabricante fabricante = context.Fabricantes.Find(id);
            if(fabricante == null)
            {
                return HttpNotFound();
            }

            return View(fabricante);
        }
        #endregion

        #region GET Delete
        public ActionResult Delete (long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Fabricante fabricante = context.Fabricantes.Find(id);
            if (fabricante == null)
            {
                return HttpNotFound();
            }
            return View(fabricante);

        }
        #endregion

        #region POST Delete
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete (long id)
        {
            Fabricante fabricante = context.Fabricantes.Find(id);
            context.Fabricantes.Remove(fabricante);
            context.SaveChanges();
            TempData["Message"] = "Fabricante " + fabricante.Nome.ToUpper() + " foi removido.";
            return RedirectToAction("Index");
        }
        #endregion

    }
}