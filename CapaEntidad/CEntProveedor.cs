using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class CEntProveedor
    {
        public int IDProveedor { get; set; }
        public string NombNegocio { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public string Correo { get; set; }
        public string Fax { get; set; }
        public string Municipio { get; set; }
        public string Departamento { get; set; }
        public string Imagen { get; set; }
        public Nullable<bool> Estado { get; set; }
    }
}
