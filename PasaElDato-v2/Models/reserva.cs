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
    
    public partial class reserva
    {
        public int idreserva { get; set; }
        public Nullable<int> idusuario { get; set; }
        public Nullable<int> idproducto { get; set; }
        public Nullable<int> idhora { get; set; }
    
        public virtual horas horas { get; set; }
        public virtual producto producto { get; set; }
        public virtual usuario usuario { get; set; }
    }
}