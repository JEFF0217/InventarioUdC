using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InventarioUdC.GUI.Models
{
    public class ModeloFotosGUI
    {
        private int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        private string nombre;

        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }
        private int id_producto;

        public int Id_producto
        {
            get { return id_producto; }
            set { id_producto = value; }
        }



        private IEnumerable<ModeloProductoGUI> listaProducto;

        public IEnumerable<ModeloProductoGUI> ListaProducto
        {
            get { return listaProducto; }
            set { listaProducto = value; }
        }
    }
}