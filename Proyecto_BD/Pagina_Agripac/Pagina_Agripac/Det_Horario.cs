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
    
    public partial class Det_Horario
    {
        public int id_det_horario { get; set; }
        public int id_horario { get; set; }
        public int id_jornada { get; set; }
        public Nullable<System.DateTime> Fecha_inicial { get; set; }
        public Nullable<System.DateTime> Fecha_final { get; set; }
    
        public virtual Horario Horario { get; set; }
        public virtual Jornada Jornada { get; set; }
    }
}
