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
    public class BasedeDatosController : Controller
    {
        private _2014118187DbContext db = new _2014118187DbContext();

        // GET: /BasedeDatos/
        public ActionResult Index()
        {
            var basededatos = db.BasedeDatos.Include(b => b.ATM).Include(b => b.Retiro);
            return View(basededatos.ToList());
        }

        // GET: /BasedeDatos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BasedeDatos basededatos = db.BasedeDatos.Find(id);
            if (basededatos == null)
            {
                return HttpNotFound();
            }
            return View(basededatos);
        }

        // GET: /BasedeDatos/Create
        public ActionResult Create()
        {
            ViewBag.BasedeDatosId = new SelectList(db.ATM, "ATMId", "DescripcionATM");
            ViewBag.BasedeDatosId = new SelectList(db.Retiro, "RetiroId", "RetiroId");
            return View();
        }

        // POST: /BasedeDatos/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="BasedeDatosId,AutentificarCuenta,ObtenerSaldoDisponible,ObtenerSaldoTotal,Debitar,Acreditar,CuentaId,ATMId,RetiroId")] BasedeDatos basededatos)
        {
            if (ModelState.IsValid)
            {
                db.BasedeDatos.Add(basededatos);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.BasedeDatosId = new SelectList(db.ATM, "ATMId", "DescripcionATM", basededatos.BasedeDatosId);
            ViewBag.BasedeDatosId = new SelectList(db.Retiro, "RetiroId", "RetiroId", basededatos.BasedeDatosId);
            return View(basededatos);
        }

        // GET: /BasedeDatos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BasedeDatos basededatos = db.BasedeDatos.Find(id);
            if (basededatos == null)
            {
                return HttpNotFound();
            }
            ViewBag.BasedeDatosId = new SelectList(db.ATM, "ATMId", "DescripcionATM", basededatos.BasedeDatosId);
            ViewBag.BasedeDatosId = new SelectList(db.Retiro, "RetiroId", "RetiroId", basededatos.BasedeDatosId);
            return View(basededatos);
        }

        // POST: /BasedeDatos/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="BasedeDatosId,AutentificarCuenta,ObtenerSaldoDisponible,ObtenerSaldoTotal,Debitar,Acreditar,CuentaId,ATMId,RetiroId")] BasedeDatos basededatos)
        {
            if (ModelState.IsValid)
            {
                db.Entry(basededatos).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.BasedeDatosId = new SelectList(db.ATM, "ATMId", "DescripcionATM", basededatos.BasedeDatosId);
            ViewBag.BasedeDatosId = new SelectList(db.Retiro, "RetiroId", "RetiroId", basededatos.BasedeDatosId);
            return View(basededatos);
        }

        // GET: /BasedeDatos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BasedeDatos basededatos = db.BasedeDatos.Find(id);
            if (basededatos == null)
            {
                return HttpNotFound();
            }
            return View(basededatos);
        }

        // POST: /BasedeDatos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BasedeDatos basededatos = db.BasedeDatos.Find(id);
            db.BasedeDatos.Remove(basededatos);
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
