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
    
    public partial class email
    {
        public int idemail { get; set; }
        public string email1 { get; set; }
        public Nullable<int> idsucursal { get; set; }
    
        public virtual sucursal sucursal { get; set; }
    }
}
