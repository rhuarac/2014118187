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
using _2014118187_ENT.IRepositories;
using _2014118187_PER.Repositories;

namespace _2014118187.MVC.Controllers
{
    public class RetiroController : Controller
    {
        //private _2014118187DbContext db = new _2014118187DbContext();
        private readonly IUnityofWork _UnityOfWork;

        
        public RetiroController()
        {

        }
        public RetiroController(UnityOfWork unityOfWork)
        {
            _UnityOfWork = unityOfWork;
        }
        // GET: Retiroes
        public ActionResult Index()
        {
            //var retiro = db.Retiro.Include(r => r.ATM).Include(r => r.BasedeDatos).Include(r => r.DispensadorEfectivo).Include(r => r.Pantalla).Include(r => r.Teclado);
            //return View(retiro.ToList());
            return View(_UnityOfWork.Retiro.GetAll());
        }

        // GET: Retiroes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Retiro retiro = _UnityOfWork.Retiro.Get(id);
            if (retiro == null)
            {
                return HttpNotFound();
            }
            return View(retiro);
        }

        // GET: Retiroes/Create
        public ActionResult Create()
        {
            //ViewBag.RetiroId = new SelectList(db.ATM, "ATMId", "DescripcionATM");
            //ViewBag.RetiroId = new SelectList(db.BasedeDatos, "BasedeDatosId", "BasedeDatosId");
            //ViewBag.RetiroId = new SelectList(db.DispensadorEfectivo, "DispensadorEfectivoId", "DispensadorEfectivoId");
            //ViewBag.RetiroId = new SelectList(db.Pantalla, "PantallaId", "PantallaId");
            //ViewBag.RetiroId = new SelectList(db.Teclado, "TecladoId", "TecladoId");
            return View();
        }

        // POST: Retiroes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "RetiroId,PantallaId,TecladoId,DispensadorEfectivoId,BasedeDatosId,ATMId")] Retiro retiro)
        {
            if (ModelState.IsValid)
            {
                _UnityOfWork.Retiro.Add(retiro);

                // db.SaveChanges();
                _UnityOfWork.SaveChanges();
                return RedirectToAction("Index");
            }

           // ViewBag.RetiroId = new SelectList(db.ATM, "ATMId", "DescripcionATM", retiro.RetiroId);
            //ViewBag.RetiroId = new SelectList(db.BasedeDatos, "BasedeDatosId", "BasedeDatosId", retiro.RetiroId);
            //ViewBag.RetiroId = new SelectList(db.DispensadorEfectivo, "DispensadorEfectivoId", "DispensadorEfectivoId", retiro.RetiroId);
            //ViewBag.RetiroId = new SelectList(db.Pantalla, "PantallaId", "PantallaId", retiro.RetiroId);
            //ViewBag.RetiroId = new SelectList(db.Teclado, "TecladoId", "TecladoId", retiro.RetiroId);
            return View(retiro);
        }

        // GET: Retiroes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            // Retiro retiro = db.Retiro.Find(id);
            Retiro retiro = _UnityOfWork.Retiro.Get(id);
            if (retiro == null)
            {
                return HttpNotFound();
            }
           // ViewBag.RetiroId = new SelectList(db.ATM, "ATMId", "DescripcionATM", retiro.RetiroId);
            //ViewBag.RetiroId = new SelectList(db.BasedeDatos, "BasedeDatosId", "BasedeDatosId", retiro.RetiroId);
            //ViewBag.RetiroId = new SelectList(db.DispensadorEfectivo, "DispensadorEfectivoId", "DispensadorEfectivoId", retiro.RetiroId);
            //ViewBag.RetiroId = new SelectList(db.Pantalla, "PantallaId", "PantallaId", retiro.RetiroId);
            //ViewBag.RetiroId = new SelectList(db.Teclado, "TecladoId", "TecladoId", retiro.RetiroId);
            return View(retiro);
        }

        // POST: Retiroes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "RetiroId,PantallaId,TecladoId,DispensadorEfectivoId,BasedeDatosId,ATMId")] Retiro retiro)
        {
            if (ModelState.IsValid)
            {
                _UnityOfWork.StateModified(retiro);
                // db.SaveChanges();
                _UnityOfWork.SaveChanges();
                return RedirectToAction("Index");
            }
           // ViewBag.RetiroId = new SelectList(db.ATM, "ATMId", "DescripcionATM", retiro.RetiroId);
            //ViewBag.RetiroId = new SelectList(db.BasedeDatos, "BasedeDatosId", "BasedeDatosId", retiro.RetiroId);
            //ViewBag.RetiroId = new SelectList(db.DispensadorEfectivo, "DispensadorEfectivoId", "DispensadorEfectivoId", retiro.RetiroId);
            //ViewBag.RetiroId = new SelectList(db.Pantalla, "PantallaId", "PantallaId", retiro.RetiroId);
            //ViewBag.RetiroId = new SelectList(db.Teclado, "TecladoId", "TecladoId", retiro.RetiroId);
            return View(retiro);
        }

        // GET: Retiroes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //Retiro retiro = db.Retiro.Find(id
            Retiro retiro= _UnityOfWork.Retiro.Get(id);
            if (retiro == null)
            {
                return HttpNotFound();
            }
            return View(retiro);
        }

        // POST: Retiroes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            //Retiro retiro = db.Retiro.Find(id);
            //db.Retiro.Remove(retiro);
            //db.SaveChanges();
            Retiro retiro = _UnityOfWork.Retiro.Get(id);

            //db.Comprobantes.Remove(boleta);
            _UnityOfWork.Retiro.Delete(retiro);

            // db.SaveChanges();
            _UnityOfWork.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                //db.Dispose();
                _UnityOfWork.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
