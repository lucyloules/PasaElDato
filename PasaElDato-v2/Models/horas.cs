//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PasaElDato_v2.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class horas
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public horas()
        {
            this.reserva = new HashSet<reserva>();
        }
    
        public int idhora { get; set; }
        [Required]
        [DataType(DataType.DateTime)]
        public string dia { get; set; }
        public string hora { get; set; }
        public string fecha { get; set; }
        public Nullable<int> idestado { get; set; }
    
        public virtual estado estado { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<reserva> reserva { get; set; }
    }
}
