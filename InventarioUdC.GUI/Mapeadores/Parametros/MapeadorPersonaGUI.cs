
using InventarioUdC.GUI.Models;
using System.Collections.Generic;
using LogicaNegocio.DTO;

namespace InventarioUdC.GUI.Mapeadores.Parametros
{
    public class MapeadorPersonaGUI : MapeadorBaseGUI<PersonaDTO, ModeloPersonaGUI>
    {
        public override ModeloPersonaGUI MapearTipo1Tipo2(PersonaDTO entrada)
        {
            return new ModeloPersonaGUI()
            {
                Id = entrada.Id,
                Primer_nombre = entrada.Primer_nombre,
                Otros_nombres = entrada.Otros_nombres,
                Primer_apellido = entrada.Primer_apellido,
                Segundo_apellido = entrada.Segundo_apellido,
                Celular = entrada.Celular,
                Correo = entrada.Correo,
                Documento = entrada.Documento

            };
        }

        public override IEnumerable<ModeloPersonaGUI> MapearTipo1Tipo2(IEnumerable<PersonaDTO> entrada)
        {
            foreach (var item in entrada)
            {
                yield return MapearTipo1Tipo2(item);
            }
        }

        public override PersonaDTO MapearTipo2Tipo1(ModeloPersonaGUI entrada)
        {
            return new PersonaDTO()
            {
                Id = entrada.Id,
                Primer_nombre = entrada.Primer_nombre,
                Otros_nombres = entrada.Otros_nombres,
                Primer_apellido = entrada.Segundo_apellido,
                Segundo_apellido = entrada.Segundo_apellido,
                Celular = entrada.Celular,
                Correo = entrada.Correo,
                Documento = entrada.Documento
            };
        }

        public override IEnumerable<PersonaDTO> MapearTipo2Tipo1(IEnumerable<ModeloPersonaGUI> entrada)
        {
            foreach (var item in entrada)
            {
                yield return MapearTipo2Tipo1(item);
            }
        }
    }
}