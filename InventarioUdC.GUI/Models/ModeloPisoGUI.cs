using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace InventarioUdC.GUI.Models
{
    public class ModeloPisoGUI
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
        private string edificioNombre;

        [DisplayName("Nombre del edificio")]
        public string EdificioNombre
        {
            get { return edificioNombre; }
            set { edificioNombre = value; }
        }


        private int id_edificio;

        public int Id_edificio
        {
            get { return id_edificio; }
            set { id_edificio = value; }
        }


        private IEnumerable<ModeloEdificioGUI> listaEdificio;

        public IEnumerable<ModeloEdificioGUI> ListaEdificio
        {
            get { return listaEdificio; }
            set { listaEdificio = value; }
        }
    }
}