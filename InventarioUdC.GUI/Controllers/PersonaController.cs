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
    public class PersonaController : Controller
    {
        private InventarioUdCDBEntities acceso = new InventarioUdCDBEntities();

        // GET: Persona
        public ActionResult Index()
        {
            return View(acceso.tb_persona.ToList());
        }

        // GET: Persona/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_persona tb_persona = acceso.tb_persona.Find(id);
            if (tb_persona == null)
            {
                return HttpNotFound();
            }
            return View(tb_persona);
        }

        // GET: Persona/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Persona/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,primer_nombre,otros_nombres,primer_apellido,segundo_apellido,documento,celular,correo")] tb_persona tb_persona)
        {
            if (ModelState.IsValid)
            {
                acceso.tb_persona.Add(tb_persona);
                acceso.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tb_persona);
        }

        // GET: Persona/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_persona tb_persona = acceso.tb_persona.Find(id);
            if (tb_persona == null)
            {
                return HttpNotFound();
            }
            return View(tb_persona);
        }

        // POST: Persona/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,primer_nombre,otros_nombres,primer_apellido,segundo_apellido,documento,celular,correo")] tb_persona tb_persona)
        {
            if (ModelState.IsValid)
            {
                acceso.Entry(tb_persona).State = EntityState.Modified;
                acceso.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tb_persona);
        }

        // GET: Persona/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_persona tb_persona = acceso.tb_persona.Find(id);
            if (tb_persona == null)
            {
                return HttpNotFound();
            }
            return View(tb_persona);
        }

        // POST: Persona/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tb_persona tb_persona = acceso.tb_persona.Find(id);
            acceso.tb_persona.Remove(tb_persona);
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
