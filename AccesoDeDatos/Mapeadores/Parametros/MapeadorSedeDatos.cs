using System.Collections.Generic;
using AccesoDeDatos.ModeloDeDatos;
using AccesoDeDatos.DbModel;


namespace AccesoDeDatos.Mapeadores.Parametros
{
    public class MapeadorSedeDatos : MapeadorBaseDatos<tb_sede, SedeDbModel>
    {
        public override SedeDbModel MapearTipo1Tipo2(tb_sede entrada)
        {
            return new SedeDbModel()
            {
                Id = entrada.id,
                Nombre = entrada.nombre,
                Direccion = entrada.direccion
            };
        }

        public override IEnumerable<SedeDbModel> MapearTipo1Tipo2(IEnumerable<tb_sede> entrada)
        {
            foreach (var item in entrada)
            {
                yield return MapearTipo1Tipo2(item);
            }
        }

        public override tb_sede MapearTipo2Tipo1(SedeDbModel entrada)
        {
            return new tb_sede()
            {
                id = entrada.Id,
                nombre = entrada.Nombre,
                direccion = entrada.Direccion
            };
        }

        public override IEnumerable<tb_sede> MapearTipo2Tipo1(IEnumerable<SedeDbModel> entrada)
        {
            foreach (var item in entrada)
            {
                yield return MapearTipo2Tipo1(item);
            }
        }
    }
}