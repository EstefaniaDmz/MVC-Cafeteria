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
    
    public partial class Asentamiento
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Asentamiento()
        {
            this.Proveedor = new HashSet<Proveedor>();
            this.Sucursal = new HashSet<Sucursal>();
        }
    
        public int idAsentamiento { get; set; }
        public Nullable<int> id { get; set; }
        public string nombre { get; set; }
        public string codigoPostal { get; set; }
        public int idTipoAsentamiento { get; set; }
        public int idMunicipio { get; set; }
        public int idEstado { get; set; }
        public int idZona { get; set; }
        public bool estatus { get; set; }
        public int idUsuarioCrea { get; set; }
        public System.DateTime fechaCrea { get; set; }
        public Nullable<int> idUsuarioModifica { get; set; }
        public Nullable<System.DateTime> fechaModifica { get; set; }
    
        public virtual Municipio Municipio { get; set; }
        public virtual TipoAsentamiento TipoAsentamiento { get; set; }
        public virtual Usuario Usuario { get; set; }
        public virtual Usuario Usuario1 { get; set; }
        public virtual Zona Zona { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Proveedor> Proveedor { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Sucursal> Sucursal { get; set; }
    }
}
