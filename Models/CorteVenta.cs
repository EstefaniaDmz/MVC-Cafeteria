//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CafeteriaTBD.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class CorteVenta
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CorteVenta()
        {
            this.Venta1 = new HashSet<Venta>();
        }
    
        public int idCorteVenta { get; set; }
        public string caja { get; set; }
        public System.DateTime fecha { get; set; }
        public decimal venta { get; set; }
        public decimal gasto { get; set; }
        public decimal tarjeta { get; set; }
        public int idTrabajador { get; set; }
        public bool estatus { get; set; }
        public int idUsuarioCrea { get; set; }
        public System.DateTime fechaCrea { get; set; }
        public Nullable<int> idUsuarioModifica { get; set; }
        public Nullable<System.DateTime> fechaModifica { get; set; }
    
        public virtual Trabajador Trabajador { get; set; }
        public virtual Usuario Usuario { get; set; }
        public virtual Usuario Usuario1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Venta> Venta1 { get; set; }
    }
}
