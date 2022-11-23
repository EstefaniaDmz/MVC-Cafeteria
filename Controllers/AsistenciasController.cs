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
    public class AsistenciasController : Controller
    {
        private CafeteriaEntities db = new CafeteriaEntities();

        // GET: Asistencias
        public ActionResult Index()
        {
            var asistencia = db.Asistencia.Include(a => a.Trabajador).Include(a => a.Usuario).Include(a => a.Usuario1);
            return View(asistencia.ToList());
        }

        // GET: Asistencias/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Asistencia asistencia = db.Asistencia.Find(id);
            if (asistencia == null)
            {
                return HttpNotFound();
            }
            return View(asistencia);
        }

        // GET: Asistencias/Create
        public ActionResult Create()
        {
            ViewBag.idTrabajador = new SelectList(db.Trabajador, "idTrabajador", "nombre");
            ViewBag.idUsuarioCrea = new SelectList(db.Usuario, "idUsuario", "nombre");
            ViewBag.idUsuarioModifica = new SelectList(db.Usuario, "idUsuario", "nombre");
            return View();
        }

        // POST: Asistencias/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idAsistencia,fecha,horaLlegada,horaSalida,idTrabajador,estatus,idUsuarioCrea,fechaCrea,idUsuarioModifica,fechaModifica")] Asistencia asistencia)
        {
            if (ModelState.IsValid)
            {
                db.Asistencia.Add(asistencia);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idTrabajador = new SelectList(db.Trabajador, "idTrabajador", "nombre", asistencia.idTrabajador);
            ViewBag.idUsuarioCrea = new SelectList(db.Usuario, "idUsuario", "nombre", asistencia.idUsuarioCrea);
            ViewBag.idUsuarioModifica = new SelectList(db.Usuario, "idUsuario", "nombre", asistencia.idUsuarioModifica);
            return View(asistencia);
        }

        // GET: Asistencias/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Asistencia asistencia = db.Asistencia.Find(id);
            if (asistencia == null)
            {
                return HttpNotFound();
            }
            ViewBag.idTrabajador = new SelectList(db.Trabajador, "idTrabajador", "nombre", asistencia.idTrabajador);
            ViewBag.idUsuarioCrea = new SelectList(db.Usuario, "idUsuario", "nombre", asistencia.idUsuarioCrea);
            ViewBag.idUsuarioModifica = new SelectList(db.Usuario, "idUsuario", "nombre", asistencia.idUsuarioModifica);
            return View(asistencia);
        }

        // POST: Asistencias/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idAsistencia,fecha,horaLlegada,horaSalida,idTrabajador,estatus,idUsuarioCrea,fechaCrea,idUsuarioModifica,fechaModifica")] Asistencia asistencia)
        {
            if (ModelState.IsValid)
            {
                db.Entry(asistencia).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idTrabajador = new SelectList(db.Trabajador, "idTrabajador", "nombre", asistencia.idTrabajador);
            ViewBag.idUsuarioCrea = new SelectList(db.Usuario, "idUsuario", "nombre", asistencia.idUsuarioCrea);
            ViewBag.idUsuarioModifica = new SelectList(db.Usuario, "idUsuario", "nombre", asistencia.idUsuarioModifica);
            return View(asistencia);
        }

        // GET: Asistencias/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Asistencia asistencia = db.Asistencia.Find(id);
            if (asistencia == null)
            {
                return HttpNotFound();
            }
            return View(asistencia);
        }

        // POST: Asistencias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Asistencia asistencia = db.Asistencia.Find(id);
            db.Asistencia.Remove(asistencia);
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
