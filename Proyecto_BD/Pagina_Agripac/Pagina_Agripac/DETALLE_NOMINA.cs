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
    
    public partial class DETALLE_NOMINA
    {
        public int id_det_nomina { get; set; }
        public int id_Nomina { get; set; }
        public int id_empleado { get; set; }
        public Nullable<System.DateTime> Fecha { get; set; }
        public Nullable<int> Periodo { get; set; }
    
        public virtual Cabecera_Nomina Cabecera_Nomina { get; set; }
        public virtual Empleado Empleado { get; set; }
    }
}