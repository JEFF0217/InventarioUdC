using InventarioUdC.GUI.Models;
using System.Collections.Generic;
using LogicaNegocio.DTO;

namespace InventarioUdC.GUI.Mapeadores.Parametros
{
    public class MapeadorTipoProductoGUI : MapeadorBaseGUI<TipoProductoDTO, ModeloTipoProductoGUI>
    {
        public override ModeloTipoProductoGUI MapearTipo1Tipo2(TipoProductoDTO entrada)
        {
            return new ModeloTipoProductoGUI()
            {
                Id = entrada.Id,
                Nombre = entrada.Nombre
            };
        }

        public override IEnumerable<ModeloTipoProductoGUI> MapearTipo1Tipo2(IEnumerable<TipoProductoDTO> entrada)
        {
            foreach (var item in entrada)
            {
                yield return MapearTipo1Tipo2(item);
            }
        }

        public override TipoProductoDTO MapearTipo2Tipo1(ModeloTipoProductoGUI entrada)
        {
            return new TipoProductoDTO()
            {
                Id = entrada.Id,
                Nombre = entrada.Nombre
            };
        }

        public override IEnumerable<TipoProductoDTO> MapearTipo2Tipo1(IEnumerable<ModeloTipoProductoGUI> entrada)
        {
            foreach (var item in entrada)
            {
                yield return MapearTipo2Tipo1(item);
            }
        }
    }
}