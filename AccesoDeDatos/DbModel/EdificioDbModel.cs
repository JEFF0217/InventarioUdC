using System.Collections.Generic;

namespace AccesoDeDatos.DbModel
{
    public class EdificioDbModel
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
        private int id_sede;

        public int Id_Sede
        {
            get { return id_sede; }
            set { id_sede = value; }
        }


        private IEnumerable<SedeDbModel> listaSede;

        public IEnumerable<SedeDbModel> ListaSede
        {
            get { return listaSede; }
            set { listaSede = value; }
        }
    }
}
