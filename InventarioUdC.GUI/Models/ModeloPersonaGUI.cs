﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InventarioUdC.GUI.Models
{
    public class ModeloPersonaGUI
    {
        private int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        private string primer_nombre;

        public string Primer_nombre
        {
            get { return primer_nombre; }
            set { primer_nombre = value; }
        }

        private string otros_nombres;

        public string Otros_nombres
        {
            get { return otros_nombres; }
            set { otros_nombres = value; }
        }


        private string primer_apellido;

        public string Primer_apellido
        {
            get { return primer_apellido; }
            set { primer_apellido = value; }
        }

        private string segundo_apellido;

        public string Segundo_apellido
        {
            get { return segundo_apellido; }
            set { segundo_apellido = value; }
        }

        private string documento;

        public string Documento
        {
            get { return documento; }
            set { documento = value; }
        }


        private string celular;

        public string Celular
        {
            get { return celular; }
            set { celular = value; }

        }

        private string correo;

        public string Correo
        {
            get { return correo; }
            set { correo = value; }
        }


    }
}