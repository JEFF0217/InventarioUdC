//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace InventarioUdC.GUI.ModeloDB
{
    using System;
    using System.Collections.Generic;
    
    public partial class tb_persona
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tb_persona()
        {
            this.tb_producto = new HashSet<tb_producto>();
        }
    
        public int id { get; set; }
        public string primer_nombre { get; set; }
        public string otros_nombres { get; set; }
        public string primer_apellido { get; set; }
        public string segundo_apellido { get; set; }
        public string documento { get; set; }
        public string celular { get; set; }
        public string correo { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tb_producto> tb_producto { get; set; }
    }
}