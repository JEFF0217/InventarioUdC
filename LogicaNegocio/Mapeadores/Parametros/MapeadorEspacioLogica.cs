using System.Collections.Generic;
using LogicaNegocio.DTO;
using AccesoDeDatos.DbModel;


namespace LogicaNegocio.Mapeadores.Parametros
{
    public class MapeadorEspacioLogica : MapeadorBaseLogica<EspacioDbModel, EspacioDTO>
    {
        public override EspacioDTO MapearTipo1Tipo2(EspacioDbModel entrada)
        {
            return new EspacioDTO()
            {
                Id = entrada.Id,
                Nombre = entrada.Nombre,
                Id_piso = entrada.Id_piso,
                PisoNombre = entrada.PisoNombre
                
            };
        }

        public override IEnumerable<EspacioDTO> MapearTipo1Tipo2(IEnumerable<EspacioDbModel> entrada)
        {
            foreach (var item in entrada)
            {
                yield return MapearTipo1Tipo2(item);
            }
        }

        public override EspacioDbModel MapearTipo2Tipo1(EspacioDTO entrada)
        {
            return new EspacioDbModel()
            {
                Id = entrada.Id,
                Nombre = entrada.Nombre,
                Id_piso = entrada.Id_piso
          
            };
        }

        public override IEnumerable<EspacioDbModel> MapearTipo2Tipo1(IEnumerable<EspacioDTO> entrada)
        {
            foreach (var item in entrada)
            {
                yield return MapearTipo2Tipo1(item);
            }
        }
    }
}