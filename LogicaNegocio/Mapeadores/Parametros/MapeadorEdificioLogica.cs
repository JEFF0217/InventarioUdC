using AccesoDeDatos.ModeloDeDatos;
using LogicaNegocio.DTO;
using System.Collections.Generic;
using AccesoDeDatos.DbModel;


namespace LogicaNegocio.Mapeadores.Parametros
{
    public class MapeadorEdificioLogica : MapeadorBaseLogica<EdificioDbModel, EdificioDTO>
    {
        public override EdificioDTO MapearTipo1Tipo2(EdificioDbModel entrada)
        {
            return new EdificioDTO()
            {
                Id = entrada.Id,
                Nombre = entrada.Nombre,
                Id_Sede = entrada.Id_Sede,
                SedeNombre = entrada.SedeNombre

                
            
              
            };
        }

        public override IEnumerable<EdificioDTO> MapearTipo1Tipo2(IEnumerable<EdificioDbModel> entrada)
        {
            foreach (var item in entrada)
            {
                yield return MapearTipo1Tipo2(item);
            }
        }

        public override EdificioDbModel MapearTipo2Tipo1(EdificioDTO entrada)
        {
            return new EdificioDbModel()
            {
                Id = entrada.Id,
                Nombre = entrada.Nombre,
                Id_Sede = entrada.Id_Sede
            };
        }

        public override IEnumerable<EdificioDbModel> MapearTipo2Tipo1(IEnumerable<EdificioDTO> entrada)
        {
            foreach (var item in entrada)
            {
                yield return MapearTipo2Tipo1(item);
            }
        }
    }
}