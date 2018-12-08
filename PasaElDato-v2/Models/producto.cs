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
    
    public partial class producto
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public producto()
        {
            this.reserva = new HashSet<reserva>();
            this.comentario = new HashSet<comentario>();
            this.imagen_producto = new HashSet<imagen_producto>();
            this.servicio_habitacion = new HashSet<servicio_habitacion>();
        }
    
        public int idproducto { get; set; }
        public string descripcion_producto { get; set; }
        public string fecha_ini { get; set; }
        public string fecha_fin { get; set; }
        public Nullable<int> idrestriccion { get; set; }
        public Nullable<int> idsucursal { get; set; }
        public Nullable<int> idtipo_habitacion { get; set; }
        public string precio1 { get; set; }
        public string precio2 { get; set; }
        public Nullable<int> idusuario { get; set; }
        public string descuento { get; set; }
    
        public virtual usuario usuario { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<reserva> reserva { get; set; }
        public virtual tipohabitacion_x_sucursal tipohabitacion_x_sucursal { get; set; }
        public virtual restricciones restricciones { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<comentario> comentario { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<imagen_producto> imagen_producto { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<servicio_habitacion> servicio_habitacion { get; set; }
    }
}
