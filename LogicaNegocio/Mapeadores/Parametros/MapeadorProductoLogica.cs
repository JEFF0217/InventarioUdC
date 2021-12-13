using System;
using System.Collections.Generic;
using LogicaNegocio.DTO;
using AccesoDeDatos.DbModel;



namespace LogicaNegocio.Mapeadores.Parametros
{
    public class MapeadorProductoLogica : MapeadorBaseLogica<ProductoDbModel, ProductoDTO>
    {
        public override ProductoDTO MapearTipo1Tipo2(ProductoDbModel entrada)
        {
            return new ProductoDTO()
            {
                Id = entrada.Id,
                Nombre = entrada.Nombre,
                Fecha_registro = (DateTime)entrada.Fecha_registro,
                Serial = entrada.Serial,
                Id_tipo_producto = entrada.Id_tipo_producto,
                Id_espacio = entrada.Id_espacio,
                Id_marca = entrada.Id_marca,
                Id_persona = entrada.Id_persona
               
            };
        }

        public override IEnumerable<ProductoDTO> MapearTipo1Tipo2(IEnumerable<ProductoDbModel> entrada)
        {
            foreach (var item in entrada)
            {
                yield return MapearTipo1Tipo2(item);
            }
        }

        public override ProductoDbModel MapearTipo2Tipo1(ProductoDTO entrada)
        {
            return new ProductoDbModel()
            {
                Id = entrada.Id,
                Nombre = entrada.Nombre,
                Fecha_registro = entrada.Fecha_registro,
                Serial = entrada.Serial,
                Id_tipo_producto = entrada.Id_tipo_producto,
                Id_espacio = entrada.Id_espacio,
                Id_marca = entrada.Id_marca,
                Id_persona = entrada.Id_persona

            };
        }

        public override IEnumerable<ProductoDbModel> MapearTipo2Tipo1(IEnumerable<ProductoDTO> entrada)
        {
            foreach (var item in entrada)
            {
                yield return MapearTipo2Tipo1(item);
            }
        }
    }
}