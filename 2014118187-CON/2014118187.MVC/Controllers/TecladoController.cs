using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using _2014118187_ENT.Entities;
using _2014118187_PER;

namespace _2014118187.MVC.Controllers
{
    public class TecladoController : Controller
    {
        private _2014118187DbContext db = new _2014118187DbContext();

        // GET: /Teclado/
        public ActionResult Index()
        {
            var teclado = db.Teclado.Include(t => t.ATM).Include(t => t.Retiro);
            return View(teclado.ToList());
        }

        // GET: /Teclado/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Teclado teclado = db.Teclado.Find(id);
            if (teclado == null)
            {
                return HttpNotFound();
            }
            return View(teclado);
        }

        // GET: /Teclado/Create
        public ActionResult Create()
        {
            ViewBag.TecladoId = new SelectList(db.ATM, "ATMId", "DescripcionATM");
            ViewBag.TecladoId = new SelectList(db.Retiro, "RetiroId", "RetiroId");
            return View();
        }

        // POST: /Teclado/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="TecladoId,ATMId,RetiroId")] Teclado teclado)
        {
            if (ModelState.IsValid)
            {
                db.Teclado.Add(teclado);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.TecladoId = new SelectList(db.ATM, "ATMId", "DescripcionATM", teclado.TecladoId);
            ViewBag.TecladoId = new SelectList(db.Retiro, "RetiroId", "RetiroId", teclado.TecladoId);
            return View(teclado);
        }

        // GET: /Teclado/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Teclado teclado = db.Teclado.Find(id);
            if (teclado == null)
            {
                return HttpNotFound();
            }
            ViewBag.TecladoId = new SelectList(db.ATM, "ATMId", "DescripcionATM", teclado.TecladoId);
            ViewBag.TecladoId = new SelectList(db.Retiro, "RetiroId", "RetiroId", teclado.TecladoId);
            return View(teclado);
        }

        // POST: /Teclado/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="TecladoId,ATMId,RetiroId")] Teclado teclado)
        {
            if (ModelState.IsValid)
            {
                db.Entry(teclado).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.TecladoId = new SelectList(db.ATM, "ATMId", "DescripcionATM", teclado.TecladoId);
            ViewBag.TecladoId = new SelectList(db.Retiro, "RetiroId", "RetiroId", teclado.TecladoId);
            return View(teclado);
        }

        // GET: /Teclado/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Teclado teclado = db.Teclado.Find(id);
            if (teclado == null)
            {
                return HttpNotFound();
            }
            return View(teclado);
        }

        // POST: /Teclado/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Teclado teclado = db.Teclado.Find(id);
            db.Teclado.Remove(teclado);
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
