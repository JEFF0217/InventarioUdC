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
using InventarioUdC.GUI.Helpers;
using InventarioUdC.GUI.Mapeadores.Parametros;
using InventarioUdC.GUI.Models;
using PagedList;


namespace InventarioUdC.GUI.Controllers
{
    public class CategoriaController : Controller
    {
        private ImplCategoriaDatos acceso = new ImplCategoriaDatos();

        // GET: Categoria
        public ActionResult Index(int? page, string filtro = "")
        {

            int numPagina = page ?? 1;
            int totalRegistros;
            int registrosPorPagina = DatosGenerales.RegistrosPorPagina;

            IEnumerable<tb_categoria> listaDatos = acceso.ListarRegistros(filtro, numPagina, registrosPorPagina, out totalRegistros).ToList();
            MapeadorCategoriaGUI mapper = new MapeadorCategoriaGUI();
            IEnumerable<ModeloCategoriaGUI> ListaGUI = mapper.MapearTipo1Tipo2(listaDatos);

            // var registrosPagina = ListaGUI.ToPagedList(numPagina, registrosPorPagina);
            var listaPagina = new StaticPagedList<ModeloCategoriaGUI>(ListaGUI, numPagina, registrosPorPagina, totalRegistros);
            return View(listaPagina);
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

            MapeadorCategoriaGUI mapper = new MapeadorCategoriaGUI();
            ModeloCategoriaGUI modelo = mapper.MapearTipo1Tipo2(tb_categoria);
            return View(modelo);
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
        public ActionResult Create([Bind(Include = "Id,Nombre")] ModeloCategoriaGUI modelo)
        {
            if (ModelState.IsValid)
            {
                MapeadorCategoriaGUI mapper = new MapeadorCategoriaGUI();
                tb_categoria tb_categoria = mapper.MapearTipo2Tipo1(modelo);

                acceso.GuardarRegistro(tb_categoria);
                return RedirectToAction("Index");
            }

            return View(modelo);
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

            MapeadorCategoriaGUI mapper = new MapeadorCategoriaGUI();
            ModeloCategoriaGUI modelo = mapper.MapearTipo1Tipo2(tb_categoria);
            return View(modelo);
        }

        // POST: Categoria/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nombre")] ModeloCategoriaGUI modelo)
        {
            if (ModelState.IsValid)
            {
                MapeadorCategoriaGUI mapper = new MapeadorCategoriaGUI();
                tb_categoria tb_categoria = mapper.MapearTipo2Tipo1(modelo);

                acceso.EditarRegistro(tb_categoria);
                return RedirectToAction("Index");
            }
            return View(modelo);
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

            MapeadorCategoriaGUI mapper = new MapeadorCategoriaGUI();
            ModeloCategoriaGUI modelo = mapper.MapearTipo1Tipo2(tb_categoria);
            return View(modelo);
        }

        // POST: Categoria/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {

            bool respuesta = acceso.ELiminarRegistro(id);
            if (respuesta)
            {
                return RedirectToAction("Index");
            }
            else {
                tb_categoria tb_categoria = acceso.BuscarRegistro(id);
                if (tb_categoria == null)
                {
                    return HttpNotFound();
                }

                MapeadorCategoriaGUI mapper = new MapeadorCategoriaGUI();
                ViewBag.mensaje = Mensajes.MensajeErrorAlEliminar;

                ModeloCategoriaGUI modelo = mapper.MapearTipo1Tipo2(tb_categoria);
                return View(modelo);
            }

            
        }
    }
}
