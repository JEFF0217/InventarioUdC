using System.Collections.Generic;
using AccesoDeDatos.ModeloDeDatos;
using AccesoDeDatos.DbModel;

namespace AccesoDeDatos.Mapeadores.Parametros
{
    public class MapeadorFotosDatos : MapeadorBaseDatos<tb_fotos, FotosDbModel>
    {
        public override FotosDbModel MapearTipo1Tipo2(tb_fotos entrada)
        {
            return new FotosDbModel()
            {
                Id = entrada.id,
                Nombre = entrada.nombre,
                Id_producto = entrada.id_producto,
                ProductoNombre = entrada.tb_producto.nombre
            };
        }

        public override IEnumerable<FotosDbModel> MapearTipo1Tipo2(IEnumerable<tb_fotos> entrada)
        {
            foreach (var item in entrada)
            {
                yield return MapearTipo1Tipo2(item);
            }
        }

        public override tb_fotos MapearTipo2Tipo1(FotosDbModel entrada)
        {
            return new tb_fotos()
            {
                id = entrada.Id,
                nombre = entrada.Nombre,
                id_producto = entrada.Id_producto
            };
        }

        public override IEnumerable<tb_fotos> MapearTipo2Tipo1(IEnumerable<FotosDbModel> entrada)
        {
            foreach (var item in entrada)
            {
                yield return MapearTipo2Tipo1(item);
            }
        }
    }
}