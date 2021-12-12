using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AccesoDeDatos.Implementacion;
using AccesoDeDatos.ModeloDeDatos;
using PagedList;


namespace InventarioUdC.GUI.Controllers
{
    public class CategoriaController : Controller
    {
        private ImplCategoriaDatos acceso = new ImplCategoriaDatos();

        // GET: Categoria
        public ActionResult Index(string filtro = "")
        {
          
            return View(acceso.ListarRegistros(filtro).ToList());
        }

        // GET: Categoria/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_categoria tb_categoria = acceso.BuscarRegistro(id.Value);
            if (tb_categoria == null)
            {
                return HttpNotFound();
            }
            return View(tb_categoria);
        }

        // GET: Categoria/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Categoria/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,nombre")] tb_categoria tb_categoria)
        {
            if (ModelState.IsValid)
            {
                acceso.GuardarRegistro(tb_categoria);
                return RedirectToAction("Index");
            }

            return View(tb_categoria);
        }

        // GET: Categoria/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_categoria tb_categoria = acceso.BuscarRegistro(id.Value);
            if (tb_categoria == null)
            {
                return HttpNotFound();
            }
            return View(tb_categoria);
        }

        // POST: Categoria/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,nombre")] tb_categoria tb_categoria)
        {
            if (ModelState.IsValid)
            {
                acceso.EditarRegistro(tb_categoria);
                return RedirectToAction("Index");
            }
            return View(tb_categoria);
        }

        // GET: Categoria/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_categoria tb_categoria = acceso.BuscarRegistro(id.Value);
            if (tb_categoria == null)
            {
                return HttpNotFound();
            }
            return View(tb_categoria);
        }

        // POST: Categoria/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
          
            acceso.ELiminarRegistro(id);
            return RedirectToAction("Index");
        }
    }
}
