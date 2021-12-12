using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace InventarioUdC.GUI.Models
{
    public class ModeloCategoriaGUI
    {
        private int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }


        
        private string nombre;
        [Required]
        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }

    }
}