using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InventarioUdC.GUI.Models
{
    public class ModeloProductoGUI
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

        private DateTime fecha_registro;

        public DateTime Fecha_registro
        {
            get { return fecha_registro; }
            set { fecha_registro = value; }
        }

        private string serial;

        public string Serial
        {
            get { return serial; }
            set { serial = value; }
        }
        private int id_marca;

        public int Id_marca
        {
            get { return id_marca; }
            set { id_marca = value; }
        }


        private IEnumerable<ModeloMarcaGUI> listaMarca;

        public IEnumerable<ModeloMarcaGUI> ListaMarca
        {
            get { return listaMarca; }
            set { listaMarca = value; }
        }

        private int id_tipo_producto;

        public int Id_tipo_producto
        {
            get { return id_tipo_producto; }
            set { id_tipo_producto = value; }
        }



        private IEnumerable<ModeloTipoProductoGUI> listaTipoProducto;

        public IEnumerable<ModeloTipoProductoGUI> ListaTipoProducto
        {
            get { return listaTipoProducto; }
            set { listaTipoProducto = value; }
        }


        private int id_persona;

        public int Id_persona
        {
            get { return id_persona; }
            set { id_persona = value; }
        }


        private IEnumerable<ModeloPersonaGUI> listaPersona;

        public IEnumerable<ModeloPersonaGUI> ListaPersona
        {
            get { return listaPersona; }
            set { listaPersona = value; }
        }

        private int id_espacio;

        public int Id_espacio
        {
            get { return id_espacio; }
            set { id_espacio = value; }
        }


        private IEnumerable<ModeloEspacioGUI> listaEspacio;

        public IEnumerable<ModeloEspacioGUI> ListaEspacio
        {
            get { return listaEspacio; }
            set { listaEspacio = value; }
        }

    }
}