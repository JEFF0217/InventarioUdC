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

using InventarioUdC.GUI.Mapeadores.Parametros;
using InventarioUdC.GUI.Models;
using InventarioUdC.GUI.Helpers;

namespace InventarioUdC.GUI.Controllers
{
    public class TipoProductoController : Controller
    {
        private ImplTipoProductoDatos acceso = new ImplTipoProductoDatos();

        // GET: TipoProducto
        public ActionResult Index(string filtro = "")
        {
            IEnumerable<tb_tipo_producto> listaDatos = acceso.ListarRegistros(filtro).ToList();
            MapeadorTipoProductoGUI mapper = new MapeadorTipoProductoGUI();
            IEnumerable<ModeloTipoProductoGUI> ListaGUI = mapper.MapearTipo1Tipo2(listaDatos);
            return View(ListaGUI);
        }

        // GET: TipoProducto/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_tipo_producto tb_tipo_producto = acceso.BuscarRegistro(id.Value);
            if (tb_tipo_producto == null)
            {
                return HttpNotFound();
            }
            MapeadorTipoProductoGUI mapper = new MapeadorTipoProductoGUI();
            ModeloTipoProductoGUI modelo = mapper.MapearTipo1Tipo2(tb_tipo_producto);
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
                tb_tipo_producto tb_tipo_producto = mapper.MapearTipo2Tipo1(modelo);

                acceso.GuardarRegistro(tb_tipo_producto);
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
            tb_tipo_producto tb_tipo_producto = acceso.BuscarRegistro(id.Value);
            if (tb_tipo_producto == null)
            {
                return HttpNotFound();
            }

            MapeadorTipoProductoGUI mapper = new MapeadorTipoProductoGUI();
            ModeloTipoProductoGUI modelo = mapper.MapearTipo1Tipo2(tb_tipo_producto);
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
                tb_tipo_producto tb_tipo_producto = mapper.MapearTipo2Tipo1(modelo);

                acceso.EditarRegistro(tb_tipo_producto);
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
            tb_tipo_producto tb_tipo_producto = acceso.BuscarRegistro(id.Value);
            if (tb_tipo_producto == null)
            {
                return HttpNotFound();
            }
            MapeadorTipoProductoGUI mapper = new MapeadorTipoProductoGUI();
            ModeloTipoProductoGUI modelo = mapper.MapearTipo1Tipo2(tb_tipo_producto);
            return View(modelo);
        }

        // POST: TipoProducto/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {

            bool respuesta = acceso.ELiminarRegistro(id);
            if (respuesta)
            {
                return RedirectToAction("Index");
            }
            else
            {
                tb_tipo_producto tb_tipo_producto = acceso.BuscarRegistro(id);
                if (tb_tipo_producto == null)
                {
                    return HttpNotFound();
                }

                MapeadorTipoProductoGUI mapper = new MapeadorTipoProductoGUI();
                ViewBag.mensaje = Mensajes.MensajeErrorAlEliminar;

                ModeloTipoProductoGUI modelo = mapper.MapearTipo1Tipo2(tb_tipo_producto);
                return View(modelo);
            }
        }


    }
}
