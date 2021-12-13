using System.Collections.Generic;
using AccesoDeDatos.DbModel;
using LogicaNegocio.DTO;

namespace LogicaNegocio.Mapeadores.Parametros
{
    public class MapeadorPisoLogica : MapeadorBaseLogica<PisoDbModel, PisoDTO>
    {
        public override PisoDTO MapearTipo1Tipo2(PisoDbModel entrada)
        {
            return new PisoDTO()
            {
                Id = entrada.Id,
                Nombre = entrada.Nombre,
                Id_edificio = entrada.Id_edificio
            };
        }

        public override IEnumerable<PisoDTO> MapearTipo1Tipo2(IEnumerable<PisoDbModel> entrada)
        {
            foreach (var item in entrada)
            {
                yield return MapearTipo1Tipo2(item);
            }
        }

        public override PisoDbModel MapearTipo2Tipo1(PisoDTO entrada)
        {
            return new PisoDbModel()
            {
                Id = entrada.Id,
                Nombre = entrada.Nombre,
                Id_edificio = entrada.Id_edificio
            };
        }

        public override IEnumerable<PisoDbModel> MapearTipo2Tipo1(IEnumerable<PisoDTO> entrada)
        {
            foreach (var item in entrada)
            {
                yield return MapearTipo2Tipo1(item);
            }
        }
    }
}