
using System.Collections.Generic;
using InventarioUdC.GUI.Models;
using LogicaNegocio.DTO;


namespace InventarioUdC.GUI.Mapeadores.Parametros
{
    public class MapeadorEspacioGUI : MapeadorBaseGUI<EspacioDTO, ModeloEspacioGUI>
    {
        public override ModeloEspacioGUI MapearTipo1Tipo2(EspacioDTO entrada)
        {
            return new ModeloEspacioGUI()
            {
                Id = entrada.Id,
                Nombre = entrada.Nombre,
                Id_piso = entrada.Id_piso,
                PisoNombre = entrada.PisoNombre
                
            };
        }

        public override IEnumerable<ModeloEspacioGUI> MapearTipo1Tipo2(IEnumerable<EspacioDTO> entrada)
        {
            foreach (var item in entrada)
            {
                yield return MapearTipo1Tipo2(item);
            }
        }

        public override EspacioDTO MapearTipo2Tipo1(ModeloEspacioGUI entrada)
        {
            return new EspacioDTO()
            {
                Id = entrada.Id,
                Nombre = entrada.Nombre,
                Id_piso = entrada.Id_piso
          
            };
        }

        public override IEnumerable<EspacioDTO> MapearTipo2Tipo1(IEnumerable<ModeloEspacioGUI> entrada)
        {
            foreach (var item in entrada)
            {
                yield return MapearTipo2Tipo1(item);
            }
        }
    }
}