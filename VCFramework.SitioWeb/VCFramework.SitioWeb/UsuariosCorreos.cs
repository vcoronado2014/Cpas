using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VCFramework.SitioWeb
{
    public class UsuariosCorreos
    {
        public string Correo { get; set; }
        public string Nombre { get; set; }

        public static List<UsuariosCorreos> ListaUsuariosCorreosPorInstId(int instId)
        {
            List<UsuariosCorreos> retorno = new List<UsuariosCorreos>();

            try
            {
                List<UsuarioFuncional> listaUsuarios =  LogicLogin.ListarUsuariosFuncional(instId);
                if (listaUsuarios != null && listaUsuarios.Count > 0)
                {
                    foreach(UsuarioFuncional au in listaUsuarios)
                    {
                        if (au.AutentificacionUsuario.CorreoElectronico != "")
                        {
                            if (!retorno.Exists(p=>p.Correo == au.AutentificacionUsuario.CorreoElectronico))
                            {
                                UsuariosCorreos us = new UsuariosCorreos();
                                us.Correo = au.AutentificacionUsuario.CorreoElectronico;
                                us.Nombre = au.Persona.Nombres + " " + au.Persona.ApellidoPaterno + " " + au.Persona.ApellidoMaterno;
                                retorno.Add(us);
                            }
                        }
                    }
                }
            }
            catch(Exception ex)
            {

            }

            return retorno;
        }
    }
}
