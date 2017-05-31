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
    public class RanuraDepositoController : Controller
    {
        private _2014118187DbContext db = new _2014118187DbContext();

        // GET: /RanuraDeposito/
        public ActionResult Index()
        {
            var ranuradeposito = db.RanuraDeposito.Include(r => r.ATM);
            return View(ranuradeposito.ToList());
        }

        // GET: /RanuraDeposito/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RanuraDeposito ranuradeposito = db.RanuraDeposito.Find(id);
            if (ranuradeposito == null)
            {
                return HttpNotFound();
            }
            return View(ranuradeposito);
        }

        // GET: /RanuraDeposito/Create
        public ActionResult Create()
        {
            ViewBag.RanuraDepositoId = new SelectList(db.ATM, "ATMId", "DescripcionATM");
            return View();
        }

        // POST: /RanuraDeposito/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="RanuraDepositoId,Cantidad,ATMId")] RanuraDeposito ranuradeposito)
        {
            if (ModelState.IsValid)
            {
                db.RanuraDeposito.Add(ranuradeposito);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.RanuraDepositoId = new SelectList(db.ATM, "ATMId", "DescripcionATM", ranuradeposito.RanuraDepositoId);
            return View(ranuradeposito);
        }

        // GET: /RanuraDeposito/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RanuraDeposito ranuradeposito = db.RanuraDeposito.Find(id);
            if (ranuradeposito == null)
            {
                return HttpNotFound();
            }
            ViewBag.RanuraDepositoId = new SelectList(db.ATM, "ATMId", "DescripcionATM", ranuradeposito.RanuraDepositoId);
            return View(ranuradeposito);
        }

        // POST: /RanuraDeposito/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="RanuraDepositoId,Cantidad,ATMId")] RanuraDeposito ranuradeposito)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ranuradeposito).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.RanuraDepositoId = new SelectList(db.ATM, "ATMId", "DescripcionATM", ranuradeposito.RanuraDepositoId);
            return View(ranuradeposito);
        }

        // GET: /RanuraDeposito/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RanuraDeposito ranuradeposito = db.RanuraDeposito.Find(id);
            if (ranuradeposito == null)
            {
                return HttpNotFound();
            }
            return View(ranuradeposito);
        }

        // POST: /RanuraDeposito/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            RanuraDeposito ranuradeposito = db.RanuraDeposito.Find(id);
            db.RanuraDeposito.Remove(ranuradeposito);
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
