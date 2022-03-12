using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;


using LogicaNegocio.Implementacion;
using InventarioUdC.GUI.Helpers;
using LogicaNegocio.DTO;
using InventarioUdC.GUI.Mapeadores.Parametros;
using InventarioUdC.GUI.Models;
using PagedList;

namespace InventarioUdC.GUI.Controllers
{
    public class FotosController : Controller
    {
        private ImplFotosLogica logica = new ImplFotosLogica();

        // GET: Fotos
        public ActionResult Index(int? page, String filtro = "")
        {
            int numPagina = page ?? 1;
            int totalRegistros;
            int registrosPorPagina = DatosGenerales.RegistrosPorPagina;

            IEnumerable<FotosDTO> listaDatos = logica.ListarRegistros(filtro, numPagina, registrosPorPagina, out totalRegistros).ToList();
            MapeadorFotosGUI mapper = new MapeadorFotosGUI();
            IEnumerable<ModeloFotosGUI> ListaGUI = mapper.MapearTipo1Tipo2(listaDatos);

            // var registrosPagina = ListaGUI.ToPagedList(numPagina, registrosPorPagina);
            var listaPagina = new StaticPagedList<ModeloFotosGUI>(ListaGUI, numPagina, registrosPorPagina, totalRegistros);
            return View(listaPagina);
        }



        // GET: Fotos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FotosDTO FotosDTO = logica.BuscarRegistro(id.Value);
            if (FotosDTO == null)
            {
                return HttpNotFound();
            }

            MapeadorFotosGUI mapper = new MapeadorFotosGUI();
            ModeloFotosGUI modelo = mapper.MapearTipo1Tipo2(FotosDTO);
            return View(modelo);
        }

        // GET: Fotos/Create
        public ActionResult Create()
        {
            IEnumerable<ModeloProductoGUI> listadoProductos = obtenerListadoProductos();
            ModeloFotosGUI modelo = new ModeloFotosGUI();
            modelo.ListaProducto = listadoProductos;

            return View(modelo);
        }

        private IEnumerable<ModeloProductoGUI> obtenerListadoProductos()
        {
            ImplProductoLogica sede = new ImplProductoLogica();
            var listaProductos = sede.ListarRegistros();
            MapeadorProductoGUI mapeador = new MapeadorProductoGUI();

            var listado = mapeador.MapearTipo1Tipo2(listaProductos);
            return listado;
        }


        // POST: Fotos/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ModeloFotosGUI modelo)
        {
            if (ModelState.IsValid)
            {
                MapeadorFotosGUI mapper = new MapeadorFotosGUI();
                FotosDTO FotosDTO = mapper.MapearTipo2Tipo1(modelo);

                logica.GuardarRegistro(FotosDTO);
                return RedirectToAction("Index");
            }

            return View(modelo);
        }

        // GET: Fotos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FotosDTO FotosDTO = logica.BuscarRegistro(id.Value);
            if (FotosDTO == null)
            {
                return HttpNotFound();
            }
            IEnumerable<ModeloProductoGUI> listadoProductos = obtenerListadoProductos();
            MapeadorFotosGUI mapper = new MapeadorFotosGUI();
            ModeloFotosGUI modelo = mapper.MapearTipo1Tipo2(FotosDTO);
            modelo.ListaProducto = listadoProductos;
            return View(modelo);
        }

        // POST: Fotos/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ModeloFotosGUI modelo)
        {
            if (ModelState.IsValid)
            {
                MapeadorFotosGUI mapper = new MapeadorFotosGUI();
                FotosDTO FotosDTO = mapper.MapearTipo2Tipo1(modelo);
                logica.EditarRegistro(FotosDTO);
                return RedirectToAction("Index");
            }

            return View(modelo);
        }

        // GET: Fotos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FotosDTO FotosDTO = logica.BuscarRegistro(id.Value);
            if (FotosDTO == null)
            {
                return HttpNotFound();
            }
            MapeadorFotosGUI mapper = new MapeadorFotosGUI();
            ModeloFotosGUI modelo = mapper.MapearTipo1Tipo2(FotosDTO);
            return View(modelo);
        }

        // POST: Fotos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            bool respuesta = logica.EliminarRegistro(id);
            if (respuesta)
            {
                return RedirectToAction("Index");
            }
            else
            {
                FotosDTO FotosDTO = logica.BuscarRegistro(id);
                if (FotosDTO == null)
                {
                    return HttpNotFound();
                }
                MapeadorFotosGUI mapper = new MapeadorFotosGUI();
                ViewBag.mensaje = Mensajes.MensajeErrorAlEliminar;
                ModeloFotosGUI modelo = mapper.MapearTipo1Tipo2(FotosDTO);
                return View(modelo);
            }
        }
    }
}
