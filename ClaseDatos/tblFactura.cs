//------------------------------------------------------------------------------
// <auto-generated>
//    Este código se generó a partir de una plantilla.
//
//    Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//    Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ClaseDatos
{
    using System;
    using System.Collections.Generic;
    
    public partial class tblFactura
    {
        public tblFactura()
        {
            this.tblDetFactura = new HashSet<tblDetFactura>();
        }
    
        public int IDFactura { get; set; }
        public System.DateTime Fecha { get; set; }
        public string NombCompCliente { get; set; }
        public float SubTotal { get; set; }
        public float Iva { get; set; }
        public float Total { get; set; }
        public bool Estado { get; set; }
    
        public virtual ICollection<tblDetFactura> tblDetFactura { get; set; }
    }
}
