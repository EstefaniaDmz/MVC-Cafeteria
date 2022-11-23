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
    
    public partial class Platillo
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Platillo()
        {
            this.PlatilloMaterial = new HashSet<PlatilloMaterial>();
            this.PlatilloVenta = new HashSet<PlatilloVenta>();
        }
    
        public int idPlatillo { get; set; }
        public string nombre { get; set; }
        public string descripcion { get; set; }
        public decimal costo { get; set; }
        public int idTipoPlatillo { get; set; }
        public bool estatus { get; set; }
        public int idUsuarioCrea { get; set; }
        public System.DateTime fechaCrea { get; set; }
        public Nullable<int> idUsuarioModifica { get; set; }
        public Nullable<System.DateTime> fechaModifica { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PlatilloMaterial> PlatilloMaterial { get; set; }
        public virtual TipoPlatillo TipoPlatillo { get; set; }
        public virtual Usuario Usuario { get; set; }
        public virtual Usuario Usuario1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PlatilloVenta> PlatilloVenta { get; set; }
    }
}