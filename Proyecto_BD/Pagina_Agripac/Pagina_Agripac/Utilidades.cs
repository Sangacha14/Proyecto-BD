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
    
    public partial class Utilidades
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Utilidades()
        {
            this.Det_Utilidades = new HashSet<Det_Utilidades>();
        }
    
        public int id_utilidades { get; set; }
        public string Comprobante { get; set; }
        public int id_empleado { get; set; }
        public Nullable<System.DateTime> Fecha { get; set; }
        public Nullable<double> Valor_Utilidades { get; set; }
        public Nullable<System.DateTime> Fecha_pago { get; set; }
        public Nullable<int> Anio { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Det_Utilidades> Det_Utilidades { get; set; }
        public virtual Empleado Empleado { get; set; }
    }
}
