//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Pagina_Agripac
{
    using System;
    using System.Collections.Generic;
    
    public partial class Reporte_Asistencia
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Reporte_Asistencia()
        {
            this.Det_Asistencia = new HashSet<Det_Asistencia>();
        }
    
        public int id_asistencia { get; set; }
        public string Comprobante { get; set; }
        public int id_empleado { get; set; }
        public int idMotivo_Asistencia { get; set; }
        public Nullable<System.DateTime> Fecha { get; set; }
        public Nullable<int> Periodo { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Det_Asistencia> Det_Asistencia { get; set; }
        public virtual Empleado Empleado { get; set; }
        public virtual Motivo_Asistencia Motivo_Asistencia { get; set; }
    }
}
