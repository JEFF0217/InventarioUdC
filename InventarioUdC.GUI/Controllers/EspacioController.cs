using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AccesoDeDatos.ModeloDeDatos;
using AccesoDeDatos.Implementacion;


namespace InventarioUdC.GUI.Controllers
{
    public class EspacioController : Controller
    {
        private InventarioUdCDBEntities acceso = new InventarioUdCDBEntities();

        // GET: Espacio
        public ActionResult Index()
        {
            var tb_espacio = acceso.tb_espacio.Include(t => t.tb_piso);
            return View(tb_espacio.ToList());
        }

        // GET: Espacio/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_espacio tb_espacio = acceso.tb_espacio.Find(id);
            if (tb_espacio == null)
            {
                return HttpNotFound();
            }
            return View(tb_espacio);
        }

        // GET: Espacio/Create
        public ActionResult Create()
        {
            ViewBag.id_piso = new SelectList(acceso.tb_piso, "id", "nombre");
            return View();
        }

        // POST: Espacio/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,nombre,id_piso")] tb_espacio tb_espacio)
        {
            if (ModelState.IsValid)
            {
                acceso.tb_espacio.Add(tb_espacio);
                acceso.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.id_piso = new SelectList(acceso.tb_piso, "id", "nombre", tb_espacio.id_piso);
            return View(tb_espacio);
        }

        // GET: Espacio/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_espacio tb_espacio = acceso.tb_espacio.Find(id);
            if (tb_espacio == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_piso = new SelectList(acceso.tb_piso, "id", "nombre", tb_espacio.id_piso);
            return View(tb_espacio);
        }

        // POST: Espacio/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,nombre,id_piso")] tb_espacio tb_espacio)
        {
            if (ModelState.IsValid)
            {
                acceso.Entry(tb_espacio).State = EntityState.Modified;
                acceso.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_piso = new SelectList(acceso.tb_piso, "id", "nombre", tb_espacio.id_piso);
            return View(tb_espacio);
        }

        // GET: Espacio/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_espacio tb_espacio = acceso.tb_espacio.Find(id);
            if (tb_espacio == null)
            {
                return HttpNotFound();
            }
            return View(tb_espacio);
        }

        // POST: Espacio/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tb_espacio tb_espacio = acceso.tb_espacio.Find(id);
            acceso.tb_espacio.Remove(tb_espacio);
            acceso.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                acceso.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
