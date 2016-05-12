using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VCFramework.NegocioMySQL
{
    public class AutentificacionUsuario
    {
        public static List<VCFramework.Entidad.AutentificacionUsuario> ListarUsuarios()
        {
            VCFramework.NegocioMySQL.Factory fac = new VCFramework.NegocioMySQL.Factory();
            List<object> lista = fac.Leer<VCFramework.Entidad.AutentificacionUsuario>();
            List<VCFramework.Entidad.AutentificacionUsuario> lista2 = new List<VCFramework.Entidad.AutentificacionUsuario>();
            if (lista != null)
            {
                lista2 = lista.Cast<VCFramework.Entidad.AutentificacionUsuario>().ToList();
            }
            return lista2.FindAll(p=>p.EsVigente == 1);
        }

        public static List<VCFramework.Entidad.AutentificacionUsuario> ListarUsuariosPorInstId(int instId)
        {
            VCFramework.NegocioMySQL.Factory fac = new VCFramework.NegocioMySQL.Factory();
            FiltroGenerico filtro = new FiltroGenerico();
            filtro.Campo = "INST_ID";
            filtro.Valor = instId.ToString();
            filtro.TipoDato = TipoDatoGeneral.Entero;
            List<object> lista = fac.Leer<VCFramework.Entidad.AutentificacionUsuario>(filtro);
            List<VCFramework.Entidad.AutentificacionUsuario> lista2 = new List<VCFramework.Entidad.AutentificacionUsuario>();
            if (lista != null)
            {
                lista2 = lista.Cast<VCFramework.Entidad.AutentificacionUsuario>().ToList();
            }
            return lista2;
        }
        public static bool ValidarUsuario(string userName, string password)
        {
            bool retorno = false;

            List<VCFramework.Entidad.AutentificacionUsuario> lista = ListarUsuarios();

            if (lista != null && lista.Count > 0)
            {
                retorno = lista.Exists(p => p.NombreUsuario == userName && p.Password == password && p.Eliminado == 0 && p.EsVigente == 1);
            }

            return retorno;
        }
        public static VCFramework.Entidad.AutentificacionUsuario ObtenerUsuario(string userName, string password)
        {
            VCFramework.Entidad.AutentificacionUsuario retorno = new Entidad.AutentificacionUsuario();

            List<VCFramework.Entidad.AutentificacionUsuario> lista = ListarUsuarios();

            if (lista != null && lista.Count > 0)
            {
                retorno = lista.Find(p => p.NombreUsuario == userName && p.Password == password && p.Eliminado == 0 && p.EsVigente == 1);
            }

            return retorno;
        }
        public static VCFramework.Entidad.AutentificacionUsuario ObtenerUsuario(int id)
        {
            VCFramework.Entidad.AutentificacionUsuario retorno = new Entidad.AutentificacionUsuario();

            List<VCFramework.Entidad.AutentificacionUsuario> lista = ListarUsuarios();

            if (lista != null && lista.Count > 0)
            {
                retorno = lista.Find(p => p.Id == id  && p.Eliminado == 0 && p.EsVigente == 1);
            }

            return retorno;
        }
        public static int ModificarAus(VCFramework.Entidad.AutentificacionUsuario aus)
        {
            aus.Nuevo = false;
            aus.Borrado = false;
            aus.Modificado = true;

            VCFramework.NegocioMySQL.Factory fac = new VCFramework.NegocioMySQL.Factory();

            return fac.Update<VCFramework.Entidad.AutentificacionUsuario>(aus);
        }
    }
}
