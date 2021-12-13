using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

using LogicaNegocio.Implementacion;
using InventarioUdC.GUI.Helpers;
using LogicaNegocio.DTO;
using InventarioUdC.GUI.Mapeadores.Parametros;
using InventarioUdC.GUI.Models;
using PagedList;
using System.Collections.Generic;
using System;

namespace InventarioUdC.GUI.Controllers
{
    public class ProductoController : Controller
    {
        private ImplProductoLogica logica = new ImplProductoLogica();

        // GET: Producto
        public ActionResult Index(int? page, String filtro = "")
        {
            int numPagina = page ?? 1;
            int totalRegistros;
            int registrosPorPagina = DatosGenerales.RegistrosPorPagina;

            IEnumerable<ProductoDTO> listaDatos = logica.ListarRegistros(filtro, numPagina, registrosPorPagina, out totalRegistros).ToList();
            MapeadorProductoGUI mapper = new MapeadorProductoGUI();
            IEnumerable<ModeloProductoGUI> ListaGUI = mapper.MapearTipo1Tipo2(listaDatos);

            // var registrosPagina = ListaGUI.ToPagedList(numPagina, registrosPorPagina);
            var listaPagina = new StaticPagedList<ModeloProductoGUI>(ListaGUI, numPagina, registrosPorPagina, totalRegistros);
            return View(listaPagina);
        }



        // GET: Producto/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductoDTO ProductoDTO = logica.BuscarRegistro(id.Value);
            if (ProductoDTO == null)
            {
                return HttpNotFound();
            }

            MapeadorProductoGUI mapper = new MapeadorProductoGUI();
            ModeloProductoGUI modelo = mapper.MapearTipo1Tipo2(ProductoDTO);
            return View(modelo);
        }

        // GET: Producto/Create
        public ActionResult Create()
        {
            IEnumerable<ModeloMarcaGUI> listadoMarcas = obtenerListadoMarcas();
            IEnumerable<ModeloTipoProductoGUI> listaTipoProductos = obtenerListadoTipoProductos();
            IEnumerable<ModeloPersonaGUI> listadoPersonas= obtenerListadoPersonas();
            IEnumerable<ModeloEspacioGUI> listadoEspacio = obtenerListadoEspacios();


            ModeloProductoGUI modelo = new ModeloProductoGUI();
            modelo.ListaMarca = listadoMarcas;
            modelo.ListaTipoProducto = listaTipoProductos;
            modelo.ListaPersona = listadoPersonas;
            modelo.ListaEspacio = listadoEspacio;
            return View(modelo);
        }

        private IEnumerable<ModeloMarcaGUI> obtenerListadoMarcas()
        {
            ImplMarcaLogica sede = new ImplMarcaLogica();
            var listaMarcas = sede.ListarRegistros();
            MapeadorMarcaGUI mapeador = new MapeadorMarcaGUI();

            var listado = mapeador.MapearTipo1Tipo2(listaMarcas);
            return listado;
        }

        private IEnumerable<ModeloTipoProductoGUI> obtenerListadoTipoProductos()
        {
            ImplTipoProductoLogica sede = new ImplTipoProductoLogica();
            var listaMarcas = sede.ListarRegistros();
            MapeadorTipoProductoGUI mapeador = new MapeadorTipoProductoGUI();

            var listado = mapeador.MapearTipo1Tipo2(listaMarcas);
            return listado;
        }
        private IEnumerable<ModeloPersonaGUI> obtenerListadoPersonas()
        {
            ImplPersonaLogica sede = new ImplPersonaLogica();
            var listaMarcas = sede.ListarRegistros();
            MapeadorPersonaGUI mapeador = new MapeadorPersonaGUI();

            var listado = mapeador.MapearTipo1Tipo2(listaMarcas);
            return listado;
        }
        private IEnumerable<ModeloEspacioGUI> obtenerListadoEspacios()
        {
            ImplEspacioLogica sede = new ImplEspacioLogica();
            var listaEspacios = sede.ListarRegistros();
            MapeadorEspacioGUI mapeador = new MapeadorEspacioGUI();

            var listado = mapeador.MapearTipo1Tipo2(listaEspacios);
            return listado;
        }



        // POST: Producto/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ModeloProductoGUI modelo)
        {
            if (ModelState.IsValid)
            {
                MapeadorProductoGUI mapper = new MapeadorProductoGUI();
                ProductoDTO ProductoDTO = mapper.MapearTipo2Tipo1(modelo);

                logica.GuardarRegistro(ProductoDTO);
                return RedirectToAction("Index");
            }

            return View(modelo);
        }

        // GET: Producto/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductoDTO ProductoDTO = logica.BuscarRegistro(id.Value);
            if (ProductoDTO == null)
            {
                return HttpNotFound();
            }

            IEnumerable<ModeloMarcaGUI> listadoMarcas = obtenerListadoMarcas();
            IEnumerable<ModeloTipoProductoGUI> listaTipoProductos = obtenerListadoTipoProductos();
            IEnumerable<ModeloPersonaGUI> listadoPersonas = obtenerListadoPersonas();
            IEnumerable<ModeloEspacioGUI> listadoEspacio = obtenerListadoEspacios();

            MapeadorProductoGUI mapper = new MapeadorProductoGUI();
            ModeloProductoGUI modelo = mapper.MapearTipo1Tipo2(ProductoDTO);
            return View(modelo);
        }

        // POST: Producto/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ModeloProductoGUI modelo)
        {
            if (ModelState.IsValid)
            {
                MapeadorProductoGUI mapper = new MapeadorProductoGUI();
                ProductoDTO ProductoDTO = mapper.MapearTipo2Tipo1(modelo);
                logica.EditarRegistro(ProductoDTO);
                return RedirectToAction("Index");
            }

            return View(modelo);
        }

        // GET: Producto/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductoDTO ProductoDTO = logica.BuscarRegistro(id.Value);
            if (ProductoDTO == null)
            {
                return HttpNotFound();
            }
            MapeadorProductoGUI mapper = new MapeadorProductoGUI();
            ModeloProductoGUI modelo = mapper.MapearTipo1Tipo2(ProductoDTO);
            return View(modelo);
        }

        // POST: Producto/Delete/5
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
                ProductoDTO ProductoDTO = logica.BuscarRegistro(id);
                if (ProductoDTO == null)
                {
                    return HttpNotFound();
                }
                MapeadorProductoGUI mapper = new MapeadorProductoGUI();
                ViewBag.mensaje = Mensajes.MensajeErrorAlEliminar;
                ModeloProductoGUI modelo = mapper.MapearTipo1Tipo2(ProductoDTO);
                return View(modelo);
            }
        }
    }
}
