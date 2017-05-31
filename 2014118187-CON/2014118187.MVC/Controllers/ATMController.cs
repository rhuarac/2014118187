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
    public class ATMController : Controller
    {
        private _2014118187DbContext db = new _2014118187DbContext();

        // GET: /ATM/
        public ActionResult Index()
        {
            var atm = db.ATM.Include(a => a.Retiro);
            return View(atm.ToList());
        }

        // GET: /ATM/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ATM atm = db.ATM.Find(id);
            if (atm == null)
            {
                return HttpNotFound();
            }
            return View(atm);
        }

        // GET: /ATM/Create
        public ActionResult Create()
        {
            ViewBag.ATMId = new SelectList(db.Retiro, "RetiroId", "RetiroId");
            return View();
        }

        // POST: /ATM/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="ATMId,DescripcionATM,RanuraDepositoId,TecladoId,DispensadorEfectivoId,PantallaId,RetiroId,BasedeDatosId")] ATM atm)
        {
            if (ModelState.IsValid)
            {
                db.ATM.Add(atm);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ATMId = new SelectList(db.Retiro, "RetiroId", "RetiroId", atm.ATMId);
            return View(atm);
        }

        // GET: /ATM/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ATM atm = db.ATM.Find(id);
            if (atm == null)
            {
                return HttpNotFound();
            }
            ViewBag.ATMId = new SelectList(db.Retiro, "RetiroId", "RetiroId", atm.ATMId);
            return View(atm);
        }

        // POST: /ATM/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="ATMId,DescripcionATM,RanuraDepositoId,TecladoId,DispensadorEfectivoId,PantallaId,RetiroId,BasedeDatosId")] ATM atm)
        {
            if (ModelState.IsValid)
            {
                db.Entry(atm).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ATMId = new SelectList(db.Retiro, "RetiroId", "RetiroId", atm.ATMId);
            return View(atm);
        }

        // GET: /ATM/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ATM atm = db.ATM.Find(id);
            if (atm == null)
            {
                return HttpNotFound();
            }
            return View(atm);
        }

        // POST: /ATM/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ATM atm = db.ATM.Find(id);
            db.ATM.Remove(atm);
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
