using System.Collections.Generic;
using LogicaNegocio.DTO;
using AccesoDeDatos.DbModel;


namespace LogicaNegocio.Mapeadores.Parametros
{
    public class MapeadorFotosLogica : MapeadorBaseLogica<FotosDbModel, FotosDTO>
    {
        public override FotosDTO MapearTipo1Tipo2(FotosDbModel entrada)
        {
            return new FotosDTO()
            {
                Id = entrada.Id,
                Nombre = entrada.Nombre,
                Id_producto = entrada.Id_producto
            };
        }

        public override IEnumerable<FotosDTO> MapearTipo1Tipo2(IEnumerable<FotosDbModel> entrada)
        {
            foreach (var item in entrada)
            {
                yield return MapearTipo1Tipo2(item);
            }
        }

        public override FotosDbModel MapearTipo2Tipo1(FotosDTO entrada)
        {
            return new FotosDbModel()
            {
                Id = entrada.Id,
                Nombre = entrada.Nombre,
                Id_producto = entrada.Id_producto
            };
        }

        public override IEnumerable<FotosDbModel> MapearTipo2Tipo1(IEnumerable<FotosDTO> entrada)
        {
            foreach (var item in entrada)
            {
                yield return MapearTipo2Tipo1(item);
            }
        }
    }
}