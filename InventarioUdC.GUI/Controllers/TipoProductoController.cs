using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using InventarioUdC.GUI.Mapeadores.Parametros;
using InventarioUdC.GUI.Models;
using InventarioUdC.GUI.Helpers;
using PagedList;
using LogicaNegocio.Implementacion;
using LogicaNegocio.DTO;

namespace InventarioUdC.GUI.Controllers
{
    public class TipoProductoController : Controller
    {
        private ImplTipoProductoLogica logica = new ImplTipoProductoLogica();

        // GET: TipoProducto
        public ActionResult Index(int? page, string filtro = "")
        {
            int numPagina = page ?? 1;
            int totalRegistros;
            int registrosPorPagina = DatosGenerales.RegistrosPorPagina;

            IEnumerable<TipoProductoDTO> listaDatos = logica.ListarRegistros(filtro, numPagina, registrosPorPagina, out totalRegistros).ToList();
            MapeadorTipoProductoGUI mapper = new MapeadorTipoProductoGUI();
            IEnumerable<ModeloTipoProductoGUI> ListaGUI = mapper.MapearTipo1Tipo2(listaDatos);

            // var registrosPagina = ListaGUI.ToPagedList(numPagina, registrosPorPagina);
            var listaPagina = new StaticPagedList<ModeloTipoProductoGUI>(ListaGUI, numPagina, registrosPorPagina, totalRegistros);
            return View(listaPagina);
        }

        // GET: TipoProducto/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoProductoDTO TipoProductoDTO = logica.BuscarRegistro(id.Value);
            if (TipoProductoDTO == null)
            {
                return HttpNotFound();
            }
            MapeadorTipoProductoGUI mapper = new MapeadorTipoProductoGUI();
            ModeloTipoProductoGUI modelo = mapper.MapearTipo1Tipo2(TipoProductoDTO);
            return View(modelo);
        }

        // GET: TipoProducto/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TipoProducto/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nombre")] ModeloTipoProductoGUI modelo)
        {
            if (ModelState.IsValid)
            {
                MapeadorTipoProductoGUI mapper = new MapeadorTipoProductoGUI();
                TipoProductoDTO TipoProductoDTO = mapper.MapearTipo2Tipo1(modelo);

                logica.GuardarRegistro(TipoProductoDTO);
                return RedirectToAction("Index");
            }

            return View(modelo);
        }

        // GET: TipoProducto/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoProductoDTO TipoProductoDTO = logica.BuscarRegistro(id.Value);
            if (TipoProductoDTO == null)
            {
                return HttpNotFound();
            }

            MapeadorTipoProductoGUI mapper = new MapeadorTipoProductoGUI();
            ModeloTipoProductoGUI modelo = mapper.MapearTipo1Tipo2(TipoProductoDTO);
            return View(modelo);
        }

        // POST: TipoProducto/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nombre")] ModeloTipoProductoGUI modelo)
        {
            if (ModelState.IsValid)
            {

                MapeadorTipoProductoGUI mapper = new MapeadorTipoProductoGUI();
                TipoProductoDTO TipoProductoDTO = mapper.MapearTipo2Tipo1(modelo);

                logica.EditarRegistro(TipoProductoDTO);
                return RedirectToAction("Index");
            }
            return View(modelo);
        }

        // GET: TipoProducto/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoProductoDTO TipoProductoDTO = logica.BuscarRegistro(id.Value);
            if (TipoProductoDTO == null)
            {
                return HttpNotFound();
            }
            MapeadorTipoProductoGUI mapper = new MapeadorTipoProductoGUI();
            ModeloTipoProductoGUI modelo = mapper.MapearTipo1Tipo2(TipoProductoDTO);
            return View(modelo);
        }

        // POST: TipoProducto/Delete/5
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
                TipoProductoDTO TipoProductoDTO = logica.BuscarRegistro(id);
                if (TipoProductoDTO == null)
                {
                    return HttpNotFound();
                }

                MapeadorTipoProductoGUI mapper = new MapeadorTipoProductoGUI();
                ViewBag.mensaje = Mensajes.MensajeErrorAlEliminar;

                ModeloTipoProductoGUI modelo = mapper.MapearTipo1Tipo2(TipoProductoDTO);
                return View(modelo);
            }
        }


    }
}
