using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VCFramework.NegocioMySQL
{
    public class LoginUsuario
    {
        public static int Insertar(Entidad.LoginUsuario login)
        {
            Factory fac = new Factory();
            return fac.Insertar<Entidad.LoginUsuario>(login);
        }
    }
}
