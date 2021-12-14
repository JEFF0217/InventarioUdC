using System;
using System.Collections.Generic;
using LogicaNegocio.DTO;
using InventarioUdC.GUI.Models;


namespace InventarioUdC.GUI.Mapeadores.Parametros
{
    public class MapeadorProductoGUI : MapeadorBaseGUI<ProductoDTO, ModeloProductoGUI>
    {
        public override ModeloProductoGUI MapearTipo1Tipo2(ProductoDTO entrada)
        {
            return new ModeloProductoGUI()
            {
                Id = entrada.Id,
                Nombre = entrada.Nombre,
                Fecha_registro = (DateTime)entrada.Fecha_registro,
                Serial = entrada.Serial,
                Id_tipo_producto = entrada.Id_tipo_producto,
                Id_espacio = entrada.Id_espacio,
                Id_marca = entrada.Id_marca,
                Id_persona = entrada.Id_persona,
                TipoProductoNombre = entrada.TipoProductoNombre,
                EspacioNombre = entrada.EspacioNombre,
                MarcaNombre = entrada.MarcaNombre,
                PersonaPrimerNombre  = entrada.PersonaPrimerNombre
                
               
            };
        }

        public override IEnumerable<ModeloProductoGUI> MapearTipo1Tipo2(IEnumerable<ProductoDTO> entrada)
        {
            foreach (var item in entrada)
            {
                yield return MapearTipo1Tipo2(item);
            }
        }

        public override ProductoDTO MapearTipo2Tipo1(ModeloProductoGUI entrada)
        {
            return new ProductoDTO()
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

        public override IEnumerable<ProductoDTO> MapearTipo2Tipo1(IEnumerable<ModeloProductoGUI> entrada)
        {
            foreach (var item in entrada)
            {
                yield return MapearTipo2Tipo1(item);
            }
        }
    }
}