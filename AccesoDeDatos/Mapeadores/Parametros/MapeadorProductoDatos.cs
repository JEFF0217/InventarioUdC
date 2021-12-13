using System;
using System.Collections.Generic;
using AccesoDeDatos.DbModel;
using AccesoDeDatos.ModeloDeDatos;



namespace AccesoDeDatos.Mapeadores.Parametros
{
    public class MapeadorProductoDatos : MapeadorBaseDatos<tb_producto, ProductoDbModel>
    {
        public override ProductoDbModel MapearTipo1Tipo2(tb_producto entrada)
        {
            return new ProductoDbModel()
            {
                Id = entrada.id,
                Nombre = entrada.nombre,
                Fecha_registro = (DateTime)entrada.fecha_registro,
                Serial = entrada.serieal,
                Id_tipo_producto = entrada.id_tipo_producto,
                Id_espacio = entrada.id_espacio,
                Id_marca = entrada.id_marca,
                Id_persona = entrada.id_persona,
                EspacioNombre = entrada.tb_espacio.nombre,
                MarcaNombre= entrada.tb_marca.nombre,
                PersonaPrimerNombre = entrada.tb_persona.primer_nombre,
                TipoProductoNombre = entrada.tb_tipo_producto.nombre

               
            };
        }

        public override IEnumerable<ProductoDbModel> MapearTipo1Tipo2(IEnumerable<tb_producto> entrada)
        {
            foreach (var item in entrada)
            {
                yield return MapearTipo1Tipo2(item);
            }
        }

        public override tb_producto MapearTipo2Tipo1(ProductoDbModel entrada)
        {
            return new tb_producto()
            {
                id = entrada.Id,
                nombre = entrada.Nombre,
                fecha_registro = entrada.Fecha_registro,
                serieal = entrada.Serial,
                id_tipo_producto = entrada.Id_tipo_producto,
                id_espacio = entrada.Id_espacio,
                id_marca = entrada.Id_marca,
                id_persona = entrada.Id_persona

            };
        }

        public override IEnumerable<tb_producto> MapearTipo2Tipo1(IEnumerable<ProductoDbModel> entrada)
        {
            foreach (var item in entrada)
            {
                yield return MapearTipo2Tipo1(item);
            }
        }
    }
}