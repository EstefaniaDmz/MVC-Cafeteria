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
    
    public partial class Asistencia
    {
        public int idAsistencia { get; set; }
        public System.DateTime fecha { get; set; }
        public System.TimeSpan horaLlegada { get; set; }
        public System.TimeSpan horaSalida { get; set; }
        public int idTrabajador { get; set; }
        public bool estatus { get; set; }
        public int idUsuarioCrea { get; set; }
        public System.DateTime fechaCrea { get; set; }
        public Nullable<int> idUsuarioModifica { get; set; }
        public Nullable<System.DateTime> fechaModifica { get; set; }
    
        public virtual Trabajador Trabajador { get; set; }
        public virtual Usuario Usuario { get; set; }
        public virtual Usuario Usuario1 { get; set; }
    }
}
