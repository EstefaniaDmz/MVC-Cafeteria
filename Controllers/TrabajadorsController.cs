using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CafeteriaTBD.Models;

namespace CafeteriaTBD.Controllers
{
    public class TrabajadorsController : Controller
    {
        private CafeteriaEntities db = new CafeteriaEntities();

        // GET: Trabajadors
        public ActionResult Index()
        {
            var trabajador = db.Trabajador.Include(t => t.Puesto).Include(t => t.Sucursal).Include(t => t.Usuario).Include(t => t.Usuario1);
            return View(trabajador.ToList());
        }

        // GET: Trabajadors/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Trabajador trabajador = db.Trabajador.Find(id);
            if (trabajador == null)
            {
                return HttpNotFound();
            }
            return View(trabajador);
        }

        // GET: Trabajadors/Create
        public ActionResult Create()
        {
            ViewBag.idPuesto = new SelectList(db.Puesto, "idPuesto", "nombre");
            ViewBag.idSucursal = new SelectList(db.Sucursal, "idSucursal", "nombre");
            ViewBag.idUsuarioCrea = new SelectList(db.Usuario, "idUsuario", "nombre");
            ViewBag.idUsuarioModifica = new SelectList(db.Usuario, "idUsuario", "nombre");
            return View();
        }

        // POST: Trabajadors/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idTrabajador,nombre,apellidoMaterno,apellidoPaterno,rfc,fechaNacimiento,telefono,correo,idPuesto,idSucursal,fechaContrata,estatus,idUsuarioCrea,fechaCrea,idUsuarioModifica,fechaModifica")] Trabajador trabajador)
        {
            if (ModelState.IsValid)
            {
                db.Trabajador.Add(trabajador);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idPuesto = new SelectList(db.Puesto, "idPuesto", "nombre", trabajador.idPuesto);
            ViewBag.idSucursal = new SelectList(db.Sucursal, "idSucursal", "nombre", trabajador.idSucursal);
            ViewBag.idUsuarioCrea = new SelectList(db.Usuario, "idUsuario", "nombre", trabajador.idUsuarioCrea);
            ViewBag.idUsuarioModifica = new SelectList(db.Usuario, "idUsuario", "nombre", trabajador.idUsuarioModifica);
            return View(trabajador);
        }

        // GET: Trabajadors/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Trabajador trabajador = db.Trabajador.Find(id);
            if (trabajador == null)
            {
                return HttpNotFound();
            }
            ViewBag.idPuesto = new SelectList(db.Puesto, "idPuesto", "nombre", trabajador.idPuesto);
            ViewBag.idSucursal = new SelectList(db.Sucursal, "idSucursal", "nombre", trabajador.idSucursal);
            ViewBag.idUsuarioCrea = new SelectList(db.Usuario, "idUsuario", "nombre", trabajador.idUsuarioCrea);
            ViewBag.idUsuarioModifica = new SelectList(db.Usuario, "idUsuario", "nombre", trabajador.idUsuarioModifica);
            return View(trabajador);
        }

        // POST: Trabajadors/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idTrabajador,nombre,apellidoMaterno,apellidoPaterno,rfc,fechaNacimiento,telefono,correo,idPuesto,idSucursal,fechaContrata,estatus,idUsuarioCrea,fechaCrea,idUsuarioModifica,fechaModifica")] Trabajador trabajador)
        {
            if (ModelState.IsValid)
            {
                db.Entry(trabajador).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idPuesto = new SelectList(db.Puesto, "idPuesto", "nombre", trabajador.idPuesto);
            ViewBag.idSucursal = new SelectList(db.Sucursal, "idSucursal", "nombre", trabajador.idSucursal);
            ViewBag.idUsuarioCrea = new SelectList(db.Usuario, "idUsuario", "nombre", trabajador.idUsuarioCrea);
            ViewBag.idUsuarioModifica = new SelectList(db.Usuario, "idUsuario", "nombre", trabajador.idUsuarioModifica);
            return View(trabajador);
        }

        // GET: Trabajadors/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Trabajador trabajador = db.Trabajador.Find(id);
            if (trabajador == null)
            {
                return HttpNotFound();
            }
            return View(trabajador);
        }

        // POST: Trabajadors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Trabajador trabajador = db.Trabajador.Find(id);
            db.Trabajador.Remove(trabajador);
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
