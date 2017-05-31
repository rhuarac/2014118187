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
    public class PantallaController : Controller
    {
        private _2014118187DbContext db = new _2014118187DbContext();

        // GET: /Pantalla/
        public ActionResult Index()
        {
            var pantalla = db.Pantalla.Include(p => p.ATM).Include(p => p.Retiro);
            return View(pantalla.ToList());
        }

        // GET: /Pantalla/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pantalla pantalla = db.Pantalla.Find(id);
            if (pantalla == null)
            {
                return HttpNotFound();
            }
            return View(pantalla);
        }

        // GET: /Pantalla/Create
        public ActionResult Create()
        {
            ViewBag.PantallaId = new SelectList(db.ATM, "ATMId", "DescripcionATM");
            ViewBag.PantallaId = new SelectList(db.Retiro, "RetiroId", "RetiroId");
            return View();
        }

        // POST: /Pantalla/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="PantallaId,ATMId,RetiroId")] Pantalla pantalla)
        {
            if (ModelState.IsValid)
            {
                db.Pantalla.Add(pantalla);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.PantallaId = new SelectList(db.ATM, "ATMId", "DescripcionATM", pantalla.PantallaId);
            ViewBag.PantallaId = new SelectList(db.Retiro, "RetiroId", "RetiroId", pantalla.PantallaId);
            return View(pantalla);
        }

        // GET: /Pantalla/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pantalla pantalla = db.Pantalla.Find(id);
            if (pantalla == null)
            {
                return HttpNotFound();
            }
            ViewBag.PantallaId = new SelectList(db.ATM, "ATMId", "DescripcionATM", pantalla.PantallaId);
            ViewBag.PantallaId = new SelectList(db.Retiro, "RetiroId", "RetiroId", pantalla.PantallaId);
            return View(pantalla);
        }

        // POST: /Pantalla/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="PantallaId,ATMId,RetiroId")] Pantalla pantalla)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pantalla).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.PantallaId = new SelectList(db.ATM, "ATMId", "DescripcionATM", pantalla.PantallaId);
            ViewBag.PantallaId = new SelectList(db.Retiro, "RetiroId", "RetiroId", pantalla.PantallaId);
            return View(pantalla);
        }

        // GET: /Pantalla/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pantalla pantalla = db.Pantalla.Find(id);
            if (pantalla == null)
            {
                return HttpNotFound();
            }
            return View(pantalla);
        }

        // POST: /Pantalla/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Pantalla pantalla = db.Pantalla.Find(id);
            db.Pantalla.Remove(pantalla);
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
