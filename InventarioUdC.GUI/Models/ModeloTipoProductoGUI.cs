using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InventarioUdC.GUI.Models
{
    public class ModeloTipoProductoGUI
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

    }
}