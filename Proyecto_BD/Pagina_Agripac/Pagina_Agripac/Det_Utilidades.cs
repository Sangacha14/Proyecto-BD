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
    
    public partial class Det_Utilidades
    {
        public int id_det_utilidades { get; set; }
        public int id_utilidades { get; set; }
        public string Descripcion { get; set; }
        public string Carga_Familiar { get; set; }
        public Nullable<int> Dias_laborados { get; set; }
    
        public virtual Utilidades Utilidades { get; set; }
    }
}
