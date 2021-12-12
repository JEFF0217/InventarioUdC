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
    public class EdificioController : Controller
    {
        private InventarioUdCDBEntities acceso = new InventarioUdCDBEntities();

        // GET: Edificio
        public ActionResult Index()
        {
            var tb_edificio = acceso.tb_edificio.Include(t => t.tb_sede);
            return View(tb_edificio.ToList());
        }

        // GET: Edificio/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_edificio tb_edificio = acceso.tb_edificio.Find(id);
            if (tb_edificio == null)
            {
                return HttpNotFound();
            }
            return View(tb_edificio);
        }

        // GET: Edificio/Create
        public ActionResult Create()
        {
            ViewBag.id_sede = new SelectList(acceso.tb_sede, "id", "nombre");
            return View();
        }

        // POST: Edificio/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,nombre,id_sede")] tb_edificio tb_edificio)
        {
            if (ModelState.IsValid)
            {
                acceso.tb_edificio.Add(tb_edificio);
                acceso.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.id_sede = new SelectList(acceso.tb_sede, "id", "nombre", tb_edificio.id_sede);
            return View(tb_edificio);
        }

        // GET: Edificio/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_edificio tb_edificio = acceso.tb_edificio.Find(id);
            if (tb_edificio == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_sede = new SelectList(acceso.tb_sede, "id", "nombre", tb_edificio.id_sede);
            return View(tb_edificio);
        }

        // POST: Edificio/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,nombre,id_sede")] tb_edificio tb_edificio)
        {
            if (ModelState.IsValid)
            {
                acceso.Entry(tb_edificio).State = EntityState.Modified;
                acceso.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_sede = new SelectList(acceso.tb_sede, "id", "nombre", tb_edificio.id_sede);
            return View(tb_edificio);
        }

        // GET: Edificio/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_edificio tb_edificio = acceso.tb_edificio.Find(id);
            if (tb_edificio == null)
            {
                return HttpNotFound();
            }
            return View(tb_edificio);
        }

        // POST: Edificio/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tb_edificio tb_edificio = acceso.tb_edificio.Find(id);
            acceso.tb_edificio.Remove(tb_edificio);
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
