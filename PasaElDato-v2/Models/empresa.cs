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
    
    public partial class empresa
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public empresa()
        {
            this.sucursal = new HashSet<sucursal>();
        }
    
        public int idempresa { get; set; }
        public string nombre { get; set; }
        public string rut { get; set; }
        public string giro { get; set; }
        public string historia { get; set; }
        public string path_imagenempresa { get; set; }
        public string link { get; set; }
        public string descripcion { get; set; }
        public string path_imagen { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<sucursal> sucursal { get; set; }
    }
}