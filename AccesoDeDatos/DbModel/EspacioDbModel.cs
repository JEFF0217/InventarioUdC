using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDeDatos.DbModel
{
    public class EspacioDbModel
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
        private int id_piso;

        public int Id_piso
        {
            get { return id_piso; }
            set { id_piso = value; }
        }




        private IEnumerable<PisoDbModel> listaPiso;

        public IEnumerable<PisoDbModel> ListaPiso
        {
            get { return listaPiso; }
            set { listaPiso = value; }
        }
    }
}
