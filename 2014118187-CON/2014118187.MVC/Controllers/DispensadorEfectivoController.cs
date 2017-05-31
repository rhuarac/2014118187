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
    public class DispensadorEfectivoController : Controller
    {
        private _2014118187DbContext db = new _2014118187DbContext();

        // GET: /DispensadorEfectivo/
        public ActionResult Index()
        {
            var dispensadorefectivo = db.DispensadorEfectivo.Include(d => d.ATM).Include(d => d.Retiro);
            return View(dispensadorefectivo.ToList());
        }

        // GET: /DispensadorEfectivo/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DispensadorEfectivo dispensadorefectivo = db.DispensadorEfectivo.Find(id);
            if (dispensadorefectivo == null)
            {
                return HttpNotFound();
            }
            return View(dispensadorefectivo);
        }

        // GET: /DispensadorEfectivo/Create
        public ActionResult Create()
        {
            ViewBag.DispensadorEfectivoId = new SelectList(db.ATM, "ATMId", "DescripcionATM");
            ViewBag.DispensadorEfectivoId = new SelectList(db.Retiro, "RetiroId", "RetiroId");
            return View();
        }

        // POST: /DispensadorEfectivo/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="DispensadorEfectivoId,ATMId,RetiroId")] DispensadorEfectivo dispensadorefectivo)
        {
            if (ModelState.IsValid)
            {
                db.DispensadorEfectivo.Add(dispensadorefectivo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.DispensadorEfectivoId = new SelectList(db.ATM, "ATMId", "DescripcionATM", dispensadorefectivo.DispensadorEfectivoId);
            ViewBag.DispensadorEfectivoId = new SelectList(db.Retiro, "RetiroId", "RetiroId", dispensadorefectivo.DispensadorEfectivoId);
            return View(dispensadorefectivo);
        }

        // GET: /DispensadorEfectivo/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DispensadorEfectivo dispensadorefectivo = db.DispensadorEfectivo.Find(id);
            if (dispensadorefectivo == null)
            {
                return HttpNotFound();
            }
            ViewBag.DispensadorEfectivoId = new SelectList(db.ATM, "ATMId", "DescripcionATM", dispensadorefectivo.DispensadorEfectivoId);
            ViewBag.DispensadorEfectivoId = new SelectList(db.Retiro, "RetiroId", "RetiroId", dispensadorefectivo.DispensadorEfectivoId);
            return View(dispensadorefectivo);
        }

        // POST: /DispensadorEfectivo/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="DispensadorEfectivoId,ATMId,RetiroId")] DispensadorEfectivo dispensadorefectivo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(dispensadorefectivo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DispensadorEfectivoId = new SelectList(db.ATM, "ATMId", "DescripcionATM", dispensadorefectivo.DispensadorEfectivoId);
            ViewBag.DispensadorEfectivoId = new SelectList(db.Retiro, "RetiroId", "RetiroId", dispensadorefectivo.DispensadorEfectivoId);
            return View(dispensadorefectivo);
        }

        // GET: /DispensadorEfectivo/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DispensadorEfectivo dispensadorefectivo = db.DispensadorEfectivo.Find(id);
            if (dispensadorefectivo == null)
            {
                return HttpNotFound();
            }
            return View(dispensadorefectivo);
        }

        // POST: /DispensadorEfectivo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DispensadorEfectivo dispensadorefectivo = db.DispensadorEfectivo.Find(id);
            db.DispensadorEfectivo.Remove(dispensadorefectivo);
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
