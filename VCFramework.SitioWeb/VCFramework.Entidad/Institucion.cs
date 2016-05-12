using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VCFramework.Entidad
{
    public class Institucion : EntidadBase
    {
        public int Eliminado { get; set; }

        public string Nombre { get; set; }

        public int Reg_id { get; set; }
        public int ComId { get; set; }

    }
}
